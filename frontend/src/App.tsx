import React from 'react';
import { Outlet } from "react-router";
import logo from './logo.svg';
import './App.css';
import Loginpage from './Pages/LoginPage/Loginpage';

function App() {
  return (
    <div className='font-poppins'>
        <Outlet />
    </div>
  );
}

export default App;
