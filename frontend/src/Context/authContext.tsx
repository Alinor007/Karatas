import { createContext, useEffect, useState, useContext, useCallback } from "react";
import { UserProfile } from "../Models/Auth";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../Service/AuthService";
import { toast } from "react-toastify";
import axios from "axios";
import axiosInstance from "../utils/axiosInstance";


type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  registerUsers: (email: string, username: string, password: string, address: string, firstName: string, lastName: string, officeId: number) => void; // Added office parameter
  loginUser: (username: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
  registerUser: (
    firstName: string,
    lastName: string,
    userName: string,
    email: string,
    password: string,
    address: string,
    officeId:number
  ) => Promise<void>;

};


type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const savedUser = localStorage.getItem("user");
    const savedToken = localStorage.getItem("token");
    if (savedUser && savedToken) {
      const parsedUser = JSON.parse(savedUser) as UserProfile;
      setUser(parsedUser);
      setToken(savedToken);
      axios.defaults.headers.common["Authorization"] = `Bearer ${savedToken}`;
    }
    setIsReady(true);
  }, []);

  const handleAuthSuccess = (token: string, userData: UserProfile) => {
    localStorage.setItem("token", token);
    localStorage.setItem("user", JSON.stringify(userData));
    setToken(token);
    setUser(userData);
    axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  };

  const registerUsers = async (
    email: string,
    username: string,
    password: string,
    address: string,
    firstName: string,
    lastName: string,
    officeId: number // Added office parameter
  ) => {
    try {
      const res = await registerAPI(email, username, password, address, firstName, lastName, officeId); // Pass office to registerAPI
      if (res?.data) {
        const userObj: UserProfile = {
          userName: res.data.userName,
          email: res.data.email,
          address: res.data.address,
          firstName: res.data.firstName,
          lastName: res.data.lastName,
          officeId: res.data.officeId // Include office in the user object
        };
  
        handleAuthSuccess(res.data.token, userObj);
        toast.success("Registration successful!");
        navigate("../login");
      }
    } catch (error) {
      console.error("Registration error:", error);
      toast.warning("Server error occurred during registration.");
    }
  };

  const loginUser = async (username: string, password: string) => {
    try {
      const res = await loginAPI(username, password);
      if (res?.data) {
        const userObj: UserProfile = {
          userName: res.data.userName,
          email: res.data.email,
          address: res.data.address,
          firstName: res.data.firstName,
          lastName: res.data.lastName,
          officeId: res.data.officeId // Include office in the user object on login
        };
        handleAuthSuccess(res.data.token, userObj);
        toast.success("Login successful!");
        navigate("/Page");
      }
    } catch (error) {
      console.error("Login error:", error);
      toast.warning("Server error occurred during login.");
    }
  };

  const isLoggedIn = () => !!user;

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken(null);
    delete axios.defaults.headers.common["Authorization"];
    navigate("/");
  };

  const registerUser = useCallback(
    async (firstName: string, lastName: string, userName: string, email: string, password: string, address: string,officeId:number) => {
      const response = await axiosInstance.post('Account/Register', {
        firstName,
        lastName,
        userName,
        email,
        password,
        address,
        officeId
      });
      console.log('Register Result:', response);
      toast.success('Register Was Successfull. Please Login.');
      navigate("/Page");
    },
    []
  );
 

  return (
    <UserContext.Provider value={{ loginUser, user, token, logout, isLoggedIn, registerUsers,registerUser, }}>
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = (): UserContextType => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useAuth must be used within a UserProvider");
  }
  return context;
};


