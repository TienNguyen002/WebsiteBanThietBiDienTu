import React from "react";
import Branch from "../../Components/branch/Branch";
import ProductFilter from "../../Components/productFilter/ProductFilter";
import ProductList from "../../Components/productList/ProductList";
import "../../styles/morePage.scss";

const MorePage = () => {
  return (
    <>
      <div className="more-page">
        <div className="more-page-branch">
          <Branch />
        </div>
        <div className="more-page-product">
          <div className="more-page-product-filter">
            <ProductFilter hasBranch={false} />
          </div>
          <div className="more-page-product-list">
            <ProductList />
          </div>
        </div>
      </div>
    </>
  );
};

export default MorePage;
