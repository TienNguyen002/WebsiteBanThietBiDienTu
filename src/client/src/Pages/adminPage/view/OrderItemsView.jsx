import React, { useEffect, useState } from "react";
import { getOrderItemsByOrderId } from "../../../Api/Controller";
import { formatVND } from "../../../Common/function";
import { Table } from "antd";

const OrderItemsView = ({ id, total }) => {
  const [orderItems, setOrderItems] = useState([]);

  useEffect(() => {
    getOrderItemsByOrderId(id).then((data) => {
      if (data) {
        setOrderItems(data);
      } else setOrderItems([]);
    });
  }, [id]);

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
      <Table columns={columns} dataSource={orderItems} pagination={false} />
      {total ? (
        <p className="total-price">
          Tổng tiền của đơn hàng:{" "}
          <span className="total-price-all">{formatVND(total)}</span>
        </p>
      ) : null}
    </div>
  );
};

export default OrderItemsView;
