import {userClient} from "../../Constants/AxiosClients";
import {authToken} from "../../Constants/LocalStorageItemKeys";


export default async function GetUsersBaseInfo(userData){
    let token = localStorage.getItem(authToken);
    console.log(token)
    const data = {
        countItems: 5,
        userName: userData.userName
    }

    let result
    await userClient
        .post('getUsers', data, {headers : {
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