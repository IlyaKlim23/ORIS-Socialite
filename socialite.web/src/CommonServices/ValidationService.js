export default function isValidRegistrationData(data){
    return data.userName!=='' && data.firstName!==''
            && data.lastName!=='' && data.role!==''
            && isValidEmail(data.email) && isValidPassword(data.password)
}

export function isValidSignInData(data){
    return isValidEmail(data.email) && isValidPassword(data.password)
}

export function isValidEmail(email){
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}
export function isValidPassword(password){
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    return password!=='' && hasLowerCase && hasUpperCase && password.length>=6
}