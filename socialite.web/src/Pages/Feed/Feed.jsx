import Sidebar from "../../Components/Sidebar";
import Header from "../../Components/Header";
import {feed} from "../../Constants/PagePaths";
import Posts from "../../Components/Posts/Posts";


export default function Feed(){
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


                                <Posts isFollowingPosts={true}/>

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
        </>
    )
}