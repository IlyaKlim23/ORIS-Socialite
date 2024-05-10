import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";


export default function ChatShortInfo({info}){
    const [avatar, setAvatar] = useState('')

    async function loadAvatar(){
        const result = await DownloadFile(info.avatarId)
        if (result)
            setAvatar(result)
    }

    useEffect(() => {
        if (info.avatarId) loadAvatar().then()
    }, []);

    return (
        <>
            <a href="#"
               className="relative flex items-center gap-4 p-2 duration-200 rounded-xl hover:bg-secondery">
                <div className="relative w-14 h-14 shrink-0">
                    <img src={avatar ? avatar : SmallAvatar} alt=""
                         className="object-cover w-full h-full rounded-full"/>
                </div>
                <div className="flex-1 min-w-0">
                    <div className="flex items-center gap-2 mb-1.5">
                        <div
                            className="mr-auto text-sm text-black dark:text-white font-medium">{info.firstName} {info.lastName}
                        </div>
                        <div
                            className="text-xs font-light text-gray-500 dark:text-white/70">09:40AM
                        </div>
                    </div>
                    <div
                        className="font-medium overflow-hidden text-ellipsis text-sm text-gray-400">{info.lastMessageText}
                    </div>
                </div>
            </a>
        </>
    )
}