//Import Component Library
import React, { useEffect, useState } from "react";
//Import Component
import Quantity from "../../reUse/quantity/Quantity";
//Import Function
import { formatVND } from "../../../../Common/function";

const CartProduct = ({ setTotal }) => {
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    setTotal(formatVND(16990000 * quantity));
  });

  return (
    <>
      <div className="cart-product">
        <div className="cart-product-item">
          <img
            src="https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-z-lip5_3_.png"
            alt="img"
            className="cart-product-item-image"
          />
          <p className="cart-product-item-name">Samsung Galaxy Z Flip5 256GB</p>
          <div className="cart-product-price">
            <p>{formatVND(16990000 * quantity)}</p>
          </div>
          <Quantity quantity={quantity} setQuantity={setQuantity} />
          <button>X</button>
        </div>
      </div>
    </>
  );
};

export default CartProduct;
