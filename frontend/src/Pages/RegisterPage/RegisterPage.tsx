import React, { useEffect, useState } from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import logo from "../../Logo-.png";
import { useAuth } from "../../Context/authContext";
import { Link } from "react-router-dom";
import axios from "axios";
import { toast } from "react-toastify";

type Props = {};

type Office = {
  id: number;
  name: string;
};

type RegisterFormsInputs = {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  password: string;
  address: string;
  officeId: number;
};

const validation = Yup.object().shape({
  firstName: Yup.string().required("First Name is required"),
  lastName: Yup.string().required("Last Name is required"),
  userName: Yup.string().required("Username is required"),
  email: Yup.string().email().required("Email is required"),
  password: Yup.string().min(6).required("Password is required"),
  address: Yup.string().required("Address is required"),
  officeId: Yup.number().positive().integer().required("Office is required"),
});

const RegisterPage = (props: Props) => {
  const { registerUser } = useAuth();
  const [offices, setOffices] = useState<Office[]>([]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });

  // Fetch offices from API
  useEffect(() => {
    const fetchOffices = async () => {
      try {
        const response = await axios.get("http://localhost:5100/api/Offices"); // Update URL if necessary
        setOffices(response.data);
      } catch (error) {
        console.error("Error fetching offices:", error);
      }
    };

    fetchOffices();
  }, []);

  const handleRegister = (form: RegisterFormsInputs) => {
    registerUser(
      form.firstName,
      form.lastName,
      form.email,
      form.userName,
      form.password,
      form.address,
      form.officeId
    );
  };

  return (
    <div className="flex items-center justify-center h-screen">
      <div className="rounded-3xl shadow-lg flex w-3/4 max-w-4xl">
        <div className="w-1/2 flex flex-col items-center justify-center p-10 rounded-s-3xl border-r-4 border-gray-300">
          <img src={logo} className="w-60 h-60" alt="Logo" />
          <h1 className="mt-4 text-2xl font-bold text-indigo-800">Karatas</h1>
        </div>

        <div className="w-1/2 p-5 flex flex-col justify-center">
          <h1 className="text-lg font-bold text-indigo-800 mb-2 text-center">Register</h1>

          <form className="mb-2" onSubmit={handleSubmit(handleRegister)}>
            <div>
              <label htmlFor="firstName" className="block text-xs font-medium text-gray-900">
                First Name
              </label>
              <input
                type="text"
                id="firstName"
                className="w-full p-2 text-xs bg-transparent border-b-4 border-gray-200"
                placeholder="Enter your First Name"
                {...register("firstName")}
              />
              {errors.firstName && <p className="error">{errors.firstName.message}</p>}
            </div>

            <div>
              <label htmlFor="lastName" className="block text-xs font-medium text-gray-900">
                Last Name
              </label>
              <input
                type="text"
                id="lastName"
                className="w-full p-2 text-xs bg-transparent border-b-4 border-gray-200"
                placeholder="Enter your Last Name"
                {...register("lastName")}
              />
              {errors.lastName && <p className="error">{errors.lastName.message}</p>}
            </div>

            <div>
              <label htmlFor="address" className="block text-xs font-medium text-gray-900">
                Address
              </label>
              <input
                type="text"
                id="address"
                className="w-full p-2 text-xs bg-transparent border-b-4 border-gray-200"
                placeholder="Enter your Address"
                {...register("address")}
              />
              {errors.address && <p className="error">{errors.address.message}</p>}
            </div>

            <div>
              <label htmlFor="userName" className="block text-xs font-medium text-gray-900">
                Username
              </label>
              <input
                type="text"
                id="userName"
                className="w-full p-2 text-xs bg-transparent border-b-4 border-gray-200"
                placeholder="Enter your Username"
                {...register("userName")}
              />
              {errors.userName && <p className="error">{errors.userName.message}</p>}
            </div>

            <div>
              <label htmlFor="email" className="block text-xs font-medium text-gray-900">
                Email
              </label>
              <input
                type="text"
                id="email"
                className="w-full p-2 text-xs bg-transparent border-b-4 border-gray-200"
                placeholder="Enter your Email"
                {...register("email")}
              />
              {errors.email && <p className="error">{errors.email.message}</p>}
            </div>

            <div>
              <label htmlFor="password" className="block mt-2 text-xs font-medium text-gray-900">
                Password
              </label>
              <input
                type="password"
                id="password"
                placeholder="••••••••"
                className="w-full p-2 bg-transparent border-b-4 border-gray-200"
                {...register("password")}
              />
              {errors.password && <p className="error">{errors.password.message}</p>}
            </div>

            <div>
              <label htmlFor="officeId" className="block text-xs font-medium text-gray-900">
                Office
              </label>
              <select
                id="officeId"
                className="w-full p-2 bg-transparent border-b-4 border-gray-200"
                {...register("officeId")}
              >
                <option value="">Select an Office</option>
                {offices.map((office) => (
                  <option key={office.id} value={office.id}>
                    {office.name}
                  </option>
                ))}
              </select>
              {errors.officeId && <p className="error">{errors.officeId.message}</p>}
            </div>

            <div className="flex flex-col mt-4 gap-y-4">
              <button
                type="submit"
                className="w-full bg-gradient-to-r from-blue-500 to-pink-400 text-white py-3 rounded-3xl font-bold hover:bg-indigo-500 transition duration-300"
              >
                Sign up
              </button>
            </div>

            <div className="flex justify-center mt-3 text-center text-xs">
              <p className="font-medium">
                Already have an account?{" "}
                <Link to="../login" className="ml-2 text-base font-medium text-violet-500">
                  Sign in
                </Link>
              </p>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default RegisterPage;
