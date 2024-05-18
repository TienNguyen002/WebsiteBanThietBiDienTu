import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye, Pencil, Trash } from "lucide-react";
import { deleteCategory, getAllOrders } from "../../../Api/Controller";
import CategoryEdit from "../edit/CategoryEdit";
import Swal from "sweetalert2";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import { convertDate, formatVND } from "../../../Common/function";
import ManageTag from "../../../Components/shared/ManageTag";
import OrderButton from "../../../Components/admin/common/OrderButton";

const OrderManagement = () => {
  const [orders, setOrders] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [idEdit, setIdEdit] = useState(0);
  const [reloadData, setReloadData] = useState(false);

  useEffect(() => {
    setReloadData(false);
    getAllOrders().then((data) => {
      if (data) {
        setOrders(data);
      } else setOrders([]);
    });
  }, [reloadData]);

  const handleAddClick = () => {
    setIdEdit(0);
    setOpen(true);
  };

  const handleEditClick = (id) => {
    setOpen(true);
    setIdEdit(id);
  };

  const handleOk = () => {
    setOpen(false);
  };

  const handleCancel = () => {
    setOpen(false);
    setIdEdit(0);
  };

  const handleDelete = (id) => {
    Remove(id);
    async function Remove(id) {
      Swal.fire({
        title: "Bạn có muốn xóa dữ liệu này!",
        text: "Dữ liệu này không thể khôi phục khi xóa!",
        cancelButtonText: "Hủy",
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Xóa",
      }).then((result) => {
        if (result.isConfirmed) {
          deleteCategory(id).then((data) => {
            if (data) {
              toast.success("Xóa thành công");
              setReloadData(true);
            } else toast.error("Xóa thất bại");
          });
        }
      });
    }
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
      width: 250,
    },
    {
      title: "Ngày đặt",
      dataIndex: "dateOrder",
      key: "dateOrder",
      width: 400,
      render: (dateOrder) => <span>{convertDate(dateOrder)}</span>,
    },
    {
      title: "Số lượng đặt",
      dataIndex: "quantity",
      key: "quantity",
      width: 400,
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

      width: 400,
    },
    {
      title: "Phương thức thanh toán",
      dataIndex: "paymentMethod",
      key: "paymentMethod",
      width: 400,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Eye />
            <OrderButton status={record.status} />
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
      <Modal centered open={open} footer={null} onCancel={handleCancel}>
        <CategoryEdit
          id={idEdit}
          onOk={handleOk}
          setReloadData={setReloadData}
        />
      </Modal>
    </div>
  );
};

export default OrderManagement;
