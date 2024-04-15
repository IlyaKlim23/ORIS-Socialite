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
        return "Пароль должен содержать символы A-Z, a-z и 0-9. Минимальная длина пароля 6 символов"
    }
    else return ("Невалидные данные");
}
