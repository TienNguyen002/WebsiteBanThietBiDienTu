import React from "react";
import "./colorSquare.scss";

const colorMap = {
  Đỏ: "#ff0000",
  yellow: "#ffff00",
  "Xanh lá": "#008000",
  Cam: "#ffa500",
  "Xanh nước": "#0000ff",
  black: "#000000",
  // Add more color mappings here
};

const ColorSquare = ({ color }) => {
  const hexColor = colorMap[color];

  if (!hexColor) {
    return <div>Không có màu: {color}</div>;
  }

  return (
    <div
      style={{
        backgroundColor: hexColor,
      }}
      className="color-square"
    />
  );
};

export default ColorSquare;
