import React from "react";
import { Input, Button } from "antd";

const SearchInput = ({ searchQuery, setSearchQuery }) => {
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
      <Button type="primary" className="management-action-add">
        Thêm mới
      </Button>
    </div>
  );
};

export default SearchInput;
