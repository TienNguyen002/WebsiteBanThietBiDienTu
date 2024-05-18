import { Button } from "antd";
import React from "react";

const OrderButton = ({ status }) => {
  return (
    <div className="order-button">
      {status === "Chờ xác nhận" ? (
        <Button type="primary">Xác nhận đơn hàng</Button>
      ) : status === "Chờ thanh toán" ? (
        <Button danger>Hủy đơn hàng</Button>
      ) : status === "Đã xác nhận" ? (
        <div>
          <Button type="primary">Tiến hành giao hàng</Button>
          <Button danger>Hủy đơn hàng</Button>
        </div>
      ) : status === "Đang giao hàng" ? (
        <Button danger>Hủy đơn hàng</Button>
      ) : status === "Thành công" ? (
        <p>Thành công</p>
      ) : status === "Đơn hàng bị hủy" ? (
        <p>Đã hủy</p>
      ) : null}
    </div>
  );
};

export default OrderButton;
