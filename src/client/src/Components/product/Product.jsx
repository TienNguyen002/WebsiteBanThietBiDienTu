import React from "react";
import { ChevronRight } from "lucide-react";
import "./product.scss";

const Product = () => {
  return (
    <>
      <div className="product">
        <div className="product-branch">
          <p>Thương hiệu</p>
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
          </div>
        </div>
        <div className="product-list">
          <div className="product-list-header">
            <p className="product-list-header-title">Tiêu đề</p>
            <div className="top-card-header-more">
              Xem tất cả <ChevronRight />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Product;
