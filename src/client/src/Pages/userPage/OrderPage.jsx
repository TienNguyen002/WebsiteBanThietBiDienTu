import React, { useEffect, useState } from "react";
import { Form, Modal, Space } from "antd";
import SearchInput from "../../Components/admin/management/SearchInput";
import DataTable from "../../Components/admin/management/DataTable";
import { getOrdersByUserId } from "../../Api/Controller";
import "../../styles/homeLayout.scss";
import { Toaster } from "react-hot-toast";
import { convertDate, formatVND } from "../../Common/function";
import ManageTag from "../../Components/shared/ManageTag";
import OrderItemsView from "../../Pages/adminPage/view/OrderItemsView";
import { useSelector } from "react-redux";
import { Eye } from "lucide-react";

const OrderPage = () => {
  const [orders, setOrders] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [orderId, setOrderId] = useState();
  const [total, setTotal] = useState();
  const [reloadData, setReloadData] = useState(false);
  let user = useSelector((state) => state.auth.login.currentUser);

  useEffect(() => {
    document.title = "Quản lý đơn hàng";

    setReloadData(false);
    getOrdersByUserId(user.id).then((data) => {
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
      title: "Xem lại sản phẩm",
      key: "operation",
      fixed: "right",
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Eye onClick={() => handleView(record.id, record.totalPrice)} />
          </div>
        </Space>
      ),
    },
  ];

  return (
    <div className="management">
      <Toaster />
      <div className="management-top">
        <h1 className="management-top-title">Danh sách đơn hàng của bạn</h1>
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
      <div className="space"> </div>
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

export default OrderPage;
