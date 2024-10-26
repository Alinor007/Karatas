import React, { useEffect, useState } from 'react';
import { OfficeGet } from '../../Models/Office';
import { officePostAPI,officeGetAPI } from "../../Services/OfficeService";
import { toast } from "react-toastify";
import axios from 'axios';
import { useParams } from 'react-router-dom';
import axiosInstance from '../../utils/axiosInstance';




const Offices = () => {

  const { Symbol } = useParams<{ Symbol: string }>(); // Extract Symbol from route parameters
  const [offices, setOffices] = useState<OfficeGet[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  
  const getMyMessages = async () => {
    try {
      setLoading(true);
      const response = await axiosInstance.get<OfficeGet[]>(MY_MESSAGE_URL);
      const { data } = response;
      setOffices(data);
      setLoading(false);
    } catch (error) {
      toast.error('An Error happened. Please Contact admins');
      setLoading(false);
    }
  };


  // Fetch office data when component mounts
  useEffect(() => {
    if (Symbol) {
      const fetchOffices = async () => {
        setLoading(true);
        try {
          const data = await officeGetAPI(Symbol);
          if (data) {
            setOffices([data]);
          } else {
            toast.error("No data found.");
          }
        } catch (error) {
          toast.error("Failed to fetch office data.");
        } finally {
          setLoading(false);
        }
      };
      fetchOffices();
    }
  }, [Symbol]);


  return (
    <div className="overflow-x-auto">
       {loading ? (
        <p>Loading...</p>
      ) : (
    <table className="min-w-full border border-gray-300">
      <thead>
        <tr className="bg-gray-200">
          <th className="border border-gray-300 px-4 py-2">Name</th>
          <th className="border border-gray-300 px-4 py-2">Description</th>
          <th className="border border-gray-300 px-4 py-2">Date Created</th>
        </tr>
      </thead>
      <tbody>
      {offices.map((office, index) => (
          <tr >
            <td className="border border-gray-300 px-4 py-2">Dean</td>
            <td className="border border-gray-300 px-4 py-2">CICS Dean</td>
            <td className="border border-gray-300 px-4 py-2">january 12 ,2020</td>
          </tr>
   ))}
      </tbody>
    </table>
       )}
  </div>
  )
}

export default Offices
