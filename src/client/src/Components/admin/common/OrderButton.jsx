import { Button } from "antd";
import React from "react";
import { cancelOrder, moveToNextStep } from "../../../Api/Controller";

const OrderButton = ({ status, id, setReloadData }) => {
  const handleNextStep = () => {
    moveToNextStep(id);
    setReloadData(true);
  };

  const handleCancel = () => {
    cancelOrder(id);
    setReloadData(true);
  };

  return (
    <div className="order-button">
      {status === "Chờ xác nhận" ? (
        <Button type="primary" onClick={handleNextStep}>
          Xác nhận đơn hàng
        </Button>
      ) : status === "Chờ thanh toán" ? (
        <Button danger onClick={handleCancel}>
          Hủy đơn hàng
        </Button>
      ) : status === "Đã xác nhận" ? (
        <div>
          <Button type="primary" onClick={handleNextStep}>
            Tiến hành giao hàng
          </Button>
          <Button danger onClick={handleCancel}>
            Hủy đơn hàng
          </Button>
        </div>
      ) : status === "Đang giao hàng" ? (
        <div>
          <Button type="primary" onClick={handleNextStep}>
            Xác nhận đã giao hàng
          </Button>
          <Button danger onClick={handleCancel}>
            Hủy đơn hàng
          </Button>
        </div>
      ) : status === "Thành công" ? null : null}
    </div>
  );
};

export default OrderButton;
