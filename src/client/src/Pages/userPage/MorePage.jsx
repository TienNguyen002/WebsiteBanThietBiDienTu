import React from "react";
import Branch from "../../Components/user/reUse/branch/Branch";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
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
            <ProductColumn />
          </div>
        </div>
      </div>
    </>
  );
};

export default MorePage;
