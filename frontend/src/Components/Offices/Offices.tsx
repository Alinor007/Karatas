import React, { useEffect, useState } from 'react';
import { OfficeGet } from '../../Models/Office';
import { officePostAPI,officeGetAPI } from "../../Services/OfficeService";
import { toast } from "react-toastify";
import axios from 'axios';


type Props = {
  Symbol: string;
};

type OfficeFormInputs = {
  name: string;
  description: string;
};


const Offices= ({ Symbol }: Props) => {

  const [messages, setMessages] = useState<OfficeGet[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  const getMyMessages = async () => {
    try {
      setLoading(true);
      const response = await axios.get<OfficeGet[]>(api + `${symbol}`, {
        name: name,
        discription: discription,
      });
      const { data } = response;
      setMessages(data);
      setLoading(false);
    } catch (error) {
      toast.error('An Error happened. Please Contact admins');
      setLoading(false);
    }
  };

  useEffect(() => {
    getMyMessages();
  }, []);


 

  return (
    <div className="overflow-x-auto">
    <table className="min-w-full border border-gray-300">
      <thead>
        <tr className="bg-gray-200">
          <th className="border border-gray-300 px-4 py-2">Name</th>
          <th className="border border-gray-300 px-4 py-2">Description</th>
          <th className="border border-gray-300 px-4 py-2">Date Created</th>
        </tr>
      </thead>
      <tbody>
        
          <tr >
            <td className="border border-gray-300 px-4 py-2">Dean</td>
            <td className="border border-gray-300 px-4 py-2">CICS Dean</td>
            <td className="border border-gray-300 px-4 py-2">january 12 ,2020</td>
          </tr>

      </tbody>
    </table>
  </div>
  )
}

export default Offices

function setLoading(arg0: boolean) {
    throw new Error('Function not implemented.');
  }
