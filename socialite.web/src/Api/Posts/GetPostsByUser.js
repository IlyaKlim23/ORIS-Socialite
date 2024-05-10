import {authToken} from "../../Constants/LocalStorageItemKeys";
import {postsClient} from "../../Constants/AxiosClients";

export default async function GetPostsByUser(userId, isFollowingPosts){
    let token = localStorage.getItem(authToken);

    let result
    let errorText = ""
    await postsClient
        .get('', {
            params:{
                userId,
                isFollowingPosts
            },
            headers:{
                Authorization: `Bearer ${token}`
            }})
        .then((response) => {
            result = response;
        })
        .catch((error) => {
            errorText = error.response?.data?.title !== undefined
                ? error.response.data.title
                : "Не удалось получить ответ от сервера"
        });

    return result ?? errorText;
}