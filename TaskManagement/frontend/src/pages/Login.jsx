import { useForm } from "react-hook-form";
import { useMutation } from "@tanstack/react-query";
import { loginUser } from "../api/account";
import { useContext } from "react";
import { AccountContext } from "../contexts/AccountContext";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const { register, handleSubmit } = useForm();
  const { login } = useContext(AccountContext);
  const navigate = useNavigate();

  const mutation = useMutation({
    mutationFn: loginUser,
    onSuccess: (data) => {
      login(data);
      navigate("/");
    },
    onError: (err) => {
      console.log(err);
    }
  });

  const onSubmit = (data) => {

    console.log(data);
    mutation.mutate(data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("username")} placeholder="Username" />
      <input {...register("password")} type="password" placeholder="Password" />

      <button type="submit" disabled={mutation.isPending}>
        {mutation.isPending ? "Loading..." : "Login"}
      </button>

      {mutation.error && <p>Login failed</p>}
    </form>
  );
}