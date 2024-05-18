import {authToken} from "../../Constants/LocalStorageItemKeys";
import {subscribersClient} from "../../Constants/AxiosClients";


export default async function GetFriends(userId){
    let token = localStorage.getItem(authToken)

    let result
    await subscribersClient
        .get('friends', {
            params:{
                userId
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