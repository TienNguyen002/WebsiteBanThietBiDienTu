//Import Component Library
import React, { useState } from "react";
import { Drawer } from "antd";
//Import Icon
import { ShoppingCart } from "lucide-react";
//Import Component
import CartProduct from "../cartProduct/CartProduct";

const CartDrawer = () => {
  const [open, setOpen] = useState(false);
  const [total, setTotal] = useState(0);

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  return (
    <>
      <ShoppingCart onClick={showDrawer} />
      <Drawer title="Giỏ hàng" onClose={onClose} open={open}>
        {/* <CartProduct setTotal={setTotal} />
        <p>Total: {total} </p>
        <button>Mở giỏ hàng</button>
        Hello tieens khoai to
        <button>Thanh toán</button> */}
        <p>Bạn chưa có sản phẩm nào tại giỏ hàng.</p> Cùng đi 1 vòng mua sắm
        nào!!
      </Drawer>
    </>
  );
};

export default CartDrawer;
