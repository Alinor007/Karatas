import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import LoginPage from "../Pages/LoginPage/Loginpage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import MainPage from "../Pages/MainPage/MainPage";
import Offices from "../Components/Offices/Offices";
import Dashboard from "../Components/Dashboard/Dashboard";


export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
          { path: "", element: <HomePage /> },
          { path: "/login", element: <LoginPage /> },
          { path: "register", element: <RegisterPage /> },
          {
        path: "Page",
        element: (
            <MainPage />
        ),
        children: [
          { path: "Offices", element: <Offices/> },
          { path: "Dashboard", element: <Dashboard/> },

        ],
      }
          
        ]

    }])