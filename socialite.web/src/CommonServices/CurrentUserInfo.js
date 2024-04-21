import GetCurrentUserInfo from "../Api/UserInfo/GetCurrentUserInfo";
import DownloadFile from "../Api/StaticFiles/DownloadFile";


export default async function CurrentUserInfoAsync(){
    let userData
    let avatar

    const response = await GetCurrentUserInfo();
    if (response?.data) {
        userData = response?.data;
        if (response.data?.avatarId){
            avatar = await DownloadFile(response.data.avatarId);
        }
    }

    return {
        avatar: avatar,
        userData: userData
    }
}