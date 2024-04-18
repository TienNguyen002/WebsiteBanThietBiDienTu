import React from "react";
import branch from "../../Shared/data/branch.json";
import "./branch.scss";

const Branch = () => {
  return (
    <>
      <div className="branch-list">
        {branch.result.map((item, index) => (
          <img
            key={index}
            src={item.logo}
            alt={item.name}
            className="branch-list-logo"
          />
        ))}
      </div>
    </>
  );
};

export default Branch;
