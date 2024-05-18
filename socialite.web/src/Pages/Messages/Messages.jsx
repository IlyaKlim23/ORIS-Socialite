import Header from "../../Components/Header";
import Sidebar from "../../Components/Sidebar";
import Chat from "../../Components/Messages/Chat";
import GetChatsShortInfo from "../../Api/Chat/GetChatsShortInfo";
import {useEffect, useState} from "react";
import ChatShortInfo from "../../Components/Messages/ChatShortInfo";
import {messages} from "../../Constants/PagePaths";
import {observer} from "mobx-react-lite";
import {useParams} from "react-router-dom";

const Messages = observer(() => {
    const chatId = useParams().chatId
    const [chatsInfo, setChatsInfo] = useState([])
    const [chatInfo, setChatInfo] = useState()

    async function loadChats(){
        const result = await GetChatsShortInfo()
        if (result){
            setChatsInfo(result.data.items)
            if (chatId){
                setChatInfo(result.data.items.find(x => x.chatId === chatId))
            }
        }
    }


    useEffect(() => {
        loadChats().then()
    }, []);

    return (
        <>
            <div id="wrapper">

                <Header></Header>
                <Sidebar currentPage={messages}></Sidebar>

                {/* main contents */}
                <main id="site__main"
                      className="2xl:ml-[--w-side]  xl:ml-[--w-side-sm] p-2.5 h-[calc(100vh-var(--m-top))] mt-[--m-top]">

                    <div className="relative overflow-hidden border -m-2.5 dark:border-slate-700 ">

                        <div className="flex bg-white dark:bg-dark15">

                            {/* sidebar */}
                            <div className="md:w-[360px] relative border-r dark:border-slate-700">

                                <div id="side-chat"
                                     className="top-0 left-0 max-md:fixed max-md:w-5/6 max-md:h-screen bg-white z-50 max-md:shadow max-md:-translate-x-full dark:bg-dark15">

                                    {/* heading title */}
                                    <div className="p-4 border-b dark:border-slate-700">

                                        <div className="flex mt-2 items-center justify-between">

                                            <h2 className="text-2xl font-bold text-black ml-1 dark:text-white"> Чаты </h2>

                                        </div>

                                        {/* search */}
                                        <div className="relative mt-4">
                                            <div className="absolute left-3 bottom-1/2 translate-y-1/2 flex">
                                            </div>
                                        </div>
                                    </div>


                                    {/* users list */}
                                    <div
                                        className="space-y-2 p-2 overflow-y-auto md:h-[calc(100vh-204px)] h-[calc(100vh-130px)]">

                                        {
                                            chatsInfo.map((x, index) =>
                                                <>
                                                    <div
                                                        onClick={() => {
                                                            setChatInfo(x)
                                                            window.history.replaceState(null, null, `${messages}/${x.chatId}`)
                                                        }}>
                                                        <ChatShortInfo key={index} info={x}/>
                                                    </div>
                                                </>
                                            )
                                        }

                                    </div>

                                </div>
                                <div className="w-full !pl-10 !py-4 !rounded-lg"></div>

                            </div>

                            {/* message center */}
                            {
                                chatInfo ? <Chat chatInfo={chatInfo} key={chatInfo.chatId}/> : <></>
                            }

                        </div>

                    </div>
                </main>
            </div>
        </>
    )
});

export default Messages