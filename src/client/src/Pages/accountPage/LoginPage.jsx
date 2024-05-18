import React, { useState } from "react";
import { Lock, Eye, EyeOff, Mail, MoveLeft } from "lucide-react";
import "../../styles/accountPage.scss";

const LoginPage = () => {
  const [show, setShow] = useState(false);

  const handleShow = () => {
    setShow(!show);
  };

  const goBack = () => {
    window.history.go(-1);
  };

  return (
    <div className="wrapper">
      <div className="account-page">
        <MoveLeft className="account-page-back" onClick={goBack} />
        <div className="account-page-login">
          <form action="" className="account-page-form">
            <h1 className="account-page-form-title">Đăng nhập</h1>
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
            <div className="account-page-form-forgot">
              <a href="#">Quên mật khẩu?</a>
            </div>
            <button type="submit" className="account-page-form-button">
              Đăng nhập
            </button>
            <div className="account-page-form-register">
              <p>
                Bạn chưa có tài khoản? <a href="/register">Đăng ký ngay!</a>
              </p>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
