import React from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import logo from '../../Logo-.png'
      
type Props = {}
const RegisterPage = (props: Props) => {
   
    return (
          <div className=" flex items-center justify-center h-screen">
            <div className="rounded-3xl shadow-lg flex w-3/4 max-w-4xl">
            <div className="w-1/2 flex flex-col items-center justify-center p-10 rounded-s-3xl border-r-4 border-gray-300">
                        <img src={logo} className="w-60 h-60"/>
                  <h1 className="mt-4 text-2xl font-bold text-indigo-800" >Karatas</h1>
            </div>

            <div className="w-1/2 p-10 flex flex-col justify-center">
            <h1 className='text-2xl font-bold text-indigo-800 mb-2 text-center'>Register</h1>
             

              <form  className='mb-2 '
              >
                <div>
                  <label
                    htmlFor="email"
                    className="block text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Username
                  </label>
                  <input
                    type="text"
                    id="username"
                    className='w-full p-2 text-sm bg-transparent border-b-4 border-gray-200 '
                    placeholder="Enter your Username"
                  
                  />

                 
                </div>
                <div>
                  <label
                    htmlFor="email"
                    className="block text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Email
                  </label>
                  <input
                    type="text"
                    id="username"
                    className='w-full p-2 text-sm bg-transparent border-b-4 border-gray-200 '
                    placeholder="Enter your Email"
                  
                  />
                  
                 
                </div>
                <div>
                  <label
                    htmlFor="password"
                    className="block mt-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Password
                  </label>
                  <input
                    type="password"
                    id="password"
                    placeholder="••••••••"
                   className='w-full p-2 bg-transparent border-b-4 border-gray-200 '

                   
                  />
                
                </div>
            
            <div className='flex flex-col mt-4 gap-y-4'>
                <button
                type="submit"
                className='w-full bg-gradient-to-r from-blue-500 to-pink-400 text-white py-3 rounded-3xl font-bold hover:bg-indigo-500 transition duration-300'>
                Sign up  
                </button>
            </div>
                <div className='flex justify-center mt-3 text-center'>

                <p className='text-base font-medium'>
                  Already have an account?{" "}
                  <a
                    href="#"
                    className='ml-2 text-base font-medium text-violet-500 '
                  >
                    Sign in
                  </a>
                </p>
                </div>
              </form>
            </div>
            </div>
            </div>
    );
  
}

export default RegisterPage