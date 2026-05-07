import { useForm } from "react-hook-form";
import { useMutation } from "@tanstack/react-query";
import { registerUser } from "../api/account";

export default function Register() {
  const { register, handleSubmit } = useForm();

  const mutation = useMutation({
    mutationFn: registerUser,
  });

  const onSubmit = (data) => {
    mutation.mutate(data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      
      <input {...register("username")} placeholder="Username" />
      <input {...register("email")} placeholder="Email" />
      <input {...register("password")} type="password" placeholder="Password" />

      <button type="submit" disabled={mutation.isPending}>
        {mutation.isPending ? "Loading..." : "Register"}
      </button>
      
      <p>{mutation.error?.message}</p>
{/* 
      {mutation.error && <p>Error registering</p>} */}
    </form>
  );
}