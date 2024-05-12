import React, { useState, useEffect, useRef } from "react";
import { Table, Dropdown, Menu, Input, Button, Form, Space, Tag } from "antd";
import { DownOutlined } from "@ant-design/icons";
import { Search } from "lucide-react";

const CategoryManagement = () => {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const [bottom] = useState("bottomCenter");

  const handleSearch = (selectedKeys, confirm) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(selectedKeys[0]);
  };

  const handleReset = (clearFilters) => {
    clearFilters();
    setSearchText("");
  };

  const handleTableChange = (pagination, filters, sorter) => {
    console.log("pagination", pagination);
    console.log("filters", filters);
    console.log("sorter", sorter);
  };

  let searchInput;

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
        <Button
          type="primary"
          onClick={confirm}
          style={{ width: 90, marginRight: 8, marginTop: 8 }}
        >
          Ok
        </Button>
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

  const getColumnSearchProps = (dataIndex) => ({
    filterDropdown: ({
      setSelectedKeys,
      selectedKeys,
      confirm,
      clearFilters,
    }) => (
      <div style={{ padding: 8 }}>
        <Input
          ref={(node) => {
            searchInput = node;
          }}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={(e) =>
            setSelectedKeys(e.target.value ? [e.target.value] : [])
          }
          onPressEnter={() => handleSearch(selectedKeys, confirm)}
          style={{ width: 188, marginBottom: 8, display: "block" }}
        />
        <Button
          type="primary"
          onClick={() => handleSearch(selectedKeys, confirm)}
          // icon={<Search />}
          size="small"
          style={{ width: 90, marginRight: 8 }}
        >
          Search
        </Button>
        <Button
          onClick={() => handleReset(clearFilters)}
          size="small"
          style={{ width: 90 }}
        >
          Reset
        </Button>
      </div>
    ),
    filterIcon: (filtered) => (
      <Search
        filtered={filtered}
        style={{ color: filtered ? "#1890ff" : undefined }}
      />
    ),
    onFilterDropdownVisibleChange: (visible) => {
      if (visible) {
        setTimeout(() => searchInput.focus(), 100);
      }
    },
    onFilter: (value, record) =>
      record[dataIndex]
        ? record[dataIndex]
            .toString()
            .toLowerCase()
            .includes(value.toLowerCase())
        : "",
    render: (text) => <a>{text}</a>,
  });

  const dataSource = [
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
  ];

  const columns = [
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
      sorter: (a, b) => a.name - b.name,
      ...getColumnSearchProps("name"),
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
      // width: 100,
      render: (_, record) => (
        <Space size="middle">
          <a>Invite {record.name}</a>
          <a>Delete</a>
        </Space>
      ),
    },
  ];

  return (
    <>
      <div className="management">
        <div className="management-top">
          <h1 className="management-top-title">Quản lý danh mục</h1>
          <p>Thêm mới</p>
        </div>
        <div className="management-table">
          <Form>
            <Table
              columns={columns}
              dataSource={dataSource}
              onChange={handleTableChange}
              pagination={{
                pageSize: 10,
                total: dataSource.length,
                showSizeChanger: true,
                showQuickJumper: true,
                position: [bottom],
              }}
            />
          </Form>
        </div>
      </div>
    </>
  );
};

export default CategoryManagement;
