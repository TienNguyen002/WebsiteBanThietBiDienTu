import React, { createContext, useState, useContext } from "react";
import logo from "../../../Shared/images/logo-4.png";
import {
  ChevronFirst,
  ChevronLast,
  LayoutDashboard,
  LayoutList,
  Slack,
  User,
  ShoppingCart,
  MessageCircle,
  Package,
  TicketPercent,
  CirclePercent,
} from "lucide-react";
import "../styles/adminPage.scss";
import { Link } from "react-router-dom";

const SideBarContext = createContext();

const SideBarItem = ({ link, icon, text, alert, setActive, isActive }) => {
  const { expanded } = useContext(SideBarContext);

  const handlePart = (text) => {
    setActive(text);
  };

  return (
    <Link to={link} className="link" onClick={() => handlePart(text)}>
      <li
        className={`sidebar-item ${isActive === text ? "active" : "deactive"}`}
      >
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
  const [active, setActive] = useState("");

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
                isActive={active}
                setActive={setActive}
              />
              <SideBarItem
                link={"/admin/category"}
                icon={<LayoutList size={20} />}
                isActive={active}
                text="Danh mục"
                setActive={setActive}
              />
              <SideBarItem
                link={"/admin/branch"}
                icon={<Slack size={20} />}
                isActive={active}
                setActive={setActive}
                text="Thương hiệu"
              />
              <SideBarItem
                link={"/admin/sale"}
                icon={<CirclePercent size={20} />}
                isActive={active}
                setActive={setActive}
                text="Ưu đãi"
              />
              <SideBarItem
                link={"/admin/serie"}
                icon={<Package size={20} />}
                isActive={active}
                setActive={setActive}
                text="Dòng sản phẩm"
              />
              <SideBarItem
                link={"/admin/order"}
                icon={<ShoppingCart size={20} />}
                isActive={active}
                setActive={setActive}
                text="Giỏ hàng"
              />
              <SideBarItem
                link={"/admin/discount"}
                icon={<TicketPercent size={20} />}
                isActive={active}
                setActive={setActive}
                text="Mã giảm giá"
              />
              <SideBarItem
                link={"/admin/user"}
                icon={<User size={20} />}
                isActive={active}
                setActive={setActive}
                text="Người dùng"
              />
              <SideBarItem
                link={"/admin/feedback"}
                icon={<MessageCircle size={20} />}
                isActive={active}
                setActive={setActive}
                text="Feedback"
              />
            </ul>
          </SideBarContext.Provider>
        </nav>
      </aside>
    </>
  );
};

export default SideBar;
