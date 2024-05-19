import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { List, Avatar, Button } from "antd";
import CartProcessing from "../../Components/user/cart/CartProcessing";
import { formatVND } from "../../Common/function";
import { removeItem } from "../../Redux/Cart";
import toast, { Toaster } from "react-hot-toast";

const CartPage = () => {
  let cart = useSelector((state) => state.cart);
  const dispatch = useDispatch();
  let current = 0;
  console.log(cart);

  const removeProduct = (id) => {
    dispatch(removeItem(id));
    toast.success("Đã xóa sản phẩm");
  };

  return (
    <div>
      <Toaster />
      <CartProcessing currentStep={current} />
      {current === 0 ? (
        <>
          <h1>Giỏ hàng của bạn</h1>
          <p>{` Có tổng ${cart.totalAmount} sản phẩm trong giỏ hàng`}</p>
          <List
            dataSource={cart.items}
            renderItem={(item) => (
              <List.Item>
                <List.Item.Meta
                  avatar={<Avatar src={item.imageUrl} />}
                  title={item.productName}
                  description={item.price}
                />
                <Button type="primary" onClick={() => removeProduct(item.id)}>
                  Xóa sản phẩm
                </Button>
              </List.Item>
            )}
          />
          <p>Tổng tiền: {formatVND(cart.totalPrice)}</p>
        </>
      ) : current === 1 ? (
        <p>Step 2</p>
      ) : current === 2 ? (
        <p>Step 3</p>
      ) : (
        <p>Step 4</p>
      )}
    </div>
  );
};

export default CartPage;
