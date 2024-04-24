import {authToken} from "../../Constants/LocalStorageItemKeys";
import {subscribersClient} from "../../Constants/AxiosClients";


export async function Subscribe(subscribeToId){
    let token = localStorage.getItem(authToken);

    let result
    await subscribersClient
        .post('subscribe', null, {
            params: {
                subscribeToId: subscribeToId
            },
        headers:{
                Authorization: `Bearer ${token}`
        }})
        .then((response) => {
            result = response;
        })
        .catch((error) => {
            console.log(error);
        });

    return result
}

export async function Unsubscribe(unsubscribeToId){
    let token = localStorage.getItem(authToken);

    let result
    await subscribersClient
        .post('unsubscribe', null, {
            params: {
                unsubscribeToId: unsubscribeToId
            },
            headers:{
                Authorization: `Bearer ${token}`
            }})
        .then((response) => {
            result = response;
        })
        .catch((error) => {
            console.log(error);
        });

    return result
}