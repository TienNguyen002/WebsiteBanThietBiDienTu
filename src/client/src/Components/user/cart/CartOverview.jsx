import React from "react";
import { useSelector } from "react-redux";
import { formatVND } from "../../../Common/function";

const CartOverview = () => {
  let cart = useSelector((state) => state.cart);

  return (
    <div>
      <p>
        Số lượng sản phẩm:{" "}
        <span className="cart-page-user-overview-total">
          {cart.totalAmount}
        </span>
      </p>
      <p>
        Tổng tiền:{" "}
        <span className="cart-page-user-overview-total">
          {formatVND(cart.totalPrice)}
        </span>
      </p>
    </div>
  );
};

export default CartOverview;
