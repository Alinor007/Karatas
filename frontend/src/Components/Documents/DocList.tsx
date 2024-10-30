import React, { useEffect, useState } from 'react';
import { IoSearch } from "react-icons/io5";
import { Document } from '../../Models/Document';
import { api } from '../../Service/DocumentApi';

type Props = {}

function DocList({}: Props) {
  const [documents, setDocuments] = useState<Document[]>([]);
  const [error, setError] = useState<string>('');
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchDocuments();
  }, []);

  const fetchDocuments = async () => {
    try {
      const data = await api.getAllDocuments();
      setDocuments(data);
    } catch (err) {
      console.error("Error fetching documents:", err);
      setError('Failed to fetch documents');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex-1 p-6">
      <h1 className="text-3xl font-bold mb-11">Document Information</h1>
      <div className="text-center text-sm">
        <div className="py-2 flex justify-between">
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

        {loading ? (
          <p>Loading...</p>
        ) : error ? (
          <p className="text-red-500">{error}</p>
        ) : (
          <table className="min-w-full bg-stone-100 border mt-9 rounded-lg">
            <thead>
              <tr>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Control Number</th>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Type</th>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Status</th>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Owner</th>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Created Date</th>
              </tr>
            </thead>
            <tbody>
              {documents.map((doc) => (
                <tr key={doc.id}>
                  <td className="px-4 py-2 border-b">{doc.name}</td>
                  <td className="px-4 py-2 border-b">{doc.status}</td>
                  <td className="px-4 py-2 border-b">{doc.status ? 'Approved' : 'Pending'}</td>
                  <td className="px-4 py-2 border-b">{doc.userId}</td>
                  <td className="px-4 py-2 border-b">{new Date(doc.created).toLocaleDateString()}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>
    </div>
  );
}

export default DocList;
