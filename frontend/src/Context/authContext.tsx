import { createContext, useEffect, useState, useContext, useCallback } from "react";
import { UserProfile } from "../Models/Auth";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../Service/AuthService";
import { toast } from "react-toastify";
import { FaCheckCircle } from "react-icons/fa";
import axios from "axios";
import React from "react";

type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  registerUser: (firstName: string, lastName: string, userName: string, email: string, password: string, address: string, officeId:number) => void; // Added office parameter
  loginUser: (username: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
 

};


type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);


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

  // const handleAuthSuccess = (token: string, userData: UserProfile) => {
  //   localStorage.setItem("token", token);
  //   localStorage.setItem("user", JSON.stringify(userData));
  //   setToken(token);
  //   setUser(userData);
  //   axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  // };

  const registerUser = async (
    firstName: string,
    lastName: string,
    userName: string,
    email: string,
    password: string,
    address: string,
    officeId:number
  ) => {
    await registerAPI( firstName, lastName, userName,email, password, address, officeId)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          const userObj = {
            firstName: res.data.firstName,
            lastName: res.data.lastName,
            userName: res.data.userName,
            email: res.data.email,
            address: res.data.address,
            officeId:res.data.officeId
          };
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token!);
          setUser(userObj!);
          toast.success("Register successful!");
          navigate("../login");
        }
      })
      .catch((e) => toast.warning("Server error occured"));
  };

  const loginUser = async (username: string, password: string) => {
    try {
      const res = await loginAPI(username, password);
      if (res?.data) {
        const userObj: UserProfile = {
          firstName: res.data.firstName,
          lastName: res.data.lastName,
          userName: res.data.userName,
          email: res.data.email,
          address: res.data.address,
          officeId:res.data.officeId
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(res?.data.token!);
        setUser(userObj!);
        toast.success("Login Success!", {
          icon: <div style={{ fontSize: "16px",display:"flex"  }}><FaCheckCircle/></div>, // Adjust fontSize as needed
        
        });
        navigate("/Page");
      }
    } catch (error) {
      console.error("Login error:", error);
      toast.warning("Server error occurred during login.");
    }
  };

  const isLoggedIn = () => {
    return !!user && !!token;
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken("");
    delete axios.defaults.headers.common["Authorization"];
    navigate("/");
  };

  
 
  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);

