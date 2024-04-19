import { authToken } from "../../Constants/LocalStorageItemKeys";
import { userProfileClient } from "../../Constants/AxiosClients";

export default async function GetCurrentUserInfo() {
    let token = localStorage.getItem(authToken);

    let result;
    await userProfileClient
        .get('currentUserInfo', {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        })
        .then((response) => {
            console.log(response);
            result = response
        })
        .catch((error) => {
            console.log(error);
            if (error.response.status === 401) {
                localStorage.removeItem(authToken);
            }
        });

    return result;
}