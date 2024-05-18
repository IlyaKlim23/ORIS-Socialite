import {sendMessageToChat} from "../../Constants/ChatMethods";

export default async function SendMessageInChat(connection, chatId, message){
    await connection.invoke(sendMessageToChat, {chatId: chatId, message: message})
}