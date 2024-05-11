import React, { useEffect } from "react";
import FlashSale from "./../../Components/user/body/flashSale/FlashSale";
import ProductList from "../../Components/user/product/productList/ProductList";
import TopSuggest from "../../Components/user/body/topSuggest/TopSuggest";
import TopHome from "../../Components/user/body/topHome/TopHome";
import Banner from "../../Components/user/common/Banner";
import Category from "../../Components/user/common/category/Category";
import "../../styles/homeLayout.scss";
import ShopPrivacy from "../../Components/user/common/Privacy";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div className="home-page">
      <TopHome />
      <FlashSale />
      <ShopPrivacy />
      <TopSuggest />
      <ProductList title={"Điện thoại"} category={"dien-thoai"} />
      <ProductList title={"Laptop"} category={"laptop"} />
      <Banner />
      <ProductList title={"Âm thanh"} category={"am-thanh"} />
      <ProductList title={"PC"} category={"pc"} />
      <Category title={true} />
    </div>
  );
};

export default HomePage;
