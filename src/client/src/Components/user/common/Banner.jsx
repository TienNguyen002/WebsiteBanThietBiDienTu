//Import Component Library
import React from "react";
import { Link } from "react-router-dom";
//CSS
import "../styles/homePage.scss";

const Banner = () => {
  return (
    <>
      <div className="home-banner">
        <h1 className="home-banner-header">
          Miễn phí giao hàng với đơn hàng trên 700.000đ
        </h1>
        <Link className="home-banner-link">Mua sắm ngay</Link>
      </div>
    </>
  );
};

export default Banner;
