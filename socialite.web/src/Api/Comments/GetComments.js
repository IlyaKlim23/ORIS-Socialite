import {authToken} from "../../Constants/LocalStorageItemKeys";
import {commentsClient} from "../../Constants/AxiosClients";


export default async function GetComment(postId, bucketNumber){
    const token = localStorage.getItem(authToken)
    const data = {
        count: 5,
        bucketNumber: bucketNumber,
    }

    let result
    await commentsClient
        .post("getComments", data, {
            params: {
                postId: postId
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
