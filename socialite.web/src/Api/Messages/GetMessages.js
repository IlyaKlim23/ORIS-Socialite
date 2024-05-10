import {authToken} from "../../Constants/LocalStorageItemKeys";
import {messagesClient} from "../../Constants/AxiosClients";


export default async function GetMessages(chatId){
    let token = localStorage.getItem(authToken)

    let result
    await messagesClient
        .get('', {
            params:{
                chatId: chatId
            },
            headers:{
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