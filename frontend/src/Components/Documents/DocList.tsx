import React, { useEffect, useState } from 'react';
import { IoSearch } from "react-icons/io5";
import { Document } from '../../Models/Document';
import { api } from '../../Service/DocumentApi';

type Props = {}

function DocList({}: Props) {
  const [documents, setDocuments] = useState<Document[]>([]);
  const [error, setError] = useState<string>('');
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);
  const [file, setFile] = useState<File | null>(null);
  const [newDoc, setNewDoc] = useState({
 name: '',
    description: ''
  });

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
  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setFile(e.target.files[0]);
    }
  };

  const createDocument = async () => {
    try {
      const formData = new FormData();
      formData.append("name", newDoc.name);
      formData.append("description", newDoc.description);
      
      // Append file if selected
      if (file) {
        formData.append("file", file);
      }
  
      // Make the API call with FormData
      const createdDoc = await api.createDocuments(formData);
      setDocuments([...documents, createdDoc]);
      setShowModal(false);
      setNewDoc({ name: '', description: '' });
      setFile(null); // Reset the file input
    } catch (err) {
      console.error("Error creating document:", err);
      setError("Failed to create document");
    }
  };

  return (
    <div className="flex-1 p-6">
      <h1 className="text-3xl font-bold mb-11">Document Information</h1>
      
      {/* Add button to open modal */}
      <button
        onClick={() => setShowModal(true)}
        className="mb-4 px-4 py-2 bg-indigo-600 text-white rounded-full "
      >
        Add New Document
      </button>

      {/* Search and Pagination Controls */}
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
            <span className="px-3">Page 1 of 10</span>
            <button className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200">Next</button>
          </div>
        </div>

        {/* Loading, Error, and Document Table */}
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
                  <td className="px-4 py-2 border-b">{doc.title}</td>
                  <td className="px-4 py-2 border-b">{doc.type}</td>
                  <td className="px-4 py-2 border-b">{doc.status ? 'Approved' : 'Pending'}</td>
                  <td className="px-4 py-2 border-b">{doc.owner}</td>
                  <td className="px-4 py-2 border-b">{new Date(doc.created).toLocaleDateString()}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

     {showModal && (
        <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
          <div className="bg-white p-6 rounded-md w-1/3">
            <h2 className="text-xl font-semibold mb-4">Create New Document</h2>
            <input
              type="text"
              placeholder="Document Name"
              className="mb-2 p-2 border w-full"
              value={newDoc.name}
              onChange={(e) => setNewDoc({ ...newDoc, name: e.target.value })}
            />
            <input
              type="text"
              placeholder="Document Description"
              className="mb-2 p-2 border w-full"
              value={newDoc.description}
              onChange={(e) => setNewDoc({ ...newDoc, description: e.target.value })}
            />
            <input type="file" onChange={handleFileChange} className="mb-2 p-2 border" />
            <div className="mt-4 flex justify-end">
              <button
                onClick={() => setShowModal(false)}
                className="px-4 py-2 mr-2 bg-gray-300 rounded"
              >
                Cancel
              </button>
              <button
                onClick={createDocument}
                className="px-4 py-2 bg-indigo-600 text-white rounded"
              >
                Save
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default DocList;
