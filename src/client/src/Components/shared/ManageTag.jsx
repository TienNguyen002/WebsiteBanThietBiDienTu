import { Tag } from "antd";
import React from "react";

const ManageTag = ({ tag }) => {
  return (
    <>
      {tag === "Chờ xác nhận" ? (
        <Tag color="yellow">{tag}</Tag>
      ) : tag === "Chờ thanh toán" ? (
        <Tag color="cyan">{tag}</Tag>
      ) : tag === "Đã xác nhận" ? (
        <Tag color="processing">{tag}</Tag>
      ) : tag === "Đang giao hàng" ? (
        <Tag color="orange">{tag}</Tag>
      ) : tag === "Thành công" ? (
        <Tag color="success">{tag}</Tag>
      ) : tag === "Đơn hàng bị hủy" ? (
        <Tag color="red">{tag}</Tag>
      ) : tag === "Người dùng" ? (
        <Tag color="green">{tag}</Tag>
      ) : tag === "Nhân viên" ? (
        <Tag color="magenta">{tag}</Tag>
      ) : tag === "Admin" ? (
        <Tag color="geekblue">{tag}</Tag>
      ) : null}
    </>
  );
};

export default ManageTag;
