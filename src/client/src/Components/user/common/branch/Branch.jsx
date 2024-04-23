//Import Component Library
import React from "react";
//Import data
import branch from "../../../../Shared/data/branch.json";
//CSS
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
