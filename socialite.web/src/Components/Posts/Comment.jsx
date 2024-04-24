import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import {ParseDateForComment} from "../../CommonServices/DateParser";
import {userIdItem} from "../../Constants/LocalStorageItemKeys";
import {profile} from "../../Constants/PagePaths";


function Comment(commentData){
    const data = commentData.commentData
    const [avatar, setAvatar] = useState('')
    const isCurrentUser = localStorage.getItem(userIdItem) === data?.owner?.userId;


    async function loadAvatar(){
        if (data?.owner?.avatarId)
        {
            const result = await DownloadFile(data?.owner?.avatarId)
            if (result)
                setAvatar(result)
        }
    }

    useEffect(() => {
        loadAvatar().then()
    }, []);

    return(
        <>
            <div className="flex items-start gap-3 relative">
                <a href={isCurrentUser ? profile : `${profile}/${data?.owner?.userId}`}> <img src={avatar ? avatar : SmallAvatar} alt=""
                    className="w-6 h-6 mt-1 rounded-full"/> </a>
                <div className="flex-1">
                    <a href={isCurrentUser ? profile : `${profile}/${data?.owner?.userId}`}
                       className="text-black font-medium inline-block dark:text-white"> {data?.owner?.firstName} {data?.owner?.lastName} </a>
                    <span
                        className="mt-0.5 ml-1 text-xs dark:text-white/60"> {ParseDateForComment(data?.createdDate)}</span>
                    <p className="mt-0.5">{data.text}</p>
                </div>
            </div>
        </>
    )
}

export default Comment