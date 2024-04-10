import {
    signIn,
    registration
} from "./Constants/PagePaths.js";
import { Route, Routes } from "react-router-dom";
import SignIn from "./Pages/SignIn/SignIn";
import Register from "./Pages/Register/Register";

function App() {
    return (
        <>
            <Routes>
                <Route path={signIn} element={SignIn()}></Route>
                <Route path={registration} element={Register()}></Route>
            </Routes>
        </>
    );
}

export default App;