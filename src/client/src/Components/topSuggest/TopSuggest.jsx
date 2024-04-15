import React from "react";
import TopCard from "../topCard/TopCard";
import "./topSuggest.scss";

const TopSuggest = () => {
  return (
    <>
      <div className="top-suggest">
        <TopCard />
        <TopCard />
      </div>
    </>
  );
};

export default TopSuggest;
