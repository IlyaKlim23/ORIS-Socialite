import {
    signIn,
    registration, feed
} from "./Constants/PagePaths.js";
import { Route, Routes } from "react-router-dom";
import SignIn from "./Pages/SignIn/SignIn";
import Register from "./Pages/Register/Register";
import Feed from "./Pages/Feed/Feed";


function App() {
    return (
        <>
            <Routes>
                <Route path={signIn} element={SignIn()}></Route>
                <Route path={registration} element={Register()}></Route>
                <Route path={feed} element={Feed()}></Route>
            </Routes>
        </>
    );
}

export default App;