import { toast } from "react-toastify";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/Auth";
import axios from "axios";

const api = "http://localhost:5100/api/";

export const loginAPI = async (username: string, password: string) => {
  try {
    const response = await axios.post<UserProfileToken>(`${api}Account/Login`, {
      username,
      password,
    });
    return response;
  } catch (error) {
    handleError(error);
    throw new Error("Login failed. Please check your credentials.");
  }
};

export const registerAPI = async (
  firstName: string,
  lastName: string,
  email: string,
  userName: string,
  password: string,
  address: string,
  officeId: number
) => {
  
  try {

    const payload = {
      firstName,
      lastName,
      email,
      userName,
      password,
      address,
      officeId,
    };

    // Log the payload to the console
    console.log("Payload Sent to API:", payload);
    const response = await axios.post<UserProfileToken>(`${api}Account/Register`, {
      firstName,
      lastName,
      email,
      userName,
      password,
      address,
      officeId,
    });
 
    return response;
  } catch (error) {
    handleError(error);
    throw new Error("Registration failed. Please try again.");
  }
};
