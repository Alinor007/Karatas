import React from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useAuth } from "../../Context/useAuth";
import { useForm } from "react-hook-form";
      
type Props = {}
type LoginFormsInputs = {
    userName: string;
    password: string;
  };
  
  const validation = Yup.object().shape({
    userName: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required"),
  });

const Loginpage = (props: Props) => {
    const { loginUser } = useAuth();
    const {
      register,
      handleSubmit,
      formState: { errors },
    } = useForm<LoginFormsInputs>({ resolver: yupResolver(validation) });
  
    const handleLogin = (form: LoginFormsInputs) => {
      loginUser(form.userName, form.password);
    };
    return (
      <section className="flex w-full h-screen">
        <div className='flex items-center justify-center w-full lg:w-1/2'>
      <div className='px-10 py-20 bg-white border-gray-100 rounded-3xl'>
          <h1 className='text-5xl font-semibold'>Welcome back!</h1>
              <h1 className='mt-4 text-lg font-medium text-gray-500'>
                Sign in to your account
              </h1>

              <form  className='mt-8'
                onSubmit={handleSubmit(handleLogin)}
              >
                <div>
                  {/* <label
                    htmlFor="email"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Username
                  </label> */}
                  <input
                    type="text"
                    id="username"
                    className='w-full p-4 mt-5 bg-transparent border-b-4 border-gray-200 '
                    placeholder="Email"
                    {...register("userName")}
                  />
                  {errors.userName ? (
                    <p className="text-white">{errors.userName.message}</p>
                  ) : (
                    ""
                  )}
                </div>
                <div>
                  {/* <label
                    htmlFor="password"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Password
                  </label> */}
                  <input
                    type="password"
                    id="password"
                    placeholder="••••••••"
                   className='w-full p-4 mt-5 bg-transparent border-b-4 border-gray-200 '

                    {...register("password")}
                  />
                  {errors.password ? (
                    <p className="text-white">{errors.password.message}</p>
                  ) : (
                    ""
                  )}
                </div>
                <div className="flex items-center justify-between">
                  <a
                    href="#"
                    className="text-sm text-white font-medium text-primary-600 hover:underline dark:text-primary-500"
                  >
                    Forgot password?
                  </a>
                </div>
            <div className='flex flex-col mt-8 gap-y-4'>
                <button
                type="submit"
                className='py-3 text-lg text-white bg-violet-500 rounded-3xl'>
                Sign in
                </button>
            </div>
                <div className='flex justify-center mt-8 text-center'>

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
            <div className="relative items-center justify-center hidden w-1/2 h-full bg-gray-200 lg:flex">
                <div className='rounded-full w-60 h-60 bg-gradient-to-tr from-violet-500 to-pink-500 animate-bounce'/>

            </div>
      </section>
    );
  
}

export default Loginpage