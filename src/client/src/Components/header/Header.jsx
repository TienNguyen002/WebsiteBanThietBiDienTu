import "./header.scss";
import banner from "../../Shared/images/banner-top.jpg";
import logo from "../../Shared/images/logo-4.png";
import { ShoppingCart, UserRound, Search } from "lucide-react";

const Header = () => {
  return (
    <>
      <div className="home-header">
        <div className="home-header-banner">
          <img src={banner} alt="Banner" />
        </div>
        <div className="home-header-navbar">
          <div className="home-header-navbar-logo">
            <img src={logo} alt="Logo" className="home-header-navbar-logo" />
          </div>
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
