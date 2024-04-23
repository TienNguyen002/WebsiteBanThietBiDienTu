import React from "react";
import Category from "../../Components/user/reUse/category/Category";
// import Branch from "../../Components/branch/Branch";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/salePage.scss";

const SalePage = () => {
  return (
    <>
      <div className="sale-page">
        <div className="sale-page-category">
          <Category title={false} />
          {/* <Branch /> */}
        </div>
        <div className="sale-page-product">
          <div className="sale-page-product-filter">
            <ProductFilter hasBranch={true} />
          </div>
          <div className="sale-page-product-list">
            <ProductColumn />
          </div>
        </div>
      </div>
    </>
  );
};

export default SalePage;
