import React from "react";
import { useNavigate } from "react-router-dom";
import "../styles/homePage.scss";

const Serie = ({ serie }) => {
  const navigate = useNavigate();

  const handleLink = (urlSlug) => {
    navigate(`${urlSlug}`);

    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="serie-list">
        {serie && serie.length > 0
          ? serie.map((item, index) => (
              <div
                key={index}
                onClick={() => handleLink(item.urlSlug)}
                className="serie-list-item"
              >
                {item.name}
              </div>
            ))
          : null}
      </div>
    </>
  );
};

export default Serie;
