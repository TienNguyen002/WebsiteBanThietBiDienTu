import React from "react";
import { ChevronRight } from "lucide-react";
import "./product.scss";
import ProductCard from "./../productCard/ProductCard";

const Product = () => {
  return (
    <>
      <div className="product">
        <div className="product-branch">
          <h2 className="product-branch-title">Thương hiệu</h2>
          <div className="product-branch-list">
            <div className="product-branch-list-detail">
              <div className="product-branch-list-detail-logo">Logo</div>
              <div className="product-branch-list-detail-name">Apple</div>
            </div>
            <div className="product-branch-list-detail">
              <div className="product-branch-list-detail-logo">Logo</div>
              <div className="product-branch-list-detail-name">Apple</div>
            </div>
            <div className="product-branch-list-detail">
              <div className="product-branch-list-detail-logo">Logo</div>
              <div className="product-branch-list-detail-name">Apple</div>
            </div>
            <div className="product-branch-list-detail">
              <div className="product-branch-list-detail-logo">Logo</div>
              <div className="product-branch-list-detail-name">Apple</div>
            </div>
            <div className="product-branch-list-detail">
              <div className="product-branch-list-detail-logo">Logo</div>
              <div className="product-branch-list-detail-name">Apple</div>
            </div>
            <div className="product-branch-list-all">Xem tất cả</div>
          </div>
        </div>
        <div className="product-list">
          <div className="product-list-header">
            <h2 className="product-list-header-title">Điện thoại</h2>
            <div className="product-list-header-more">
              Xem tất cả <ChevronRight />
            </div>
          </div>
          <div className="product-list-item">
            <ProductCard className="product-list-item-detail" />
            <ProductCard className="product-list-item-detail" />
            <ProductCard className="product-list-item-detail" />
            <ProductCard className="product-list-item-detail" />
            <ProductCard className="product-list-item-detail" />
            <ProductCard className="product-list-item-detail" />
          </div>
        </div>
      </div>
    </>
  );
};

export default Product;
