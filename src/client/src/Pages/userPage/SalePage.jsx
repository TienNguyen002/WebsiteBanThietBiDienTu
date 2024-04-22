import React from "react";
import Category from "../../Components/category/Category";
// import Branch from "../../Components/branch/Branch";
import ProductFilter from "../../Components/productFilter/ProductFilter";
import ProductList from "../../Components/productList/ProductList";
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
            <ProductList />
          </div>
        </div>
      </div>
    </>
  );
};

export default SalePage;
