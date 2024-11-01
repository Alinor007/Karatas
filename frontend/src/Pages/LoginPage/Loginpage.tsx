import React from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import logo from '../../Logo-.png'
import { useAuth } from "../../Context/authContext";
      
type Props = {};

type LoginFormsInputs = {
  userName: string;
  password: string;
};

const validation = Yup.object().shape({
  userName: Yup.string().required("Username is required"),
  password: Yup.string().required("Password is required"),
});
const Loginpage = (props: Props) => {
  const { loginUser } = useAuth(); // Access loginUser function from context
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginFormsInputs>({ resolver: yupResolver(validation) });
 
  const handleLogin = (form: LoginFormsInputs) => {
    loginUser(form.userName, form.password);
  };



    return (
          <div className=" flex items-center justify-center h-screen">
            <div className="rounded-3xl shadow-lg flex w-3/4 max-w-4xl">
            <div className="w-1/2 flex flex-col items-center justify-center border-r-4 border-gray-300 p-10 rounded-s-3xl">
                        <img src={logo} className="w-60 h-60"/>
                  <h1 className="mt-4 text-2xl font-bold text-indigo-800" >Karatas</h1>
            </div>

            <div className="w-1/2 p-10 flex flex-col justify-center">
            <h1 className='text-2xl font-bold text-indigo-800 mb-2 text-center'>Welcome back!</h1>
              <h3 className='text-sm font-medium text-gray-500 mb-8 text-center'>
                Sign in to your account
              </h3> 

              <form  className='mb-2 '
              onSubmit={handleSubmit(handleLogin)}
              >
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
                    {...register("userName")}
                  
                  />
                  {errors.userName ? (
                  <p className="text-red-500">{errors.userName.message}</p>
                ) : (
                  ""
                )}
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
                   {...register("password")}
                  />
                    {errors.password ? (
                  <p className="text-red-500">{errors.password.message}</p>
                ) : (
                  ""
                )}
                
                </div>
                <div className="flex items-center justify-between">
                  <a
                    href="#"
                    className="text-sm mt-3 text-indigo-800 font-medium text-primary-600 hover:underline dark:text-primary-500"
                  >
                    Forgot password?
                  </a>
                </div>
            <div className='flex flex-col mt-4 gap-y-4'>
                <button
                type="submit"
                className='w-full bg-gradient-to-r from-blue-500 to-pink-400 text-white py-3 rounded-3xl font-bold hover:bg-indigo-500 transition duration-300'>
                Sign in
                </button>
            </div>
                <div className='flex justify-center mt-3 text-center'>

                <p className='text-base font-medium'>
                  Don’t have an account yet?{" "}
                  <a
                    href="#"
                    className='ml-2 text-base font-medium text-violet-500'
                  >
                    Sign up
                  </a>
                </p>
                </div>
              </form>
            </div>
            </div>
            </div>
    );
  
}

export default Loginpage