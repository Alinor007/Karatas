import axios from 'axios';
import { Office, CreateOfficeDTO, UpdateOfficeDTO } from '../Models/Office';

const API_BASE_URL = 'http://localhost:5100/api';

export const api = {
  getAllOffices: async (): Promise<Office[]> => {
    const response = await axios.get(`${API_BASE_URL}/offices`);
    return response.data;
  },

  getOfficeById: async (id: number): Promise<Office> => {
    const response = await axios.get(`${API_BASE_URL}/offices/${id}`);
    return response.data;
  },

  createOffice: async (office: CreateOfficeDTO): Promise<Office> => {
    const response = await axios.post(`${API_BASE_URL}/offices`, office);
    return response.data;
  },

  updateOffice: async (id: number, office: UpdateOfficeDTO): Promise<Office> => {
    const response = await axios.put(`${API_BASE_URL}/offices/${id}`, office);
    return response.data;
  },

  deleteOffice: async (id: number): Promise<void> => {
    await axios.delete(`${API_BASE_URL}/offices/${id}`);
  }
};