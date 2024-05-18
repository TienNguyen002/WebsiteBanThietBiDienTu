import React from "react";
import { Bell, MessageSquareText, User } from "lucide-react";

const Topbar = () => {
  return (
    <>
      <div className="topbar">
        <span className="topbar-text">Trang Admin</span>
        <div className="topbar-nofication">
          {/* <MessageSquareText className="topbar-nofication-message" /> */}
          <Bell className="topbar-nofication-bell" />
          <User className="topbar-nofication-user" />
        </div>
      </div>
    </>
  );
};

export default Topbar;
