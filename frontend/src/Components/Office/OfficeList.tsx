import React, { useEffect, useState } from 'react';
import { Office } from '../../Models/Office';
import { api } from '../../Service/OfficeApi';

type Props = {}

export const OfficeList = (props: Props) => {
  const [offices, setOffices] = useState<Office[]>([]);
  const [error, setError] = useState<string>('');
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchOffices();
  }, []);

  const fetchOffices = async () => {
    try {
      const data = await api.getAllOffices();
      setOffices(data);
    } catch (err) {
      console.error("Error fetching offices:", err); // Log the full error
      setError('Failed to fetch offices');
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await api.deleteOffice(id);
      setOffices(offices.filter(office => office.id !== id));
    } catch (err) {
      setError('Failed to delete office');
    }
  };

  if (loading) return <div>Loading...</div>;
  if (error) return <div className="text-red-500">Error: {error}</div>;

  return (
    <div className="space-y-4">
      <h2 className="text-xl font-bold">Offices</h2>
      <div className="grid gap-4">
        {offices.map((office) => (
          <div key={office.id} className="border p-4 rounded shadow">
            <h3 className="font-bold">{office.name}</h3>
            <p className="text-gray-600">Stage: {office.stage}</p>
            <p className="text-gray-600">{office.description}</p>
            <p className="text-sm text-gray-500">
              Last updated: {new Date(office.updated).toLocaleDateString()}
            </p>
            <button
              onClick={() => handleDelete(office.id)}
              className="mt-2 bg-red-500 text-white px-3 py-1 rounded text-sm hover:bg-red-600"
            >
              Delete
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};