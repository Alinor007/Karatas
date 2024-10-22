import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { DocumentGet, DocumentPost } from "../Models/Document";

const api = "http://localhost:5100/api/document/";

export const DocumentPostAPI = async (
    id: number,         // Assuming you'll want to include the id when retrieving documents
    name: string,
    description: string,  // This can represent some document description field
    symbol: string
) => {
  try {
    const data = await axios.post<DocumentPost>(api + `${symbol}`, {
      name: name,
      discription: description,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const DocumentGetAPI = async (symbol: string) => {
  try {
    const data = await axios.get<DocumentGet>(api + `?Symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
// PUT: Update an existing document
export const DocumentUpdateAPI = async (
  id: number,
  name: string,
  description: string,
  symbol: string
) => {
  try {
    const data = await axios.put<DocumentPost>(`${api}${id}`, {
      name: name,
      description: description, // Fixed typo from 'discription'
      symbol: symbol,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

// DELETE: Remove a document by ID
export const DocumentDeleteAPI = async (id: number) => {
  try {
    const data = await axios.delete(`${api}${id}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};

