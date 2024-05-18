import React from "react";
import { Dropdown, Menu, Button } from "antd";
import { DownOutlined } from "@ant-design/icons";

const FilterDropdown = ({
  dataIndex,
  dataSource,
  selectedKeys,
  setSelectedKeys,
  confirm,
}) => {
  const uniqueDataSource = [
    ...new Set(dataSource.map((item) => item[dataIndex])),
  ];

  return (
    <div className="filter-dropdown">
      <Dropdown
        overlay={
          <Menu
            items={uniqueDataSource.map((item) => ({
              label: item,
              key: item,
            }))}
            onClick={({ key }) => {
              setSelectedKeys([key]);
              confirm();
            }}
          />
        }
      >
        <Button>
          {selectedKeys.length > 0 ? selectedKeys[0] : "Lựa chọn ..."}
          <DownOutlined />
        </Button>
      </Dropdown>
      <Button
        onClick={() => {
          setSelectedKeys([]);
          confirm();
        }}
        type="primary"
        className="filter-dropdown-reset"
      >
        Xóa lọc
      </Button>
    </div>
  );
};

export default FilterDropdown;
