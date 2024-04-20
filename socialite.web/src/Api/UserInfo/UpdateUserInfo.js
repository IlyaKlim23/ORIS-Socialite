import {authToken} from "../../Constants/LocalStorageItemKeys";
import {userProfileClient} from "../../Constants/AxiosClients";


export default async function UpdateUserInfo(userInfo){
    let token = localStorage.getItem(authToken);
    const data = {
        avatarId: userInfo.avatarId,
        status: userInfo.status,
        placeOfLiving: userInfo.placeOfLiving,
        placeOfWork: userInfo.placeOfWork,
        placeOfStudy: userInfo.placeOfStudy,
        maritalStatus: userInfo.maritalStatus,
    };

    let result
    await userProfileClient
        .put('currentUserInfo', data, {headers : {
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