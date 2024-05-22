import React from "react";
import { Youtube, Facebook, Instagram, Twitter } from "lucide-react";
import "../styles/homePage.scss";
import { Link } from "react-router-dom";

const Footer = () => {
  return (
    <>
      <div className="home-footer">
        <div className="home-footer-top">
          <div className="home-footer-top-about">
            <ul className="item">
              <h4 className="footer-title">VỀ CHÚNG TÔI</h4>
              <li>Giới thiệu</li>
              <li>Tuyển dụng</li>
              <Link className="link" to={"/feedback"}>
                <li>Liên hệ</li>
              </Link>
            </ul>
          </div>
          <div className="home-footer-top-policy">
            <ul className="item">
              <h4 className="footer-title">CHÍNH SÁCH</h4>
              <li>Chính sách bảo hành</li>
              <li>Chính sách thanh toán</li>
              <li>Chính sách giao hàng</li>
              <li>Chính sách bảo mật</li>
            </ul>
          </div>
          <div className="home-footer-top-information">
            <ul className="item">
              <h4 className="footer-title">THÔNG TIN</h4>
              <li>Hệ thống cửa hàng</li>
              <li>Trung tâm bảo hành</li>
              <li>Tra cứu địa chỉ bảo hành</li>
            </ul>
          </div>
          <div className="home-footer-top-support">
            <ul className="item">
              <h4 className="footer-title">TỔNG ĐÀI HỖ TRỢ (8:00 - 21:00)</h4>
              <li>
                CSKH:
                <Link className="link"> 0819104319</Link>
              </li>
              <li>
                Bảo hành:
                <Link className="link"> 0819104319</Link>
              </li>
              <li>
                HTKT:
                <Link className="link"> 0819104319</Link>
              </li>
              <li>
                Email:
                <Link className="link"> 2015749@dlu.edu.vn</Link>
              </li>
            </ul>
          </div>
        </div>
        <div className="home-footer-bot">
          <div className="home-footer-bot-copyright">
            <h4>&copy; 2024 - HỆ THỐNG BÁN THIẾT BỊ</h4>
          </div>
          <div className="home-footer-bot-social">
            <h4 className="home-footer-bot-social-title">
              KẾT NỐI VỚI CHÚNG TÔI
            </h4>
            <div className="home-footer-bot-social-icon">
              <Youtube className="youtube-icon" />
              <Facebook className="facebook-icon" />
              <Instagram className="instagram-icon" />
              <Twitter className="twitter-icon" />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Footer;
