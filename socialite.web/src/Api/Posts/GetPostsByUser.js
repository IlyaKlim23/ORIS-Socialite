import {authToken} from "../../Constants/LocalStorageItemKeys";
import {postsClient} from "../../Constants/AxiosClients";

export default async function GetPostsByUser(userId){
    let token = localStorage.getItem(authToken);

    let result
    await postsClient
        .get('', {
            params:{
                userId
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