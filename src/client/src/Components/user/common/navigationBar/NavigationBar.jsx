import React from "react";
import { ChevronRight } from "lucide-react";
import { useNavigate } from "react-router-dom";
import "./navigationBar.scss";

const NavigationBar = ({ sale, category, branch, serie, name }) => {
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
          {sale ? (
            <>
              <ChevronRight />
              {sale}
            </>
          ) : null}
          {category ? (
            <>
              <ChevronRight />
              {category}
            </>
          ) : null}
          {branch ? (
            <>
              <ChevronRight />
              {branch}
            </>
          ) : null}
          {serie ? (
            <>
              <ChevronRight />
              {serie}
            </>
          ) : null}
          {name ? (
            <>
              <ChevronRight />
              {name}
            </>
          ) : null}
        </div>
      </div>
    </>
  );
};

export default NavigationBar;
