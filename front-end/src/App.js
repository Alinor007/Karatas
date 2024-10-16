import './App.css';
import logo from './DocTrackLogo.png'
import Login from './Components/Login';
import Dashboard from './Components/Dashboard';  // Import Dashboard component
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Register from './Components/Registration';

function App() {
  return (
    <Router>
      <div className="flex w-full h-screen">
        {/* <div className='flex items-center justify-center w-full lg:w-1/2'> */}
          <Routes>
            {/* <Route path="/" element={<Login />} /> */}
            {/* <Route path="/" element={<Register />} /> */}
                 <Route path="/" element={<Dashboard />} /> {/* Add dashboard route */}
          </Routes>
        </div>
      
        {/* <div className="relative items-center justify-center hidden w-1/2 h-full bg-gray-200 lg:flex">
          <div className='rounded-full w-60 h-60 bg-gradient-to-tr from-violet-500 to-pink-500 animate-pulse'>
          <img src={logo} alt="Logo" className='w-60 h-60'/>
          </div>
          <div className='absolute bottom-0 w-full bg-white/10 ' />
        </div> */}
      {/* </div> */}
    </Router>
  );
}

export default App;
