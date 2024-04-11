import React, { useEffect } from "react";
import Header from "../../Components/header/Header";
import Category from "../../Components/category/Category";
import FlashSale from "./../../Components/flashSale/FlashSale";
import Footer from "./../../Components/footer/Footer";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div>
      <Header />
      <Category />
      <FlashSale />
      <Footer />
    </div>
  );
};

export default HomePage;
