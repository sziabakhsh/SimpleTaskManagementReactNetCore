import axios from "axios";
import { api } from "../api/axios";

// const API = 'https://localhost:7139/api/acccount'

// import { api } from "./axios";

export const registerUser = async (data) => {
  const res = await api.post("/account/register", data);
  return res.data;
};

export const loginUser = async (data) => {
  const res = await api.post("/account/login", data);
  return res.data;
};

// export const loginUser = async (userData) => {
//   const response = await api.post("/account/login", userData);

//   return response.data;
// };