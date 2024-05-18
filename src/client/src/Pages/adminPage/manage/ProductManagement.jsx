import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye, MoveLeft, Pencil, Trash } from "lucide-react";
import { getColumnFilterProps } from "../../../Common/tableFunction";
import { deleteCategory, getAllSerie } from "../../../Api/Controller";
import CategoryEdit from "../edit/CategoryEdit";
import Swal from "sweetalert2";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import { useNavigate } from "react-router-dom";

const ProductManagement = () => {
  const [series, setSeries] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [idEdit, setIdEdit] = useState(0);
  const [reloadData, setReloadData] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    setReloadData(false);
    getAllSerie().then((data) => {
      if (data) {
        setSeries(data);
      } else setSeries([]);
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

  const goBack = () => {
    window.history.go(-1);
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
      title: "Hình",
      dataIndex: "images",
      key: "images",
      render: (images) =>
        images[0] ? (
          <img
            src={images[0].imageUrl}
            className="item-image"
            alt={images[0].imageUrl}
          />
        ) : null,
      width: 100,
    },
    {
      title: "Tên danh mục",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Danh mục",
      dataIndex: "category",
      key: "name",
      ...getColumnFilterProps("category", series),
      width: 400,
    },
    {
      title: "Thương hiệu",
      dataIndex: "branch",
      key: "branch",
      ...getColumnFilterProps("branch", series),
      width: 400,
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
      <div className="management-back" onClick={goBack}>
        <MoveLeft />
      </div>
      <div className="management-top">
        <h1 className="management-top-title">Danh sách sản phẩm </h1>
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
            dataSource={series}
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

export default ProductManagement;
