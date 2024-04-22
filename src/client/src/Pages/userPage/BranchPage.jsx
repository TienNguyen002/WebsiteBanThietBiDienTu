import React from "react";
import ProductFilter from "../../Components/productFilter/ProductFilter";
import ProductList from "../../Components/productList/ProductList";
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
            <ProductList />
          </div>
        </div>
      </div>
    </>
  );
};

export default BranchPage;
