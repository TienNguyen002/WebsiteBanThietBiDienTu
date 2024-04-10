import React, { useEffect } from "react";
import Header from "../../Components/header/Header";
import Banner from "../../Components/banner/Banner";
import FlashSale from "../../Components/flashSale/FlashSale";
import Product from "../../Components/product/Product";
import Footer from "../../Components/footer/Footer";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div>
      <Header />
      {/* <Banner />
      <FlashSale />
      <Product />
      <Footer /> */}
    </div>
  );
};

export default HomePage;
