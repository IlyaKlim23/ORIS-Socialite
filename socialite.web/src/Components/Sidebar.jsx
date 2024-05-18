import {feed, messages, signIn} from "../Constants/PagePaths";
import feedLogo from "../Sources/Images/Icons/home.png"
import messagesLogo from "../Sources/Images/Icons/messages.png"
import "./Styles/componentStyles.css"
import {Link} from "react-router-dom";

function Sidebar(currentPage) {

    function onLogOut(){
        localStorage.clear()
        window.location.href = signIn
    }


    return(
        <>
            <div id="site__sidebar"
                 onClick={() => console.log(currentPage)}
                 className="fixed top-0 left-0 z-[99] pt-[--m-top] bg-white/10 overflow-hidden transition-transform xl:duration-500 dark:bg-dark15 max-xl:w-full max-xl:-translate-x-full">
                <div
                    className="p-2 max-xl:bg-white shadow-sm 2xl:w-72 sm:w-64 w-[80%] h-[calc(100vh-64px)] relative z-30 max-lg:border-r dark:max-xl:!bg-slate-700 dark:border-slate-700">

                    <div className="pr-4" data-simplebar>

                        <nav id="side">
                            <ul>
                                <li className={currentPage.currentPage === feed ? "active" : ""}>
                                    <Link to={feed}>
                                        <img src={feedLogo} alt="feeds" className="w-6"/>
                                        <span> Лента </span>
                                    </Link>
                                </li>
                                <li className={currentPage.currentPage === messages ? "active" : ""}>
                                    <Link to={messages}>
                                        <img src={messagesLogo} alt="messages" className="w-6"/>
                                        <span> Сообщения </span>
                                    </Link>
                                </li>
                            </ul>

                            <nav id="side"
                                 className="font-medium text-sm text-black border-t pt-3 mt-2 dark:text-white dark:border-slate-800">
                                <div className="px-3 pb-2 text-sm font-medium">
                                    <div className="text-black dark:text-white">Страницы</div>
                                </div>

                                <ul className=""
                                    uk-nav="multiple: true">

                                    <li>
                                        <a onClick={onLogOut}>
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                 stroke-width="1.5" stroke="currentColor" className="w-4 h-4">
                                                <path stroke-linecap="round" stroke-linejoin="round"
                                                      d="M15.75 9V5.25A2.25 2.25 0 0013.5 3h-6a2.25 2.25 0 00-2.25 2.25v13.5A2.25 2.25 0 007.5 21h6a2.25 2.25 0 002.25-2.25V15m3 0l3-3m0 0l-3-3m3 3H9"/>
                                            </svg>
                                            <span>   Выход   </span>
                                        </a>
                                    </li>

                                </ul>

                            </nav>
                        </nav>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Sidebar;
