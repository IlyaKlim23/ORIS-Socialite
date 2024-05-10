import {authToken} from "../../Constants/LocalStorageItemKeys";
import {commentsClient} from "../../Constants/AxiosClients";


export default async function AddComment(commentInfo){
    let token = localStorage.getItem(authToken);
    const data = {
        text: commentInfo.text,
    }

    let result
    await commentsClient
        .post("", data, {
            params: {
                postId: commentInfo.postId
            },
            headers : {
                Authorization: `Bearer ${token}`
            }} )
        .then((response) => {
            result = response;
        })
        .catch((error) => {
            console.log(error);
        });

    return result
}