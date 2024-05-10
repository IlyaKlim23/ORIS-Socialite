import {authToken} from "../../Constants/LocalStorageItemKeys";
import {chatClient} from "../../Constants/AxiosClients";

export default async function GetChat(userId){
    let token = localStorage.getItem(authToken)

    let result
    await chatClient
        .get('', {
            headers:{
                Authorization: `Bearer ${token}`
            },
            params:{
                userId: userId
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