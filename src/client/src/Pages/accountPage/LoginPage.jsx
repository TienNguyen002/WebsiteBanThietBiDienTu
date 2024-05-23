import React, { useEffect, useState } from "react";
import { Lock, Eye, EyeOff, Mail, MoveLeft } from "lucide-react";
import "../../styles/accountPage.scss";
import { useDispatch } from "react-redux";
import { loginUser } from "../../Api/AuthController";
import toast, { Toaster } from "react-hot-toast";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const initialState = {
    email: "",
    password: "",
  };
  const [show, setShow] = useState(false);
  const [account, setAccount] = useState(initialState);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    document.title = "Đăng nhập";
  }, []);

  const handleLogin = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    loginUser(formData, dispatch, navigate)
      .then(() => {
        localStorage.setItem("isLoggedIn", true);
      })
      .catch((error) => {
        toast.error("Đăng nhập không thành công: " + error.message);
      });
  };

  const handleShow = () => {
    setShow(!show);
  };

  const goBack = () => {
    window.history.go(-1);
  };

  return (
    <div className="wrapper">
      <Toaster />
      <div className="account-page">
        <MoveLeft className="account-page-back" onClick={goBack} />
        <div className="account-page-login">
          <form onSubmit={handleLogin} className="account-page-form">
            <h1 className="account-page-form-title">Đăng nhập</h1>
            <div className="account-page-form-input">
              <Mail className="account-page-form-input-icon" />
              <input
                type="email"
                placeholder="Email"
                name="email"
                required
                className="account-page-form-input-box"
                onChange={(e) =>
                  setAccount({ ...account, email: e.target.value })
                }
              />
            </div>
            <div className="account-page-form-input">
              <Lock className="account-page-form-input-icon" />
              <input
                type={show ? "text" : "password"}
                name="password"
                placeholder="Mật khẩu"
                required
                className="account-page-form-input-box"
                onChange={(e) =>
                  setAccount({ ...account, password: e.target.value })
                }
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
              <a href="/">Quay lại trang chủ</a>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
