import React, { useEffect, useState } from "react";
import { Form, Space, Modal } from "antd";
import SearchInput from "../../../Components/admin/management/SearchInput";
import DataTable from "../../../Components/admin/management/DataTable";
import { Trash } from "lucide-react";
import {
  deleteFeedback,
  getAllFeedbacks,
  getAllOrders,
} from "../../../Api/Controller";
import CategoryEdit from "../edit/CategoryEdit";
import "../../../styles/adminLayout.scss";
import toast, { Toaster } from "react-hot-toast";
import { convertDate, formatVND } from "../../../Common/function";
import Swal from "sweetalert2";

const FeedbackManagement = () => {
  const [feedbacks, setFeedbacks] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [reloadData, setReloadData] = useState(false);

  useEffect(() => {
    document.title = "Quản lý feedback";

    setReloadData(false);
    getAllFeedbacks().then((data) => {
      if (data) {
        setFeedbacks(data);
      } else setFeedbacks([]);
    });
  }, [reloadData]);

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
          deleteFeedback(id).then((data) => {
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
      title: "Tên người gửi",
      dataIndex: "username",
      key: "username",
      width: 400,
    },
    {
      title: "Tiêu đề",
      dataIndex: "title",
      key: "title",
      width: 200,
    },
    {
      title: "Nội dung",
      dataIndex: "description",
      key: "description",
      width: 300,
    },
    {
      title: "Ngày gửi",
      dataIndex: "createdDate",
      key: "createdDate",
      width: 400,
      render: (createdDate) => <span>{convertDate(createdDate)}</span>,
    },
    {
      title: "Chức năng",
      key: "operation",
      fixed: "right",
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <div className="action">
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
      <div className="management-top">
        <h1 className="management-top-title">Quản lý feedback</h1>
        <SearchInput
          searchQuery={searchQuery}
          setSearchQuery={setSearchQuery}
        />
      </div>
      <div className="management-table">
        <Form>
          <DataTable
            columns={columns}
            dataSource={feedbacks}
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

export default FeedbackManagement;
