import { userClient } from "../../Constants/AxiosClients.js";
import {
    authToken,
    userIdItem,
    userNameItem,
} from "../../Constants/LocalStorageItemKeys.js";
import SignalRConnection from "../../Stores/SignalRConnection";

export async function signIn(signInData) {
  localStorage.removeItem(authToken);
  localStorage.removeItem(userNameItem);
  localStorage.removeItem(userIdItem);
  let errorText = "";
  await userClient
          .post("signIn", signInData)
          .then( async (result) => {
              let token = result?.data?.jwtToken;
              localStorage.setItem(authToken, token);
              localStorage.setItem(userIdItem, result?.data?.userId);
              localStorage.setItem(userNameItem, result?.data?.userName);
              await SignalRConnection.joinAllChats()
              return ""
          })
          .catch((error) => {
              console.log(error)
              errorText = error.response?.data?.title !== undefined
                  ? error.response.data.title
                  : "Не удалось получить ответ от сервера"
          });

  console.log(errorText)
  return errorText
}
