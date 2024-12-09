import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { MdExpandLess, MdExpandMore, MdOutlineKeyboardArrowRight } from "react-icons/md";
import { IoDocuments,IoExitOutline,IoTrash } from "react-icons/io5";
import { ImUsers } from "react-icons/im";
import { BiSolidDashboard } from "react-icons/bi";
import { HiMiniBuildingOffice2 } from "react-icons/hi2";
import Logo from "../../Logo-.png"; 
import IconAdmin from "../../Assets/Admin Icon.png"
import { useAuth } from "../../Context/authContext";



type Props = {};

const Sidebar = (props: Props) => {
  const { isLoggedIn, user, logout } = useAuth();
  const [open, setOpen] = useState(true);
  const [documentsOpen, setDocumentsOpen] = useState(false); // State for Documents dropdown
  const [officesOpen, setOfficesOpen] = useState(false); // State for Offices dropdown
  const location = useLocation(); // Get the current route
  


  const isActive = (path: string) => location.pathname === path;


  return (
   
    <div className="flex ">
      <div
        className={`${
          open ? "w-64" : "w-20"
        } h-120 duration-300 flex flex-col p-5 pt-8 bg-stone-100 shadow-sm relative`}>
             <button
          className="absolute cursor-pointer text-lg bg-indigo-100 text-indigo-800 hover:bg-indigo-200 rounded-full -right-4 top-9 w-7 h-7 border-2 border-indigo-600 items-center justify-center"
          onClick={() => setOpen(!open)}
        >
          <MdOutlineKeyboardArrowRight
            className={`transform transition-transform duration-300 ${
              open ? "rotate-180" : ""
            }`}
          />
        </button>
        <div className="flex flex-col flex-grow">
        <div className="flex gap-x-4 items-center">
                <img src={Logo} alt="Logo" className={"w-16 cursor-pointer duration-300"} />
                <h1 className={`text-indigo-700 origin-left font-medium text-xl duration-300 ${!open && "scale-0"}`}>
                Karatas
                </h1>
        </div>
       
        {/* Add your sidebar links/icons below */}
        <nav className="mt-10 justify-between content-center text-gray-500 text-sm">
        <Link
            to="Dashboard"
            className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg hover:text-indigo-800${
              isActive("Dashboard") ? "font-medium text-indigo-900" : ""
            }`}
          ><BiSolidDashboard />{open && <span>Dashboard</span>}
        </Link>
        <div>
            <div
              className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg cursor-pointer ${
                isActive("/documents") ? "font-medium text-indigo-900" : ""
              }`}
              onClick={() => setDocumentsOpen(!documentsOpen)}
            >
              <IoDocuments />
              {open && (
                <>
                  <span>Documents</span>
                  {documentsOpen ? <MdExpandLess /> : <MdExpandMore />}
                </>
              )}
            </div>
            {documentsOpen && open && (
              <div className="pl-8 flex flex-col space-y-2 text-sm">
                <Link to="documents/create" className="hover:text-indigo-900 p-1 rounded-lg hover:bg-indigo-400">Pending </Link>
                <Link to="Incoming" className="hover:text-indigo-900 p-1 rounded-lg hover:bg-indigo-400">Incoming </Link>
                <Link to="DocumentList" className="hover:text-indigo-900 p-1 rounded-lg hover:bg-indigo-400">List</Link>
              </div>
            )}
          </div>
      
          <Link to="recycleBin"
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lghover:text-indigo-900 ${
                    isActive("/recycleBin") ? "font-medium text-indigo-900" : ""
                  }`}><IoTrash /> {open && <span>Recycle bin</span>}
          </Link>
          {/* <Link to="history"
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg hover:text-indigo-900 ${
                    isActive("/history") ? "font-medium text-indigo-900" : ""
                  }`}><ImHistory /> {open && <span>Histories</span>}
          </Link> */}
          <div>
            <div
              className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg cursor-pointer hover:text-indigo-900 ${
                isActive("/offices") ? "font-medium text-indigo-900" : ""
              }`}
              onClick={() => setOfficesOpen(!officesOpen)}
            >
              <HiMiniBuildingOffice2 />
              {open && (
                <>
                  <span>Offices</span>
                  {officesOpen ? <MdExpandLess /> : <MdExpandMore />}
                </>
              )}
            </div>
            {officesOpen && open && (
              <div className="pl-8 flex flex-col space-y-2">
                <Link to="AddOffice" className="hover:text-indigo-900 p-1 rounded-lg hover:bg-indigo-400">Create </Link>
                <Link to="Offices/" className="hover:text-indigo-900 p-1 rounded-lg hover:bg-indigo-400">List</Link>
              </div>
            )}
          </div>
          <div className="mt-9 border-gray-200 border-b-2 border-t-2">
          <Link 
                to="ManageUser" 
                className={`flex items-center p-2 hover:bg-indigo-200 rounded-lg hover:text-indigo-900 ${
                    isActive("/ManageUser") ? "font-medium text-indigo-900" : ""
                  }`}><ImUsers />{open && <span>Manage Users</span>}
          </Link>
            <a 
               onClick={logout}
            className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg hover:text-indigo-900 ${
                      isActive("/history") ? "font-medium text-indigo-900" : ""
                    }`}>
            <IoExitOutline />{open && <span>Logout</span>}
            </a>
 
          </div>
          
        </nav>
        </div>
        
      <footer className={`flex items-center pt-2 pb-2 ${open ? "space-x-4" : "justify-center"}`}>
      <img src={IconAdmin} alt="Admin Icon" className={`rounded-full ${open ? "h-12 w-12" : "w-8 h-8"}`} />
          {open && (
            <div>
              {isLoggedIn() ? (
                <p className="font-semibold text-sm">{user?.userName}</p>
              ) : (
                <p className="text-xs">{"You're not logged in"}</p>
              )}
            </div>
          )}
    </footer>
      </div>
     
    </div>
    
  );
};

export default Sidebar;
