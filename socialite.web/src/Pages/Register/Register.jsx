import {signIn} from "../../Constants/PagePaths"
import {useState} from "react";
import {useNavigate} from "react-router-dom";
import processRegistration from "./RegistrationService";
import {feed} from "../../Constants/PagePaths"
import {AlertError} from "../../Components/AlertError";

export default function Register(){
    const [registrationData, setRegistrationData] = useState({
        userName: "",
        firstName: "",
        lastName: "",
        email: "",
        password: "",
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setRegistrationData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    let errorText = "";
    const [textForAlert, setTextForAlert] = useState("")
    const navigate = useNavigate();
    async function onRegistrationSubmit(event) {
        event.preventDefault();
        errorText = await processRegistration(registrationData)
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

                        <div className="hidden">
                            <img className="w-12" src="../../../public/assets/images/logo-icon.png"
                                 alt="Socialite html template"/>
                        </div>

                        <div>
                            <h2 className="text-2xl font-semibold mb-1.5"> Войдите чтобы начать </h2>
                            <p className="text-sm text-gray-700 font-normal">Есть аккаунт? <a
                                href={signIn} className="text-blue-700">Войти</a></p>
                        </div>


                        <form method="#" action="#" className="space-y-7 text-sm text-black font-medium dark:text-white"
                              uk-scrollspy="target: > *; cls: uk-animation-scale-up; delay: 100 ;repeat: true">

                            <div className="grid grid-cols-2 gap-4 gap-y-7">

                                <div className="col-span-2">
                                    <label htmlFor="email" className="">Никнейм</label>
                                    <div className="mt-2.5">
                                        <input name="userName" type="text" autoFocus="" placeholder="Никнейм"
                                               value={registrationData.userName}
                                               onChange={handleInputChange}
                                               required=""
                                               className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                    </div>
                                </div>

                                <div>
                                    <label htmlFor="email" className="">Имя</label>
                                    <div className="mt-2.5">
                                        <input name="firstName" type="text" autoFocus="" placeholder="Имя"
                                               required=""
                                               value={registrationData.firstName}
                                               onChange={handleInputChange}
                                               className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                    </div>
                                </div>

                                <div>
                                    <label htmlFor="email" className="">Фамилия</label>
                                    <div className="mt-2.5">
                                        <input name="lastName" type="text" placeholder="Фамилия" required=""
                                               value={registrationData.lastName}
                                               onChange={handleInputChange}
                                               className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                    </div>
                                </div>

                                <div className="col-span-2">
                                    <label htmlFor="email" className="">Почта</label>
                                    <div className="mt-2.5">
                                        <input id="email" name="email" type="email" placeholder="Почта" required=""
                                               value={registrationData.email}
                                               onChange={handleInputChange}
                                               className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                    </div>
                                </div>

                                <div className="col-span-2">
                                    <label htmlFor="email" className="">Пароль</label>
                                    <div className="mt-2.5">
                                        <input id="password" name="password" type="password" placeholder="Пароль"
                                               value={registrationData.password}
                                               onChange={handleInputChange}
                                               className="!w-full !rounded-lg !bg-transparent !shadow-sm !border-slate-200 dark:!border-slate-800 dark:!bg-white/5"/>
                                    </div>
                                </div>

                                <div className="col-span-2">
                                    <button type="button" onClick={onRegistrationSubmit}
                                            className="button bg-primary text-white w-full">Начать
                                    </button>
                                </div>
                                <div className="col-span-2">{AlertError(textForAlert)}</div>

                            </div>
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
                                            uk-slideshow-parallax="y: 600,0,0"> Общайся с друзьями </h4>
                                        <p className="!text-white text-lg mt-7 leading-8"
                                           uk-slideshow-parallax="y: 800,0,0;"> Держите своих друзей в курсе всего, что происходит в вашей жизни.</p>
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