//Import Component Library
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
//Import API
import { getAllCategory } from "../../../../Api/Controller";
//CSS
import "./category.scss";

const Category = (props) => {
  const { title, sale } = props;
  const [categories, setCategories] = useState([]);
  const navigate = useNavigate();

  const handleLink = () => {
    if (sale) {
      navigate("/sale/1");
    }
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  useEffect(() => {
    getAllCategory().then((data) => {
      if (data) {
        setCategories(data);
      } else setCategories([]);
    });
  }, []);

  return (
    <>
      <div className="home-category">
        {title ? (
          <div className="home-category-top">
            <h1 className="home-category-top-title">Danh mục</h1>
          </div>
        ) : null}
        <div className="home-category-component">
          {categories.map((item, index) => (
            <div
              key={index}
              className="home-category-component-item"
              onClick={handleLink}
            >
              {/* <div> */}
              {/* <Smartphone className="home-category-component-icon" /> */}
              <img
                src={item.imageUrl}
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
