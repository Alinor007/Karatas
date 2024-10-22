import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import LoginPage from "../Pages/LoginPage/Loginpage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import Office from ".././Components/Offices/Offices"


export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
          { path: "", element: <HomePage /> },
          { path: "login", element: <LoginPage /> },
          { path: "register", element: <RegisterPage /> },
          { path: "register", element: <RegisterPage /> },
          
        ]

    }])


