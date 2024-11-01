import React from 'react';
import { Outlet } from "react-router";
import logo from './logo.svg';
import './App.css';
import Loginpage from './Pages/LoginPage/Loginpage';
import { UserProvider } from './Context/authContext';
import Navbar from './Components/Navbar/Navbar';
import { ToastContainer } from 'react-toastify';

function App() {
  return (
    <div className='font-poppins'>
      <UserProvider>
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </div>
  );
}

export default App;
