import React from 'react';
import { Link } from 'react-router-dom';
import Lottie from "lottie-react";
import Astoraut from '../../Assets/Animation - 1730007686399.json';

const Hero: React.FC = () => {
  return (
    <section className="bg-gradient-to-r from-blue-500 to-pink-400 text-white py-20">
      <div className="container mx-auto px-6 text-center md:text-left">
        <div className="flex flex-col-reverse md:flex-row items-center relative">
          <div className="w-full md:w-1/2 mt-8 md:mt-0">
            <h1 className="text-3xl sm:text-4xl md:text-5xl font-bold">
              Karatas
            </h1>
            <h2 className="text-lg sm:text-xl md:text-2xl">Document Tracker System</h2>
            <p className="mt-4 text-base sm:text-lg md:text-xl">
              Efficiently manage and track your documents through every office step.
            </p>
            <div className="mt-6">
              <Link
                to="/"
                className="bg-white text-blue-500 py-2 px-6 rounded-lg font-semibold hover:bg-gray-100"
              >
                Get Started
              </Link>
            </div>
          </div>
          <div className="w-48 h-48 sm:w-64 sm:h-64 md:w-72 md:h-72 duration-1000 ease-in-out animate-floating">
            <Lottie animationData={Astoraut} loop={true} />
          </div>
         
        </div>
      </div>
    </section>
  );
};

export default Hero;
