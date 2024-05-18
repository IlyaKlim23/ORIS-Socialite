import {useState} from "react";
import GetUsersBaseInfo from "../../Api/UserInfo/GetUsersBaseInfo";
import UserInfo from "./UserInfo";

export default function SearchString(){
    const [users, setUsers] = useState([])

    async function loadUsers(value){
        const result = await GetUsersBaseInfo({
            userName: value
        })
        if (result)
            setUsers(result?.data?.users)
    }

    return (
        <>
            <div id="search--box" class="sm:w-96 sm:relative rounded-xl overflow-hidden z-20 bg-secondery max-md:hidden w-screen max-sm:fixed max-sm:top-2 dark:!bg-white/5">
                    <ion-icon name="search" class="absolute left-4 top-1/2 -translate-y-1/2"></ion-icon>
                    <input type="text" onChange={e => loadUsers(e.target.value)} placeholder={"Найти друзей"} className="w-full !pl-10 !font-normal !bg-transparent h-12 !text-sm" />
            </div>
                 <div className="hidden uk- open z-10"
                       uk-drop="pos: bottom-center; animation: uk-animation-slide-top-small;mode:click ">

                    <div className="sm:w-100 bg-white dark:bg-dark3 w-screen p-2 rounded-lg shadow-lg -mt-14 pt-14">
                        {users.length > 0
                            ? <div className="flex justify-between px-2 py-2.5 text-sm font-medium">
                            </div>
                        : <></>}

                        <nav className="text-sm font-medium text-black dark:text-white">
                            {
                                users.map(x => <UserInfo key={x.userId} userInfo={x}/>)
                            }
                        </nav>
                    </div>
                 </div>
        </>
    )
}