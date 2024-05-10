import {HttpTransportType, HubConnectionBuilder} from "@microsoft/signalr";
import {chatUrl} from "../../Constants/AxiosClients";
import {joinChat, receiveMessage} from "../../Constants/ChatMethods";
import GetChat from "./GetChat";
import {authToken} from "../../Constants/LocalStorageItemKeys";

export default async function JoinChat(userToId){
    let token = localStorage.getItem(authToken)
    let chatId
    const getChatResult = await GetChat(userToId)
    if (getChatResult)
        chatId = getChatResult.data.chatId

    var connection = new HubConnectionBuilder()
        .withUrl(chatUrl,
            {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
                accessTokenFactory: ()=> {return token}
            })
        .withAutomaticReconnect()
        .build();

    connection.on(receiveMessage, (message) => {
        console.log(message)
    })

    try{
        await connection.start();
        await connection.invoke("SuggestAChat", {ChatId: userToId});
        //await connection.invoke(joinChat, { ChatId: chatId });

    }
    catch (error){
        console.log(error)
    }

    return connection
}