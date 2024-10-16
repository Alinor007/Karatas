import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import axios from 'axios';

export default function Register() {
  const [name, setName] = useState('');  // For name input
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();  // Hook to navigate programmatically

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:5001/api/register', {
        name,       // Sending name to the registration endpoint
        email,
        password
      });

      localStorage.setItem('token', response.data.token);  // Store token
      navigate('/dashboard');  // Redirect to dashboard
    } catch (err) {
      setError('Registration failed. Please check your inputs.');
    }
  };

  return (
    <div className='px-10 py-20 bg-white border-gray-100 rounded-3xl'>
      <h1 className='text-5xl font-semibold'>Create an account</h1>
      <p className='mt-4 text-lg font-medium text-gray-500'>Please fill in the details</p>

      <form className='mt-8' onSubmit={handleSubmit}>
        <div>
          <label className='text-lg font-medium'>Full Name</label>
          <input
            className='w-full p-4 mt-5 bg-transparent border-2 border-gray-100 rounded-xl'
            placeholder='Enter your name'
            value={name}
            onChange={(e) => setName(e.target.value)}
            type="text"
            required
          />
        </div>
        <div>
          <label className='text-lg font-medium'>Email</label>
          <input
            className='w-full p-4 mt-5 bg-transparent border-2 border-gray-100 rounded-xl'
            placeholder='Enter your email'
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            required
          />
        </div>
        <div>
          <label className='text-lg font-medium'>Password</label>
          <input
            className='w-full p-4 mt-5 bg-transparent border-2 border-gray-100 rounded-xl'
            placeholder='Enter your password'
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            type="password"
            required
          />
        </div>

        {error && <p className="mt-4 text-red-500">{error}</p>}

        <div className='flex flex-col mt-5 gap-y-4'>
          <button type="submit" className='py-3 text-lg text-white bg-violet-500 rounded-xl active:scale-[.98] active:duration-75 hover:scale-[1.01] ease-in-out transition-all'>
            Sign Up
          </button>
        </div>

        <div className='flex justify-center mt-5 text-center'>
          <p className='text-base font-medium'>Already have an account?</p>
          <button type="button" className='ml-2 text-base font-medium text-violet-500'>Sign In</button>
        </div>
      </form>
    </div>
  );
}
