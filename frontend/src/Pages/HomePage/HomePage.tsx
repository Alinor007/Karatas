import React from 'react'
import Sidebar from '../../Components/Sidebar/Sidebar'
import Dashboard from '../../Components/Dashboard/Dashboard'

type Props = {}

const HomePage = (props: Props) => {
  return (
        <>
        <div className='flex'>
        <Sidebar/>
        <Dashboard/>
        </div>
        </>
  )
}

export default HomePage