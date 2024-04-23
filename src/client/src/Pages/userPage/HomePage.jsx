import React, { useEffect } from "react";
import FlashSale from "./../../Components/user/body/flashSale/FlashSale";
import ProductList from "../../Components/user/product/productList/ProductList";
import "../../styles/homePage.scss";
import TopSuggest from "../../Components/user/body/topSuggest/TopSuggest";
import TopHome from "../../Components/user/body/topHome/TopHome";
import Privacy from "../../Components/user/common/privacy/Privacy";
import Banner from "../../Components/user/common/banner/Banner";
import Category from "../../Components/user/common/category/Category";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div className="home-page">
      <TopHome />
      <FlashSale />
      <Privacy />
      <TopSuggest />
      <ProductList title={"Điện thoại"} />
      <ProductList title={"Laptop"} />
      <Banner />
      <ProductList title={"Âm thanh"} />
      <ProductList title={"PC"} />
      <Category title={true} />
    </div>
  );
};

export default HomePage;
