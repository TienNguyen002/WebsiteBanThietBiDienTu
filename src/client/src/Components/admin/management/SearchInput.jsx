import React from "react";
import { Input, Button } from "antd";
import { useSelector } from "react-redux";

const SearchInput = ({ searchQuery, setSearchQuery, addClick }) => {
  let user = useSelector((state) => state.auth.login.currentUser);

  const handleSearch = (e) => {
    setSearchQuery(e.target.value);
  };

  return (
    <div className="management-action">
      <Input
        value={searchQuery}
        onChange={handleSearch}
        placeholder="Tìm kiếm ..."
        className="management-action-search"
      />
      {/* <Button type="primary" icon={<Search />} style={{ marginLeft: 8 }}>
          Search
        </Button> */}
      {addClick && user.role === "Quản lý" ? (
        <Button
          type="primary"
          className="management-action-add"
          onClick={addClick}
        >
          Thêm mới
        </Button>
      ) : null}
    </div>
  );
};

export default SearchInput;
