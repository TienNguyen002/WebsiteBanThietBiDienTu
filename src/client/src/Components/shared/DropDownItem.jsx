import React from "react";
import "./shared.scss";

const DropDownItem = (props) => {
  return (
    <li className="drop-down">
      <p className="drop-down">
        {props.image} {props.title}
      </p>
    </li>
  );
};

export default DropDownItem;
