import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye, Pencil, Trash } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { deleteCategory, getAllCategory } from "../../../Api/Controller";
import "../../../styles/adminLayout.scss";
import CategoryEdit from "../edit/CategoryEdit";
import Swal from "sweetalert2";

const CategoryManagement = () => {
  const [categories, setCategories] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [idEdit, setIdEdit] = useState(0);
  const navigate = useNavigate();

  const handleLink = (link) => {
    navigate(link);
  };

  useEffect(() => {
    getAllCategory().then((data) => {
      if (data) {
        setCategories(data);
      } else setCategories([]);
    });
  }, []);

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
    setIdEdit(0);
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
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "DELETE",
      }).then((result) => {
        if (result.isConfirmed) {
          deleteCategory(id);
          Swal.fire({
            title: "Xóa thành công",
            icon: "success",
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
      width: 400,
    },
    {
      title: "Tên danh mục",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Số sản phẩm thuộc danh mục",
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
            <Eye onClick={() => handleLink(`${record.id}`)} />
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
      <div className="management-top">
        <h1 className="management-top-title">Quản lý danh mục</h1>
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
            dataSource={categories}
            searchQuery={searchQuery}
            page={page}
            pageSize={pageSize}
            setPage={setPage}
            setPageSize={setPageSize}
          />
        </Form>
      </div>
      <Modal centered open={open} footer={null} onCancel={handleCancel}>
        <CategoryEdit id={idEdit} onOk={handleOk} />
      </Modal>
    </div>
  );
};

export default CategoryManagement;
