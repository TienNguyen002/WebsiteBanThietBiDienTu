import React, { useState } from "react";
import { formatVND } from "../../Common/function";
import "./productTag.scss";

const ProductTag = () => {
  const [activeBox, setActiveBox] = useState(null);

  const handleSelect = (index) => {
    setActiveBox(index);
  };

  return (
    <div className="product-tag">
      {[
        { name: "256GB", price: 16990000 },
        { name: "512GB", price: 16990000 },
        { name: "1TB", price: 16990000 },
      ].map((item, index) => (
        <div
          key={index}
          className={
            activeBox === index ? "product-tag-box-active" : "product-tag-box"
          }
          onClick={() => handleSelect(index)}
        >
          <div className="product-tag-box-name">{item.name}</div>
          <p className="product-tag-box-price">{formatVND(item.price)}</p>
        </div>
      ))}
    </div>
  );
};

export default ProductTag;
