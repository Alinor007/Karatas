// src/components/Hero.tsx
import React from 'react';
import astro from '../../Astronaut.png'
import { Link } from 'react-router-dom';

const Hero: React.FC = () => {
  return (
    <section className="bg-gradient-to-r from-blue-500 to-pink-400 text-white py-20">      
      <div className="container mx-auto px-6 text-center md:text-left ">
        <div className="md:flex items-center relative">
          <div className="md:w-1/2">
            <h1 className="text-4xl font-bold md:text-5xl">
              Karatas
            </h1>
                <h2>Document Tracker System</h2>
            <p className="mt-4 text-lg md:text-xl">
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
          <div className="absolute h-64 w-64  top-0 right-0 py-4 duration-1000 ease-in-out   ">
            <img  src={astro} alt="" />
          </div>
        </div>
      </div>
    </section>
  );
};

export default Hero;
