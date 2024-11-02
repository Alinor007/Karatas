import axios from 'axios';

const HOST_API_KEY  = "http://localhost:5100/api/";

const axiosInstance = axios.create({ 
  baseURL: HOST_API_KEY ,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add request interceptor for better error handling
axiosInstance.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, (error) => {
  return Promise.reject(error);
});

// Add response interceptor for better error handling
axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Error:', error.response);
    if (error.response?.status === 500) {
      // Log internal server errors for debugging
      console.error('Internal Server Error:', error.response.data);
    }
    return Promise.reject(error);
  }
);

export default axiosInstance;
