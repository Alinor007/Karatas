import React, { useState, useEffect } from "react";

interface IProps  {
  docCount: number;

  
};

const Dashboard : React.FC = () => {

  const [totalDocuments, setTotalDocuments] = useState(0);
  const [pendingDocuments, setPendingDocuments] = useState(0);
  const [totalUsers, setTotalUsers] = useState(0);

    // Function to fetch data from the API
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5100/api/document/total"); // Adjust the API endpoint
        const data = await response.json();
  
        // Assuming your API returns an object with these keys
        setTotalDocuments(data.totalDocuments);
        setPendingDocuments(data.pendingDocuments);
        setTotalUsers(data.totalUsers);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
  
    // Use useEffect to call the API when the component mounts
    useEffect(() => {
      fetchData();
    }, []);

  return (
    <div className="flex-1 p-6  ">
      <h1 className="text-3xl font-bold mb-4 ">Document Tracker Dashboard</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        {/* Total Documents */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-2  text-indigo-800">Total Documents</h3>
          <p className="text-3xl font-bold text-indigo-600">301</p>
          <p className="text-gray-600">Documents tracked in the system</p>
        </div>
        {/* Pending Approvals */}
             
            <div className="bg-white p-6 shadow rounded-3xl "> 
              <div className="bg-indigo-600 flex-row-reverse"/>    
              <h3 className="text-sm font-semibold mb-2  text-indigo-800">Pending Approvals</h3>
              <p className="text-3xl font-bold  text-indigo-600">15</p>
              <p className="text-gray-600">Documents awaiting approval</p>
            </div>       
             {/* Pending Approvals */}
             
             <div className="bg-white p-6 shadow rounded-3xl "> 
              <div className="bg-indigo-600 flex-row-reverse"/>    
              <h3 className="text-sm font-semibold mb-2  text-indigo-800">Total of Users</h3>
              <p className="text-3xl font-bold  text-indigo-600">150</p>
              <p className="text-gray-600"></p>
            </div>        

        {/* Documents by Office */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-2  text-indigo-800">Documents by Office</h3>
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
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-1 gap-3 mt-4">
         {/* Recent Activity */}
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-4">User Table</h3>
          <ul className="text-gray-600">
            <li>Alinor</li>
            <li>Mudag </li>
            <li>Hasanor </li>
          </ul>
        </div>
    
      </div>
    </div>
  )
}

export default Dashboard