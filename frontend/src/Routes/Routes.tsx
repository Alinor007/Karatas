import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import LoginPage from "../Pages/LoginPage/Loginpage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import MainPage from "../Pages/MainPage/MainPage";
import { OfficeList } from "../Components/Office/OfficeList";
import Dashboard from "../Components/Dashboard/Dashboard";
import DocList from "../Components/Documents/DocList";
import Incoming from "../Components/Documents/Incoming";
import ManageUser from "../Components/ManageUsers/ManageUser";
import Office from "../Components/Office/List";
import AddOffice from "../Components/Office/addOffice";
import { UserProvider } from "../Context/authContext";


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
          <UserProvider>
            <MainPage />
            </UserProvider>
        ),
        children: [
          { path: "Offices", element: <OfficeList/> },
          { path: "AddOffice", element: <AddOffice/> },
          { path: "Dashboard", element: <Dashboard/> },
          { path: "DocumentList", element: <DocList/> },
          { path: "Incoming", element: <Incoming/> },
          { path: "ManageUser", element: <ManageUser/> },
          { path: "List", element: <Office/> },



        ],
      }
          
        ]

    }])