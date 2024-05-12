import React from "react";
import { Outlet } from "react-router-dom";
import SideBar from "../Components/admin/common/SideBar";
import Topbar from "../Components/admin/common/Topbar";
import "../styles/adminLayout.scss";

const AdminLayout = () => {
  return (
    <>
      <div className="admin-layout">
        <SideBar />
        <div className="admin-layout-content">
          <Topbar />
          <Outlet />
        </div>
      </div>
    </>
  );
};

export default AdminLayout;
