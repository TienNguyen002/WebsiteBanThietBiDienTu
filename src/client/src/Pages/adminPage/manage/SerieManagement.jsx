import { Table } from "antd";
import React from "react";

const SerieManagement = () => {
  const dataSource = [
    {
      key: "1",
      name: "Mike",
      age: 32,
      address: "10 Downing Street",
    },
    {
      key: "2",
      name: "John",
      age: 42,
      address: "10 Downing Street",
    },
  ];

  const columns = [
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
    },
    {
      title: "Age",
      dataIndex: "age",
      key: "age",
    },
    {
      title: "Address",
      dataIndex: "address",
      key: "address",
    },
  ];

  return (
    <>
      <div className="management">
        <h1 className="management-title">Quản lý dòng sản phẩm</h1>
        <div className="management-table">
          <Table dataSource={dataSource} columns={columns} />
        </div>
      </div>
    </>
  );
};

export default SerieManagement;
