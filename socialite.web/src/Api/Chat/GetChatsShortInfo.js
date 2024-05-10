import {authToken} from "../../Constants/LocalStorageItemKeys";
import {chatClient} from "../../Constants/AxiosClients";

export default async function GetChatsShortInfo(){
    let token = localStorage.getItem(authToken)

    let result
    await chatClient
        .post('shortInfo', {}, {
            headers : {
                Authorization: `Bearer ${token}`
            }
        })
        .then((response) => {
            result = response;
        })
        .catch((error) => {
            console.log(error);
        });

    return result
}