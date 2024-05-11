import React, { useEffect, useRef, useState } from "react";
import "../styles/homePage.scss";
import banner from "../../../Shared/images/banner-top.jpg";
import logo from "../../../Shared/images/logo-4.png";
import { UserRound, Search, UserRoundPlus, LogIn } from "lucide-react";
import { Link } from "react-router-dom";
import CartDrawer from "../cart/CartDrawer";

const Header = () => {
  const navbarRef = useRef(null);
  const userRef = useRef(null);
  const [open, setOpen] = useState(false);

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

    // let handler = (e) => {
    //   if (userRef.current && !userRef.current.contains(e.target)) {
    //     setOpen(false);
    //   }
    // };

    // document.addEventListener("mousedown", handler);

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
            />
            <Search className="search-icon" />
          </div>
          <div className="home-header-navbar-end">
            <div className="home-header-navbar-end-user" ref={userRef}>
              <UserRound className="user-icon" onClick={() => setOpen(!open)} />
              {open && (
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
              )}
            </div>
            <div className="home-header-navbar-end-cart">
              <CartDrawer className="cart-icon" />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

const DropDownItem = (props) => {
  return (
    <li className="drop-down">
      <p className="drop-down">
        {props.image} {props.title}
      </p>
    </li>
  );
};

export default Header;
