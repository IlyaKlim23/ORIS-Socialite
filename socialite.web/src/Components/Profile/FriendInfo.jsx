import {profile} from "../../Constants/PagePaths";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";


export default function FriendInfo({userInfo}){
    let [avatar, setAvatar] = useState('')

    async function loadAvatar(){
        if (userInfo?.userInfo?.avatarId){
            const result = await DownloadFile(userInfo.userInfo.avatarId)
            if (result)
                setAvatar(result)
        }
    }

    useEffect(() => {
        loadAvatar().then()
    }, []);


    return(
        <>
            <a href={`${profile}/${userInfo?.userId}`}
               className="relative px-3 py-1.5 flex items-center gap-4 hover:bg-secondery rounded-lg dark:hover:bg-white/10">
                <img alt="" src={userInfo?.userInfo?.avatarId ? avatar : SmallAvatar} className="w-9 h-9 rounded-full"/>
                <div>
                    <div> {userInfo?.firstName} {userInfo?.lastName} </div>
                    <div
                        className="text-xs text-blue-500 font-medium mt-0.5"> @{userInfo?.userName}</div>
                </div>
            </a>
        </>
    )
}