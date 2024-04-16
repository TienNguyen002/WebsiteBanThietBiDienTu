import React from "react";
import "./privacy.scss";

const Privacy = () => {
  return (
    <>
      <div className="privacy">
        <div className="privacy-delivery">
          <i className="fa-solid fa-truck privacy-logo"></i>
          <p className="privacy-title">Giao hàng nhanh chóng</p>
        </div>
        <div className="privacy-payment">
          <i className="fa-solid fa-wallet privacy-logo"></i>
          <p className="privacy-title">Bảo mật thanh toán</p>
        </div>
        <div className="privacy-confidence">
          <i className="fa-solid fa-shield privacy-logo"></i>
          <p className="privacy-title">Tự tin mua hàng</p>
        </div>
        <div className="privacy-support">
          <i className="fa-solid fa-headset privacy-logo"></i>
          <p className="privacy-title">Hỗ trợ 24/7</p>
        </div>
      </div>
    </>
  );
};

export default Privacy;
