import {useEffect, useState} from "react";
import GetPostsByUser from "../../Api/Posts/GetPostsByUser";
import Post from "./Post";
import UserInfoAsync from "../../CommonServices/UserInfo";

function Posts({userId, isFollowingPosts}){
    const [posts, setPosts] = useState([])
    const [currentUserInfo, setCurrentUserInfo] = useState({})

    async function loadPosts(){
        const result = await GetPostsByUser(userId, isFollowingPosts)
        if (typeof result !== "string")
            setPosts(result?.data?.posts)
    }

    async function loadCurrentUserInfo(){
        const result = await UserInfoAsync(null)
        if (result)
        {
            setCurrentUserInfo(result)
        }
    }

    useEffect(() => {
        loadPosts().then()
        if (userId !== undefined || isFollowingPosts)
            loadCurrentUserInfo().then()
    }, []);

    return(
        <>
            {posts.map((info, index) => <Post
                key={index}
                postData={info}
                isCurrentUser={userId === undefined}
                isFollowingPosts = {isFollowingPosts}
                currentUserInfo={currentUserInfo}/>)}

            <div className="mt-3"></div>
        </>
    )
}

export default Posts