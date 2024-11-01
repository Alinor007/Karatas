// import axiosInstance from "./../utils/axiosInstance"; // Adjust the path to where axiosInstance is located
import { toast } from "react-toastify";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/Auth";
import axios, { AxiosError } from "axios";

const api = "http://localhost:5100/api/";

export const loginAPI = async (username: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(api+"Account/Login", {
      username: username,
      password: password,

    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (

  firstName: string,
  lastName: string,
  email: string,
  username: string,
  password: string,
  address: string,
  officeId: number 

) => {
  try {
    const data = await axios.post<UserProfileToken>(api+"Account/Register", {
      email,
      username,
      password,
      address,
      firstName,
      lastName,
      officeId, // Send office in the request
    });
    return data;
  } catch (error: unknown) {
    if (error instanceof AxiosError && error.response) {
      console.error("API error:", error.response.data);
      // Optionally, show an error toast to the user
      toast.error("Registration failed: " + error.response.data.message || "Unknown error");
    } else {
      console.error("Unexpected error:", error);
    }
    handleError(error);  // Continue with generic error handling
  }
};