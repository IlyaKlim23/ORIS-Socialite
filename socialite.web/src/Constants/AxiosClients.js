import axios from "axios";

export const backendOrigin = "https://localhost:7272";

export const userClient = axios.create({
  baseURL: `${backendOrigin}/api/User/`,
});