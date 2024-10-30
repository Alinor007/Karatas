import React from 'react';
import { IoSearch } from 'react-icons/io5';
import { RiSearchEyeLine } from 'react-icons/ri';
import { TiPlus } from 'react-icons/ti';

type Props = {};

function ManageUser({}: Props) {
  return (
    <div className="flex-1 p-6">
      <h1 className="text-3xl font-bold mb-11">Manage Users</h1>
      <div className="text-center text-sm">

      <div className="py-2 flex justify-center content-center mb-5 items-center">
      <div className="relative w-1/2">
            <IoSearch className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-500 text-2xl" />
            <input
              type="text"
              placeholder="Search by Control Number, Type, or Owner"
              className="border border-gray-300 rounded-full px-10 py-2 w-full pr-10 text-sm shadow-md"
              aria-label="Search Users"
            />
          </div>
      </div>
        <div className="py-2 flex justify-between items-center">
        <div className="flex items-center space-x-2 border-indigo-500 border-2 rounded-full ml-4">
            <button className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200">
              Previous
            </button>
            <span className="px-3">Page 1 of 10</span> {/* Update based on dynamic data */}
            <button className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200">
              Next
            </button>
          </div>

         

          {/* Pagination Controls */}
          
          {/* Add Button */}
          <button className="flex items-center border-gray-400 border-2 p-1 rounded-3xl mr-4">
            Add <TiPlus className="ml-1" aria-hidden="true" />
          </button>
        </div>

        {/* Table */}
        <table className="min-w-full bg-stone-100 border mt-9 rounded-lg">
          <thead>
            <tr>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">User ID</th>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Username</th>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Email</th>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Office</th>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Created Date</th>
              <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Action</th>
            </tr>
          </thead>
          <tbody>
            {/* Example row, replace with dynamic data */}
            <tr>
              <td className="px-4 py-2 border-b">DCN-00123</td>
              <td className="px-4 py-2 border-b">Juan Dela Cruz</td>
              <td className="px-4 py-2 border-b">Jua@example.com</td>
              <td className="px-4 py-2 border-b">Office of the Dean</td>
              <td className="px-4 py-2 border-b">2023-10-01</td>
              <td className="px-4 py-2 border-b">
                <a href="#" className="text-indigo-500 flex items-center space-x-1" aria-label="View Details">
                  <RiSearchEyeLine className="text-xl" />
                  <span>View</span>
                </a>
              </td>
            </tr>
            {/* Add more rows as needed */}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default ManageUser;
