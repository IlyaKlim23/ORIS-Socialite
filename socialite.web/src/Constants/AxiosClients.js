import axios from "axios";

export const backendOrigin = "https://localhost:7272";

export const userClient = axios.create({
  baseURL: `${backendOrigin}/api/User/`,
});

export const userProfileClient = axios.create({
  baseURL: `${backendOrigin}/api/UserProfiles/`,
});


export const filesClient = axios.create({
  baseURL: `${backendOrigin}/api/Files/`,
})
