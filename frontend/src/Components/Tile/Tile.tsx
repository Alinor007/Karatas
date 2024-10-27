
import React from "react";

type Props = {
  title: string;
  subTitle: string;
};

const Tile = ({ title, subTitle }: Props) => {
  return (
  
        <div className="bg-white p-6 shadow rounded-3xl">
          <h3 className="text-sm font-semibold mb-2  text-indigo-800">{title}</h3>
          <p className="text-3xl font-bold text-indigo-600">{subTitle}</p>
          
        </div>
   
  );
};

export default Tile;


