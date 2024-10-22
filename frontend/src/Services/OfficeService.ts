import axios from "axios";
import { OfficeGet, OfficePost } from "../Models/Office";
import { handleError } from "../Helpers/ErrorHandler";

const api = "http://localhost:5100/api/office/";

export const officePostAPI = async (
  name: string,
  discription: string,
  symbol: string
) => {
  try {
    const data = await axios.post<OfficePost>(api + `${symbol}`, {
      name: name,
      discription: discription,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const officeGetAPI = async (symbol: string) => {
  try {
    const data = await axios.get<OfficeGet>(api + `?Symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};