import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye } from "lucide-react";
import { getAllOrders } from "../../../Api/Controller";
import "../../../styles/adminLayout.scss";
import { Toaster } from "react-hot-toast";
import { convertDate, formatVND } from "../../../Common/function";
import ManageTag from "../../../Components/shared/ManageTag";
import OrderButton from "../../../Components/admin/common/OrderButton";
import OrderItemsView from "../view/OrderItemsView";
import { getColumnFilterProps } from "../../../Common/tableFunction";

const OrderManagement = () => {
  const [orders, setOrders] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [orderId, setOrderId] = useState();
  const [total, setTotal] = useState();
  const [reloadData, setReloadData] = useState(false);

  useEffect(() => {
    document.title = "Quản lý đơn hàng";

    setReloadData(false);
    getAllOrders().then((data) => {
      if (data) {
        setOrders(data);
      } else setOrders([]);
    });
  }, [reloadData]);

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
    {
      title: "Họ tên người đặt",
      dataIndex: "userName",
      key: "userName",
      width: 400,
    },
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
      width: 300,
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
            <OrderButton
              status={record.status}
              id={record.id}
              setReloadData={setReloadData}
            />
          </div>
        </Space>
      ),
    },
  ];

  return (
    <div className="management">
      <Toaster />
      <div className="management-top">
        <h1 className="management-top-title">Quản lý đơn hàng</h1>
        <SearchInput
          searchQuery={searchQuery}
          setSearchQuery={setSearchQuery}
        />
      </div>
      <div className="management-table">
        <Form>
          <DataTable
            columns={columns}
            dataSource={orders}
            searchQuery={searchQuery}
            page={page}
            pageSize={pageSize}
            setPage={setPage}
            setPageSize={setPageSize}
          />
        </Form>
      </div>
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

export default OrderManagement;
