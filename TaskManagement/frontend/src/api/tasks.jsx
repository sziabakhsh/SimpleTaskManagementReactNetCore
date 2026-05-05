import axios from "axios";

const API = "http://localhost:3001/tasks";

export const getTasks = async () => {
  const res = await axios.get(API);
  return res.data;
};

export const addTask = async (task) => {
  const res = await axios.post(API, task);
  return res.data;
};

export const deleteTask = async (id) => {
  await axios.delete(`${API}/${id}`);
};

export const updateTask = async (task) => {
  const res = await axios.put(`${API}/${task.id}`, task);
  return res.data;
};