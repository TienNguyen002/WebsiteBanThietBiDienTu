import React from "react";
import { Bell, MessageSquareText } from "lucide-react";

const Topbar = () => {
  return (
    <>
      <div className="topbar">
        <span className="topbar-text">Trang Admin</span>
        <div className="topbar-nofication">
          <MessageSquareText className="topbar-nofication-message" />
          <Bell className="topbar-nofication-bell" />
        </div>
      </div>
    </>
  );
};

export default Topbar;
