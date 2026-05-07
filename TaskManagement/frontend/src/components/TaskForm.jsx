import { useForm } from "react-hook-form";
import { useTasks } from "../hooks/useTasks";

export default function TaskForm() {
  const { register, handleSubmit, reset } = useForm();
  const { addTask } = useTasks();

  const onSubmit = (data) => {
    addTask({ ...data, completed: false });
    reset();
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("title")} placeholder="Task title" />
      <input {...register("description")} placeholder="Task description" />
      <button type="submit">Add</button>
    </form>
  );
}