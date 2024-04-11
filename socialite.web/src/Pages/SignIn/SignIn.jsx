import {registration} from "../../Constants/PagePaths"
import {useNavigate} from "react-router-dom";
import {useState} from "react";
import {processSignIn} from "./SignInService";
import {AlertError} from "../../Components/AlertError";
import {feed} from "../../Constants/PagePaths"

export default function SignIn() {
    const [signInData, setSignInData] = useState({
        email: "",
        password: "",
    });
    let errorText = "";
    const [textForAlert, setTextForAlert] = useState("")
    const navigate = useNavigate();
    async function onFormSubmit(event) {
        event.preventDefault();
        errorText = await processSignIn(signInData)
        if (errorText === ""){
            navigate(feed)
        }
        else{
            setTextForAlert(errorText)
        }
    }

    return(
        <>
            <div className="sm:flex">
                <div
                    className="relative lg:w-[580px] md:w-96 w-full p-10 min-h-screen bg-white shadow-xl flex items-center pt-10 dark:bg-slate-900 z-10">
                    <div className="w-full lg:max-w-sm mx-auto space-y-10"
                         uk-scrollspy="target: > *; cls: uk-animation-scale-up; delay: 100 ;repeat: true">
                        <div>
                            <h2 className="text-2xl font-semibold mb-1.5"> Sign in to your account </h2>
                            <p className="text-sm text-gray-700 font-normal">If you haven’t signed up yet. <a
                                href={registration} className="text-blue-700">Register here!</a>
                            </p>
                        </div>
                        <form method="#" action="#" className="space-y-7 text-sm text-black font-medium dark:text-white"
                              uk-scrollspy="target: > *; cls: uk-animation-scale-up; delay: 100 ;repeat: true">

                            <div>
                                <label htmlFor="email" className="">Email address</label>
                                <div className="mt-2.5">
                                    <input id="email" name="email" type="email" autoFocus="" placeholder="Email"
                                           required=""
                                           onChange={(event) => {
                                               setSignInData({ ...signInData, email: event.target.value });
                                           }}
                                           className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                </div>
                            </div>
                            <div>
                                <label htmlFor="email" className="">
                                    Password</label>
                                <div className="mt-2.5">
                                    <input id="password" name="password" type="password" placeholder="Password"
                                           onChange={(event) => {
                                               setSignInData({ ...signInData, password: event.target.value });}}
                                           className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                </div>
                            </div>

                            <div className="flex items-center justify-between">
                                <a href="#" className="text-blue-700">Forgot password</a>
                            </div>
                            <div>
                                <button type="button" onClick={onFormSubmit} className="button bg-primary text-white w-full">Sign in</button>
                                </div>
                            <div>{AlertError(textForAlert)}</div>
                        </form>
                    </div>
                </div>
                <div className="flex-1 relative bg-primary max-md:hidden">
                    <div className="relative w-full h-full" tabIndex="-1"
                         uk-slideshow="animation: slide; autoplay: true">
                        <ul className="uk-slideshow-items w-full h-full">
                            <li className="w-full">
                                <div className="absolute bottom-0 w-full uk-tr ansition-slide-bottom-small z-10">
                                    <div className="max-w-xl w-full mx-auto pb-32 px-5 z-30 relative"
                                         uk-scrollspy="target: > *; cls: uk-animation-scale-up; delay: 100 ;repeat: true">
                                        <h4 className="!text-white text-2xl font-semibold mt-7"
                                            uk-slideshow-parallax="y: 600,0,0"> Connect With Friends </h4>
                                        <p className="!text-white text-lg mt-7 leading-8"
                                           uk-slideshow-parallax="y: 800,0,0;"> This phrase is more casual and playful.
                                            It suggests that you are keeping your friends updated on what’s happening in
                                            your life.</p>
                                    </div>
                                </div>
                                <div className="w-full h-96 bg-gradient-to-t from-black absolute bottom-0 left-0"></div>
                            </li>
                        </ul>
                        <div className="flex justify-center">
                            <ul className="inline-flex flex-wrap justify-center  absolute bottom-8 gap-1.5 uk-dotnav uk-slideshow-nav"></ul>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}