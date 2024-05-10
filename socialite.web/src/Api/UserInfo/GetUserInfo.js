import { authToken } from "../../Constants/LocalStorageItemKeys";
import { userProfileClient } from "../../Constants/AxiosClients";

export default async function GetUserInfo(userId) {
    let token = localStorage.getItem(authToken);

    let result;
    let errorText = ""
    await userProfileClient
        .get('', {
            params:{
                userId: userId
            },
            headers: {
                Authorization: `Bearer ${token}`,
            },
        })
        .then((response) => {
            result = response
        })
        .catch((error) => {
            if (error?.response?.status === 401) {
                localStorage.removeItem(authToken);
            }
            errorText = error.response?.data?.title !== undefined
                ? error.response.data.title
                : "Не удалось получить ответ от сервера"
        });

    return result ?? errorText;
}