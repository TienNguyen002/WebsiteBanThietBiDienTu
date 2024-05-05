import React, { useState } from "react";
import {
  CircleUserRound,
  Lock,
  Eye,
  EyeOff,
  Mail,
  MoveLeft,
} from "lucide-react";
import "../../styles/accountPage.scss";

const RegisterPage = () => {
  const [show, setShow] = useState(false);

  const handleShow = () => {
    setShow(!show);
  };

  const goBack = () => {
    window.history.go(-1);
  };

  return (
    <div className="wrapper">
      {" "}
      <div className="account-page">
        <MoveLeft className="account-page-back" onClick={goBack} />
        <div className="account-page-register">
          <form action="" className="account-page-form">
            <h1 className="account-page-form-title">Đăng ký</h1>
            <div className="account-page-form-input">
              <Mail className="account-page-form-input-icon" />
              <input
                type="email"
                placeholder="Email"
                required
                className="account-page-form-input-box"
              />
            </div>
            <div className="account-page-form-input">
              <CircleUserRound className="account-page-form-input-icon" />
              <input
                type="text"
                placeholder="Tên đăng nhập"
                required
                className="account-page-form-input-box"
              />
            </div>
            <div className="account-page-form-input">
              <Lock className="account-page-form-input-icon" />
              <input
                type="password"
                placeholder="Mật khẩu"
                required
                className="account-page-form-input-box"
              />
              <div
                className="account-page-form-input-show"
                onClick={handleShow}
              >
                {show ? <EyeOff /> : <Eye />}
              </div>
            </div>
            <div className="account-page-form-input">
              <Lock className="account-page-form-input-icon" />
              <input
                type="password"
                placeholder="Mật khẩu xác nhận"
                required
                className="account-page-form-input-box"
              />
              <div
                className="account-page-form-input-show"
                onClick={handleShow}
              >
                {show ? <EyeOff /> : <Eye />}
              </div>
            </div>
            <div className="account-page-form-accept">
              <label>
                <input type="checkbox" />
                Tôi đồng ý với điều khoản
              </label>
            </div>
            <button type="submit" className="account-page-form-button">
              Đăng ký
            </button>
            <div className="account-page-form-register">
              <p>
                Bạn đã có tài khoản? <a href="/login">Đăng nhập ngay!</a>
              </p>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default RegisterPage;
