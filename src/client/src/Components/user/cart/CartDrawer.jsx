//Import Component Library
import React, { useState } from "react";
import { Drawer } from "antd";
//Import Icon
import { ShoppingCart } from "lucide-react";
//Import Component
import CartProduct from "./CartProduct";
import { Link, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { formatVND } from "../../../Common/function";

const CartDrawer = () => {
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();
  let cart = useSelector((state) => state.cart);

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  const handleLink = () => {
    setOpen(false);
    navigate("/cart");
  };

  return (
    <>
      <ShoppingCart onClick={showDrawer} />
      <Drawer title="Giỏ hàng" onClose={onClose} open={open}>
        {cart.items.length > 0 ? (
          <>
            <Link to={"/cart"}>Click here</Link>
            <CartProduct items={cart.items} />
            <p>Tổng tiền: {formatVND(cart.totalPrice)} </p>
            <button onClick={handleLink}>Mở giỏ hàng</button>
            <button>Thanh toán</button>
          </>
        ) : (
          <>
            <p>Bạn chưa có sản phẩm nào tại giỏ hàng.</p> Cùng đi 1 vòng mua sắm
            nào!!
            <button onClick={handleLink}>Mở giỏ hàng</button>
          </>
        )}
      </Drawer>
    </>
  );
};

export default CartDrawer;
