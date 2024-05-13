import React from "react";
import { Table } from "antd";

const DataTable = ({
  columns,
  dataSource,
  searchQuery,
  page,
  pageSize,
  setPage,
  setPageSize,
}) => {
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
        current: page,
        pageSize: pageSize,
        onChange: (page, pageSize) => {
          setPage(page);
          setPageSize(pageSize);
        },
        total: filteredData.length,
        showSizeChanger: true,
        showQuickJumper: true,
        position: ["bottomCenter"],
      }}
    />
  );
};

export default DataTable;
