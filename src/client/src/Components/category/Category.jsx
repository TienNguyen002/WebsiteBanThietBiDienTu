import React from "react";
import category from "../../Shared/data/category.json";
import { Smartphone } from "lucide-react";
import "./category.scss";

const Category = () => {
  return (
    <>
      <div className="home-category">
        <h1 className="home-category-title">Danh mục</h1>
        <div className="home-category-component">
          {category.result.map((item, index) => (
            <div key={index} className="home-category-component-item">
              <div>
                <Smartphone className="home-category-component-icon" />
                <span className="home-category-component-name">
                  {item.name}
                </span>
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default Category;
