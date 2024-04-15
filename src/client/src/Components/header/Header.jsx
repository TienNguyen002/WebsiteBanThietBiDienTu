import React, { useEffect, useRef } from "react";
import "./header.scss";
import banner from "../../Shared/images/banner-top.jpg";
import logo from "../../Shared/images/logo-4.png";
import { ShoppingCart, UserRound, Search } from "lucide-react";
import { Link } from "react-router-dom";

const Header = () => {
  const navbarRef = useRef(null);

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
              placeholder="I'm shopping for ..."
            />
            <Search className="search-icon" />
          </div>
          <div className="home-header-navbar-end">
            <UserRound className="user-icon" />
            <ShoppingCart className="cart-icon" />
          </div>
        </div>
      </div>
    </>
  );
};

export default Header;
