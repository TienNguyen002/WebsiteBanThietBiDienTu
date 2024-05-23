import React from "react";
import { useSelector } from "react-redux";
import { formatVND } from "../../../Common/function";
import { Table } from "antd";

const CartProduct = () => {
  let cart = useSelector((state) => state.cart);

  const columns = [
    {
      title: "Hình",
      dataIndex: "imageUrl",
      key: "imageUrl",
      render: (imageUrl) => (
        <img src={imageUrl} className="item-image" alt={imageUrl} />
      ),
      width: 100,
    },
    {
      title: "Sản phẩm",
      dataIndex: "productName",
      key: "productName",
      width: 500,
    },
    {
      title: "Số lượng đặt",
      dataIndex: "quantity",
      key: "quantity",
      width: 200,
    },
    {
      title: "Màu sản phẩm",
      dataIndex: "color",
      key: "color",
      width: 200,
    },
    {
      title: "Tổng tiền",
      dataIndex: "price",
      key: "price",
      width: 200,
      render: (price) => <span>{formatVND(price)}</span>,
    },
  ];

  return (
    <div>
      <Table columns={columns} dataSource={cart.items} pagination={false} />
    </div>
  );
};

export default CartProduct;
