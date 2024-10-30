import React from 'react'
import { IoSearch } from 'react-icons/io5'
import { RiSearchEyeLine } from "react-icons/ri";
import { GrTransaction } from "react-icons/gr";
import { Link } from 'react-router-dom';

type Props = {}

const Incoming = (props: Props) => {
  return (
    <div className=" flex-1 p-6  ">
    <div className='flex justify-between mb-11'>
    <h1 className="text-3xl font-bold  ">Incoming Documents </h1>
    <Link 
      to="Dashboard"
      className='mt-3 mr-6  text-white flex bg-indigo-700 p-1.5  rounded-lg shadow-lg'>
    <GrTransaction  className='mt-1 mr-3' /> Transaction history
    </Link>
    </div>
    <div className="text-center text-sm">
   
    
  <div className=" py-2 flex  justify-between">
    <div className="relative w-1/2">
    <IoSearch className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-500 text-2xl" />
      <input
        type="text"
        placeholder="Search by Control Number, Type, or Owner"
        className="border border-gray-300 rounded-full px-10 py-2 w-full pr-10 text-sm shadow-md"
      />
     
    </div>
    {/* Pagination Controls */}
    <div className="flex items-center ml-4 space-x-2 border-indigo-500 border-2 rounded-full">
      <button className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200">Previous</button>
      <span className="px-3">Page 1 of 10</span> {/* Update based on dynamic data */}
      <button className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200">Next</button>
    </div>
  </div>


  <table className="min-w-full bg-stone-100 border mt-9 rounded-lg hover:table-fixed">
  <thead>
    <tr>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700 ">Control Number</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Type</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Remark</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Comment</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Owner</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Created Date</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Document Location</th>
      <th className="px-4 py-2 border-b  border-indigo-600 text-indigo-700">Actions</th>

    </tr>
  </thead>
  <tbody>
    {/* Example row, replace with dynamic data */}
    <tr>
      <td className="px-2 py-2 border-b">DCN-00123</td>
      <td className="px-2 py-2 border-b">Policy</td>
      <td className="px-2 py-2 border-b">Declined</td>
      <td className="px-2 py-2 border-b">Need to revise</td>
      <td className="px-2 py-2 border-b">Juan Dela Cruz</td>
      <td className="px-2 py-2 border-b">2023-10-01</td>
      <td className="px-2 py-2 border-b">Office of the Extension</td>
      <td className="px-2 py-2 border-b relative justify-between align-middle h-1/2 text-indigo-500 ">
      <p className='py-2 mr-2 '>
        <a href="#">
        <RiSearchEyeLine className='mt-0.5 absolute' />
       View
        </a>
        </p>
        </td>

    </tr>
    <tr>
    <td className="px-2 py-2 border-b">DCN-00123</td>
      <td className="px-2 py-2 border-b">Policy</td>
      <td className="px-2 py-2 border-b">Declined</td>
      <td className="px-2 py-2 border-b">Need to revise</td>
      <td className="px-2 py-2 border-b">Juan Dela Cruz</td>
      <td className="px-2 py-2 border-b">2023-10-01</td>
      <td className="px-2 py-2 border-b">Office of the Extension</td>
      <td className="px-2 py-2 border-b relative justify-between align-middle h-1/2 text-indigo-500 ">
      <p className='py-2 mr-2 '>
        <a href="#">
        <RiSearchEyeLine className='mt-0.5 absolute' />
       View
        </a>
        </p>
        </td>

    </tr>
     <tr>
     <td className="px-2 py-2 border-b">DCN-00123</td>
      <td className="px-2 py-2 border-b">Leave</td>
      <td className="px-2 py-2 border-b">Declined</td>
      <td className="px-2 py-2 border-b">Need to revise</td>
      <td className="px-2 py-2 border-b">Juan Dela Cruz</td>
      <td className="px-2 py-2 border-b">2023-10-01</td>
      <td className="px-2 py-2 border-b">Office of the Extension</td>
      <td className="px-2 py-2 border-b relative justify-between align-middle h-1/2 text-indigo-500 ">
        <p className='py-2 mr-2 '>
          <a href="#">
          <RiSearchEyeLine className='mt-0.5 absolute' />
        View
          </a>
          </p>
          </td>
      </tr> 
    <tr>
    <td className="px-2 py-2 border-b">DCN-00123</td>
      <td className="px-2 py-2 border-b">Policy</td>
      <td className="px-2 py-2 border-b">Declined</td>
      <td className="px-2 py-2 border-b">Need to revise</td>
      <td className="px-2 py-2 border-b">Juan Dela Cruz</td>
      <td className="px-2 py-2 border-b">2023-10-01</td>
      <td className="px-2 py-2 border-b">Office of the Dean</td>
      <td className="px-2 py-2 border-b relative justify-between align-middle h-1/2 text-indigo-500 ">
      <p className='py-2 mr-2 '>
        <a href="#">
        <RiSearchEyeLine className='mt-0.5 absolute' />
       View
        </a>
        </p>
        </td>
    </tr>
    {/* Add more rows as needed */}
  </tbody>
</table>

</div>
</div>
  )
}

export default Incoming