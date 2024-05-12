import React, { createContext, useState, useContext } from "react";
import logo from "../../../Shared/images/logo-4.png";
import {
  ChevronFirst,
  ChevronLast,
  MoreVertical,
  UserIcon,
  LayoutDashboard,
  LayoutList,
  Slack,
  User,
  ShoppingCart,
  MessageCircle,
  Package,
  TicketPercent,
} from "lucide-react";
import "../styles/adminPage.scss";
import { Link } from "react-router-dom";

const SideBarContext = createContext();

const SideBarItem = ({ link, icon, text, active, alert }) => {
  const { expanded } = useContext(SideBarContext);

  return (
    <Link to={link} className="link">
      <li className={`sidebar-item ${active ? "active" : "deactive"}`}>
        {icon}
        <span
          className={`sidebar-item-text ${expanded ? "expanded" : "collapsed"}`}
        >
          {text}
        </span>
        {alert && (
          <div
            className={`sidebar-item-alert ${
              expanded ? "" : "alert-collapsed"
            }`}
          />
        )}
        {!expanded && <div className={`sidebar-item-collapse`}>{text}</div>}
      </li>
    </Link>
  );
};

const SideBar = () => {
  const [expanded, setExpanded] = useState(true);

  return (
    <>
      <aside className="admin">
        <nav className="admin-navbar">
          <div className="admin-navbar-top">
            <img
              src={logo}
              className={`admin-navbar-top-image ${
                expanded ? "image-expanded" : "collapsed"
              }`}
              alt="logo"
            />
            <button
              onClick={() => setExpanded(!expanded)}
              className="admin-navbar-top-button"
            >
              {expanded ? <ChevronFirst /> : <ChevronLast />}
            </button>
          </div>
          <SideBarContext.Provider value={{ expanded }}>
            <ul className="admin-navbar-items">
              <SideBarItem
                link={"/admin/dashboard"}
                icon={<LayoutDashboard size={20} />}
                text="Dashboard"
              />
              <SideBarItem
                link={"/admin/category"}
                icon={<LayoutList size={20} />}
                text="Danh mục"
              />
              <SideBarItem
                link={"/admin/branch"}
                icon={<Slack size={20} />}
                text="Thương hiệu"
              />
              <SideBarItem
                link={"/admin/serie"}
                icon={<Package size={20} />}
                text="Dòng sản phẩm"
              />
              <SideBarItem
                link={"/admin/cart"}
                icon={<ShoppingCart size={20} />}
                text="Giỏ hàng"
              />
              <SideBarItem
                link={"/admin/discount"}
                icon={<TicketPercent size={20} />}
                text="Mã giảm giá"
              />
              <SideBarItem
                link={"/admin/user"}
                icon={<User size={20} />}
                text="Người dùng"
              />
              <SideBarItem
                link={"/admin/feedback"}
                icon={<MessageCircle size={20} />}
                text="Feedback"
              />
            </ul>
          </SideBarContext.Provider>
          <div className="admin-navbar-user">
            <UserIcon className="admin-navbar-user-icon" />
            {/* <img className="w-10 h-10 rounded-md"/> */}
            <div
              className={`admin-navbar-user-info ${
                expanded ? "user-expanded" : "collapsed"
              }`}
            >
              <div className="admin-navbar-user-info-text">
                <h4 className="admin-navbar-user-info-text-name">Admin</h4>
                <span className="admin-navbar-user-info-text-gmail">
                  admin@gmail.com
                </span>
              </div>
              <MoreVertical
                size={20}
                className="admin-navbar-user-info-text-button"
              />
            </div>
          </div>
        </nav>
      </aside>
    </>
  );
};

export default SideBar;
