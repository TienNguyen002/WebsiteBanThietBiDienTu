import React from "react";
import "../../styles/commonPage.scss";
import { useNavigate } from "react-router-dom";

const NotFound = () => {
  const navigate = useNavigate();

  const handleBack = () => {
    navigate("/");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  }

  return (
    <div className="not-found-page">
      <img
        src="https://img.freepik.com/free-vector/404-error-with-landscape-concept-illustration_114360-7898.jpg"
        alt="404"
        className="not-found-page-image"
      />
      <p className="not-found-page-message">Trang không tồn tại!</p>
      <button className="not-found-page-button" onClick={handleBack}>Quay lại trang chủ</button>
    </div>
  );
};

export default NotFound;
