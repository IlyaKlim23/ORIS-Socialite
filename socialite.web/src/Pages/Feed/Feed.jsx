import Sidebar from "../../Components/Sidebar";
import Header from "../../Components/Header";


export default function Feed(){
    return(
        <>
            <Sidebar />
            <Header />
            <div id="wrapper">
                <div id="sidebar"></div>
                {/* main contents */}
                <main id="site__main"
                      className="2xl:ml-[--w-side] xl:ml-[--w-side-sm] p-2.5 h-[calc(100vh-var(--m-top))] mt-[--m-top]">

                    {/* timeline */}
                    <div className="lg:flex 2xl:gap-16 gap-12 max-w-[1065px] mx-auto" id="js-oversized">

                        <div className="max-w-[680px] mx-auto">

                            {/* stories */}
                            <div className="mb-3">

                                <h3 className="font-extrabold text-2xl text-black dark:text-white hidden">Stories</h3>

                                <div className="relative" tabIndex="-1" uk-slider="auto play: true;finite: true"
                                     uk-lightbox="">

                                    <div className="py-5 uk-slider-container">

                                        <ul className="uk-slider-items w-[calc(100%+14px)]"
                                            uk-scrollspy="target: > li; cls: uk-animation-scale-up; delay: 20;repeat:true">
                                            <li className="md:pr-3" uk-scrollspy-class="uk-animation-fade">
                                                <div
                                                    className="md:w-16 md:h-16 w-12 h-12 rounded-full relative border-2 border-dashed grid place-items-center bg-slate-200 border-slate-300 dark:border-slate-700 dark:bg-dark2 shrink-0"
                                                    uk-toggle="target: #create-story">
                                                    <ion-icon name="camera" className="text-2xl"></ion-icon>
                                                </div>
                                            </li>
                                            <li className="md:pr-3 pr-2 hover:scale-[1.15] hover:-rotate-2 duration-300">
                                                <a href="../../../public/assets/images/avatars/avatar-lg-1.jpg"
                                                   data-caption="Caption 1">
                                                    <div
                                                        className="md:w-16 md:h-16 w-12 h-12 relative md:border-4 border-2 shadow border-white rounded-full overflow-hidden dark:border-slate-700">
                                                        <img src="../../../public/assets/images/avatars/avatar-2.jpg"
                                                             alt="" className="absolute w-full h-full object-cover"/>
                                                    </div>
                                                </a>
                                            </li>
                                        </ul>

                                    </div>

                                    <div className="max-md:hidden">

                                        <button type="button"
                                                className="absolute -translate-y-1/2 bg-white shadow rounded-full top-1/2 -left-3.5 grid w-8 h-8 place-items-center dark:bg-dark3"
                                                uk-slider-item="previous">
                                            <ion-icon name="chevron-back" className="text-2xl"></ion-icon>
                                        </button>
                                        <button type="button"
                                                className="absolute -right-2 -translate-y-1/2 bg-white shadow rounded-full top-1/2 grid w-8 h-8 place-items-center dark:bg-dark3"
                                                uk-slider-item="next">
                                            <ion-icon name="chevron-forward" className="text-2xl"></ion-icon>
                                        </button>

                                    </div>


                                </div>

                            </div>

                            {/* feed story */}
                            <div className="md:max-w-[580px] mx-auto flex-1 xl:space-y-6 space-y-3">

                                {/* add story */}
                                <div
                                    className="bg-white rounded-xl shadow-sm md:p-4 p-2 space-y-4 text-sm font-medium border1 dark:bg-dark2">

                                    <div className="flex items-center md:gap-3 gap-1">
                                        <div
                                            className="flex-1 bg-slate-100 hover:bg-opacity-80 transition-all rounded-lg cursor-pointer dark:bg-dark3"
                                            uk-toggle="target: #create-status">
                                            <div className="py-2.5 text-center dark:text-white"> What do you have in
                                                mind?
                                            </div>
                                        </div>
                                        <div
                                            className="cursor-pointer hover:bg-opacity-80 p-1 px-1.5 rounded-xl transition-all bg-pink-100/60 hover:bg-pink-100 dark:bg-white/10 dark:hover:bg-white/20"
                                            uk-toggle="target: #create-status">
                                            <svg xmlns="http://www.w3.org/2000/svg"
                                                 className="w-8 h-8 stroke-pink-600 fill-pink-200/70"
                                                 viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none"
                                                 stroke-linecap="round" stroke-linejoin="round">
                                                <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                                <path d="M15 8h.01"/>
                                                <path d="M12 3c7.2 0 9 1.8 9 9s-1.8 9 -9 9s-9 -1.8 -9 -9s1.8 -9 9 -9z"/>
                                                <path d="M3.5 15.5l4.5 -4.5c.928 -.893 2.072 -.893 3 0l5 5"/>
                                                <path d="M14 14l1 -1c.928 -.893 2.072 -.893 3 0l2.5 2.5"/>
                                            </svg>
                                        </div>
                                    </div>
                                </div>

                                {/*  post image*/}
                                <div
                                    className="bg-white rounded-xl shadow-sm text-sm font-medium border1 dark:bg-dark2">

                                    {/* post heading */}
                                    <div className="flex gap-3 sm:p-4 p-2.5 text-sm font-medium">
                                        <a href="../Profile/profile.html"> <img
                                            src="../../../public/assets/images/avatars/avatar-3.jpg" alt=""
                                            className="w-9 h-9 rounded-full"/> </a>
                                        <div className="flex-1">
                                            <a href="../Profile/profile.html"><h4
                                                className="text-black dark:text-white"> Monroe Parker </h4></a>
                                            <div className="text-xs text-gray-500 dark:text-white/80"> 2 hours ago</div>
                                        </div>
                                    </div>

                                    {/* post image */}
                                    <a href="#preview_modal" uk-toggle>
                                        <div className="relative w-full lg:h-96 h-full sm:px-4">
                                            <img src="../../../public/assets/images/post/img-2.jpg" alt=""
                                                 className="sm:rounded-lg w-full h-full object-cover"/>
                                        </div>
                                    </a>

                                    {/* post icons */}
                                    <div className="sm:p-4 p-2.5 flex items-center gap-4 text-xs font-semibold">
                                        <div>
                                            <div className="flex items-center gap-2.5">
                                                <button type="button"
                                                        className="button-icon text-red-500 bg-red-100 dark:bg-slate-700">
                                                    <ion-icon className="text-lg" name="heart"></ion-icon>
                                                </button>
                                                <a href="#">1,300</a>
                                            </div>
                                        </div>
                                        <div className="flex items-center gap-3">
                                            <button type="button"
                                                    className="button-icon bg-slate-200/70 dark:bg-slate-700">
                                                <ion-icon className="text-lg" name="chatbubble-ellipses"></ion-icon>
                                            </button>
                                            <span>260</span>
                                        </div>
                                        <button type="button" className="button-icon ml-auto">
                                            <ion-icon className="text-xl" name="paper-plane-outline"></ion-icon>
                                        </button>
                                        <button type="button" className="button-icon">
                                            <ion-icon className="text-xl" name="share-outline"></ion-icon>
                                        </button>
                                    </div>

                                    {/* comments */}
                                    <div
                                        className="sm:p-4 p-2.5 border-t border-gray-100 font-normal space-y-3 relative dark:border-slate-700/40">

                                        <div className="flex items-start gap-3 relative">
                                            <a href="../Profile/profile.html"> <img
                                                src="../../../public/assets/images/avatars/avatar-2.jpg" alt=""
                                                className="w-6 h-6 mt-1 rounded-full"/> </a>
                                            <div className="flex-1">
                                                <a href="../Profile/profile.html"
                                                   className="text-black font-medium inline-block dark:text-white"> Steeve </a>
                                                <p className="mt-0.5">What a beautiful photo! I love it. 😍 </p>
                                            </div>
                                        </div>
                                        <div className="flex items-start gap-3 relative">
                                            <a href="../Profile/profile.html"> <img
                                                src="../../../public/assets/images/avatars/avatar-3.jpg" alt=""
                                                className="w-6 h-6 mt-1 rounded-full"/> </a>
                                            <div className="flex-1">
                                                <a href="../Profile/profile.html"
                                                   className="text-black font-medium inline-block dark:text-white"> Monroe </a>
                                                <p className="mt-0.5"> You captured the moment.😎 </p>
                                            </div>
                                        </div>

                                        <button type="button"
                                                className="flex items-center gap-1.5 text-gray-500 hover:text-blue-500 mt-2">
                                            <ion-icon name="chevron-down-outline"
                                                      className="ml-auto duration-200 group-aria-expanded:rotate-180"></ion-icon>
                                            More Comment
                                        </button>

                                    </div>

                                    {/* add comment */}
                                    <div
                                        className="sm:px-4 sm:py-3 p-2.5 border-t border-gray-100 flex items-center gap-1 dark:border-slate-700/40">

                                        <img src="../../../public/assets/images/avatars/avatar-7.jpg" alt=""
                                             className="w-6 h-6 rounded-full"/>

                                        <div className="flex-1 relative overflow-hidden h-10">
                                            <textarea placeholder="Add Comment...." rows="1"
                                                      className="w-full resize-none !bg-transparent px-4 py-2 focus:!border-transparent focus:!ring-transparent"></textarea>

                                            <div className="!top-2 pr-2" uk-drop="pos: bottom-right; mode: click">
                                                <div className="flex items-center gap-2"
                                                     uk-scrollspy="target: > svg; cls: uk-animation-slide-right-small; delay: 100 ;repeat: true">
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
                                                         fill="currentColor" className="w-6 h-6 fill-sky-600">
                                                        <path fill-rule="evenodd"
                                                              d="M1.5 6a2.25 2.25 0 012.25-2.25h16.5A2.25 2.25 0 0122.5 6v12a2.25 2.25 0 01-2.25 2.25H3.75A2.25 2.25 0 011.5 18V6zM3 16.06V18c0 .414.336.75.75.75h16.5A.75.75 0 0021 18v-1.94l-2.69-2.689a1.5 1.5 0 00-2.12 0l-.88.879.97.97a.75.75 0 11-1.06 1.06l-5.16-5.159a1.5 1.5 0 00-2.12 0L3 16.061zm10.125-7.81a1.125 1.125 0 112.25 0 1.125 1.125 0 01-2.25 0z"
                                                              clip-rule="evenodd"/>
                                                    </svg>
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"
                                                         fill="currentColor" className="w-5 h-5 fill-pink-600">
                                                        <path
                                                            d="M3.25 4A2.25 2.25 0 001 6.25v7.5A2.25 2.25 0 003.25 16h7.5A2.25 2.25 0 0013 13.75v-7.5A2.25 2.25 0 0010.75 4h-7.5zM19 4.75a.75.75 0 00-1.28-.53l-3 3a.75.75 0 00-.22.53v4.5c0 .199.079.39.22.53l3 3a.75.75 0 001.28-.53V4.75z"/>
                                                    </svg>
                                                </div>
                                            </div>


                                        </div>


                                        <button type="submit"
                                                className="text-sm rounded-full py-1.5 px-3.5 bg-secondery"> Replay
                                        </button>
                                    </div>

                                </div>

                                {/*  post image with slider*/}
                                <div
                                    className="bg-white rounded-xl shadow-sm text-sm font-medium border1 dark:bg-dark2">

                                    {/* post heading */}
                                    <div className="flex gap-3 sm:p-4 p-2.5 text-sm font-medium">
                                        <a href="../Profile/profile.html"> <img
                                            src="../../../public/assets/images/avatars/avatar-3.jpg" alt=""
                                            className="w-9 h-9 rounded-full"/> </a>
                                        <div className="flex-1">
                                            <a href="../Profile/profile.html"><h4
                                                className="text-black dark:text-white"> Monroe Parker </h4></a>
                                            <div className="text-xs text-gray-500 dark:text-white/80"> 2 hours ago</div>
                                        </div>

                                        <div className="-mr-1">
                                            <button type="button" className="button-icon w-8 h-8">
                                                <ion-icon className="text-xl" name="ellipsis-horizontal"></ion-icon>
                                            </button>
                                            <div className="w-[245px]"
                                                 uk-dropdown="pos: bottom-right; animation: uk-animation-scale-up uk-transform-origin-top-right; animate-out: true; mode: click">
                                                <nav>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="bookmark-outline"></ion-icon>
                                                        Add to favorites </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="notifications-off-outline"></ion-icon>
                                                        Mute Notification </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="flag-outline"></ion-icon>
                                                        Report this post </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="share-outline"></ion-icon>
                                                        Share your profile </a>
                                                    <hr/>
                                                    <a href="#"
                                                       className="text-red-400 hover:!bg-red-50 dark:hover:!bg-red-500/50">
                                                        <ion-icon className="text-xl shrink-0"
                                                                  name="stop-circle-outline"></ion-icon>
                                                        Unfollow </a>
                                                </nav>
                                            </div>
                                        </div>
                                    </div>

                                    {/* post image */}
                                    <div className="relative uk-visible-toggle sm:px-4" tabIndex="-1"
                                         uk-slideshow="animation: push;ratio: 4:3">

                                        <ul className="uk-slideshow-items overflow-hidden rounded-xl"
                                            uk-lightbox="animation: fade">
                                            <li className="w-full">
                                                <a className="inline" href="https://getuikit.com/docs/images/photo3.jpg"
                                                   data-caption="Caption 1">
                                                    <img src="../../../public/assets/images/post/img-2.jpg" alt=""
                                                         className="w-full h-full absolute object-cover insta-0"/>
                                                </a>
                                            </li>
                                            <li className="w-full">
                                                <a className="inline" href="https://getuikit.com/docs/images/photo2.jpg"
                                                   data-caption="Caption 2">
                                                    <img src="../../../public/assets/images/post/img-3.jpg" alt=""
                                                         className="w-full h-full absolute object-cover insta-0"/>
                                                </a>
                                            </li>
                                            <li className="w-full">
                                                <a className="inline" href="https://getuikit.com/docs/images/photo.jpg"
                                                   data-caption="Caption 3">
                                                    <img src="../../../public/assets/images/post/img-4.jpg" alt=""
                                                         className="w-full h-full absolute object-cover insta-0"/>
                                                </a>
                                            </li>
                                        </ul>

                                        <a className="nav-prev left-6" href="#" uk-slideshow-item="previous">
                                            <ion-icon name="chevron-back" className="text-2xl"></ion-icon>
                                        </a>
                                        <a className="nav-next right-6" href="#" uk-slideshow-item="next">
                                            <ion-icon name="chevron-forward" className="text-2xl"></ion-icon>
                                        </a>

                                    </div>

                                    {/* post icons */}
                                    <div className="sm:p-4 p-2.5 flex items-center gap-4 text-xs font-semibold">
                                        <div>
                                            <div className="flex items-center gap-2.5">
                                                <button type="button"
                                                        className="button-icon text-red-500 bg-red-100 dark:bg-slate-700">
                                                    <ion-icon className="text-lg" name="heart"></ion-icon>
                                                </button>
                                                <a href="#">1,300</a>
                                            </div>
                                            <div
                                                className="p-1 px-2 bg-white rounded-full drop-shadow-md w-[212px] dark:bg-slate-700 text-2xl"
                                                uk-drop="offset:10;pos: top-left; animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-left">

                                                <div className="flex gap-2"
                                                     uk-scrollspy="target: > button; cls: uk-animation-scale-up; delay: 100 ;repeat: true">
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 👍 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> ❤️ </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😂 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😯 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😢 </span></button>
                                                </div>

                                                <div
                                                    className="w-2.5 h-2.5 absolute -bottom-1 left-3 bg-white rotate-45 hidden"></div>
                                            </div>
                                        </div>
                                        <div className="flex items-center gap-3">
                                            <button type="button"
                                                    className="button-icon bg-slate-200/70 dark:bg-slate-700">
                                                <ion-icon className="text-lg" name="chatbubble-ellipses"></ion-icon>
                                            </button>
                                            <span>260</span>
                                        </div>
                                        <button type="button" className="button-icon ml-auto">
                                            <ion-icon className="text-xl" name="paper-plane-outline"></ion-icon>
                                        </button>
                                        <button type="button" className="button-icon">
                                            <ion-icon className="text-xl" name="share-outline"></ion-icon>
                                        </button>
                                    </div>

                                    {/* comments */}
                                    <div
                                        className="sm:p-4 p-2.5 border-t border-gray-100 font-normal space-y-3 relative dark:border-slate-700/40">

                                        <div className="flex items-start gap-3 relative">
                                            <a href="../Profile/profile.html"> <img
                                                src="../../../public/assets/images/avatars/avatar-2.jpg" alt=""
                                                className="w-6 h-6 mt-1 rounded-full"/> </a>
                                            <div className="flex-1">
                                                <a href="../Profile/profile.html"
                                                   className="text-black font-medium inline-block dark:text-white"> Steeve </a>
                                                <p className="mt-0.5">What a beautiful photo! I love it. 😍 </p>
                                            </div>
                                        </div>
                                        <div className="flex items-start gap-3 relative">
                                            <a href="../Profile/profile.html"> <img
                                                src="../../../public/assets/images/avatars/avatar-3.jpg" alt=""
                                                className="w-6 h-6 mt-1 rounded-full"/> </a>
                                            <div className="flex-1">
                                                <a href="../Profile/profile.html"
                                                   className="text-black font-medium inline-block dark:text-white"> Monroe </a>
                                                <p className="mt-0.5"> You captured the moment.😎 </p>
                                            </div>
                                        </div>

                                        <button type="button"
                                                className="flex items-center gap-1.5 text-gray-500 hover:text-blue-500 mt-2">
                                            <ion-icon name="chevron-down-outline"
                                                      className="ml-auto duration-200 group-aria-expanded:rotate-180"></ion-icon>
                                            More Comment
                                        </button>

                                    </div>

                                    {/* add comment */}
                                    <div
                                        className="sm:px-4 sm:py-3 p-2.5 border-t border-gray-100 flex items-center gap-1 dark:border-slate-700/40">

                                        <img src="../../../public/assets/images/avatars/avatar-7.jpg" alt=""
                                             className="w-6 h-6 rounded-full"/>

                                        <div className="flex-1 relative overflow-hidden h-10">
                                            <textarea placeholder="Add Comment...." rows="1"
                                                      className="w-full resize-none !bg-transparent px-4 py-2 focus:!border-transparent focus:!ring-transparent"></textarea>

                                            <div className="!top-2 pr-2" uk-drop="pos: bottom-right; mode: click">
                                                <div className="flex items-center gap-2"
                                                     uk-scrollspy="target: > svg; cls: uk-animation-slide-right-small; delay: 100 ;repeat: true">
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
                                                         fill="currentColor" className="w-6 h-6 fill-sky-600">
                                                        <path fill-rule="evenodd"
                                                              d="M1.5 6a2.25 2.25 0 012.25-2.25h16.5A2.25 2.25 0 0122.5 6v12a2.25 2.25 0 01-2.25 2.25H3.75A2.25 2.25 0 011.5 18V6zM3 16.06V18c0 .414.336.75.75.75h16.5A.75.75 0 0021 18v-1.94l-2.69-2.689a1.5 1.5 0 00-2.12 0l-.88.879.97.97a.75.75 0 11-1.06 1.06l-5.16-5.159a1.5 1.5 0 00-2.12 0L3 16.061zm10.125-7.81a1.125 1.125 0 112.25 0 1.125 1.125 0 01-2.25 0z"
                                                              clip-rule="evenodd"/>
                                                    </svg>
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"
                                                         fill="currentColor" className="w-5 h-5 fill-pink-600">
                                                        <path
                                                            d="M3.25 4A2.25 2.25 0 001 6.25v7.5A2.25 2.25 0 003.25 16h7.5A2.25 2.25 0 0013 13.75v-7.5A2.25 2.25 0 0010.75 4h-7.5zM19 4.75a.75.75 0 00-1.28-.53l-3 3a.75.75 0 00-.22.53v4.5c0 .199.079.39.22.53l3 3a.75.75 0 001.28-.53V4.75z"/>
                                                    </svg>
                                                </div>
                                            </div>


                                        </div>


                                        <button type="submit"
                                                className="text-sm rounded-full py-1.5 px-3.5 bg-secondery"> Replay
                                        </button>
                                    </div>

                                </div>

                                {/* post text*/}
                                <div
                                    className="bg-white rounded-xl shadow-sm text-sm font-medium border1 dark:bg-dark2">

                                    {/* post heading */}
                                    <div className="flex gap-3 sm:p-4 p-2.5 text-sm font-medium">
                                        <a href="../Profile/profile.html"> <img
                                            src="../../../public/assets/images/avatars/avatar-5.jpg" alt=""
                                            className="w-9 h-9 rounded-full"/> </a>
                                        <div className="flex-1">
                                            <a href="../Profile/profile.html"><h4
                                                className="text-black dark:text-white"> John Michael </h4></a>
                                            <div className="text-xs text-gray-500 dark:text-white/80"> 2 hours ago</div>
                                        </div>

                                        <div className="-mr-1">
                                            <button type="button" className="button__ico w-8 h-8" aria-haspopup="true"
                                                    aria-expanded="false">
                                                <ion-icon className="text-xl md hydrated" name="ellipsis-horizontal"
                                                          role="img" aria-label="ellipsis horizontal"></ion-icon>
                                            </button>
                                            <div className="w-[245px] uk-dropdown"
                                                 uk-dropdown="pos: bottom-right; animation: uk-animation-scale-up uk-transform-origin-top-right; animate-out: true; mode: click">
                                                <nav>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0 md hydrated"
                                                                  name="bookmark-outline" role="img"
                                                                  aria-label="bookmark outline"></ion-icon>
                                                        Add to favorites </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0 md hydrated"
                                                                  name="notifications-off-outline" role="img"
                                                                  aria-label="notifications off outline"></ion-icon>
                                                        Mute Notification </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0 md hydrated"
                                                                  name="flag-outline" role="img"
                                                                  aria-label="flag outline"></ion-icon>
                                                        Report this post </a>
                                                    <a href="#">
                                                        <ion-icon className="text-xl shrink-0 md hydrated"
                                                                  name="share-outline" role="img"
                                                                  aria-label="share outline"></ion-icon>
                                                        Share your profile </a>
                                                    <hr/>
                                                    <a href="#"
                                                       className="text-red-400 hover:!bg-red-50 dark:hover:!bg-red-500/50">
                                                        <ion-icon className="text-xl shrink-0 md hydrated"
                                                                  name="stop-circle-outline" role="img"
                                                                  aria-label="stop circle outline"></ion-icon>
                                                        Unfollow </a>
                                                </nav>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="sm:px-4 p-2.5 pt-0">
                                        <p className="font-normal"> Photography is the art of capturing light with a
                                            camera. It can be used to create images that tell stories, express emotions,
                                            or document reality. it can be fun, challenging, or rewarding. It can also
                                            be a hobby, a profession, or a passion. 📷 </p>
                                    </div>

                                    {/* post icons */}
                                    <div className="sm:p-4 p-2.5 flex items-center gap-4 text-xs font-semibold">
                                        <div>
                                            <div className="flex items-center gap-2.5">
                                                <button type="button"
                                                        className="button-icon text-red-500 bg-red-100 dark:bg-slate-700">
                                                    <ion-icon className="text-lg" name="heart"></ion-icon>
                                                </button>
                                                <a href="#">1,300</a>
                                            </div>
                                            <div
                                                className="p-1 px-2 bg-white rounded-full drop-shadow-md w-[212px] dark:bg-slate-700 text-2xl"
                                                uk-drop="offset:10;pos: top-left; animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-left">

                                                <div className="flex gap-2"
                                                     uk-scrollspy="target: > button; cls: uk-animation-scale-up; delay: 100 ;repeat: true">
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 👍 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> ❤️ </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😂 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😯 </span></button>
                                                    <button type="button"
                                                            className="text-red-600 hover:scale-125 duration-300">
                                                        <span> 😢 </span></button>
                                                </div>

                                                <div
                                                    className="w-2.5 h-2.5 absolute -bottom-1 left-3 bg-white rotate-45 hidden"></div>
                                            </div>
                                        </div>
                                        <div className="flex items-center gap-3">
                                            <button type="button"
                                                    className="button-icon bg-slate-200/70 dark:bg-slate-700">
                                                <ion-icon className="text-lg" name="chatbubble-ellipses"></ion-icon>
                                            </button>
                                            <span>260</span>
                                        </div>
                                        <button type="button" className="button-icon ml-auto">
                                            <ion-icon className="text-xl" name="paper-plane-outline"></ion-icon>
                                        </button>
                                        <button type="button" className="button-icon">
                                            <ion-icon className="text-xl" name="share-outline"></ion-icon>
                                        </button>
                                    </div>

                                    {/* comments */}
                                    <div
                                        className="sm:p-4 p-2.5 border-t border-gray-100 font-normal space-y-3 relative dark:border-slate-700/40">

                                        <div className="flex items-start gap-3 relative">
                                            <a href="../Profile/profile.html"> <img
                                                src="../../../public/assets/images/avatars/avatar-2.jpg" alt=""
                                                className="w-6 h-6 mt-1 rounded-full"/> </a>
                                            <div className="flex-1">
                                                <a href="../Profile/profile.html"
                                                   className="text-black font-medium inline-block dark:text-white"> Steeve </a>
                                                <p className="mt-0.5"> I love taking photos of nature and animals.
                                                    🌳🐶</p>
                                            </div>
                                        </div>

                                    </div>

                                    {/* add comment */}
                                    <div
                                        className="sm:px-4 sm:py-3 p-2.5 border-t border-gray-100 flex items-center gap-1 dark:border-slate-700/40">

                                        <img src="../../../public/assets/images/avatars/avatar-7.jpg" alt=""
                                             className="w-6 h-6 rounded-full"/>

                                        <div className="flex-1 relative overflow-hidden h-10">
                                            <textarea placeholder="Add Comment...." rows="1"
                                                      className="w-full resize-none !bg-transparent px-4 py-2 focus:!border-transparent focus:!ring-transparent"
                                                      aria-haspopup="true" aria-expanded="false"></textarea>

                                            <div className="!top-2 pr-2 uk-drop"
                                                 uk-drop="pos: bottom-right; mode: click">
                                                <div className="flex items-center gap-2"
                                                     uk-scrollspy="target: > svg; cls: uk-animation-slide-right-small; delay: 100 ;repeat: true">
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
                                                         fill="currentColor" className="w-6 h-6 fill-sky-600">
                                                        <path fill-rule="evenodd"
                                                              d="M1.5 6a2.25 2.25 0 012.25-2.25h16.5A2.25 2.25 0 0122.5 6v12a2.25 2.25 0 01-2.25 2.25H3.75A2.25 2.25 0 011.5 18V6zM3 16.06V18c0 .414.336.75.75.75h16.5A.75.75 0 0021 18v-1.94l-2.69-2.689a1.5 1.5 0 00-2.12 0l-.88.879.97.97a.75.75 0 11-1.06 1.06l-5.16-5.159a1.5 1.5 0 00-2.12 0L3 16.061zm10.125-7.81a1.125 1.125 0 112.25 0 1.125 1.125 0 01-2.25 0z"
                                                              clip-rule="evenodd"></path>
                                                    </svg>
                                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"
                                                         fill="currentColor" className="w-5 h-5 fill-pink-600">
                                                        <path
                                                            d="M3.25 4A2.25 2.25 0 001 6.25v7.5A2.25 2.25 0 003.25 16h7.5A2.25 2.25 0 0013 13.75v-7.5A2.25 2.25 0 0010.75 4h-7.5zM19 4.75a.75.75 0 00-1.28-.53l-3 3a.75.75 0 00-.22.53v4.5c0 .199.079.39.22.53l3 3a.75.75 0 001.28-.53V4.75z"></path>
                                                    </svg>
                                                </div>
                                            </div>


                                        </div>


                                        <button type="submit"
                                                className="text-sm rounded-full py-1.5 px-3.5 bg-secondery"> Replay
                                        </button>
                                    </div>

                                </div>

                                {/* placeholder */}
                                <div
                                    className="rounded-xl shadow-sm p-4 space-y-4 bg-slate-200/40 animate-pulse border1 dark:bg-dark2">

                                    <div className="flex gap-3">
                                        <div className="w-9 h-9 rounded-full bg-slate-300/20"></div>
                                        <div className="flex-1 space-y-3">
                                            <div className="w-40 h-5 rounded-md bg-slate-300/20"></div>
                                            <div className="w-24 h-4 rounded-md bg-slate-300/20"></div>
                                        </div>
                                        <div className="w-6 h-6 rounded-full bg-slate-300/20"></div>
                                    </div>

                                    <div className="w-full h-52 rounded-lg bg-slate-300/10 my-3"></div>

                                    <div className="flex gap-3">

                                        <div className="w-16 h-5 rounded-md bg-slate-300/20"></div>

                                        <div className="w-14 h-5 rounded-md bg-slate-300/20"></div>

                                        <div className="w-6 h-6 rounded-full bg-slate-300/20 ml-auto"></div>
                                        <div className="w-6 h-6 rounded-full bg-slate-300/20  "></div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>


            {/* open chat box */}
            <div>
                <button type="button"
                        className="sm:m-10 m-5 px-4 py-2.5 rounded-2xl bg-gradient-to-tr from-blue-500 to-blue-700 text-white shadow fixed bottom-0 right-0 group flex items-center gap-2">

                    <svg className="w-6 h-6 group-aria-expanded:hidden duration-500" xmlns="http://www.w3.org/2000/svg"
                         fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
                        <path stroke-linecap="round" stroke-linejoin="round"
                              d="M7.5 8.25h9m-9 3H12m-9.75 1.51c0 1.6 1.123 2.994 2.707 3.227 1.129.166 2.27.293 3.423.379.35.026.67.21.865.501L12 21l2.755-4.133a1.14 1.14 0 01.865-.501 48.172 48.172 0 003.423-.379c1.584-.233 2.707-1.626 2.707-3.228V6.741c0-1.602-1.123-2.995-2.707-3.228A48.394 48.394 0 0012 3c-2.392 0-4.744.175-7.043.513C3.373 3.746 2.25 5.14 2.25 6.741v6.018z"></path>
                    </svg>

                    <div className="text-base font-semibold max-sm:hidden"> Chat</div>

                    <svg className="w-6 h-6 -mr-1 hidden group-aria-expanded:block" xmlns="http://www.w3.org/2000/svg"
                         viewBox="0 0 24 24" fill="currentColor">
                        <path fill-rule="evenodd"
                              d="M5.47 5.47a.75.75 0 011.06 0L12 10.94l5.47-5.47a.75.75 0 111.06 1.06L13.06 12l5.47 5.47a.75.75 0 11-1.06 1.06L12 13.06l-5.47 5.47a.75.75 0 01-1.06-1.06L10.94 12 5.47 6.53a.75.75 0 010-1.06z"
                              clip-rule="evenodd"/>
                    </svg>

                </button>
                <div
                    className="bg-white rounded-xl drop-shadow-xl  sm:w-80 w-screen border-t dark:bg-dark3 dark:border-slate-600"
                    id="chat__box"
                    uk-drop="offset:10;pos: bottom-right; animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-right; mode: click">

                    <div className="relative">
                        <div className="p-5">
                            <h1 className="text-lg font-bold text-black"> Chats </h1>
                        </div>

                        {/* search input defaul is hidden */}
                        <div
                            className="bg-white p-3 absolute w-full top-11 border-b flex gap-2 hidden dark:border-slate-600 dark:bg-slate-700 z-10"
                            uk-scrollspy="cls:uk-animation-slide-bottom-small ; repeat: true; duration:0"
                            id="search__chat">

                            <div className="relative w-full">
                                <input type="text" className="w-full rounded-3xl dark:!bg-white/10"
                                       placeholder="Search"/>

                                <button type="button"
                                        className="absolute  right-0  rounded-full shrink-0 px-2 -translate-y-1/2 top-1/2"
                                        uk-toggle="target: #search__chat ; cls: hidden">

                                    <ion-icon name="close-outline" className="text-xl flex"></ion-icon>
                                </button>
                            </div>

                        </div>

                        {/* button actions */}
                        <div className="absolute top-0 -right-1 m-5 flex gap-2 text-xl">
                            <button uk-toggle="target: #search__chat ; cls: hidden">
                                <ion-icon name="search-outline"></ion-icon>
                            </button>
                            <button uk-toggle="target: #chat__box ; cls: uk-open">
                                <ion-icon name="close-outline"></ion-icon>
                            </button>
                        </div>

                        {/* tab 2 optional */}
                        <div
                            className="grid grid-cols-2 px-3 py-2 bg-slate-50  -mt-12 relative z-10 text-sm border-b  hidden"
                            uk-switcher="connect: #chat__tabs; toggle: * > button ; animation: uk-animation-slide-right uk-animation-slide-top">
                            <button className="bg-white shadow rounded-md py-1.5"> Friends</button>
                        </div>

                        {/* chat list */}
                        <div className="uk-switcher overflow-hidden rounded-xl -mt-8" id="chat__tabs">
                            {/* tab list 1 */}
                            <div className="space-y -m t-5 p-3 text-sm font-medium h-[280px] overflow-y-auto">
                                <a href="#" className="block">
                                    <div
                                        className="flex items-center gap-3.5 rounded-lg p-2 hover:bg-secondery dark:hover:bg-white/10">
                                        <img src="../../../public/assets/images/avatars/avatar-1.jpg" alt=""
                                             className="w-7 rounded-full"/>
                                        <div> Jesse Steeve</div>
                                    </div>
                                </a>
                            </div>
                        </div>

                    </div>

                    <div className="w-3.5 h-3.5 absolute -bottom-2 right-5 bg-white rotate-45 dark:bg-dark3"></div>
                </div>
            </div>

            {/* post preview modal */}
            <div className="hidden lg:p-20 max-lg:!items-start" id="preview_modal" uk-modal="">

                <div
                    className="uk-modal-dialog tt relative mx-auto overflow-hidden shadow-xl rounded-lg lg:flex items-center ax-w-[86rem] w-full lg:h-[80vh]">

                    {/* image previewer */}
                    <div className="lg:h-full w-full h-96 flex justify-center items-center relative">
                        <div className="relative z-10 w-full h-full">
                            <img src="../../../public/assets/images/post/post-1.jpg" alt=""
                                 className="w-full h-full object-cover absolute"/>
                        </div>
                        {/* close button */}
                        <button type="button"
                                className="bg-white rounded-full p-2 absolute right-0 top-0 m-3 uk-animation-slide-right-medium z-10 dark:bg-slate-600 uk-modal-close">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                 stroke="currentColor" className="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"/>
                            </svg>
                        </button>
                    </div>
                </div>

            </div>

            {/* create status */}
            <div className="hidden lg:p-20 uk- open" id="create-status" uk-modal="">

                <div
                    className="uk-modal-dialog tt relative overflow-hidden mx-auto bg-white shadow-xl rounded-lg md:w-[520px] w-full dark:bg-dark2">

                    <div className="text-center py-4 border-b mb-0 dark:border-slate-700">
                        <h2 className="text-sm font-medium text-black"> Create Status </h2>

                        {/* close button */}
                        <button type="button" className="button-icon absolute top-0 right-0 m-2.5 uk-modal-close">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                 stroke="currentColor" className="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"/>
                            </svg>
                        </button>

                    </div>

                    <div className="space-y-5 mt-3 p-2">
                        <textarea
                            className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800"
                            name="" id="" rows="6" placeholder="What do you have in mind?"></textarea>
                    </div>

                    <div className="flex items-center gap-2 text-sm py-2 px-4 font-medium flex-wrap">
                        <button type="button"
                                className="flex items-center gap-1.5 bg-sky-50 text-sky-600 rounded-full py-1 px-2 border-2 border-sky-100 dark:bg-sky-950 dark:border-sky-900">
                            <ion-icon name="image" className="text-base"></ion-icon>
                            Image
                        </button>
                    </div>

                    <div className="p-5 flex justify-between items-center">
                        <div className="flex items-center gap-2">
                            <button type="button"
                                    className="button bg-blue-500 text-white py-2 px-12 text-[14px]">Create
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            {/* create story */}
            <div className="hidden lg:p-20" id="create-story" uk-modal="">

                <div
                    className="uk-modal-dialog tt relative overflow-hidden mx-auto bg-white p-7 shadow-xl rounded-lg md:w-[520px] w-full dark:bg-dark2">

                    <div className="text-center py-3 border-b -m-7 mb-0 dark:border-slate-700">
                        <h2 className="text-sm font-medium"> Create Status </h2>

                        {/* close button */}
                        <button type="button" className="button__ico absolute top-0 right-0 m-2.5 uk-modal-close">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                 stroke="currentColor" className="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"/>
                            </svg>
                        </button>

                    </div>

                    <div className="space-y-5 mt-7">

                        <div>
                            <label htmlFor="" className="text-base">What do you have in mind? </label>
                            <input type="text" className="w-full mt-3"/>
                        </div>

                        <div>
                            <div
                                className="w-full h-72 relative border1 rounded-lg overflow-hidden bg-[url('../images/ad_pattern.png')] bg-repeat">

                                <label htmlFor="createStatusUrl"
                                       className="flex flex-col justify-center items-center absolute -translate-x-1/2 left-1/2 bottom-0 z-10 w-full pb-6 pt-10 cursor-pointer bg-gradient-to-t from-gray-700/60">
                                    <input id="createStatusUrl" type="file" className="hidden"/>
                                    <ion-icon name="image" className="text-3xl text-teal-600"></ion-icon>
                                    <span className="text-white mt-2">Browse to Upload image </span>
                                </label>

                                <img id="createStatusImage" src="#" alt="Uploaded Image" accept="image/png, image/jpeg"
                                     className="w-full h-full absolute object-cover"/>

                            </div>

                        </div>

                        <div className="flex justify-between items-center">

                            <div className="flex items-start gap-2">
                                <ion-icon name="time-outline"
                                          className="text-3xl text-sky-600  rounded-full bg-blue-50 dark:bg-transparent"></ion-icon>
                                <p className="text-sm text-gray-500 font-medium"> Your Status will be
                                    available <br/> for <span className="text-gray-800"> 24 Hours</span></p>
                            </div>

                            <button type="button" className="button bg-blue-500 text-white px-8"> Create</button>

                        </div>

                    </div>

                </div>

            </div>
        </>
    )
}