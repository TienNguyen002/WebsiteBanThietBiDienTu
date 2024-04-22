import React, { useState } from "react";
import { ChevronDown } from "lucide-react";
import "./dropDown.scss";
import dropDown from "../../Shared/data/dropDown.json";

const DropDown = ({ selected, setSelected }) => {
  const [isActive, setIsActive] = useState(false);
  const options = [
    "Sắp xếp mặc định",
    "Sắp xếp từ A - Z",
    "Sắp xếp từ Z - A",
    "Sắp xếp theo giá tăng dần",
    "Sắp xếp theo giá giảm dần",
  ];

  return (
    <>
      <div className="dropdown">
        <div
          className="dropdown-button"
          onClick={(e) => setIsActive(!isActive)}
        >
          {selected === "" ? "Sắp xếp mặc định" : selected}
          <ChevronDown />
        </div>
        {isActive && (
          <div className="dropdown-content">
            {options.map((option) => (
              <div
                className="dropdown-content-item"
                onClick={(e) => {
                  setSelected(option);
                  setIsActive(false);
                }}
              >
                {option}
              </div>
            ))}
          </div>
        )}
      </div>
    </>
  );
};

export default DropDown;
