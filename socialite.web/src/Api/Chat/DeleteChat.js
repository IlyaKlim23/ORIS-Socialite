import {authToken} from "../../Constants/LocalStorageItemKeys";
import {chatClient} from "../../Constants/AxiosClients";


export default async function DeleteChat(chatId){
    let token = localStorage.getItem(authToken)

    let result
    await chatClient
        .delete('', {
            params:{
                chatId
            },
            headers:{
                Authorization: `Bearer ${token}`
            }
        })
        .then(response =>{
            result = response
        })
        .catch(error =>{
            console.log(error)
        })

    return result
}