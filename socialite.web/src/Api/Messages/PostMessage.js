import {authToken} from "../../Constants/LocalStorageItemKeys";
import {messagesClient} from "../../Constants/AxiosClients";


export default async function PostMessage(chatId, messageText){
    let token = localStorage.getItem(authToken)
    const data = {
        text: messageText
    }

    let result
    await messagesClient
        .post('', data, {
            params: {
                chatId: chatId
            },
            headers: {
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