import axios from "axios";
import { Document, DocumentPost, UpdateDocument } from "../Models/Document";

const API_BASE_URL = "http://localhost:5100/api";

export interface PaginatedResponse<T> {
  data: T[];
  totalCount: number;
  currentPage: number;
  pageSize: number;
  totalPages: number;
}

export const api = {
  // Upload File for a Specific Document
  uploadFile: async (id: number, formData: FormData): Promise<void> => {
    await axios.post(`${API_BASE_URL}/Documents/${id}/upload`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  // Retrieve All Documents with Pagination
  getAllDocuments: async (
    page: number = 1,
    pageSize: number = 10
  ): Promise<PaginatedResponse<Document>> => {
    const response = await axios.get(
      `${API_BASE_URL}/Documents?page=${page}&pageSize=${pageSize}`
    );
    return response.data;
  },

  // Retrieve a Document by ID
  getDocumentById: async (id: number): Promise<Document> => {
    const response = await axios.get(`${API_BASE_URL}/Documents/${id}`);
    return response.data;
  },

  // Create a New Document
  createDocument: async (document: DocumentPost): Promise<Document> => {
    const response = await axios.post(`${API_BASE_URL}/Documents/Add`, document, {
      headers: { "Content-Type": "application/json" },
    });
    return response.data;
  },

  // Update an Existing Document
  updateDocument: async (
    id: number,
    document: UpdateDocument
  ): Promise<Document> => {
    const response = await axios.put(`${API_BASE_URL}/Documents/${id}`, document, {
      headers: { "Content-Type": "application/json" },
    });
    return response.data;
  },

  // Delete a Document
  deleteDocument: async (id: number): Promise<void> => {
    await axios.delete(`${API_BASE_URL}/Documents/${id}`);
  },
};
