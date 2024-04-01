import React from "react";
import "./footer.scss";

const Footer = () => {
  return (
    <div className="footer">
      <div className="footer-top">
        <div className="footer-top-about">
          <h4 className="title">VỀ CHÚNG TÔI</h4>
          <ul className="item">
            <li>Giới thiệu</li>
            <li>Tuyển dụng</li>
          </ul>
        </div>
        <div className="footer-top-policy">
          <h4 className="title">CHÍNH SÁCH</h4>
          <ul className="item">
            <li>Chính sách bảo hành</li>
            <li>Chính sách thanh toán</li>
            <li>Chính sách giao hàng</li>
            <li>Chính sách bảo mật</li>
          </ul>
        </div>
        <div className="footer-top-information">
          <h4 className="title">THÔNG TIN</h4>
          <ul className="item">
            <li>Hệ thống cửa hàng</li>
            <li>Trung tâm bảo hành</li>
            <li>Tra cứu địa chỉ bảo hành</li>
          </ul>
        </div>
        <div className="footer-top-support">
          <h4 className="title">TỔNG ĐÀI HỖ TRỢ (8:00 - 21:00)</h4>
          <ul className="item">
            <li>CSKH:</li>
            <li>Bảo hành:</li>
            <li>HTKT:</li>
            <li>Email:</li>
          </ul>
        </div>
      </div>
      <div className="footer-bot">
        <div className="footer-bot-copyright">
          &copy; 2024 - HỆ THỐNG BÁN THIẾT BỊ
        </div>
        <div className="footer-bot-social">
          <h4>KẾT NỐI VỚI CHÚNG TÔI</h4>
          <div className="footer-bot-social-icon">
            <i class="fa-brands fa-youtube"></i>
            <i class="fa-brands fa-facebook"></i>
            <i class="fa-brands fa-instagram"></i>
            <i class="fa-brands fa-tiktok"></i>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
