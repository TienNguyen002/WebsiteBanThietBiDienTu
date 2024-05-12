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
    <div className="bad-request-page">
      <img
        src="https://t3.ftcdn.net/jpg/04/08/40/50/360_F_408405006_Ou80YYIL1ssetJXkfAgyTDPIkgKzVnkj.jpg"
        alt="400"
        className="bad-request-page-image"
      />
      <p className="bad-request-page-message">Bad Request!</p>
      <button className="bad-request-page-button" onClick={handleBack}>
        Quay lại trang chủ
      </button>
    </div>
  );
};

export default BadRequest;
