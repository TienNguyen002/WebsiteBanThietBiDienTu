import React, { useState } from "react";
import { Modal, Space, Table } from "antd";
import { Eye } from "lucide-react";
import "../../../styles/adminLayout.scss";
import { convertDate, formatVND } from "../../../Common/function";
import ManageTag from "../../../Components/shared/ManageTag";
import OrderButton from "../../../Components/admin/common/OrderButton";
import OrderItemsView from "./OrderItemsView";

const OrderView = ({ orders }) => {
  const [open, setOpen] = useState(false);
  const [orderId, setOrderId] = useState();
  const [total, setTotal] = useState();

  const handleView = (id, totalPrice) => {
    setOpen(true);
    setOrderId(id);
    setTotal(totalPrice);
  };

  const handleCancel = () => {
    setOpen(false);
  };

  const columns = [
    {
      title: "Mã đơn hàng",
      dataIndex: "name",
      key: "name",
      width: 250,
    },
    // {
    //   title: "Họ tên người đặt",
    //   dataIndex: "userName",
    //   key: "userName",
    //   width: 400,
    // },
    {
      title: "Ngày đặt",
      dataIndex: "dateOrder",
      key: "dateOrder",
      width: 200,
      render: (dateOrder) => <span>{convertDate(dateOrder)}</span>,
    },
    {
      title: "Số lượng đặt",
      dataIndex: "quantity",
      key: "quantity",
      width: 300,
      sorter: (a, b) => a.quantity - b.quantity,
    },
    {
      title: "Tổng tiền",
      dataIndex: "totalPrice",
      key: "totalPrice",
      width: 400,
      render: (totalPrice) => <span>{formatVND(totalPrice)}</span>,
      sorter: (a, b) => a.totalPrice - b.totalPrice,
    },
    {
      title: "Trạng thái",
      dataIndex: "status",
      key: "status",
      render: (status) => <ManageTag tag={status} />,
      width: 200,
    },
    {
      title: "Phương thức thanh toán",
      dataIndex: "paymentMethod",
      key: "paymentMethod",
      width: 500,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Eye onClick={() => handleView(record.id, record.totalPrice)} />
            <OrderButton status={record.status} />
          </div>
        </Space>
      ),
    },
  ];

  return (
    <div>
      <Table
        columns={columns}
        dataSource={orders}
        pagination={false}
        width={1000}
      />
      <Modal
        centered
        open={open}
        footer={null}
        onCancel={handleCancel}
        width={1000}
      >
        <OrderItemsView id={orderId} total={total} />
      </Modal>
    </div>
  );
};

export default OrderView;
