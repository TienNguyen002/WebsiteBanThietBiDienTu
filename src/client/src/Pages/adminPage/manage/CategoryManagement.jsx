import React, { useState, useEffect } from "react";
import { Table, Input, Button, Form, Space, Dropdown, Menu } from "antd";
import { Search } from "lucide-react";
import { DownOutlined } from "@ant-design/icons";

const SearchInput = ({ searchQuery, setSearchQuery }) => {
  const handleSearch = (e) => {
    setSearchQuery(e.target.value);
  };

  return (
    <div style={{ display: "flex", alignItems: "center" }}>
      <Input
        value={searchQuery}
        onChange={handleSearch}
        placeholder="Search"
        style={{ width: 200 }}
      />
      {/* <Button type="primary" icon={<Search />} style={{ marginLeft: 8 }}>
        Search
      </Button> */}
      <Button type="primary" style={{ marginLeft: 8 }}>
        Add
      </Button>
    </div>
  );
};

const DataTable = ({ columns, dataSource, searchQuery }) => {
  const filteredData = dataSource.filter((item) => {
    return Object.values(item).some((value) =>
      value.toString().toLowerCase().includes(searchQuery.toLowerCase())
    );
  });

  return (
    <Table
      columns={columns}
      dataSource={filteredData}
      pagination={{
        pageSize: 10,
        total: filteredData.length,
        showSizeChanger: true,
        showQuickJumper: true,
        position: ["bottomCenter"],
      }}
    />
  );
};

const CategoryManagement = () => {
  const [searchQuery, setSearchQuery] = useState("");

  const getColumnFilterProps = (dataIndex) => ({
    filterDropdown: ({
      setSelectedKeys,
      selectedKeys,
      confirm,
      clearFilters,
    }) => (
      <div style={{ padding: 8 }}>
        <Dropdown
          overlay={
            <Menu
              items={dataSource.map((item) => ({
                label: item[dataIndex],
                key: item[dataIndex],
              }))}
              onClick={({ key }) => {
                setSelectedKeys([key]);
                confirm();
              }}
            />
          }
        >
          <Button>
            {selectedKeys.length > 0 ? selectedKeys[0] : "Select"}{" "}
            <DownOutlined />
          </Button>
        </Dropdown>
        <Button onClick={clearFilters} style={{ width: 90, marginTop: 8 }}>
          Reset
        </Button>
      </div>
    ),
    onFilter: (value, record) =>
      record[dataIndex]
        ? record[dataIndex]
            .toString()
            .toLowerCase()
            .includes(value.toLowerCase())
        : "",
    render: (text) => <a>{text}</a>,
  });

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
      title: "Name",
      dataIndex: "name",
      key: "name",
      sorter: (a, b) => a.name - b.name,
    },
    {
      title: "Age",
      dataIndex: "age",
      key: "age",
      sorter: (a, b) => a.age - b.age,
    },
    {
      title: "Address",
      dataIndex: "address",
      key: "address",
      sorter: (a, b) => a.address - b.address,
      ...getColumnFilterProps("address"),
    },
    {
      title: "Action",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <a>Invite {record.name}</a>
          <a>Delete</a>
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
          />
        </Form>
      </div>
    </div>
  );
};

export default CategoryManagement;
