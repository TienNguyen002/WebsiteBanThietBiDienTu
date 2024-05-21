import React, { useEffect, useState } from "react";
import { Form, Space, Modal, Image, Tag } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { MoveLeft, PackagePlus, Pencil, Percent, Trash } from "lucide-react";
import {
  deleteCategory,
  deleteProduct,
  getSerieBySlug,
} from "../../../Api/Controller";
import CategoryEdit from "../edit/CategoryEdit";
import Swal from "sweetalert2";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import { useParams } from "react-router-dom";
import { formatVND } from "../../../Common/function";
import DOMPurify from "dompurify";
import ProductEdit from "../edit/ProductEdit";
import ProductSaleEdit from "../edit/ProductSaleEdit";
import AmountAdd from "../edit/AmountAdd";

const ProductManagement = () => {
  const [serie, setSerie] = useState("");
  const [products, setProducts] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [open, setOpen] = useState(false);
  const [saleOpen, setSaleOpen] = useState(false);
  const [amountOpen, setAmountOpen] = useState(false);
  const [idEdit, setIdEdit] = useState(0);
  const [reloadData, setReloadData] = useState(false);
  const param = useParams();
  let { slug } = param;

  useEffect(() => {
    setReloadData(false);
    getSerieBySlug(slug).then((data) => {
      if (data) {
        setSerie(data);
        setProducts(data.products);
      } else {
        setSerie("");
        setProducts([]);
      }
    });
  }, [reloadData]);

  const handleAddClick = () => {
    setIdEdit(0);
    setOpen(true);
  };

  const handleSaleAddClick = (id) => {
    setSaleOpen(true);
    setIdEdit(id);
  };

  const handleAmountAddClick = (id) => {
    setAmountOpen(true);
    setIdEdit(id);
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
    setSaleOpen(false);
    setAmountOpen(false);
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
          deleteProduct(id).then((data) => {
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
      title: "Tên danh mục",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Giá gốc",
      dataIndex: "orPrice",
      key: "orPrice",
      render: (orPrice) => formatVND(orPrice),
      width: 200,
    },
    {
      title: "Giá hiện tại",
      dataIndex: "price",
      key: "price",
      render: (price) => formatVND(price),
      width: 200,
    },
    {
      title: "Màu sản phẩm",
      dataIndex: "colors",
      key: "colors",
      render: (colors) =>
        colors.map((item, index) => <Tag key={index}>{item.name}</Tag>),
      width: 300,
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
            {record.salePrice ? null : (
              <Percent onClick={() => handleSaleAddClick(`${record.id}`)} />
            )}

            <PackagePlus onClick={() => handleAmountAddClick(`${record.id}`)} />
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
      <div className="manage-serie">
        <div className="manage-serie-title">
          <h3 className="title">Dòng sản phẩm:</h3>
          <span>{serie.name}</span>
        </div>
        <div className="manage-serie-description">
          <h3 className="title">Mô tả:</h3>
          <span
            dangerouslySetInnerHTML={{
              __html: DOMPurify.sanitize(serie.description),
            }}
          ></span>
        </div>
        <div className="manage-serie-description">
          <h3 className="title">Danh sách hình ảnh:</h3>
          <Image.PreviewGroup
            preview={{
              onChange: (current, prev) =>
                console.log(`current index: ${current}, prev index: ${prev}`),
            }}
          >
            {serie.images && serie.images.length > 0 ? (
              serie.images.map((item, index) => (
                <Image width={200} src={item.imageUrl} key={index} />
              ))
            ) : (
              <p>Không có ảnh</p>
            )}
          </Image.PreviewGroup>
        </div>
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
            dataSource={products}
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
        <ProductEdit
          id={idEdit}
          serieId={serie.id}
          onOk={handleOk}
          setReloadData={setReloadData}
        />
      </Modal>
      <Modal
        centered
        open={saleOpen}
        footer={null}
        onCancel={handleCancel}
        width={1000}
      >
        <ProductSaleEdit
          id={idEdit}
          onOk={handleCancel}
          setReloadData={setReloadData}
        />
      </Modal>
      <Modal
        centered
        open={amountOpen}
        footer={null}
        onCancel={handleCancel}
        width={1000}
      >
        <AmountAdd
          id={idEdit}
          onOk={handleCancel}
          setReloadData={setReloadData}
        />
      </Modal>
    </div>
  );
};

export default ProductManagement;
