import {useEffect, useState} from "react";
import GetPostsByUser from "../../Api/Posts/GetPostsByUser";
import Post from "./Post";
import UserInfoAsync from "../../CommonServices/UserInfo";

function Posts(userId){
    const [posts, setPosts] = useState([])
    const [currentUserInfo, setCurrentUserInfo] = useState({})

    async function loadPosts(){
        const result = await GetPostsByUser(userId.userId)
        setPosts(result.data.posts)
    }

    async function loadCurrentUserInfo(){
        const result = await UserInfoAsync(null)
        if (result)
        {
            setCurrentUserInfo(result)
        }
    }

    useEffect(() => {
        loadPosts()
        if (userId.userId !== undefined)
            loadCurrentUserInfo()
    }, []);

    return(
        <>
            {posts.map((info) => <Post
                postData={info}
                isCurrentUser={userId.userId === undefined}
                currentUserInfo={currentUserInfo}/>)}

            <div className="mt-3"></div>
        </>
    )
}

export default Posts