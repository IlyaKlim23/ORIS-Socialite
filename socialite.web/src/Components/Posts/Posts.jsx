import {useEffect, useState} from "react";
import GetPostsByUser from "../../Api/Posts/GetPostsByUser";
import Post from "./Post";


function Posts(userId){
    const [posts, setPosts] = useState([])

    async function loadPosts(){
        const result = await GetPostsByUser(userId)
        setPosts(result.data.posts)
    }

    useEffect(() => {
        loadPosts()
    }, []);

    return(
        <>
            {posts.map((info) => <Post postData={info} currentUser={userId === null}/>)}
        </>
    )
}

export default Posts