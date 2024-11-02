import React, { useState } from 'react';
import { useForm, Controller } from 'react-hook-form';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import { CreateOfficeDTO } from '../../Models/Office';
import { api } from '../../Service/OfficeApi';
import { toast } from 'react-toastify';

const validationSchema = Yup.object().shape({
  name: Yup.string().required('Office name is required'),
  stage: Yup.string().required('Stage is required'),
  description: Yup.string().required('Description is required'),
});

const OfficeForm = () => {
  const { control, handleSubmit, formState: { errors }, reset } = useForm<CreateOfficeDTO>({
    resolver: yupResolver(validationSchema),
    defaultValues: {
      name: '',
      stage: '',
      description: '',
    },
  });

  const [loading, setLoading] = useState(false);

  const onSubmit = async (data: CreateOfficeDTO) => {
    setLoading(true);
    try {
      await api.createOffice(data);
      toast.success('Office created successfully!');
      reset(); // Reset form after successful submission
    } catch (error) {
      toast.error('Failed to create office. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen">
      <form onSubmit={handleSubmit(onSubmit)} className="bg-white shadow-lg rounded px-8 pt-6 pb-8 mb-4 w-full max-w-md">
        <h2 className="text-2xl font-bold mb-6 text-center">Create New Office</h2>
        
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2">Name</label>
          <Controller
            name="name"
            control={control}
            render={({ field }) => (
              <input {...field} className="w-full px-3 py-2 border rounded" />
            )}
          />
          {errors.name && <p className="text-red-500 text-xs mt-2">{errors.name.message}</p>}
        </div>

        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2">Stage</label>
          <Controller
            name="stage"
            control={control}
            render={({ field }) => (
              <input {...field} className="w-full px-3 py-2 border rounded" />
            )}
          />
          {errors.stage && <p className="text-red-500 text-xs mt-2">{errors.stage.message}</p>}
        </div>

        <div className="mb-6">
          <label className="block text-gray-700 text-sm font-bold mb-2">Description</label>
          <Controller
            name="description"
            control={control}
            render={({ field }) => (
              <textarea {...field} className="w-full px-3 py-2 border rounded" rows={4}></textarea>
            )}
          />
          {errors.description && <p className="text-red-500 text-xs mt-2">{errors.description.message}</p>}
        </div>

        <div className="flex items-center justify-between">
          <button
            type="submit"
            disabled={loading}
            className={`w-full bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded ${loading && 'opacity-50 cursor-not-allowed'}`}
          >
            {loading ? 'Creating...' : 'Create Office'}
          </button>
        </div>
      </form>
    </div>
  );
};

export default OfficeForm;
