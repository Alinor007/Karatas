import React, { useEffect, useState } from "react";
import { IoSearch } from "react-icons/io5";
import { Document, DocumentPost } from "../../Models/Document";
import { api } from "../../Service/DocumentApi";
import { useAuth } from '../../Context/authContext'; // Example path to AuthContext

type Props = {};


function DocList({}: Props) {
  const [documents, setDocuments] = useState<Document[]>([]);
  const [error, setError] = useState<string>("");
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);
  const { user } = useAuth();
  const [newDoc, setNewDoc] = useState<{ title: string; status: number; type: number }>({
    title: "",
    status: 1,
    type: 1,
  });

  const [pagination, setPagination] = useState({
    totalCount: 0,
    currentPage: 1,
    pageSize: 10,
    totalPages: 1,
  });

  const statusMap: { [key: number]: "Draft" | "Pending" | "Approved" | "Rejected" } = {
    1: "Draft",
    2: "Pending",
    3: "Approved",
    4: "Rejected",
  };

  const typeMap: { [key: number]: "Contract" | "Invoice" | "Report" | "Proposal" } = {
    1: "Contract",
    2: "Invoice",
    3: "Report",
    4: "Proposal",
  };

  useEffect(() => {
    fetchDocuments();
  }, [pagination.currentPage]);

  const fetchDocuments = async () => {
    try {
      setLoading(true);
      console.log( "Current  user:" ,user?.userName); // Access user details 
      const response = await api.getAllDocuments(pagination.currentPage, pagination.pageSize);
       console.log("API  Response:", response);
      setPagination({
        totalCount: response.totalCount,
        currentPage: response.currentPage,
        pageSize: response.pageSize,
        totalPages: response.totalPages,
      });
      setDocuments(response.data);
    } catch (err) {
      console.error("Error fetching documents:", err);
      setError("Failed to fetch documents");
    } finally {
      setLoading(false);
    }
  };
  console.log("API documents Response:", documents);

  const createDocument = async () => {
    try {
      const newDocument: DocumentPost = {
        Title: newDoc.title,
        TrackingNumber: "AUTO_GENERATED", // Replace with actual logic
        Status: statusMap[newDoc.status],
        Type: typeMap[newDoc.type],
        OwnerId: "current_user_id", // Replace with logic to fetch current user
        DateCreated: new Date().toISOString(),
      };

      const createdDoc = await api.createDocument(newDocument);
      setDocuments((prev) => [...prev, createdDoc]);
      setShowModal(false);
      setNewDoc({ title: "", status: 1, type: 1 });
    } catch (err) {
      console.error("Error creating document:", err);
      setError("Failed to create document");
    }
  };

  const handlePagination = (direction: "previous" | "next") => {
    setPagination((prev) => ({
      ...prev,
      currentPage: direction === "previous" ? prev.currentPage - 1 : prev.currentPage + 1,
    }));
  };

  return (
    <div className="flex-1 p-6">
      <h1 className="text-3xl font-bold mb-11">Document Information</h1>

      <button
        onClick={() => setShowModal(true)}
        className="mb-4 px-4 py-2 bg-indigo-600 text-white rounded-full"
      >
        Add New Document
      </button>

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
          <div className="flex items-center ml-4 space-x-2 border-indigo-500 border-2 rounded-full">
            <button
              onClick={() => handlePagination("previous")}
              className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200"
              disabled={pagination.currentPage === 1}
            >
              Previous
            </button>
            <span className="px-3">Page {pagination.currentPage}</span>
            <button
              onClick={() => handlePagination("next")}
              className="px-3 py-1 border rounded-full text-sm bg-gray-100 hover:bg-gray-200"
              disabled={pagination.currentPage === pagination.totalPages}
            >
              Next
            </button>
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
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Title</th>
                <th className="px-4 py-2 border-b border-indigo-600 text-indigo-700">Tracking Number</th>
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
                  <td className="px-4 py-2 border-b">{doc.trackingNumber}</td>
                  <td className="px-4 py-2 border-b">{doc.type}</td>
                  <td className="px-4 py-2 border-b">{doc.status}</td>
                  <td className="px-4 py-2 border-b">{doc.ownerId}</td>
                  <td className="px-4 py-2 border-b">{new Date(doc.dateCreated).toLocaleDateString()}</td>
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
              placeholder="Document Title"
              className="mb-2 p-2 border w-full"
              value={newDoc.title}
              onChange={(e) => setNewDoc({ ...newDoc, title: e.target.value })}
            />
            <select
              value={newDoc.status}
              onChange={(e) => setNewDoc({ ...newDoc, status: Number(e.target.value) })}
              className="mb-2 p-2 border w-full"
            >
              <option value={1}>Draft</option>
              <option value={2}>Pending</option>
              <option value={3}>Approved</option>
              <option value={4}>Rejected</option>
            </select>
            <select
              value={newDoc.type}
              onChange={(e) => setNewDoc({ ...newDoc, type: Number(e.target.value) })}
              className="mb-2 p-2 border w-full"
            >
              <option value={1}>Contract</option>
              <option value={2}>Invoice</option>
              <option value={3}>Report</option>
              <option value={4}>Proposal</option>
            </select>
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
