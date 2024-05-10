import {useEffect, useState} from "react";
import Message from "./Message";
import GetMessages from "../../Api/Messages/GetMessages";
import PostMessage from "../../Api/Messages/PostMessage";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import {profile} from "../../Constants/PagePaths";

export default function Chat({chatInfo}){
    const [inputText, setInputText] = useState('')
    const [messages, setMessages] = useState([])
    const [avatar, setAvatar] = useState('')

    async function loadMessages()
    {
        const result = await GetMessages(chatInfo.chatId)
        if (result){
            setMessages(result.data.items)
        }
    }

    async function loadAvatar(){
        const result = await DownloadFile(chatInfo.avatarId)
        if (result)
            setAvatar(result)
    }

    async function sendMessage(){
        if (inputText.length > 0){
            await PostMessage(chatInfo.chatId, inputText)
            await loadMessages()
            setInputText('')
        }
    }

    useEffect(() => {
        setAvatar('')
        loadMessages().then()
        if (chatInfo.avatarId) loadAvatar().then()
    }, [chatInfo]);

    return(
        <>
            <div className="flex-1">

                {/* chat heading */}
                <div
                    className="flex items-center justify-between gap-2 w- px-6 py-3.5 z-10 border-b dark:border-slate-700 uk-animation-slide-top-medium">

                    <div className="flex items-center sm:gap-4 gap-2">

                        {/* toggle for mobile */}
                        <button type="button" className="md:hidden"
                                uk-toggle="target: #side-chat ; cls: max-md:-translate-x-full">
                            <ion-icon name="chevron-back-outline" className="text-2xl -ml-4"></ion-icon>
                        </button>

                        <div className="relative cursor-pointer max-md:hidden"
                             uk-toggle="target: .rightt ; cls: hidden">
                            <img src={avatar && chatInfo.avatarId ? avatar : SmallAvatar} alt=""
                                 className="w-8 h-8 rounded-full shadow"/>
                        </div>
                        <div className="cursor-pointer" uk-toggle="target: .rightt ; cls: hidden">
                            <div className="text-base font-bold"> {chatInfo.firstName} {chatInfo.lastName} </div>
                        </div>
                    </div>

                </div>

                {/* chats bubble */}
                <div
                    className="w-full p-5 py-10 overflow-y-auto md:h-[calc(100vh-204px)] h-[calc(100vh-195px)]">

                    <div className="py-10 text-center text-sm lg:pt-8">
                        <img src={avatar && chatInfo.avatarId ? avatar : SmallAvatar}
                             className="w-24 h-24 rounded-full mx-auto mb-3" alt=""/>
                        <div className="mt-8">
                            <div
                                className="md:text-xl text-base font-medium text-black dark:text-white"> {chatInfo.firstName} {chatInfo.lastName}
                            </div>
                            <div className="text-gray-500 text-sm   dark:text-white/80"> @{chatInfo.userName}
                            </div>
                        </div>
                        <div className="mt-3.5">
                            <a href={`${profile}/${chatInfo.userId}`}
                               className="inline-block rounded-lg px-4 py-1.5 text-sm font-semibold bg-secondery">View
                                profile</a>
                        </div>
                    </div>

                    <div className="text-sm font-medium space-y-4 messages">

                        {messages.map((x, index) =>
                            <Message isReceived={!x.isCurrentUser} text={x.text}/>)}

                    </div>

                </div>

                {/* sending message area */}
                <div className="flex items-center md:gap-4 gap-2 md:p-3 p-2 overflow-hidden">

                    <div id="message__wrap"
                         className="flex items-center gap-2 h-full dark:text-white ml-2 -mt-1.5">

                        <button type="button" className="shrink-0">
                            <ion-icon className="text-3xl flex" name="happy-outline"></ion-icon>
                        </button>
                        <div className="dropbar p-2"
                             uk-drop="stretch: x; target: #message__wrap ;animation: uk-animation-scale-up uk-transform-origin-bottom-left ;animate-out: true; pos: top-left ; offset:2; mode: click ; duration: 200; container: false ">

                            <div
                                className="sm:w-60 bg-white shadow-lg border rounded-xl  pr-0 dark:border-slate-700 dark:bg-dark3">

                                <div
                                    className="grid grid-cols-5 overflow-y-auto max-h-44 p-3 text-center text-xl">

                                    <div
                                        onClick={() => setInputText(inputText + '😊')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😊
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🥳')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🥳
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😂')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😂
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🥰')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🥰
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😡')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😡
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🤩')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🤩
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😎')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😎
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🤔')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🤔
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😍')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😍
                                    </div>

                                    <div
                                        onClick={() => setInputText(inputText + '🙃')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🙃
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😘')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😘
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😭')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😭
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🤡')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🤡
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '🙏')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 🙏
                                    </div>
                                    <div
                                        onClick={() => setInputText(inputText + '😐')}
                                        className="hover:bg-secondery p-1.5 rounded-md hover:scale-125 cursor-pointer duration-200"> 😐
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                    <div className="relative flex-1">
                                        <textarea placeholder="Write your message" rows="1"
                                                  value={inputText}
                                                  onChange={e => setInputText(e.target.value)}
                                                  className="w-full resize-none bg-secondery rounded-full px-4 p-2"></textarea>

                        <button type="button"
                                onClick={sendMessage}
                                className="text-white shrink-0 p-2 absolute right-0.5 top-0">
                            <ion-icon className="text-xl flex" name="send"></ion-icon>
                        </button>

                    </div>

                </div>

            </div>
        </>
    )
}