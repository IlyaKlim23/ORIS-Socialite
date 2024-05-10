import GetUserInfo from "../Api/UserInfo/GetUserInfo";
import DownloadFile from "../Api/StaticFiles/DownloadFile";


export default async function UserInfoAsync(userId){
    let userData
    let avatar

    const response = await GetUserInfo(userId);
    if (response?.data) {
        userData = response?.data;
        if (response?.data?.avatarId){
            avatar = await DownloadFile(response?.data?.avatarId);
        }
    }
    else{
        return response
    }

    return {
        avatar: avatar,
        userData: userData
    }
}