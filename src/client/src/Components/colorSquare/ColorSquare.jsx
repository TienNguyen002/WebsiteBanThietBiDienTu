import React from "react";
import "./colorSquare.scss";

const colorMap = {
  red: "#ff0000",
  yellow: "#ffff00",
  green: "#008000",
  orange: "#ffa500",
  blue: "#0000ff",
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
