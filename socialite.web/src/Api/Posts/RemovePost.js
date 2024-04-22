import {authToken} from "../../Constants/LocalStorageItemKeys";
import {postsClient} from "../../Constants/AxiosClients";

export default async function RemovePost(postId){
    let token = localStorage.getItem(authToken);

    let result
    await postsClient
        .delete('',
            {params:{
            postId,
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