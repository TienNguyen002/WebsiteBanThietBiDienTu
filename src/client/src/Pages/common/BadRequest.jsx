import React from "react";
import { useNavigate } from "react-router-dom";
import "../../styles/commonPage.scss";

const BadRequest = () => {
  const navigate = useNavigate();

  const handleBack = () => {
    navigate("/");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <div className="common-page">
      <img
        src="https://t3.ftcdn.net/jpg/04/08/40/50/360_F_408405006_Ou80YYIL1ssetJXkfAgyTDPIkgKzVnkj.jpg"
        alt="400"
        className="common-page-image"
      />
      <p className="common-page-message">Bad Request!</p>
      <button className="common-page-button" onClick={handleBack}>
        Quay lại trang chủ
      </button>
    </div>
  );
};

export default BadRequest;
