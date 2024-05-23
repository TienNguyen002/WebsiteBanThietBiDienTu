import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Pencil, Trash } from "lucide-react";
import { deleteBranch, getAllBranch } from "../../../Api/Controller";
import Swal from "sweetalert2";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import BranchEdit from "../edit/BranchEdit";

const BranchManagement = () => {
  const [branches, setBranches] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [idEdit, setIdEdit] = useState(0);
  const [reloadData, setReloadData] = useState(false);

  useEffect(() => {
    document.title = "Quản lý thương hiệu";
    setReloadData(false);
    getAllBranch().then((data) => {
      if (data) {
        setBranches(data);
      } else setBranches([]);
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
          deleteBranch(id).then((data) => {
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
      title: "Hình",
      dataIndex: "imageUrl",
      key: "imageUrl",
      render: (imageUrl) => (
        <img src={imageUrl} className="item-image" alt={imageUrl} />
      ),
      width: 100,
    },
    {
      title: "Tên thương hiệu",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Số sản phẩm thuộc thương hiệu",
      dataIndex: "productCount",
      key: "productCount",
      width: 400,
      sorter: (a, b) => a.productCount - b.productCount,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Pencil
              className="action-edit"
              onClick={() => handleEditClick(`${record.id}`)}
            />
            <Trash
              className="action-remove"
              onClick={() => handleDelete(`${record.id}`)}
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
        <h1 className="management-top-title">Quản lý thương hiệu</h1>
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
            dataSource={branches}
            searchQuery={searchQuery}
            page={page}
            pageSize={pageSize}
            setPage={setPage}
            setPageSize={setPageSize}
          />
        </Form>
      </div>
      <Modal centered open={open} footer={null} onCancel={handleCancel}>
        <BranchEdit id={idEdit} onOk={handleOk} setReloadData={setReloadData} />
      </Modal>
    </div>
  );
};

export default BranchManagement;
