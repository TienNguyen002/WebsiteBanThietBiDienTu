import React, { useState } from "react";
import { Form, Space } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { getColumnFilterProps } from "../../../Common/tableFunction";
import { Eye, Pencil, Trash } from "lucide-react";
import { useNavigate } from "react-router-dom";
import "../../../styles/adminLayout.scss";

const CategoryManagement = () => {
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const navigate = useNavigate();

  const handleLink = (link) => {
    navigate(link);
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
      sorter: (a, b) => a.name - b.name,
    },
    {
      title: "Tên danh mục",
      dataIndex: "age",
      key: "age",
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
            <Eye onClick={() => handleLink(`${record.key}`)} />
            <Pencil
              className="action-edit"
              onClick={() => handleLink(`${record.key}`)}
            />
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
        <h1 className="management-top-title">Quản lý danh mục</h1>
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

export default CategoryManagement;
