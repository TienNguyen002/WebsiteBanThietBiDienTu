import React, { useEffect, useState } from "react";
import { Form, Space } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Eye, Pencil, Trash } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { getAllCategory } from "../../../Api/Controller";
import "../../../styles/adminLayout.scss";

const CategoryManagement = () => {
  const [categories, setCategories] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const navigate = useNavigate();

  const handleLink = (link) => {
    navigate(link);
  };

  useEffect(() => {
    getAllCategory().then((data) => {
      if (data) {
        setCategories(data);
      } else setCategories([]);
    });
  }, []);

  const columns = [
    {
      title: "Hình",
      dataIndex: "imageUrl",
      key: "imageUrl",
      render: (imageUrl) => <img src={imageUrl} className="item-image" />,
      width: 400,
    },
    {
      title: "Tên danh mục",
      dataIndex: "name",
      key: "name",
      width: 400,
    },
    {
      title: "Số sản phẩm thuộc danh mục",
      dataIndex: "productCount",
      key: "productCount",
      width: 400,
      sorter: (a, b) => a.productCount - b.productCount,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
            <Eye onClick={() => handleLink(`${record.id}`)} />
            <Pencil
              className="action-edit"
              onClick={() => handleLink(`${record.id}`)}
            />
            <Trash
              className="action-remove"
              onClick={() => handleLink(`${record.id}`)}
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
            dataSource={categories}
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
