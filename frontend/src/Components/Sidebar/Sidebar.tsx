import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { MdOutlineKeyboardArrowRight } from "react-icons/md";
import { SlGraph } from "react-icons/sl";
import { IoDocuments,IoTrash } from "react-icons/io5";
import { ImUsers,ImHistory } from "react-icons/im";
import { BiSolidDashboard } from "react-icons/bi";
import { HiMiniBuildingOffice2 } from "react-icons/hi2";
import Logo from "../../Logo-.png"; // Make sure the path is correct

type Props = {};

const Sidebar = (props: Props) => {
  const [open, setOpen] = useState(true);
  const location = useLocation(); // Get the current route

  const isActive = (path: string) => location.pathname === path;


  return (
    <div className="flex">
      <div
        className={`${
          open ? "w-64" : "w-20"
        } h-screen duration-300 flex flex-col p-5 pt-8 bg-stone-100 shadow-sm relative`}>
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
        <div className="flex gap-x-4 items-center">
                <img src={Logo} alt="Logo" className={"w-16 cursor-pointer duration-300"} />
                <h1 className={`text-indigo-700 origin-left font-medium text-xl duration-300 ${!open && "scale-0"}`}>
                Karatas
                </h1>
        </div>
       
        {/* Add your sidebar links/icons below */}
        <nav className="mt-10 justify-between content-center text-gray-500 text-sm">
        <Link
            to="/"
            className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
              isActive("/") ? "font-medium text-indigo-900" : ""
            }`}
          ><BiSolidDashboard />{open && <span>Dashboard</span>}
        </Link>
       <Link 
            to="/table"
            className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
                isActive("/documents") ? "font-medium text-indigo-900" : ""
              }`}
            > <IoDocuments />{open && <span>Documents</span>}
          </Link>
          <Link 
                to="/users" 
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
                    isActive("/manageUser") ? "font-medium text-indigo-900" : ""
                  }`}><ImUsers />{open && <span>Manage Users</span>}
          </Link>
          <Link to="/recycleBin"
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
                    isActive("/recycleBin") ? "font-medium text-indigo-900" : ""
                  }`}><IoTrash /> {open && <span>Recycle bin</span>}
          </Link>
          <Link to="/history"
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
                    isActive("/history") ? "font-medium text-indigo-900" : ""
                  }`}><ImHistory /> {open && <span>Histories</span>}
          </Link>
          <Link to="/offices"
                className={`flex items-center gap-2 p-2 hover:bg-indigo-200 rounded-lg ${
                    isActive("/Offices") ? "font-medium text-indigo-900" : ""
                  }`}><HiMiniBuildingOffice2 /> {open && <span>Offices</span>}
          </Link>
        </nav>
      </div>

      <div className="p-4">HOMEPAGE</div>
    </div>
  );
};

export default Sidebar;
