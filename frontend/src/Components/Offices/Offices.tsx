import React from "react";
import { OfficeGet } from "../../Models/Office";

type Props = {
  office: OfficeGet;
};

const StockCommentListItem = ({ office }: Props) => {
  return (
    <div className="relative grid grid-cols-1 gap-4 ml-4 p-4 mb-8 w-full border rounded-lg bg-white shadow-lg">
      <div className="relative flex gap-4">
        <div className="flex flex-col w-full">
          <div className="flex flex-row justify-between">
            <p className="relative text-xl whitespace-nowrap truncate overflow-hidden">
              {office.name}
            </p>
          </div>
          <p className="text-dark text-sm">@{office.discription}</p>
        </div>
      </div>
    </div>
  );
};

export default StockCommentListItem;