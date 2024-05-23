import React, { useEffect } from "react";
import "../../styles/commonPage.scss";
import { useNavigate } from "react-router-dom";

const NotFound = () => {
  const navigate = useNavigate();

  useEffect(() => {
    document.title = "Không tìm thấy trang này";
  }, []);

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
        src="https://img.freepik.com/free-vector/404-error-with-landscape-concept-illustration_114360-7898.jpg"
        alt="404"
        className="common-page-image"
      />
      <p className="common-page-message">Trang không tồn tại!</p>
      <button className="common-page-button" onClick={handleBack}>
        Quay lại trang chủ
      </button>
    </div>
  );
};

export default NotFound;
