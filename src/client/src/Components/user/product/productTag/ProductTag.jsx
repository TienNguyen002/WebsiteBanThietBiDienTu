import React from "react";
import { formatVND } from "../../../../Common/function";
import "./productTag.scss";

const ProductTag = ({ products, tag, onClick }) => {
  return (
    <div className="product-tag">
      {products
        ? products.map((item, index) => (
            <div
              key={index}
              className={
                item.shortName === tag
                  ? "product-tag-box-active"
                  : "product-tag-box"
              }
              onClick={() => onClick(item.urlSlug)}
            >
              <div className="product-tag-box-name">{item.shortName}</div>
              <p className="product-tag-box-price">{formatVND(item.price)}</p>
            </div>
          ))
        : null}
    </div>
  );
};

export default ProductTag;
