import Sidebar from "../../Components/Sidebar";
import Header from "../../Components/Header";
import {SmallAvatar} from "../../Constants/Images/Avatars";
import {useEffect, useState} from "react";
import './style/profile.css'
import UploadFile from "../../Api/StaticFiles/UploadFile";
import UpdateUserInfo from "../../Api/UserInfo/UpdateUserInfo";
import UserInfoAsync from "../../CommonServices/UserInfo";
import CreatePostByCurrentUser from "../../Api/Posts/CreatePostByCurrentUser";
import Posts from "../../Components/Posts/Posts";
import {useParams} from "react-router-dom";
import {Subscribe, Unsubscribe} from "../../Api/SubscribeSystem/Subscribe";
import ErrorToast from "../../Components/ErrorToast";
import SignalRConnection from "../../Stores/SignalRConnection";
import {observer} from "mobx-react-lite";
import GetChat from "../../Api/Chat/GetChat";
import {messages} from "../../Constants/PagePaths";
import GetFriends from "../../Api/SubscribeSystem/GetFriends";
import FriendInfo from "../../Components/Profile/FriendInfo";
import {userIdItem} from "../../Constants/LocalStorageItemKeys";
import Loader from "../../Components/Loader";

const Profile = observer(() => {
    const userId = useParams().userId
    const isCurrentUser = userId === undefined || userId === localStorage.getItem(userIdItem)
    const [userData, setUserData] = useState({});
    const [avatar, setAvatar] = useState('');
    const [postFiles, setPostFiles] = useState([])
    const [errorMessage, setErrorMessage] = useState('')
    const [showPosts, setShowPosts] = useState(true)
    const [friends, setFriends] = useState([])
    const [loading, setLoading] = useState(false);

    async function loadProfile(){
        setLoading(true)
        const result = await UserInfoAsync(userId)
        if (typeof result === 'string'){
            setErrorMessage(result)
            setLoading(false)
        }
        else {
            setUserData(result?.userData)
            setAvatar(result?.avatar)
            setLoading(false)
        }
    }

    async function uploadAvatarInServer(file){
        const response = await UploadFile([file])
        if (response?.data?.files){
            const avatarId = Object.values(response?.data?.files)[0]
            if (avatarId)
            {
                const avatarChange = await UpdateUserInfo({
                    avatarId: avatarId,
                    status: userData?.status,
                    placeOfLiving: userData?.placeOfLiving,
                    placeOfWork: userData?.placeOfWork,
                    placeOfStudy: userData?.placeOfStudy,
                    maritalStatus: userData?.maritalStatus
                })
                if (avatarChange){
                    await loadProfile()
                    // eslint-disable-next-line no-restricted-globals
                    location.reload()
                }
            }
        }
    }

    const clickOnAvatarInput = () => {
        document.getElementById('avatar-input').click()
    };

    const clickOnPostFileInput = () => {
        document.getElementById('post-file-input').click()
    };

    const pushPostFile = (file) => {
        if (file)
            setPostFiles(oldArray => [...oldArray, file])
    }

    const postFileNames = postFiles.map((x, index) => {
        return(
            <>
                <div key={index} className="post-profile-photo relative overflow-hidden rounded-2xl border-gray-100 shrink-0 shadow border-2 dark:bg-sky-950">
                    <img className="small-cropped" alt="" src={URL.createObjectURL(x)}></img>
                </div>
            </>
        )
    })

    async function onChangeStatus(){
        const text = document.getElementById('profile_status_textarea').value
        const statusChange = await UpdateUserInfo({
            avatarId: userData?.avatarId,
            status: text,
            placeOfLiving: userData?.placeOfLiving,
            placeOfWork: userData?.placeOfWork,
            placeOfStudy: userData?.placeOfStudy,
            maritalStatus: userData?.maritalStatus,
        })
        if (statusChange)
            await loadProfile()
    }

    async function onChangeIntro(){
        const introChange = await UpdateUserInfo({
            avatarId: userData?.avatarId,
            status: userData?.status,
            placeOfLiving: document.getElementById('living_place_input').value,
            placeOfWork: document.getElementById('working_place_input').value,
            placeOfStudy: document.getElementById('studying_place_input').value,
            maritalStatus: document.getElementById('marital-status-input').value === "true"
                ? userData?.maritalStatus
                : document.getElementById('marital-status-input').value,
        })
        if (introChange)
            await loadProfile()
    }

    async function onPostCreate(){
        const uploadFilesResult = await UploadFile(postFiles)
        const fileIds = postFiles.length > 0 ? Object.values(uploadFilesResult.data.files) : []

        const postCreate = await CreatePostByCurrentUser({
            description: document.getElementById('create-post-text-input').value,
            fileIds: fileIds
        })
        if (postCreate){
            await loadProfile()
            // eslint-disable-next-line no-restricted-globals
            location.reload()
        }
    }

    async function loadFriends(){
        const result = await GetFriends(userId)
        if (result){
            setFriends(result?.data?.users)
        }
    }

    async function onSubscribe(){
        const result = await Subscribe(userId)
        if (result)
            await loadProfile()
    }

    async function onUnsubscribe(){
        const result = await Unsubscribe(userId)
        if (result)
            await loadProfile()
    }

    async function joinChat() {
        const result = await GetChat(userId)
        if (result)
            window.location.href = `${messages}/${result.data.chatId}`
    }

    useEffect(() => {
        loadProfile().then()
        loadFriends().then()
        SignalRConnection.refreshConnection().then()
    }, []);

    return (
        <>
            {loading && <Loader loading={loading} /> }

            <div onClick={() => {setErrorMessage('')}}>
                <ErrorToast message={errorMessage}/>
            </div>
            <Sidebar/>
            <Header/>
            <div id="wrapper">

                {/* main contents */}
                <main id="site__main"
                      className="2xl:ml-[--w-side]  xl:ml-[--w-side-sm] p-2.5 h-[calc(100vh-var(--m-top))] mt-[--m-top]">
                    <div className="max-w-[1065px] mx-auto max-lg:-m-2.5">
                        {/* cover */}
                        <div className="bg-white shadow lg:rounded-b-2xl lg:-mt-10 dark:bg-dark15">
                            {/* cover */}
                            <div className="relative overflow-hidden w-full lg:h-72 h-48">
                                <div
                                    className="w-full bottom-0 absolute left-0 bg-gradient-to-t from-black/60 pt-20 z-10"></div>
                                <div className="absolute bottom-0 right-0 m-4 z-20">
                                    <div className="flex items-center gap-3">
                                    </div>
                                </div>
                            </div>

                            {/* user info */}
                            <div className="p-3">

                                <div className="flex flex-col justify-center md:items-center lg:-mt-48 -mt-28">

                                    <div className="relative mb-4 z-10">
                                        <div
                                            className="relative overflow-hidden rounded-full md:border-[6px] border-gray-100 shrink-0 dark:border-slate-900 shadow">
                                            <img src={avatar ? avatar : SmallAvatar} alt=""
                                                 className="cropped"/>
                                        </div>
                                        <input type='file' id='avatar-input'
                                               accept="image/*"
                                               onChange={e => uploadAvatarInServer(e.target.files[0])}
                                               style={{display: "none"}}></input>
                                        {
                                            isCurrentUser
                                                ?
                                                <>
                                                    <button type="button"
                                                            onClick={clickOnAvatarInput}
                                                            className="absolute -bottom-3 left-1/2 -translate-x-1/2 dark:bg-dark15 shadow p-1.5 rounded-full sm:flex hidden">
                                                        <ion-icon name="camera" className="text-2xl md hydrated"
                                                                  role="img"
                                                                  aria-label="camera"></ion-icon>
                                                    </button>
                                                </>
                                                : <></>
                                        }
                                    </div>

                                    <h3 className="md:text-3xl text-base font-bold text-black dark:text-white"> {userData?.firstName} {userData?.lastName} </h3>
                                    <p className="mt-2 text-gray-400">@{userData?.userName}</p>
                                    <div className="w-1/2" style={{wordWrap: "break-word"}}>
                                        {
                                            userData?.status || isCurrentUser
                                                ? <>
                                                    <p className="mt-2 text-gray-500 dark:text-white/80 text-center">{userData?.status}&nbsp;&nbsp;
                                                        {isCurrentUser
                                                            ? <>
                                                                <a
                                                                    href="#" className="text-blue-500 inline-block"
                                                                    uk-toggle="target: #change-profile-status"> {userData?.status ? "Изменить" : "Похоже у вас нет статуса. Добавить?"}
                                                                </a>
                                                            </>
                                                            : <></>}
                                                    </p>
                                                </>
                                                : <></>
                                        }

                                    </div>
                                </div>

                            </div>

                            {/* navigations */}
                            <div
                                className="flex items-center justify-between mt-3 border-t border-gray-100 px-2 max-lg:flex-col dark:border-slate-700"
                                uk-sticky="offset:50; cls-active: bg-white/80 shadow rounded-b-2xl z-50 backdrop-blur-xl dark:!bg-slate-700/80; animation:uk-animation-slide-top ; media: 992">
                                <div className="flex items-center gap-2 text-sm py-2 pr-1 max-md:w-full lg:order-2">

                                    {
                                        isCurrentUser
                                            ? <>
                                            </>
                                            : <>
                                                <button
                                                    onClick={joinChat}
                                                    className="button dark:!bg-white/5 flex items-center gap-2 text-white py-2 px-3.5 max-md:flex-1">
                                                    <ion-icon name="mail"
                                                              className="text-xl"></ion-icon>
                                                    <span className="text-sm"> Сообщение </span>
                                                </button>
                                            </>
                                    }

                                    {
                                        isCurrentUser
                                            ? <></>
                                            : userData?.isSubscribeTo === true ?
                                                <button
                                                    onClick={onUnsubscribe}
                                                    className="button dark:!bg-white/10 flex items-center gap-2 text-white py-2 px-3.5 max-md:flex-1">
                                                    <ion-icon name="checkmark-circle"
                                                              className="text-xl"></ion-icon>
                                                    <span className="text-sm"> Отписаться  </span>
                                                </button>
                                                : <button
                                                    onClick={onSubscribe}
                                                    className="button bg-primary flex items-center gap-2 text-white py-2 px-3.5 max-md:flex-1">
                                                    <ion-icon name="checkmark-circle-outline"
                                                              className="text-xl"></ion-icon>
                                                    <span className="text-sm"> Подписаться  </span>
                                                </button>
                                    }
                                </div>
                                <nav
                                    className="flex gap-0.5 rounded-xl -mb-px text-gray-600 font-medium text-[15px]  dark:text-white max-md:w-full max-md:overflow-x-auto">
                                    <a onClick={() => setShowPosts(true)}
                                       className={showPosts ? "inline-block  py-3 leading-8 px-3.5 border-b-2 border-blue-600 text-blue-600"
                                           : "inline-block py-3 leading-8 px-3.5"}>
                                        Посты <span
                                        className="text-xs pl-2 font-normal lg:inline-block hidden">{userData?.postsCount}</span></a>
                                    <a onClick={() => setShowPosts(false)}
                                       className={showPosts ? "inline-block py-3 leading-8 px-3.5" : "inline-block  py-3 leading-8 px-3.5 border-b-2 border-blue-600 text-blue-600"}>Друзья <span
                                        className="text-xs pl-2 font-normal lg:inline-block hidden">{userData?.friendCount}</span></a>
                                </nav>
                            </div>
                        </div>

                        <div className="flex 2xl:gap-12 gap-10 mt-8 max-lg:flex-col" id="js-oversized">

                            {/* feed story */}

                            <div className="flex-1 xl:space-y-6 space-y-3">

                                {isCurrentUser && showPosts
                                    ? <>
                                        {/* add post */}
                                        <div
                                            className="bg-white rounded-xl shadow-sm p-4 space-y-4 text-sm font-medium border1 dark:bg-dark15">
                                            <div className="flex items-center gap-3">
                                                <div
                                                    className="flex-1 bg-slate-100 hover:bg-opacity-80 transition-all rounded-lg cursor-pointer dark:bg-dark3"
                                                    uk-toggle="target: #create-status">
                                                    <div className="py-2.5 text-center dark:text-white"> Создать новый
                                                        пост
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </>
                                    : <></>}

                                {
                                    showPosts
                                    ? <Posts userId={userId} isFollowingPosts={false}/>
                                        : friends.length > 0 ? friends.map(x => <FriendInfo userInfo={x} key={x.userId}/>) : <div className="text-center text-xl font-bold">У вас нет друзей :)</div>
                                }
                                {/*POST*/}

                            </div>

                            {/* sidebar */}

                            <div className="lg:w-[400px]">

                                <div className="lg:space-y-4 lg:pb-8 max-lg:grid sm:grid-cols-2 max-lg:gap-6"
                                     uk-sticky="media: 1024; end: #js-oversized; offset: 80">

                                    <div className="box p-5 px-6">

                                        <div className="flex items-ce justify-between text-black dark:text-white">
                                            <h3 className="font-bold text-lg"> Информация </h3>
                                            {isCurrentUser
                                                ? <a href="#" uk-toggle="target: #change-intro"
                                                     className="text-sm text-blue-500">Изменить</a>
                                                : <></>}

                                        </div>

                                        <ul className="text-gray-700 space-y-4 mt-4 text-sm dark:text-white/80">

                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M15 10.5a3 3 0 11-6 0 3 3 0 016 0z"/>
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1115 0z"/>
                                                </svg>
                                                <div> Место проживания: <span
                                                    className="font-semibold text-black dark:text-white"> {userData?.placeOfLiving ?? "-"} </span>
                                                </div>
                                            </li>
                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M4.26 10.147a60.436 60.436 0 00-.491 6.347A48.627 48.627 0 0112 20.904a48.627 48.627 0 018.232-4.41 60.46 60.46 0 00-.491-6.347m-15.482 0a50.57 50.57 0 00-2.658-.813A59.905 59.905 0 0112 3.493a59.902 59.902 0 0110.399 5.84c-.896.248-1.783.52-2.658.814m-15.482 0A50.697 50.697 0 0112 13.489a50.702 50.702 0 017.74-3.342M6.75 15a.75.75 0 100-1.5.75.75 0 000 1.5zm0 0v-3.675A55.378 55.378 0 0112 8.443m-7.007 11.55A5.981 5.981 0 006.75 15.75v-1.5"/>
                                                </svg>
                                                <div> Образование: <span
                                                    className="font-semibold text-black dark:text-white"> {userData?.placeOfStudy ?? "-"}  </span>
                                                </div>
                                            </li>
                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M20.25 14.15v4.25c0 1.094-.787 2.036-1.872 2.18-2.087.277-4.216.42-6.378.42s-4.291-.143-6.378-.42c-1.085-.144-1.872-1.086-1.872-2.18v-4.25m16.5 0a2.18 2.18 0 00.75-1.661V8.706c0-1.081-.768-2.015-1.837-2.175a48.114 48.114 0 00-3.413-.387m4.5 8.006c-.194.165-.42.295-.673.38A23.978 23.978 0 0112 15.75c-2.648 0-5.195-.429-7.577-1.22a2.016 2.016 0 01-.673-.38m0 0A2.18 2.18 0 013 12.489V8.706c0-1.081.768-2.015 1.837-2.175a48.111 48.111 0 013.413-.387m7.5 0V5.25A2.25 2.25 0 0013.5 3h-3a2.25 2.25 0 00-2.25 2.25v.894m7.5 0a48.667 48.667 0 00-7.5 0M12 12.75h.008v.008H12v-.008z"/>
                                                </svg>

                                                <div> Место работы: <span
                                                    className="font-semibold text-black dark:text-white">  {userData?.placeOfWork ?? "-"} </span>
                                                </div>
                                            </li>
                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12z"/>
                                                </svg>
                                                <div> Семейное положение: <span
                                                    className="font-semibold text-black dark:text-white"> {userData?.maritalStatus ?? "-"}  </span>
                                                </div>
                                            </li>
                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M12.75 19.5v-.75a7.5 7.5 0 00-7.5-7.5H4.5m0-6.75h.75c7.87 0 14.25 6.38 14.25 14.25v.75M6 18.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0z"/>
                                                </svg>
                                                <div> Кол-во подписчиков: <span
                                                    className="font-semibold text-black dark:text-white"> {userData?.subscribersCount} </span>
                                                </div>
                                            </li>
                                            <li className="flex items-center gap-3">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                                                     stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                                    <path stroke-linecap="round" stroke-linejoin="round"
                                                          d="M11.48 3.499a.562.562 0 011.04 0l2.125 5.111a.563.563 0 00.475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 00-.182.557l1.285 5.385a.562.562 0 01-.84.61l-4.725-2.885a.563.563 0 00-.586 0L6.982 20.54a.562.562 0 01-.84-.61l1.285-5.386a.562.562 0 00-.182-.557l-4.204-3.602a.563.563 0 01.321-.988l5.518-.442a.563.563 0 00.475-.345L11.48 3.5z"/>
                                                </svg>
                                                <div> Кол-во подписок: <span
                                                    className="font-semibold text-black dark:text-white"> {userData?.subscriberToCount} </span>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>


            {/* change intro */}
            <div className="hidden lg:p-20 uk- open" id="change-intro" uk-modal="container: false">
                <div
                    className="uk-modal-dialog tt relative overflow-hidden mx-auto bg-white shadow-xl rounded-lg md:w-[520px] w-full dark:bg-dark15">
                    <div className="text-center py-4 border-b mb-0 dark:border-slate-700">
                        <h2 className="text-sm font-medium text-black"> Изменить информацию </h2>
                        {/* close button */}
                        <button type="button" className="button-icon absolute top-0 right-0 m-2.5 uk-modal-close">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                 stroke="currentColor" className="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"/>
                            </svg>
                        </button>
                    </div>
                    <div className="space-y-5 mt-3 ml-3 mr-3 p-2">
                        <input id="living_place_input" placeholder="Место проживания" type={"text"}
                               defaultValue={userData?.placeOfLiving}
                               className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800"/>
                    </div>
                    <div className="space-y-5 mt-3 ml-3 mr-3 p-2">
                        <input id="studying_place_input" placeholder="Образование" type={"text"}
                               defaultValue={userData?.placeOfStudy}
                               className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800"/>
                    </div>
                    <div className="space-y-5 mt-3 ml-3 mr-3 p-2">
                        <input id="working_place_input" placeholder="Место работы" type={"text"}
                               defaultValue={userData?.placeOfWork}
                               className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800"/>
                    </div>

                    <div className="space-y-5 mt-3 ml-3 mr-3 p-2">
                        <select id="marital-status-input"
                                className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800">
                            <option disabled selected value style={{display: "none"}}>Семейное положение</option>
                            <option value="В отношениях">В отношениях</option>
                            <option value="В поиске">В поиске</option>
                            <option value="Одинок">Одинок</option>
                            <option value="В браке">В браке</option>
                        </select>
                    </div>
                    <div className="p-5 flex justify-between items-center">
                        <div>
                            <div
                                className="p-2 bg-white rounded-lg shadow-lg text-black font-medium border border-slate-100 w-60 dark:bg-slate-700"
                                uk-drop="offset:10;pos: bottom-left; reveal-left;animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-left ; mode:click">
                            </div>
                        </div>
                        <div className="flex items-center gap-2">
                            <button type="button"
                                    onClick={onChangeIntro}
                                    className="button bg-blue-500 text-white py-2 px-12 text-[14px] uk-modal-close"> Сохранить
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            {/* change profile status */}
            <div className="hidden lg:p-20 uk- open" id="change-profile-status" uk-modal="container: false">
                <div
                    className="uk-modal-dialog tt relative overflow-hidden mx-auto bg-white shadow-xl rounded-lg md:w-[520px] w-full dark:bg-dark15">
                    <div className="text-center py-4 border-b mb-0 dark:border-slate-700">
                        <h2 className="text-sm font-medium text-black"> Изменить статус </h2>
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
                            name="" id="profile_status_textarea" rows="6"
                            maxLength={250}
                            placeholder="Ваш статус">{userData?.status}</textarea>
                    </div>
                    <div className="p-5 flex justify-between items-center">
                        <div>
                            <div
                                className="p-2 bg-white rounded-lg shadow-lg text-black font-medium border border-slate-100 w-60 dark:bg-slate-700"
                                uk-drop="offset:10;pos: bottom-left; reveal-left;animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-left ; mode:click">
                            </div>
                        </div>
                        <div className="flex items-center gap-2">
                            <button type="button"
                                    onClick={onChangeStatus}
                                    className="button bg-blue-500 text-white py-2 px-12 text-[14px] uk-modal-close"> Сохранить
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            {/* create post */}
            <div className="hidden lg:p-20 uk- open" id="create-status" uk-modal="container: false">

                <div
                    className="uk-modal-dialog tt relative overflow-hidden mx-auto bg-white shadow-xl rounded-lg md:w-[520px] w-full dark:bg-dark15">

                    <div className="text-center py-4 border-b mb-0 dark:border-slate-700">
                        <h2 className="text-sm font-medium text-black"> Новый пост </h2>

                        {/* close button */}
                        <button type="button" onClick={() => {
                            setPostFiles([])
                            document.getElementById("create-post-text-input").value = ""
                        }} className="button-icon absolute top-0 right-0 m-2.5 uk-modal-close">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                 stroke="currentColor" className="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"/>
                            </svg>
                        </button>

                    </div>

                    <div className="space-y-5 mt-3 p-2">
                        <textarea
                            className="w-full !text-black placeholder:!text-black !bg-white !border-transparent focus:!border-transparent focus:!ring-transparent !font-normal !text-xl   dark:!text-white dark:placeholder:!text-white dark:!bg-slate-800"
                            name="" id="create-post-text-input" rows="6"
                            placeholder="Описание"></textarea>
                    </div>

                    <input type='file' id='post-file-input'
                           onChange={e => pushPostFile(e.target.files[0])}
                           style={{display: "none"}}></input>
                    <div className="flex items-center gap-2 text-sm py-2 px-4 font-medium flex-wrap">
                        {
                            postFileNames.length < 3
                                ? <button type="button"
                                          onClick={clickOnPostFileInput}
                                          className="flex items-center gap-1.5 bg-sky-50 text-sky-600 rounded-2xl py-5 px-5 border-2 border-sky-100 dark:bg-sky-950 dark:border-sky-900 add-image-button">
                                    <ion-icon name="image" className="text-base"></ion-icon>
                                </button>
                                : <></>
                        }
                        <div className="post-profile-block">
                            {postFileNames}
                        </div>
                    </div>


                    <div className="p-5 flex justify-between items-center">
                        <div>
                            <div
                                className="p-2 bg-white rounded-lg shadow-lg text-black font-medium border border-slate-100 w-60 dark:bg-slate-700"
                                uk-drop="offset:10;pos: bottom-left; reveal-left;animate-out: true; animation: uk-animation-scale-up uk-transform-origin-bottom-left ; mode:click">
                            </div>
                        </div>
                        <div className="flex items-center gap-2">
                            <button type="button"
                                    onClick={onPostCreate}
                                    className="button bg-blue-500 text-white py-2 px-12 text-[14px] uk-modal-close"> Создать
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
});

export default Profile
