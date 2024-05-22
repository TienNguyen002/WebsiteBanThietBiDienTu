import React, { useState, useEffect } from "react";
import { Button, DatePicker, Form, Space } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Trash } from "lucide-react";
import "../../../styles/adminLayout.scss";
import dayjs from "dayjs";
import {
  getAllSale,
  removeProductSale,
  updateSaleDate,
} from "../../../Api/Controller";
import Swal from "sweetalert2";
import toast, { Toaster } from "react-hot-toast";
import { formatVND } from "../../../Common/function";

const SaleManagement = () => {
  const [sale, setSales] = useState([]);
  const [products, setProducts] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [editable, setEditable] = useState(false);
  const [reloadData, setReloadData] = useState(false);

  const disableDate = (current) => {
    return current && current < dayjs().startOf("day");
  };

  const updateDate = (value) => {
    if (value) {
      let formData = new FormData();
      formData.append("endDate", value.toISOString());
      updateSaleDate(formData).then((data) => {
        if (data) {
          onOk();
          toast.success("Cập nhật thành công");
          setReloadData(true);
        } else {
          toast.error("Cập nhật thất bại");
        }
      });
    }
  };

  const removeProduct = (id) => {
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
          removeProductSale(id).then((data) => {
            if (data) {
              toast.success("Xóa thành công");
              setReloadData(true);
            } else toast.error("Xóa thất bại");
          });
        }
      });
    }
  };

  useEffect(() => {
    document.title = "Quản lý ưu đãi";

    setReloadData(false);
    getAllSale().then((data) => {
      if (data) {
        setSales(data);
        setProducts(data.products);
      } else setSales([]);
    });
  }, [reloadData]);

  const format = "YYYY-MM-DD HH:mm:ss";

  const onOk = () => {
    setEditable(!editable);
  };

  const columns = [
    {
      title: "Hình",
      dataIndex: "imageUrl",
      key: "imageUrl",
      width: 100,
      render: (imageUrl) => (
        <img src={imageUrl} className="item-image" alt={imageUrl} />
      ),
    },
    {
      title: "Sản phẩm",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Giá khuyến mãi",
      dataIndex: "salePrice",
      key: "salePrice",
      width: 400,
      render: (salePrice) => <span>{formatVND(salePrice)}</span>,
      sorter: (a, b) => a.salePrice - b.salePrice,
    },
    {
      title: "Giá hiện tại",
      dataIndex: "price" || "orPrice",
      key: "price" || "orPrice",
      width: 400,
      render: (price) => <span>{formatVND(price)}</span>,
      sorter: (a, b) => a.price - b.price,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Trash
              className="action-remove"
              onClick={() => removeProduct(`${record.id}`)}
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
        <h1 className="management-top-title">Quản lý ưu đãi</h1>
      </div>
      <div className="management-date">
        <h2 className="management-date-title">Thời gian kết thúc ưu đãi:</h2>
        <DatePicker
          showTime
          name="endDate"
          value={dayjs(sale.endDate, format)}
          placeholder="Thời gian kết thúc ưu đãi"
          onChange={(value) => {
            updateDate(value);
          }}
          className="management-date-picker"
          disabled={editable ? false : true}
          onOk={onOk}
          disabledDate={disableDate}
        />
        <Button
          type="primary"
          onClick={onOk}
          className="management-date-button"
        >
          {editable ? "Cập nhật thời gian" : "Chỉnh sửa"}
        </Button>
      </div>

      <div className="management-top">
        <h1 className="management-top-title">
          Các sản phẩm đang trong thời gian ưu đãi
        </h1>
        <SearchInput
          searchQuery={searchQuery}
          setSearchQuery={setSearchQuery}
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
    </div>
  );
};

export default SaleManagement;
