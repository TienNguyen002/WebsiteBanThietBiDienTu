import React, { useEffect, useState } from "react";
import { Form, Space, Modal, Button } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye, Trash } from "lucide-react";
import { deleteUser, getAllUsers, updateRole } from "../../../Api/Controller";
import Swal from "sweetalert2";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import ManageTag from "../../../Components/shared/ManageTag";
import { useSelector } from "react-redux";
import { getColumnFilterProps } from "../../../Common/tableFunction";
import OrderView from "../view/OrderView";
import UserEdit from "../edit/UserEdit";

const UserManagement = () => {
  const [users, setUsers] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [editOpen, setEditOpen] = useState(false);
  const [reloadData, setReloadData] = useState(false);
  const [orders, setOrders] = useState();

  let user = useSelector((state) => state.auth.login.currentUser);

  useEffect(() => {
    setReloadData(false);
    getAllUsers().then((data) => {
      if (data) {
        setUsers(data);
      } else setUsers([]);
    });
  }, [reloadData]);

  const handleAddClick = () => {
    setEditOpen(true);
  };

  const handleView = (orders) => {
    setOpen(true);
    setOrders(orders);
  };

  const handleCancel = () => {
    setEditOpen(false);
    setOpen(false);
  };

  const handleUpdateRole = (id) => {
    UpdateRole(id);
    async function UpdateRole(id) {
      Swal.fire({
        title: "Bạn có muốn thay đổi vai trò của người này này!",
        cancelButtonText: "Hủy",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Xóa",
      }).then((result) => {
        if (result.isConfirmed) {
          updateRole(id).then((data) => {
            if (data) {
              toast.success("Thay đổi vai trò thành công");
              setReloadData(true);
            } else toast.error("Thay đổi vai trò thất bại");
          });
        }
      });
    }
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
          deleteUser(id).then((data) => {
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
    // {
    //   title: "Hình",
    //   dataIndex: "images",
    //   key: "images",
    //   render: (imageUrl) => (
    //     <img src={imageUrl} className="item-image" alt={imageUrl} />
    //   ),
    //   width: 100,
    // },
    {
      title: "Tên người dùng",
      dataIndex: "name",
      key: "name",
      width: 200,
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
      width: 200,
    },
    {
      title: "Số điện thoại",
      dataIndex: "phoneNumber",
      key: "phoneNumber",
      width: 150,
    },
    {
      title: "Địa chỉ",
      dataIndex: "address",
      key: "address",
      width: 200,
    },
    {
      title: "Vai trò",
      dataIndex: "role",
      key: "role",
      ...getColumnFilterProps("role", users),
      render: (role) => <ManageTag tag={role} />,
      width: 100,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Eye onClick={() => handleView(record.orders)} />
            {user.role === "Quản lý" ? (
              <Trash
                className="action-remove"
                onClick={() => handleDelete(`${record.id}`)}
              />
            ) : null}
            {user.role === "Quản lý" ? (
              record.role === "Nhân viên" ? (
                <Button
                  type="primary"
                  onClick={() => handleUpdateRole(record.id)}
                >
                  Thay đổi thành quản lý
                </Button>
              ) : record.role === "Người dùng" ? (
                <Button
                  type="primary"
                  onClick={() => handleUpdateRole(record.id)}
                >
                  Thay đổi thành nhân viên
                </Button>
              ) : null
            ) : null}
          </div>
        </Space>
      ),
    },
  ];

  return (
    <div className="management">
      <Toaster />
      <div className="management-top">
        <h1 className="management-top-title">Quản lý người dùng</h1>
        <SearchInput
          searchQuery={searchQuery}
          setSearchQuery={setSearchQuery}
          addClick={handleAddClick}
        />
      </div>
      <div className="management-table">
        <Form>
          <DataTable
            columns={columns}
            dataSource={users}
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
        <OrderView orders={orders} />
      </Modal>
      <Modal centered open={editOpen} footer={null} onCancel={handleCancel}>
        <UserEdit onOk={handleCancel} setReloadData={setReloadData} />
      </Modal>
    </div>
  );
};

export default UserManagement;
