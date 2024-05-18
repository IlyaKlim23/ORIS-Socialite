import {profile, signIn} from "../Constants/PagePaths";
import {SmallAvatar} from "../Constants/Images/Avatars";
import {useEffect, useState} from "react";
import UserInfoAsync from "../CommonServices/UserInfo";
import SearchString from "./SearchString/SearchString";
import {Link} from "react-router-dom";

function Header(){
    const [userInfo, setUserInfo] = useState({})

    async function loadProfile(){
        const result = await UserInfoAsync(null)
        setUserInfo(result)
    }

    function onLogOut(){
        localStorage.clear()
        window.location.href = signIn
    }

    useEffect(() => {
        loadProfile().then()
    }, []);


    return(
        <>
            <header
                className="z-[100] h-[--m-top] fixed top-0 left-0 w-full flex items-center bg-white/80 sky-50 backdrop-blur-xl border-b border-slate-200 dark:bg-dark2 dark:border-slate-800">

                <div className="flex items-center w-full   max-lg:gap-10">

                    <div className="flex-1 relative">

                        <div className="max-w-[1220px] ml-422 flex items-center">

                            <SearchString />

                            {/* header icons */}
                            <div className="flex items-center sm:gap-4 gap-2 absolute right-6 top-1/2 -translate-y-1/2 text-black">

                                {/* profile */}
                                <div className="rounded-full relative bg-secondery cursor-pointer shrink-0">
                                    <img src={userInfo?.avatar ? userInfo.avatar : SmallAvatar} alt=""
                                         className="sm:w-9 sm:h-9 w-7 h-7 rounded-full shadow shrink-0"/>
                                </div>
                                <div
                                    className="hidden bg-white rounded-lg drop-shadow-xl dark:bg-slate-700 w-64 border2"
                                    uk-drop="offset:6;pos: bottom-right;animate-out: true; animation: uk-animation-scale-up uk-transform-origin-top-right ">

                                    <a href={profile}>
                                        <div className="p-4  flex items-center gap-4">
                                            <img src={userInfo?.avatar ? userInfo.avatar : SmallAvatar} alt=""
                                                 className="w-10 h-10 rounded-full shadow"/>
                                            <div className="flex-1">
                                                <h4 className="text-sm font-medium text-black">{userInfo?.userData?.firstName} {userInfo?.userData?.lastName}</h4>
                                                <div
                                                    className="text-sm mt-1 text-blue-600 font-light dark:text-white/70">@{userInfo?.userData?.userName}
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                    <nav className="p-2 text-sm text-black font-normal dark:text-white">
                                        <hr className="-mx-2 my-2 dark:border-gray-600/60"/>
                                        <a href="#"
                                            onClick={onLogOut}>
                                            <div
                                                className="flex items-center gap-2.5 hover:bg-secondery p-2 px-2.5 rounded-md dark:hover:bg-white/10">
                                                <svg className="w-6" xmlns="http://www.w3.org/2000/svg" fill="none"
                                                     viewBox="0 0 24 24" stroke="currentColor">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          stroke-width="2"
                                                          d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path>
                                                </svg>
                                                Выход
                                            </div>
                                        </a>

                                    </nav>

                                </div>

                                <div className="flex items-center gap-2 hidden">

                                    <img src={SmallAvatar} alt=""
                                         className="w-9 h-9 rounded-full shadow"/>

                                    <div className="w-20 font-semibold text-gray-600"> Hamse</div>

                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                         stroke-width="1.5" stroke="currentColor" className="w-5 h-5">
                                        <path stroke-linecap="round" stroke-linejoin="round"
                                              d="M19.5 8.25l-7.5 7.5-7.5-7.5"/>
                                    </svg>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </header>
        </>
    )
}

export default Header;