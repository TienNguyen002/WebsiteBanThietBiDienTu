import React, { useRef, useState } from "react";
import { ChevronRight, Smartphone } from "lucide-react";
import category from "../../Shared/data/category.json";
import "./banner.scss";

const Banner = () => {
  return (
    <>
      <div className="home-top-body">
        {category.result.map((item, index) => (
          <div key={index}>
            <Smartphone />
            <span>{item.name}</span>
            <ChevronRight />
          </div>
        ))}
      </div>
      <div></div>
    </>
  );
};

export default Banner;
