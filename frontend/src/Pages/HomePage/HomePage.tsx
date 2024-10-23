import React from 'react'
import Hero from '../../Components/Hero/Hero'
import Navbar from '../../Components/Navbar/Navbar'


type Props = {}

const HomePage = (props: Props) => {
  return (
    <div className='font-poppins'>
          <Navbar/>
          <Hero/>
        </div>
  )
}

export default HomePage