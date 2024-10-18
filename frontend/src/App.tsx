import React from 'react';
import './App.css';
import Navbar from './Components/Navbar/Navbar';
import { ToastContainer } from 'react-toastify';
import { Outlet } from 'react-router';
import "react-toastify/dist/ReactToastify.css";
import { UserProvider } from './Context/useAuth';
import Loginpage from './Pages/LoginPage/Loginpage';

function App() {
  return (
    
    <>
    
    <Loginpage/>
    </>
  );
}

export default App;
