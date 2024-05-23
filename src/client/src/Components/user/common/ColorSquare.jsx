import React from "react";
import "../styles/homePage.scss";

const colorMap = {
  Đỏ: "#ff0000",
  Vàng: "#ffff00",
  "Xanh lá": "#008000",
  Cam: "#ffa500",
  "Xanh nước": "#0000ff",
  Đen: "#000000",
  // Add more color mappings here
};

const NoColorFound = ({ color, click }) => {
  return <div onClick={click}>{color}</div>;
};

const ColorSquare = ({ color, slug, onClick, select }) => {
  const hexColor = colorMap[color];

  if (!hexColor) {
    return <NoColorFound color={color} click={onClick} />;
  }

  return (
    <div
      key={slug}
      style={{
        backgroundColor: hexColor,
      }}
      className={select === color ? "color-square-selected" : "color-square"}
      onClick={onClick}
    />
  );
};

export default ColorSquare;
