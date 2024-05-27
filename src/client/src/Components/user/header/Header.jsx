import React, { useEffect, useRef, useState } from "react";
import "../styles/homePage.scss";
import banner from "../../../Shared/images/banner-top.jpg";
import logo from "../../../Shared/images/logo-4.png";
import {
  UserRound,
  Search,
  UserRoundPlus,
  LogIn,
  ShoppingCart,
  LogOut,
  LockKeyhole,
  Info,
  ShoppingBag,
} from "lucide-react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../../Redux/Account";
import { Badge } from "antd";
import DropDownItem from "../../shared/DropDownItem";
import { getUserById } from "../../../Api/Controller";

const Header = () => {
  const initialState = {
    id: 0,
    imageUrl: "",
    name: "",
    email: "",
    address: "",
    phoneNumber: "",
  };
  const navbarRef = useRef(null);
  const userRef = useRef(null);
  const [open, setOpen] = useState(false);
  const [userInfo, setUserInfo] = useState(initialState);
  const [query, setQuery] = useState("");
  let user = useSelector((state) => state.auth.login.currentUser);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  let cart = useSelector((state) => state.cart);

  const editImageFrame =
    "https://i0.wp.com/digitalhealthskills.com/wp-content/uploads/2022/11/3da39-no-user-image-icon-27.png?fit=500%2C500&ssl=1";

  useEffect(() => {
    if (user !== null) {
      getUserById(user.id).then((data) => {
        if (data) {
          setUserInfo(data);
        } else setUserInfo(initialState);
      });
    }
  }, [user]);

  const handleLogout = () => {
    dispatch(logout());
    navigate(`/`);
    window.location.reload();
  };

  const handleLink = () => {
    window.scrollTo({ top: 0, behavior: "instant" });
    navigate("/cart");
  };

  const onSearch = () => {
    navigate("/search", { state: { query } });
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") {
      onSearch();
    }
  };

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY > 0) {
        navbarRef.current.style.position = "fixed";
        navbarRef.current.style.top = "0";
        navbarRef.current.style.width = "100%";
      } else {
        navbarRef.current.style.position = "relative";
        navbarRef.current.style.top = "";
        navbarRef.current.style.width = "";
      }
    };

    window.addEventListener("scroll", handleScroll);

    let handler = (e) => {
      if (userRef.current && !userRef.current.contains(e.target)) {
        setOpen(false);
      }
    };

    document.addEventListener("mousedown", handler);

    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  return (
    <>
      <div className="home-header">
        <div className="home-header-banner">
          <img src={banner} alt="Banner" />
        </div>
        <div ref={navbarRef} className="home-header-navbar">
          <Link to="/" className="home-header-navbar-logo">
            <img src={logo} alt="Logo" className="home-header-navbar-logo" />
          </Link>
          <div className="home-header-navbar-search">
            <input
              className="input-search"
              type="text"
              placeholder="Bạn đang tìm gì ..."
              onChange={(e) => setQuery(e.target.value)}
              onKeyDown={handleKeyDown}
            />
            <Search className="search-icon" onSubmit={onSearch} />
          </div>
          <div className="home-header-navbar-end">
            <div className="home-header-navbar-end-user" ref={userRef}>
              {user !== null ? (
                <div className="home-header-navbar-end-user-icon">
                  {userInfo.imageUrl === "" || userInfo.imageUrl === null ? (
                    <img
                      src={editImageFrame}
                      alt={userInfo.name}
                      onClick={() => setOpen(!open)}
                    />
                  ) : (
                    <img
                      src={userInfo.imageUrl}
                      alt={userInfo.name}
                      onClick={() => setOpen(!open)}
                    />
                  )}
                </div>
              ) : (
                <div className="home-header-navbar-end-user-icon">
                  <img
                    src={editImageFrame}
                    alt="Hinh"
                    onClick={() => setOpen(!open)}
                  />
                </div>
              )}

              {open && user === null ? (
                <div className="home-header-navbar-end-user-dropdown">
                  <ul>
                    <Link to={`/login`} className="link">
                      <DropDownItem image={<LogIn />} title="Đăng nhập" />
                    </Link>
                    <Link to={`/register`} className="link">
                      <DropDownItem image={<UserRoundPlus />} title="Đăng ký" />
                    </Link>
                  </ul>
                </div>
              ) : (open && user.role === "Quản lý") ||
                (open && user.role === "Nhân viên") ? (
                <div className="home-header-navbar-end-user-dropdown">
                  <ul>
                    <Link to={`/admin`} className="link">
                      <DropDownItem
                        image={<LockKeyhole />}
                        title="Trang quản lý"
                      />
                    </Link>
                    <div onClick={handleLogout} className="link">
                      <DropDownItem image={<LogOut />} title="Đăng xuất" />
                    </div>
                  </ul>
                </div>
              ) : open && user ? (
                <div className="home-header-navbar-end-user-dropdown">
                  <ul>
                    <Link to={`/profile`} className="link">
                      <DropDownItem image={<Info />} title="Trang cá nhân" />
                    </Link>
                    <Link to={`/order`} className="link">
                      <DropDownItem
                        image={<ShoppingBag />}
                        title="Đơn hàng của bạn"
                      />
                    </Link>
                    <div onClick={handleLogout} className="link">
                      <DropDownItem image={<LogOut />} title="Đăng xuất" />
                    </div>
                  </ul>
                </div>
              ) : null}
            </div>
            <div className="home-header-navbar-end-cart">
              <Badge
                count={cart.totalAmount}
                overflowCount={10}
                size="small"
                showZero
                className="cart-icon"
              >
                <ShoppingCart onClick={handleLink} />
              </Badge>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Header;
