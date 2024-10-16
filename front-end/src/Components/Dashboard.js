// src/Components/Dashboard.js
import React from 'react';

function Dashboard() {
  return (
    <div className="flex flex-col items-center justify-center w-full h-screen bg-gray-100">
      <h1 className="text-4xl font-bold text-gray-700">Dashboard</h1>
      <p className="mt-4 text-lg text-gray-500">Welcome to your dashboard!</p>

      {/* Example cards or sections */}
      <div className="grid grid-cols-1 gap-8 mt-8 lg:grid-cols-3">
        <div className="p-6 bg-white shadow-md rounded-xl">
          <h2 className="text-xl font-semibold">Documents</h2>
          <p className="mt-2 text-gray-500">View your app Documents here.</p>
        </div>
        <div className="p-6 bg-white shadow-md rounded-xl">
          <h2 className="text-xl font-semibold">Transactions</h2>
          <p className="mt-2 text-gray-500">Manage your users here.</p>
        </div>
        <div className="p-6 bg-white shadow-md rounded-xl">
          <h2 className="text-xl font-semibold">History</h2>
          <p className="mt-2 text-gray-500">Configure your app History.</p>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
