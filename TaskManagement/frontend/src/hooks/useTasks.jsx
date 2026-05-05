// /hooks/useTasks.js
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { getTasks, addTask, deleteTask, updateTask } from "../api/tasks";

export const useTasks = () => {
  const queryClient = useQueryClient();

  // GET
  const tasksQuery = useQuery({
    queryKey: ["tasks"],
    queryFn: getTasks,
  });

  // ADD
  const addMutation = useMutation({
    mutationFn: addTask,
    onSuccess: () => {
      queryClient.invalidateQueries(["tasks"]);
    },
  });

  // DELETE
  const deleteMutation = useMutation({
    mutationFn: deleteTask,
    onSuccess: () => {
      queryClient.invalidateQueries(["tasks"]);
    },
  });

  // UPDATE
  const updateMutation = useMutation({
    mutationFn: updateTask,
    onSuccess: () => {
      queryClient.invalidateQueries(["tasks"]);
    },
  });

  return {
    ...tasksQuery,
    addTask: addMutation.mutate,
    deleteTask: deleteMutation.mutate,
    updateTask: updateMutation.mutate,
  };
};