import {isValidEmail, isValidSignInData} from "../../CommonServices/ValidationService.js";
import { signIn } from "../../Api/Auth/SignIn.js";

export async function processSignIn(signInData) {
  if (isValidSignInData(signInData)) {
    return await signIn(signInData)
  }
  else if (!isValidEmail(signInData.email)){
    return "Формат почты неверен"
  }
  else{
    return "Пароль должен содержать заглавные и строчные символы, а также цифры. Длина пароля от 6 символов"
  }
}
