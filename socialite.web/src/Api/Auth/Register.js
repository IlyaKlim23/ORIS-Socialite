import { userClient } from "../../Constants/AxiosClients.js";
import { signIn } from "./SignIn.js";

export async function register(registerData) {
  let errorText = "";
  await userClient
    .post("register", registerData)
    .then((response) => {
      if (response.data.result.succeeded) {
        console.log(registerData);
        let signInData = {
          email: registerData.email,
          password: registerData.password,
        };
        return signIn(signInData);
      }
    })
    .catch((error) => {
      errorText = error.response?.data?.title !== undefined
          ? error.response.data.title
          : "Не удалось получить ответ от сервера"
    });

  console.log(errorText)
  return errorText
}
