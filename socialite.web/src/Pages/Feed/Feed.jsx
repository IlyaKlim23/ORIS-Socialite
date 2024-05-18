import Sidebar from "../../Components/Sidebar";
import Header from "../../Components/Header";
import {feed} from "../../Constants/PagePaths";
import Posts from "../../Components/Posts/Posts";
import {observer} from "mobx-react-lite";

const Feed = observer(() => {

    return(
        <>
            <Sidebar currentPage={feed}/>
            <Header />

            <div id="wrapper">
                <div id="sidebar"></div>
                {/* main contents */}
                <main id="site__main"
                      className="2xl:ml-[--w-side] xl:ml-[--w-side-sm] p-2.5 h-[calc(100vh-var(--m-top))] mt-[--m-top]">

                    {/* timeline */}
                    <div className="lg:flex 2xl:gap-16 gap-12 max-w-[1065px] mx-auto" id="js-oversized">

                        <div className="max-w-[680px] mx-auto w-2/3">

                            {/* stories */}
                            <div className="mb-4">

                            </div>

                                {/* feed story */}
                                <Posts isFollowingPosts={true}/>

                            </div>
                        </div>
                </main>
            </div>
        </>
    )
});

export default Feed