import React, { useState } from "react";
import { Button, DatePicker, Form, Space } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { getColumnFilterProps } from "../../../Common/tableFunction";
import { Trash } from "lucide-react";
import { useNavigate } from "react-router-dom";
import "../../../styles/adminLayout.scss";
import dayjs from "dayjs";

const SaleManagement = () => {
  const [sale, setSale] = useState();
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [editable, setEditable] = useState(false);
  const navigate = useNavigate();

  const handleLink = (link) => {
    navigate(link);
  };

  const value = dayjs("2024-05-11 00:00:00", "YYYY-MM-DD HH:mm:ss");
  const onOk = (value) => {
    setEditable(!editable);
    console.log(editable);
    console.log("onOk: ", value);
  };

  const [dataSource, setDataSource] = useState([
    {
      key: 1,
      name: "123",
      age: 32,
      address: "10 Downing Street",
    },
    {
      key: 2,
      name: "456",
      age: 42,
      address: "123 Downing Street",
    },
  ]);

  const columns = [
    {
      title: "Hình",
      dataIndex: "name",
      key: "name",
      width: 400,
      sorter: (a, b) => a.name - b.name,
    },
    {
      title: "Tên thương hiệu",
      dataIndex: "age",
      key: "age",
      width: 400,
      sorter: (a, b) => a.age - b.age,
    },
    {
      title: "Số sản phẩm thuộc thương hiệu",
      dataIndex: "age",
      key: "age",
      width: 400,
      sorter: (a, b) => a.age - b.age,
    },
    // {
    //   title: "Address",
    //   dataIndex: "address",
    //   key: "address",
    //   sorter: (a, b) => a.address - b.address,
    //   ...getColumnFilterProps("address", dataSource),
    // },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Trash
              className="action-remove"
              onClick={() => handleLink(`${record.key}`)}
            />
          </div>
        </Space>
      ),
    },
  ];

  return (
    <div className="management">
      <div className="management-top">
        <h1 className="management-top-title">Quản lý ưu đãi</h1>
      </div>
      <div className="management-date">
        <h2 className="management-date-title">Thời gian kết thúc ưu đãi:</h2>
        <DatePicker
          showTime
          value={value}
          placeholder="Thời gian kết thúc ưu đãi"
          onChange={(value, dateString) => {
            console.log("Selected Time: ", value);
            console.log("Formatted Selected Time: ", dateString);
          }}
          className="management-date-picker"
          disabled={editable ? false : true}
          onOk={onOk}
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
            dataSource={dataSource}
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
