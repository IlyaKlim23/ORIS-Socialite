import {
    signIn,
    registration,
    feed,
    profile
} from "./Constants/PagePaths.js";
import {Route, Routes} from "react-router-dom";
import SignIn from "./Pages/SignIn/SignIn";
import Register from "./Pages/Register/Register";
import Feed from "./Pages/Feed/Feed";
import Profile from "./Pages/Profile/Profile";


function App() {
    return (
        <Routes>
            <Route path={signIn} element={<SignIn />}></Route>
            <Route path={registration} element={<Register />}></Route>
            <Route path={feed} element={<Feed />}></Route>
            <Route path={profile} element={<Profile />}>
                <Route path={`:userId`} element={<Profile />}></Route>
            </Route>
        </Routes>
    );
}

export default App;