import api from "./api";

export const getTasks = async () => {
  const response = await api.get("/taskitem");
  return response.data;
};

export const addTask = async (task) => {
  const response = await api.post("/taskitem", task);
  return response.data;
};
export const deleteTask = async (id) => {
  await api.delete(`${API}/${id}`);
};

export const updateTask = async (task) => {
  const res = await api.put(`${API}/${task.id}`, task);
  return res.data;
};
