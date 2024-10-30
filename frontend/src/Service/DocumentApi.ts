import axios from "axios";
import { Document,DocumentPost,UpdateDocument } from "../Models/Document";

const API_BASE_URL = 'http://localhost:5100/api';


export const api = {
    getAllDocuments: async (): Promise<Document[]> => {
      const response = await axios.get(`${API_BASE_URL}/Documents`);
      return response.data;
    },
  
    getDocumentsById: async (id: number): Promise<Document> => {
      const response = await axios.get(`${API_BASE_URL}/Documents/${id}`);
      return response.data;
    },
  
    createDocuments: async (documents: DocumentPost): Promise<Document> => {
      const response = await axios.post(`${API_BASE_URL}/Documents`, documents);
      return response.data;
    },
  
    updateDocument: async (id: number, documents: UpdateDocument): Promise<Document> => {
      const response = await axios.put(`${API_BASE_URL}/Documents/${id}`, documents);
      return response.data;
    },
  
    deleteOffice: async (id: number): Promise<void> => {
      await axios.delete(`${API_BASE_URL}/Documents/${id}`);
    }
  };