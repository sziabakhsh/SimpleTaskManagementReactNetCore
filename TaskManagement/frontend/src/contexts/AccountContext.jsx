import { createContext, useState } from "react";

export const AccountContext = createContext();

export function AccountContextProvider({ children }) {

  const [user, setUser] = useState(null);

  const login = (data) => {
    localStorage.setItem(
      "token", 
      data.accessToken
    );

    setUser({
      token: data.accessToken,
    });
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
  };

  return (
    <AccountContext.Provider
      value={{
        user,
        login,
        logout
      }}
    >
      {children}
    </AccountContext.Provider>
  );
}