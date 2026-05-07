import api from "./api";

export const registerUser = async (data) => {
  const res = await api.post("/account/register", data);
  return res.data;
};

export const loginUser = async (data) => {
  const res = await api.post("/account/login", data);
  return res.data;
};
