import {createBrowserRouter} from "react-router";
import App from "../layout/App";
import LoginPage from "../../features/login/LoginPage";
import FilmDashboard from "../../features/films/dashboard/FilmDashboard";
import CinemaRommDashboard from "../../features/cinemaRoom/dashboard/CinemaRommDashboard";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <LoginPage />},
            {path: 'films', element: <FilmDashboard />},
            {path: 'films/:id', element: <CinemaRommDashboard/>}
        ]
    }
])