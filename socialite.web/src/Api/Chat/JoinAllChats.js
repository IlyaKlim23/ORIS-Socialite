import GetAllChats from "./GetAllChats";
import {HttpTransportType, HubConnectionBuilder} from "@microsoft/signalr";
import {chatUrl} from "../../Constants/AxiosClients";
import {joinAllChats} from "../../Constants/ChatMethods";

export default async function JoinAllChats(){
    let chatIds
    const chatIdsResult = await GetAllChats();
    if (chatIdsResult)
        chatIds = chatIdsResult.data.chatIds

    let connection = new HubConnectionBuilder()
        .withUrl(chatUrl,
            {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
            })
        .withAutomaticReconnect()
        .build();

    try{
        await connection.start();
        await connection.invoke(joinAllChats, { ChatIds: chatIds });
    }
    catch (error){
        console.log(error)
    }

    return connection
}