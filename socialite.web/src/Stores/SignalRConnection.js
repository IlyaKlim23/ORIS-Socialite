import {makeAutoObservable} from "mobx";
import JoinAllChats from "../Api/Chat/JoinAllChats";
import {authToken} from "../Constants/LocalStorageItemKeys";

class SignalRConnection{
    connection
    constructor() {
        makeAutoObservable(this)
    }

    async joinAllChats(){
        if (localStorage.getItem(authToken)) {
            this.connection = await JoinAllChats();
        }
        else console.log("Нет токена")
    }

    async refreshConnection(){
        if (this.connection === undefined)
            await this.joinAllChats()
    }
}

export default new SignalRConnection();