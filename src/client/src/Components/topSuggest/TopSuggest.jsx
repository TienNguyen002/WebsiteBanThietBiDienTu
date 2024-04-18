import React from "react";
import TopCard from "../topCard/TopCard";
import "./topSuggest.scss";

const TopSuggest = () => {
  return (
    <>
      <div className="top-suggest">
        <TopCard title={"Sản phẩm được đánh giá cao"} />
        <TopCard title={"Sản phẩm mới"} />
        <TopCard title={"Sản phẩm bán chạy"} />
      </div>
    </>
  );
};

export default TopSuggest;
