import React, { useEffect, useState } from "react";
import {
  CircleUserRound,
  Lock,
  Eye,
  EyeOff,
  Mail,
  MoveLeft,
} from "lucide-react";
import "../../styles/accountPage.scss";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { registerUser } from "../../Api/AuthController";
import toast, { Toaster } from "react-hot-toast";

const RegisterPage = () => {
  const initialState = {
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
  };
  const [show, setShow] = useState(false);
  const [account, setAccount] = useState(initialState);
  const [acceptedTerms, setAcceptedTerms] = useState(false);

  const dispatch = useDispatch();
  const naviagate = useNavigate();

  useEffect(() => {
    document.title = "Đăng ký";
  }, []);

  const handleShow = () => {
    setShow(!show);
  };

  const goBack = () => {
    window.history.go(-1);
  };

  const handleRegister = (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    if (!acceptedTerms) {
      toast.error("Bạn phải đồng ý với điều khoản trước khi đăng ký.");
      return;
    } else {
      registerUser(formData, dispatch, naviagate);
    }
  };

  return (
    <div className="wrapper">
      <Toaster />
      <div className="account-page">
        <MoveLeft className="account-page-back" onClick={goBack} />
        <div className="account-page-register">
          <form onSubmit={handleRegister} className="account-page-form">
            <h1 className="account-page-form-title">Đăng ký</h1>
            <div className="account-page-form-input">
              <Mail className="account-page-form-input-icon" />
              <input
                type="email"
                placeholder="Email"
                required
                name="email"
                className="account-page-form-input-box"
                onChange={(e) =>
                  setAccount({ ...account, email: e.target.value })
                }
              />
            </div>
            <div className="account-page-form-input">
              <CircleUserRound className="account-page-form-input-icon" />
              <input
                type="text"
                placeholder="Tên đăng nhập"
                required
                name="name"
                className="account-page-form-input-box"
                onChange={(e) =>
                  setAccount({ ...account, name: e.target.value })
                }
              />
            </div>
            <div className="account-page-form-input">
              <Lock className="account-page-form-input-icon" />
              <input
                type={show ? "text" : "password"}
                placeholder="Mật khẩu"
                required
                name="password"
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
            <div className="account-page-form-input">
              <Lock className="account-page-form-input-icon" />
              <input
                type={show ? "text" : "password"}
                placeholder="Mật khẩu xác nhận"
                required
                name="confirmPassword"
                className="account-page-form-input-box"
                onChange={(e) =>
                  setAccount({ ...account, confirmPassword: e.target.value })
                }
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
                <input
                  type="checkbox"
                  checked={acceptedTerms}
                  onChange={() => setAcceptedTerms(!acceptedTerms)}
                />
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
