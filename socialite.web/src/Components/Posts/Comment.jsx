import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";


function Comment(commentData){
    const data = commentData.commentData
    const [avatar, setAvatar] = useState('')

    async function loadAvatar(){
        if (data?.owner?.avatar?.fileId)
        {
            const result = await DownloadFile(data?.owner?.avatar?.fileId)
            setAvatar(avatar)
        }
    }

    useEffect(() => {
        loadAvatar()
    }, []);

    return(
        <>
            <div
                className="sm:p-4 p-2.5 border-t border-gray-100 font-normal space-y-3 relative dark:border-slate-700/40">

                <div className="flex items-start gap-3 relative">
                    <a href="profile.html"> <img
                        src={avatar ? avatar : SmallAvatar} alt=""
                        className="w-6 h-6 mt-1 rounded-full"/> </a>
                    <div className="flex-1">
                        <a href="profile.html"
                           className="text-black font-medium inline-block dark:text-white"> Steeve </a>
                        <p className="mt-0.5">{data.text}</p>
                    </div>
                </div>

                <button type="button"
                        className="flex items-center gap-1.5 text-gray-500 hover:text-blue-500 mt-2">
                    <ion-icon name="chevron-down-outline"
                              className="ml-auto duration-200 group-aria-expanded:rotate-180"></ion-icon>
                    More Comment
                </button>

            </div>
        </>
    )
}

export default Comment