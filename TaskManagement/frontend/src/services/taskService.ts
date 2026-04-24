import api from "./api";
import { Task } from "../types/Task";

export const getTasks = async (): Promise<Task[]> => {
    const response = await api.get("/taskitem");
    return response.data;
};