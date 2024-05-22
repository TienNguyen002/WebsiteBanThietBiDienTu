import React, { useEffect, useRef, useState } from "react";
import { Bell, Home, Info, LogOut, User } from "lucide-react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import DropDownItem from "../../shared/DropDownItem";
import "../styles/adminPage.scss";
import { logout } from "../../../Redux/Account";

const Topbar = () => {
  const userRef = useRef(null);
  const [open, setOpen] = useState(false);
  let user = useSelector((state) => state.auth.login.currentUser);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    let handler = (e) => {
      if (userRef.current && !userRef.current.contains(e.target)) {
        setOpen(false);
      }
    };

    document.addEventListener("mousedown", handler);
  }, []);

  const handleLogout = () => {
    dispatch(logout());
    navigate(`/`);
    window.location.reload();
  };

  return (
    <>
      <div className="topbar">
        <span className="topbar-text">Trang Admin</span>
        <div className="topbar-notification">
          <div className="topbar-notification-user" ref={userRef}>
            <User className="user-icon" onClick={() => setOpen(!open)} />
            {open && user ? (
              <div className="topbar-notification-user-dropdown">
                <ul>
                  <Link to={`/admin/profile`} className="link">
                    <DropDownItem image={<Info />} title="Trang cá nhân" />
                  </Link>
                  <Link to={`/`} className="link">
                    <DropDownItem image={<Home />} title="Quay lại trang chủ" />
                  </Link>
                  <div onClick={handleLogout} className="link">
                    <DropDownItem image={<LogOut />} title="Đăng xuất" />
                  </div>
                </ul>
              </div>
            ) : null}
          </div>
          <div className="topbar-notification-bell">
            <Bell className="bell-icon" />
          </div>
        </div>
      </div>
    </>
  );
};

export default Topbar;
