// src/components/Navbar.tsx
import React, { useState } from 'react';
import Logo from '../../Logo-.png'
import { useAuth } from "../../Context/authContext";
import { Link } from 'react-router-dom';


const Navbar: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { isLoggedIn, user, logout } = useAuth();


  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <nav className=" shadow-md">
      <div className="container mx-auto px-6 py-4 flex justify-between items-center">
        
        <div className='flex '>
        <h1 className="text-2xl font-bold text-blue-500"> Karatas </h1>      
        </div>
        
        <div className="hidden md:flex space-x-6">
        {isLoggedIn() ? (
            <>
              <Link to="#home" className="text-gray-800 hover:text-blue-500">Home</Link>
              <Link to="#features" className="text-gray-800 hover:text-blue-500">Features</Link>
              <Link to="#pricing" className="text-gray-800 hover:text-blue-500">Pricing</Link>
              <Link to="#contact" className="text-gray-800 hover:text-blue-500">Contact</Link>
              <button onClick={logout} className="text-gray-800 hover:text-blue-500">Logout</button>
            </>
          ) : (
            <>
              <Link to='../Login' className="text-gray-800 hover:text-blue-500">Login</Link>
              <Link to='../Register' className="text-gray-800 hover:text-blue-500">Register</Link>
            </>
          )}
        
        </div>
        <div className="md:hidden">
          <button
            onClick={toggleMenu}
            className="text-gray-800 focus:outline-none"
          >
            <svg
              className="w-6 h-6"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d={isOpen ? 'M6 18L18 6M6 6l12 12' : 'M4 6h16M4 12h16M4 18h16'}
              ></path>
            </svg>
          </button>
        </div>
      </div>
      {isOpen && (
        <div className="md:hidden">
          <div className="px-6 py-4 space-y-2">
            <a href="#home" className="block text-gray-800 hover:text-blue-500">
              Home
            </a>
            <a
              href="#features"
              className="block text-gray-800 hover:text-blue-500"
            >
              Features
            </a>
            <a
              href="#pricing"
              className="block text-gray-800 hover:text-blue-500"
            >
              Pricing
            </a>
            <a
              href="#contact"
              className="block text-gray-800 hover:text-blue-500"
            >
              Contact
            </a>
          </div>
        </div>
       
      )}
      
    </nav>
  );
};

export default Navbar;
