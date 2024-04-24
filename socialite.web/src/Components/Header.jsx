import {profile, signIn} from "../Constants/PagePaths";
import {SmallAvatar} from "../Constants/Images/Avatars";
import {useEffect, useState} from "react";
import UserInfoAsync from "../CommonServices/UserInfo";
import SearchString from "./SearchString/SearchString";

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
        loadProfile()
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

                                {/* notification */}
                                <button type="button"
                                        className="sm:p-2 p-1 rounded-full relative sm:bg-secondery dark:text-white"
                                        uk-tooltip="title: Notification; pos: bottom; offset:6">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"
                                         className="w-6 h-6 max-sm:hidden">
                                        <path
                                            d="M5.85 3.5a.75.75 0 00-1.117-1 9.719 9.719 0 00-2.348 4.876.75.75 0 001.479.248A8.219 8.219 0 015.85 3.5zM19.267 2.5a.75.75 0 10-1.118 1 8.22 8.22 0 011.987 4.124.75.75 0 001.48-.248A9.72 9.72 0 0019.266 2.5z"/>
                                        <path fill-rule="evenodd"
                                              d="M12 2.25A6.75 6.75 0 005.25 9v.75a8.217 8.217 0 01-2.119 5.52.75.75 0 00.298 1.206c1.544.57 3.16.99 4.831 1.243a3.75 3.75 0 107.48 0 24.583 24.583 0 004.83-1.244.75.75 0 00.298-1.205 8.217 8.217 0 01-2.118-5.52V9A6.75 6.75 0 0012 2.25zM9.75 18c0-.034 0-.067.002-.1a25.05 25.05 0 004.496 0l.002.1a2.25 2.25 0 11-4.5 0z"
                                              clip-rule="evenodd"/>
                                    </svg>
                                    <div
                                        className="absolute top-0 right-0 -m-1 bg-red-600 text-white text-xs px-1 rounded-full">1
                                    </div>
                                </button>
                                <div
                                    className="hidden bg-white pr-1.5 rounded-lg drop-shadow-xl dark:bg-slate-700 md:w-[365px] w-screen border2"
                                    uk-drop="offset:6;pos: bottom-right; mode: click; animate-out: true; animation: uk-animation-scale-up uk-transform-origin-top-right ">

                                    {/* heading */}
                                    <div className="flex items-center justify-between gap-2 p-4 pb-2">
                                        <h3 className="font-bold text-xl"> Notifications </h3>

                                        <div className="flex gap-2.5">
                                            <button type="button"
                                                    className="p-1 flex rounded-full focus:bg-secondery dark:text-white">
                                                <ion-icon className="text-xl" name="ellipsis-horizontal"></ion-icon>
                                            </button>
                                            <div className="w-[280px] group"
                                                 uk-dropdown="pos: bottom-right; animation: uk-animation-scale-up uk-transform-origin-top-right; animate-out: true; mode: click; offset:5">
                                                <nav className="text-sm">
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="checkmark-circle-outline"></ion-icon>
                                                        Mark all as read</a>
                                                </nav>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="text-sm h-[400px] w-full overflow-y-auto pr-2">

                                        {/* contents list */}
                                        <div className="pl-2 p-1 text-sm font-normal dark:text-white">

                                            {/* Notification */}
                                            <a href="#"
                                               className="relative flex items-center gap-3 p-2 duration-200 rounded-xl pr-10 hover:bg-secondery dark:hover:bg-white/10 bg-teal-500/5">
                                                <div className="relative w-12 h-12 shrink-0"><img
                                                    src={SmallAvatar} alt=""
                                                    className="object-cover w-full h-full rounded-full"/></div>
                                                <div className="flex-1 ">
                                                    <p><b className="font-bold mr-1"> Alexa Gray</b> started
                                                        following you. Welcome him to your profile. 👋 </p>
                                                    <div
                                                        className="text-xs text-gray-500 mt-1.5 dark:text-white/80"> 4
                                                        hours ago
                                                    </div>
                                                    <div
                                                        className="w-2.5 h-2.5 bg-teal-600 rounded-full absolute right-3 top-5"></div>
                                                </div>
                                            </a>
                                        </div>

                                    </div>


                                    {/* footer */}
                                    <a href="#">
                                        <div
                                            className="text-center py-4 border-t border-slate-100 text-sm font-medium text-blue-600 dark:text-white dark:border-gray-600"> View
                                            Notifications
                                        </div>
                                    </a>

                                    <div
                                        className="w-3 h-3 absolute -top-1.5 right-3 bg-white border-l border-t rotate-45 max-md:hidden dark:bg-dark3 dark:border-transparent"></div>
                                </div>

                                {/* messages */}
                                <button type="button"
                                        className="sm:p-2 p-1 rounded-full relative sm:bg-secondery dark:text-white"
                                        uk-tooltip="title: Messages; pos: bottom; offset:6">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"
                                         className="w-6 h-6 max-sm:hidden">
                                        <path fill-rule="evenodd"
                                              d="M4.848 2.771A49.144 49.144 0 0112 2.25c2.43 0 4.817.178 7.152.52 1.978.292 3.348 2.024 3.348 3.97v6.02c0 1.946-1.37 3.678-3.348 3.97a48.901 48.901 0 01-3.476.383.39.39 0 00-.297.17l-2.755 4.133a.75.75 0 01-1.248 0l-2.755-4.133a.39.39 0 00-.297-.17 48.9 48.9 0 01-3.476-.384c-1.978-.29-3.348-2.024-3.348-3.97V6.741c0-1.946 1.37-3.68 3.348-3.97zM6.75 8.25a.75.75 0 01.75-.75h9a.75.75 0 010 1.5h-9a.75.75 0 01-.75-.75zm.75 2.25a.75.75 0 000 1.5H12a.75.75 0 000-1.5H7.5z"
                                              clip-rule="evenodd"></path>
                                    </svg>
                                </button>
                                <div
                                    className="hidden bg-white pr-1.5 rounded-lg drop-shadow-xl dark:bg-slate-700 md:w-[360px] w-screen border2"
                                    uk-drop="offset:6;pos: bottom-right; mode: click; animate-out: true; animation: uk-animation-scale-up uk-transform-origin-top-right ">

                                    {/* heading */}
                                    <div className="flex items-center justify-between gap-2 p-4 pb-1">
                                        <h3 className="font-bold text-xl"> Chats </h3>

                                        <div className="flex gap-2.5 text-lg text-slate-900 dark:text-white">
                                            <ion-icon name="expand-outline"></ion-icon>
                                            <ion-icon name="create-outline"></ion-icon>
                                        </div>
                                    </div>

                                    <div className="relative w-full p-2 px-3 ">
                                        <input type="text" className="w-full !pl-10 !rounded-lg dark:!bg-white/10"
                                               placeholder="Search"/>
                                        <ion-icon name="search-outline"
                                                  className="dark:text-white absolute left-7 -translate-y-1/2 top-1/2"></ion-icon>
                                    </div>

                                    <div className="h-80 overflow-y-auto pr-2">

                                        <div className="p-2 pt-0 pr-1 dark:text-white/80">

                                            <a href="#"
                                               className="relative flex items-center gap-4 p-2 py-3 duration-200 rounded-lg hover:bg-secondery dark:hover:bg-white/10">
                                                <div className="relative w-10 h-10 shrink-0">
                                                    <img src={SmallAvatar}
                                                         alt=""
                                                         className="object-cover w-full h-full rounded-full"/>
                                                </div>
                                                <div className="flex-1 min-w-0">
                                                    <div className="flex items-center gap-2 mb-1">
                                                        <div
                                                            className="mr-auto text-sm text-black dark:text-white font-medium">Jesse
                                                            Steeve
                                                        </div>
                                                        <div
                                                            className="text-xs text-gray-500 dark:text-white/80"> 09:40AM
                                                        </div>
                                                        <div
                                                            className="w-2.5 h-2.5 bg-blue-600 rounded-full dark:bg-slate-700"></div>
                                                    </div>
                                                    <div
                                                        className="font-normal overflow-hidden text-ellipsis text-xs whitespace-nowrap">Love
                                                        your photos 😍
                                                    </div>
                                                </div>
                                            </a>

                                        </div>
                                    </div>


                                    {/* footer */}
                                    <a href="#">
                                        <div
                                            className="text-center py-4 border-t border-slate-100 text-sm font-medium text-blue-600 dark:text-white dark:border-gray-600"> See
                                            all Messages
                                        </div>
                                    </a>

                                    <div
                                        className="w-3 h-3 absolute -top-1.5 right-3 bg-white border-l border-t rotate-45 max-md:hidden dark:bg-dark3 dark:border-transparent"></div>
                                </div>

                                {/* profile */}
                                <div className="rounded-full relative bg-secondery cursor-pointer shrink-0">
                                    <img src={userInfo?.avatar ? userInfo.avatar : SmallAvatar} alt=""
                                         className="sm:w-9 sm:h-9 w-7 h-7 rounded-full shadow shrink-0"/>
                                </div>
                                <div
                                    className="hidden bg-white rounded-lg drop-shadow-xl dark:bg-slate-700 w-64 border2"
                                    uk-drop="offset:6;pos: bottom-right;animate-out: true; animation: uk-animation-scale-up uk-transform-origin-top-right ">

                                    <a href={profile}>
                                        <div className="p-4 py-5 flex items-center gap-4">
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

                                    <hr className="dark:border-gray-600/60"/>

                                    <nav className="p-2 text-sm text-black font-normal dark:text-white">
                                        <a href="../../../public/upgrade.html">
                                            <div
                                                className="flex items-center gap-2.5 hover:bg-secondery p-2 px-2.5 rounded-md dark:hover:bg-white/10 text-blue-600">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none"
                                                     viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
                                                     className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M3.75 13.5l10.5-11.25L12 10.5h8.25L9.75 21.75 12 13.5H3.75z"/>
                                                </svg>
                                                Upgrade To Premium
                                            </div>
                                        </a>
                                        <a href="../../../public/setting.html">
                                            <div
                                                className="flex items-center gap-2.5 hover:bg-secondery p-2 px-2.5 rounded-md dark:hover:bg-white/10">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none"
                                                     viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
                                                     className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z"/>
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"/>
                                                </svg>
                                                My Account
                                            </div>
                                        </a>
                                        <button type="button" className="w-full">
                                            <div
                                                className="flex items-center gap-2.5 hover:bg-secondery p-2 px-2.5 rounded-md dark:hover:bg-white/10">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none"
                                                     viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
                                                     className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z"/>
                                                </svg>
                                                Night mode
                                                <span
                                                    className="bg-slate-200/40 ml-auto p-0.5 rounded-full w-9 dark:hover:bg-white/20">
                                                <span
                                                    className="bg-white block h-4 relative rounded-full shadow-md w-2 w-4 dark:bg-blue-600"></span>
                                            </span>
                                            </div>
                                        </button>
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
                                                Log Out
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