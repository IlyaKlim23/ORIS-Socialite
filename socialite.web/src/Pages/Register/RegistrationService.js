import isValidRegistrationData, {isValidEmail, isValidPassword} from "../../CommonServices/ValidationService.js";
import { register } from "../../Api/Auth/Register.js";

export default async function processRegistration(registrationData) {
    if (isValidRegistrationData(registrationData)) {
      return await register(registrationData)
    }
    else if (!isValidEmail(registrationData.email)){
        return "Формат почты неверен"
    }
    else if (!isValidPassword(registrationData.password)){
        return "Пароль должен содержать заглавные и строчные символы, а также цифры. Длина пароля от 6 символов"
    }
    else return ("Невалидные данные");
}
