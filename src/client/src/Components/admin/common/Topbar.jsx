import React from "react";
import { Bell, User } from "lucide-react";

const Topbar = () => {
  return (
    <>
      <div className="topbar">
        <span className="topbar-text">Trang Admin</span>
        <div className="topbar-nofication">
          <Bell className="topbar-nofication-bell" />
          <User className="topbar-nofication-user" />
        </div>
      </div>
    </>
  );
};

export default Topbar;
