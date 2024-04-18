import React from "react";
import { ChevronRight } from "lucide-react";
import "./product.scss";
import ProductCard from "./../productCard/ProductCard";
import branch from "../../Shared/data/branch.json";
import product from "../../Shared/data/product.json";

const Product = (props) => {
  const { title } = props;
  return (
    <>
      <div className="product">
        <div className="product-branch">
          <h2 className="product-branch-title">Thương hiệu</h2>
          <div className="product-branch-list">
            {branch.result.slice(0, 5).map((item, index) => (
              <div className="product-branch-list-detail" key={index}>
                <img
                  src={item.logo}
                  alt={item.name}
                  className="product-branch-list-detail-logo"
                />
                <div className="product-branch-list-detail-name">
                  {item.name}
                </div>
              </div>
            ))}
            <div className="product-branch-list-all">Xem tất cả</div>
          </div>
        </div>
        <div className="product-list">
          <div className="product-list-header">
            <h2 className="product-list-header-title">{title}</h2>
            <div className="product-list-header-more">
              Xem tất cả <ChevronRight />
            </div>
          </div>
          <div className="product-list-item">
            {product.result.map((item, index) => (
              <ProductCard
                className="product-list-item-detail"
                key={index}
                name={item.name}
                image={item.image}
                discout={item.discout}
                current={item.current}
                star={item.star}
              />
            ))}
          </div>
        </div>
      </div>
    </>
  );
};

export default Product;
