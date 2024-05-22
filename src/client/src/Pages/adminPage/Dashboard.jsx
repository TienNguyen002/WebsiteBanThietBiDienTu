import React, { useEffect } from "react";

const Dashboard = () => {
  useEffect(() => {
    document.title = "Trang Admin";
  }, []);

  return (
    <>
      <h1>Bảng thống kê hệ thống</h1>
    </>
  );
};

export default Dashboard;
