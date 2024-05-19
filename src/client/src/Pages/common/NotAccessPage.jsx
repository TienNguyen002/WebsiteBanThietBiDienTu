import React from "react";
import { useNavigate } from "react-router-dom";
import "../../styles/commonPage.scss";

const NotAccessPage = () => {
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
        src="https://assets.wpdeveloper.com/2022/08/image.png"
        alt="No Access"
        className="common-page-image"
      />
      <p className="common-page-message">Bạn không có quyền!</p>
      <button className="common-page-button" onClick={handleBack}>
        Quay lại trang chủ
      </button>
    </div>
  );
};

export default NotAccessPage;
