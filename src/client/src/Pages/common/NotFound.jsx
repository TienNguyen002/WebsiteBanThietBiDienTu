import React from "react";
import "../../styles/commonPage.scss";

const NotFound = () => {
  return (
    <div className="not-found-page">
      <img
        src="https://img.freepik.com/free-vector/404-error-with-landscape-concept-illustration_114360-7898.jpg"
        alt="404"
        className="not-found-page-imge"
      />
      <p>Đường dẫn này không tồn tại!</p>
      <button>Quay lại trang chủ</button>
    </div>
  );
};

export default NotFound;
