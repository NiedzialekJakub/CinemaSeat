import {createBrowserRouter} from "react-router";
import App from "../layout/App";
import LoginPage from "../../features/login/LoginPage";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <LoginPage />}
        ]
    }
])