import {profile} from "../../Constants/PagePaths";
import {useEffect, useState} from "react";
import DownloadFile from "../../Api/StaticFiles/DownloadFile";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import Comment from "./Comment";
import "../Styles/componentStyles.css"
import RemovePost from "../../Api/Posts/RemovePost";
import {ParseDateForPost} from "../../CommonServices/DateParser";
import AddComment from "../../Api/Comments/AddComment";
import GetComment from "../../Api/Comments/GetComments";

function Post({postData, isCurrentUser, currentUserInfo}){
    const [avatar, setAvatar] = useState('')
    const [postFiles, setPostFiles] = useState([])
    const [comments, setComments] = useState([])

    async function loadImages(){
        if (postData?.owner?.avatar?.fileId)
        {
            const result = await DownloadFile(postData?.owner?.avatar?.fileId)
            setAvatar(result)
        }
        if (postData?.files?.length > 0)
            for (let i = 0; i < postData?.files?.length; i++){
                const result = await DownloadFile(postData.files[i].fileId)
                setPostFiles((files) => [...files, result])
            }
    }

    async function removePost(){
        const result = await RemovePost(postData.postId)
        if (result)
            // eslint-disable-next-line no-restricted-globals
            location.reload()
    }

    async function loadComments(){
        const result = await GetComment(postData.postId)
        if (result){
            setComments(result?.data?.items)
        }
    }

    async function onCommendAdd(){
        const text = document.getElementById("post_comment_area").value
        const result = await AddComment({
            text: text,
            postId: postData.postId
        })
       if (result){
           document.getElementById("post_comment_area").value = ""
           await loadComments()
       }

    }

    useEffect(() => {
        loadImages().then()
        loadComments().then()
    }, []);

    return (
        <>
            <div
                className="bg-white rounded-xl shadow-sm text-sm font-medium border1 dark:bg-dark15">

                {/* post heading */}
                <div className="flex gap-3 sm:p-4 p-2.5 text-sm font-medium">
                    <a href={isCurrentUser ? profile : `${profile}/${postData?.owner?.userId}`}> <img
                        src={avatar ? avatar : SmallAvatar} alt=""
                        className="w-9 h-9 rounded-full"/> </a>
                    <div className="flex-1">
                        <a href={isCurrentUser ? profile : `${profile}/${postData?.owner?.userId}`}><h4
                            className="text-black dark:text-white"> {postData?.owner?.firstName} {postData?.owner?.lastName}</h4>
                        </a>
                        <div
                            className="mt-0.5 text-xs text-gray-500 dark:text-white/60"> {ParseDateForPost(postData.createDate)}</div>
                    </div>

                    {isCurrentUser
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
                                        Удалить
                                    </a>
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
                    <p className="font-normal text-lg text-gray-300"> {postData.description} </p>
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
                                postData.likesCount > 0
                                    ? <a href="#">{postData.likesCount}</a>
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
                            postData.commentsCount > 0
                                ? <span>{postData.commentsCount}</span>
                                : <></>
                        }
                    </div>
                    <button type="button" className="button-icon ml-auto">
                        <ion-icon className="text-xl" name="share-outline"></ion-icon>
                    </button>
                </div>

                {comments && comments.length > 0
                    ? <div
                        className="sm:p-4 p-2.5 border-t border-gray-100 font-normal space-y-3 relative dark:border-slate-700/40">

                        {comments.map(x => <Comment commentData={x}/>)}

                        {comments.length > 3
                            ? <button type="button"
                                      className="flex items-center gap-1.5 text-gray-500 hover:text-blue-500 mt-2">
                                <ion-icon name="chevron-down-outline"
                                          className="ml-auto duration-200 group-aria-expanded:rotate-180"></ion-icon>
                                More Comment
                            </button>
                            : <></>}


                    </div>
                    : <></>
                }


                {/* add comment */}
                <div
                    className="sm:px-4 sm:py-3 p-2.5 border-t border-gray-100 flex items-center gap-1 dark:border-slate-700/40">

                    <img src={
                        !isCurrentUser
                            ? currentUserInfo?.avatar ? currentUserInfo?.avatar : SmallAvatar
                            : avatar ? avatar : SmallAvatar} alt=""
                         className="w-6 h-6 rounded-full"/>

                    <div className="flex-1 relative overflow-hidden h-10">
                                            <input type="text" placeholder="Ваш комментарий..."
                                                      id="post_comment_area"
                                                      className="w-full resize-none !bg-transparent px-4 py-2 focus:!border-transparent focus:!ring-transparent"></input>

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
                            onClick={onCommendAdd}
                            className="text-sm rounded-full py-1.5 px-3.5 bg-secondery"> Отправить
                    </button>
                </div>

            </div>
        </>
    )
}


export default Post;