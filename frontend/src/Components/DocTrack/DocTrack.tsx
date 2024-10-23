import React, { useState, useEffect } from "react";
import { Outlet } from "react-router";

interface Props  {
  children: React.ReactNode;
  ticker: string;

  
};


const DocTrack =  ({ children }: Props)=> {

    
  return (
    <div>
    <div className="flex flex-wrap">{children}</div>
    </div>
   
  )
}

export default DocTrack