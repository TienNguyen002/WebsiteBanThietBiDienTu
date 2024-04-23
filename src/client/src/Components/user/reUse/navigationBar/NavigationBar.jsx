import React from "react";
import { ChevronRight } from "lucide-react";
import { useNavigate } from "react-router-dom";
import "./navigationBar.scss";

const NavigationBar = () => {
  const navigate = useNavigate();

  const handleLink = () => {
    navigate("/");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="navigation-bar">
        <div className="navigation-bar-item">
          <div onClick={handleLink} className="navigation-bar-item-home">
            <i className="fa-solid fa-house"></i>
            Trang chủ
          </div>
          <ChevronRight />
          Điện thoại <ChevronRight />
          Samsung <ChevronRight />
          Z5 Series <ChevronRight />
          Samsung Galaxy Z Flip5 256GB
        </div>
      </div>
    </>
  );
};

export default NavigationBar;
