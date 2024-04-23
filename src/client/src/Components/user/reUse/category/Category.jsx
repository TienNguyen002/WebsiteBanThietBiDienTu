//Import Component Library
import React from "react";
import { useNavigate } from "react-router-dom";
//Import Data
import category from "../../../../Shared/data/category.json";
//CSS
import "./category.scss";

const Category = (props) => {
  const { title } = props;
  const navigate = useNavigate();

  const handleLink = () => {
    navigate("/more");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="home-category">
        {title ? (
          <div className="home-category-top">
            <h1 className="home-category-top-title">Danh mục</h1>
          </div>
        ) : null}
        <div className="home-category-component">
          {category.result.map((item, index) => (
            <div
              key={index}
              className="home-category-component-item"
              onClick={handleLink}
            >
              {/* <div> */}
              {/* <Smartphone className="home-category-component-icon" /> */}
              <img
                src={item.image}
                alt={item.name}
                className="home-category-component-item-image"
              />
              {/* <span className="home-category-component-name">
                  {item.name}
                </span> */}
              {/* </div> */}
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default Category;
