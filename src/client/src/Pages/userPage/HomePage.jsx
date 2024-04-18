import React, { useEffect } from "react";
import FlashSale from "./../../Components/flashSale/FlashSale";
import Product from "../../Components/product/Product";
import "../../styles/homePage.scss";
import TopSuggest from "../../Components/topSuggest/TopSuggest";
import TopBody from "../../Components/topBody/TopBody";
import Privacy from "../../Components/privacy/Privacy";
import Banner from "../../Components/banner/Banner";
import Category from "../../Components/category/Category";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div className="home-page">
      <TopBody />
      <FlashSale />
      <Privacy />
      <TopSuggest />
      <Product title={"Điện thoại"} />
      <Product title={"Laptop"} />
      <Banner />
      <Product title={"Âm thanh"} />
      <Product title={"PC"} />
      <Category />
    </div>
  );
};

export default HomePage;
