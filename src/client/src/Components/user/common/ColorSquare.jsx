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

const NoColorFound = ({ color }) => {
  return <div>Không có màu: {color}</div>;
};

const ColorSquare = ({ color, slug, onClick }) => {
  const hexColor = colorMap[color];

  if (!hexColor) {
    return <NoColorFound color={color} />;
  }

  return (
    <div
      key={slug}
      style={{
        backgroundColor: hexColor,
      }}
      className="color-square"
      onClick={() => onClick(slug)}
    />
  );
};

export default ColorSquare;
