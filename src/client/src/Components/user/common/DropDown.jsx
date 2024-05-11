import React, { useState } from "react";
import { ChevronDown } from "lucide-react";
import "../styles/homePage.scss";

const DropDown = ({ selected, setSelected, onChange }) => {
  const [isActive, setIsActive] = useState(false);
  const options = [
    {
      name: "Sắp xếp mặc định",
      sort: "",
    },
    {
      name: "Sắp xếp từ A - Z",
      sort: "ASC",
    },
    {
      name: "Sắp xếp từ Z - A",
      sort: "DESC",
    },
    {
      name: "Sắp xếp theo giá tăng dần",
      sort: "HighPrice",
    },
    {
      name: "Sắp xếp theo giá giảm dần",
      sort: "LowPrice",
    },
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
            {options.map((option, index) => (
              <div
                className="dropdown-content-item"
                key={index}
                onClick={(e) => {
                  setSelected(option.name);
                  setIsActive(false);
                  onChange(option.sort);
                }}
              >
                {option.name}
              </div>
            ))}
          </div>
        )}
      </div>
    </>
  );
};

export default DropDown;
