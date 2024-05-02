//Import Component Library
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
//Import API
import { getAllCategory } from "../../../../Api/Controller";
//CSS
import "./category.scss";

const Category = (props) => {
  const { title, sale, category } = props;
  const [categories, setCategories] = useState([]);
  const navigate = useNavigate();

  const handleLink = (urlSlug) => {
    if (sale) {
      navigate(`/sale/${urlSlug}`);
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
          <>
            <div className="home-category-top">
              <h1 className="home-category-top-title">Danh mục</h1>
            </div>
            <div className="home-category-component">
              {categories.map((item, index) => (
                <div
                  key={index}
                  className="home-category-component-item"
                  onClick={handleLink(item.urlSlug)}
                >
                  <img
                    src={item.imageUrl}
                    alt={item.name}
                    className="home-category-component-item-image"
                  />
                </div>
              ))}
            </div>
          </>
        ) : (
          <>
            <div className="home-category-component">
              {category && category.length > 0
                ? category.map((item, index) => (
                    <div
                      key={index}
                      className="home-category-component-item"
                      onClick={handleLink}
                    >
                      <img
                        src={item.imageUrl}
                        alt={item.name}
                        className="home-category-component-item-image"
                      />
                    </div>
                  ))
                : null}
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default Category;
