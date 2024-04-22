import ParseDateForPost from "../../CommonServices/DateParser";
import {profile} from "../../Constants/PagePaths";
import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import Comment from "./Comment";
import "../Styles/componentStyles.css"
import RemovePost from "../../Api/Posts/RemovePost";

function Post(postData, currentUser){
    const [avatar, setAvatar] = useState('')
    const [postFiles, setPostFiles] = useState([])
    const data = postData.postData

    async function loadImages(){
        if (data?.owner?.avatar?.fileId)
        {
            const result = await DownloadFile(data?.owner?.avatar?.fileId)
            setAvatar(result)
        }
        if (data?.files?.length > 0)
            for (let i = 0; i < data?.files?.length; i++){
                const result = await DownloadFile(data.files[i].fileId)
                setPostFiles((files) => [...files, result])
            }
    }

    async function removePost(){
        const result = await RemovePost(data.postId)
        if (result)
            // eslint-disable-next-line no-restricted-globals
            location.reload()
    }

    useEffect(() => {
        loadImages()
    }, []);

    return (
        <>
            <div
                className="bg-white rounded-xl shadow-sm text-sm font-medium border1 dark:bg-dark15">

                {/* post heading */}
                <div className="flex gap-3 sm:p-4 p-2.5 text-sm font-medium">
                    <a href={profile}> <img
                        src={avatar ? avatar : SmallAvatar} alt=""
                        className="w-9 h-9 rounded-full"/> </a>
                    <div className="flex-1">
                        <a href={profile}><h4
                            className="text-black dark:text-white"> {data?.owner?.firstName} {data?.owner?.lastName} </h4>
                        </a>
                        <div
                            className="mt-0.5 text-xs text-gray-500 dark:text-white/60"> {ParseDateForPost(data.createDate)}</div>
                    </div>

                    {currentUser
                        ? <div className="-mr-1">
                            <button type="button" className="button-icon w-8 h-8">
                                <ion-icon className="text-xl" name="ellipsis-horizontal"></ion-icon>
                            </button>
                            <div className="w-[245px]"
                                 uk-dropdown="pos: bottom-right; animation: uk-animation-scale-up uk-transform-origin-top-right; animate-out: true; mode: click">
                                <nav>
                                    <a href="#"
                                       onClick={removePost}
                                       className="text-red-400 hover:!bg-red-50 dark:hover:!bg-red-500/50">
                                        <ion-icon className="text-xl shrink-0"
                                                  name="stop-circle-outline"></ion-icon>
                                        Удалить </a>
                                </nav>
                            </div>
                        </div>
                    : <></>}

                </div>

                {/* post image */}


                {postFiles.length > 1
                    ? <div className="relative uk-visible-toggle sm:px-4 slider-images" tabIndex="-1"
                           uk-slideshow="animation: push;ratio: 4:3">

                        <ul className="uk-slideshow-items overflow-hidden rounded-xl" uk-lightbox="animation: fade">
                            {postFiles.map(x => {
                                console.log(postFiles)
                                return (
                                    <>
                                        <li className="w-full">
                                            <img src={x} alt=""
                                                 className="w-full h-full absolute object-cover insta-0"/>
                                        </li>
                                    </>
                                )
                            })}
                        </ul>

                        <a className="nav-button nav-prev left-6" href="#" uk-slideshow-item="previous">
                            <ion-icon name="chevron-back" className="text-2xl"></ion-icon>
                        </a>
                        <a className="nav-button nav-next right-6" href="#" uk-slideshow-item="next">
                            <ion-icon name="chevron-forward" className="text-2xl"></ion-icon>
                        </a>
                    </div>

                    : postFiles.length === 1
                        ? <div className="relative w-full lg:h-96 h-full sm:px-4">
                            <img src={postFiles[0]} alt="" className="sm:rounded-lg w-full h-full object-cover"/>
                        </div>
                        : <></>
                }

                <div className="mt-3 ml-2 sm:px-4 p-2.5 pt-0">
                    <p className="font-normal text-lg text-gray-300"> {data.description} </p>
                </div>


                {/* post icons */}
                <div className="sm:p-4 p-2.5 flex items-center gap-4 text-xs font-semibold">
                    <div>
                        <div className="flex items-center gap-2.5">
                            <button type="button"
                                    className="button-icon text-red-500 bg-red-100 dark:bg-slate-700">
                                <ion-icon className="text-lg" name="heart"></ion-icon>
                            </button>
                            {
                                data.likesCount > 0
                                    ? <a href="#">{data.likesCount}</a>
                                    : <></>
                            }
                        </div>

                    </div>
                    <div className="flex items-center gap-3">
                        <button type="button"
                                className="button-icon bg-slate-200/70 dark:bg-slate-700">
                            <ion-icon className="text-lg" name="chatbubble-ellipses"></ion-icon>
                        </button>
                        {
                            data.commentsCount > 0
                                ? <span>{data.commentsCount}</span>
                                : <></>
                        }
                        <span>{data.commentsCount > 0 ? data.commentsCount : ""}</span>
                    </div>
                    <button type="button" className="button-icon ml-auto">
                        <ion-icon className="text-xl" name="share-outline"></ion-icon>
                    </button>
                </div>


                {data.comments.map(x => <Comment commentData={x}/>)}

                {/* add comment */}
                <div
                    className="sm:px-4 sm:py-3 p-2.5 border-t border-gray-100 flex items-center gap-1 dark:border-slate-700/40">

                    <img src={avatar ? avatar : SmallAvatar} alt=""
                         className="w-6 h-6 rounded-full"/>

                    <div className="flex-1 relative overflow-hidden h-10">
                                            <textarea placeholder="Ваш комментарий..." rows="1"
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
                            </div>
                        </div>
                    </div>

                    <button type="submit"
                            className="text-sm rounded-full py-1.5 px-3.5 bg-secondery"> Отправить
                    </button>
                </div>

            </div>
        </>
    )
}


export default Post;