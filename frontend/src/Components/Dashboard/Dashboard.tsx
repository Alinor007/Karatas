import React, { useState, useEffect } from "react";
import { Outlet } from "react-router";
import Tile from "../Tile/Tile";

interface Props  {
 
};

const Dashboard =({}: Props) => {

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

        <Tile title="Total Documents" subTitle="301"></Tile>
        <Tile title="Pending Approvals" subTitle="15"></Tile>
        <Tile title="Total of Users" subTitle="159"></Tile>
        <Tile title="Total Office" subTitle="11"></Tile>
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