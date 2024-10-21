import React from "react";
import { Outlet } from "react-router-dom";

type Props = {}

const Dashboard = (props: Props) => {
  return (
    <div className="flex-1 p-6  ">
      <h1 className="text-lg font-bold mb-4">Document Tracker Dashboard</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        {/* Total Documents */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-2">Total Documents</h3>
          <p className="text-3xl font-bold">320</p>
          <p className="text-gray-600">Documents tracked in the system</p>
        </div>
        {/* Pending Approvals */}
             
            <div className="bg-white p-6 shadow rounded-3xl "> 
              <div className="bg-indigo-600 flex-row-reverse"/>    
              <h3 className="text-sm font-semibold mb-2">Pending Approvals</h3>
              <p className="text-3xl font-bold">15</p>
              <p className="text-gray-600">Documents awaiting approval</p>
            </div>       
             {/* Pending Approvals */}
             
             <div className="bg-white p-6 shadow rounded-3xl "> 
              <div className="bg-indigo-600 flex-row-reverse"/>    
              <h3 className="text-sm font-semibold mb-2">Total of Users</h3>
              <p className="text-3xl font-bold">150</p>
              <p className="text-gray-600"></p>
            </div>        

        {/* Documents by Office */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-2">Documents by Office</h3>
          <p className="text-sm font-medium ">Department Office: 30</p>
          <p className="text-sm font-medium ">Extension Office: 45</p>
          <p className="text-sm font-medium ">Dean Office: 45</p>
          <p className="text-sm font-medium ">President Office: 45</p>

        </div>

       
      </div>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-2 gap-3 mt-4">
         {/* Recent Activity */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-4">Recent Activity</h3>
          <ul className="text-gray-600">
            <li>Document 123 approved by Dean</li>
            <li>Document 124 submitted by Chairperson</li>
            <li>Document 125 reviewed by President</li>
          </ul>
        </div>
         {/* Status Breakdown */}
         <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-4">Status Breakdown in chart</h3>
          <p className="text-sm font-medium">Approved: 200</p>
          <p className="text-sm font-medium">In Review: 75</p>
          <p className="text-sm font-medium">Rejected: 45</p>
        </div>
      </div>
    </div>
  )
}

export default Dashboard