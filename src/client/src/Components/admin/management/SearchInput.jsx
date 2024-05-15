import React from "react";
import { Input, Button } from "antd";
import { useNavigate } from "react-router-dom";

const SearchInput = ({ searchQuery, setSearchQuery, addClick }) => {
  const navigate = useNavigate();

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
      <Button
        type="primary"
        className="management-action-add"
        onClick={addClick}
      >
        Thêm mới
      </Button>
    </div>
  );
};

export default SearchInput;
