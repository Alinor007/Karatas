import React, { useEffect } from 'react'
import Sidebar from '../../Components/Sidebar/Sidebar'
import Dashboard from '../../Components/Dashboard/Dashboard'
import { Outlet, useParams } from 'react-router-dom'
import DocTrack from '../../Components/DocTrack/DocTrack'
import Tile from '../../Components/Tile/Tile'
import Footer from '../../Components/Footer/Footer'

type Props = {}

const MainPage = (props: Props) => {
  let { ticker } = useParams();
  
  
  return (
    <>
       
       <div className="flex min-h-screen ">
        <Sidebar />
        <div className='flex-grow'>
         <Outlet/>

            {/* Render the nested routes here */}
         
        </div>
      </div>
      <Footer/>
    
       
    </>
  )
}

export default MainPage
