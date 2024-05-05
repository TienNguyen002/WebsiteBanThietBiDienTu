import React from "react";
import "./colorSquare.scss";

const colorMap = {
  Đỏ: "#ff0000",
  Vàng: "#ffff00",
  "Xanh lá": "#008000",
  Cam: "#ffa500",
  "Xanh nước": "#0000ff",
  Đen: "#000000",
  // Add more color mappings here
};

const NoColorFound = ({ color }) => {
  return <div>Không có màu: {color}</div>;
};

const ColorSquare = ({ color, onClick }) => {
  const hexColor = colorMap[color];

  if (!hexColor) {
    return <NoColorFound color={color} />;
  }

  return (
    <div
      key={color}
      style={{
        backgroundColor: hexColor,
      }}
      className="color-square"
      onClick={() => onClick(color)}
    />
  );
};

export default ColorSquare;
