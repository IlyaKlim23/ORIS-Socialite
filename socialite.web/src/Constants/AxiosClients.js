import axios from "axios";

export const backendOrigin = "https://localhost:7272";

export const userClient = axios.create({
  baseURL: `${backendOrigin}/api/User/`,
});

export const userProfileClient = axios.create({
  baseURL: `${backendOrigin}/api/UserProfiles/`,
});

export const postsClient = axios.create({
  baseURL: `${backendOrigin}/api/Posts/`
})

export const filesClient = axios.create({
  baseURL: `${backendOrigin}/api/Files/`,
})

export const subscribersClient = axios.create({
  baseURL: `${backendOrigin}/api/Subscribers/`,
})

export const commentsClient = axios.create({
  baseURL: `${backendOrigin}/api/Comments/`
})

export const chatClient = axios.create({
  baseURL: `${backendOrigin}/api/Chat/`
})

export const messagesClient = axios.create({
  baseURL: `${backendOrigin}/api/Messages/`
})

export const chatUrl = `${backendOrigin}/chat`
