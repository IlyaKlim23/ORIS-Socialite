import {useEffect, useState} from "react";
import GetPostsByUser from "../../Api/Posts/GetPostsByUser";
import Post from "./Post";
import UserInfoAsync from "../../CommonServices/UserInfo";

function Posts({userId, isFollowingPosts}){
    const [posts, setPosts] = useState([])
    const [currentUserInfo, setCurrentUserInfo] = useState({})
    const [pageNumber, setPageNumber] = useState(2)
    const [fetching, setFetching] = useState(false)
    const [totalCount, setTotalCount] = useState(0)

    async function loadPosts(){
        const result = await GetPostsByUser(userId, isFollowingPosts, 1)
        if (typeof result !== "string"){
            setPosts(result?.data?.posts)
            setTotalCount(result?.data?.count)
        }
    }

    async function updatePosts(){
        console.log(posts.length < totalCount)
        if (posts.length < totalCount) {
            const result = await GetPostsByUser(userId, isFollowingPosts, pageNumber)
            if (typeof result !== "string") {
                if (result?.data?.posts?.length > 0)
                    result?.data?.posts.map(x => setPosts(prevState => ([...prevState, x])))
            }
        }
    }

    async function loadCurrentUserInfo(){
        const result = await UserInfoAsync(null)
        if (result)
        {
            setCurrentUserInfo(result)
        }
    }

    const scrollHandler = (e) => {
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 100){
            setFetching(true)
        }
    }

    useEffect(() =>{
        if (fetching){
            updatePosts()
                .then(() => setPageNumber(prevState => prevState + 1))
                .finally(() => setFetching(false))
        }
    }, [fetching])

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)
        loadPosts().then()
        if (userId !== undefined || isFollowingPosts)
            loadCurrentUserInfo().then()

        return function(){
            document.removeEventListener('scroll', scrollHandler)
        }
    }, []);

    if (posts.length !== 0)
        return(

        <>
            {posts.map(info => <Post
                key={info.postId}
                postData={info}
                isCurrentUser={userId === undefined}
                isFollowingPosts={isFollowingPosts}
                currentUserInfo={currentUserInfo}/>)}


            <div className="mt-3"></div>

            {posts.length < totalCount
                ? <div>
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
                : <></>}

            <div className="mt-3"></div>

        </>
    )
    else
        return (<div className="text-center text-xl font-bold font-monospace mt-7">
            Пока что тут пусто:(
        </div>)
}

export default Posts