import React from "react";
import { Zap } from "lucide-react";
import "./flashSale.scss";
import ProductDetail from "../productDetail/ProductDetail";

const FlashSale = () => {
  return (
    <>
      <div className="home-flash-sale">
        <div className="home-flash-sale-top">
          <h1 className="home-flash-sale-title">FlashSale</h1>
          <Zap className="home-flash-sale-icon" />
        </div>
        <div className="home-flash-sale-product">
          <ProductDetail />
        </div>
      </div>
    </>
  );
};

export default FlashSale;
