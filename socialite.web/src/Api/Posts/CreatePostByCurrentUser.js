import {authToken} from "../../Constants/LocalStorageItemKeys";
import {postsClient} from "../../Constants/AxiosClients";


export default async function CreatePostByCurrentUser(postInfo){
    let token = localStorage.getItem(authToken);
    const data = {
        description: postInfo.description,
        fileIds: postInfo.fileIds
    }

    let result
    await postsClient
        .post("", data, {headers : {
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