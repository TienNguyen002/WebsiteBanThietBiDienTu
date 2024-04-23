import React from "react";
import ProductFilter from "../../Components/user/product/productFilter/ProductFilter";
import ProductColumn from "../../Components/user/product/productColumn/ProductColumn";
import "../../styles/branchPage.scss";

const BranchPage = () => {
  return (
    <>
      <div className="branch-page">
        <div className="branch-page-product">
          <div className="branch-page-product-filter">
            <ProductFilter hasBranch={false} />
          </div>
          <div className="branch-page-product-list">
            <ProductColumn />
          </div>
        </div>
      </div>
    </>
  );
};

export default BranchPage;
