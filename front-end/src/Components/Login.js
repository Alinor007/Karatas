import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import axios from 'axios';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();  // Hook to navigate programmatically

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:5001/api/auth/login', {
        email,
        password
      });

      localStorage.setItem('token', response.data.token);  // Store token
      navigate('/dashboard');  // Redirect to dashboard
    } catch (err) {
      setError('Login failed. Please check your email or password.');
    }
  };

  return (
    <div className='px-10 py-20 bg-white border-gray-100 rounded-3xl'>
      <h1 className='text-5xl font-semibold'>Welcome back!</h1>
      <p className='mt-4 text-lg font-medium text-gray-500'>We're excited to see you again</p>

      <form className='mt-8' onSubmit={handleSubmit}>
        <div>
          <input
             className='w-full p-4 mt-5 bg-transparent border-b-4 border-gray-200 '
            placeholder='Email'
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            required
          />
        </div>
        <div>
          <input
            className='w-full p-4 mt-5 bg-transparent border-b-4 border-gray-200 '
            placeholder='Password'
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            type="password"
            required
          />
        </div>

        {error && <p className="mt-4 text-red-500">{error}</p>}

        <div className='flex flex-col mt-8 gap-y-4'>
          <button type="submit" className='py-3 text-lg text-white bg-violet-500 rounded-3xl'>
            Sign in
          </button>
        </div>

        <div className='flex justify-center mt-8 text-center'>
          <p className='text-base font-medium'>Don't have an account?</p>
          <button type="button" className='ml-2 text-base font-medium text-violet-500'>Sign Up</button>
        </div>
      </form>
    </div>
  );
}
