using TaskManagement.Data;
using TaskManagement.DTOs.Account;
using TaskManagement.Entities;
using TaskManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace TaskManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null)
                throw new Exception("Invalid credentials");

            // password check 
            // if (!CheckPassword(...)) ...

            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = GenerateRefreshToken(user.Id);

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }

        public async Task LogoutAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);

            if (refreshToken == null)
                return;

            refreshToken.Revoked = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Token == token);

            if (refreshToken == null || !refreshToken.IsActive)
                throw new Exception("Invalid refresh token");

            var newAccessToken = _tokenService.CreateToken(refreshToken.AppUser);
            var newRefreshToken = GenerateRefreshToken(refreshToken.AppUserId);

            refreshToken.Revoked = DateTime.UtcNow;

            _context.RefreshTokens.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }

        private RefreshToken GenerateRefreshToken(string userId)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                AppUserId = userId
            };
        }
    }
}
