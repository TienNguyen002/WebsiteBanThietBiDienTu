//Import Component Library
import React from "react";
import { useNavigate } from "react-router-dom";
//CSS
import "../styles/homePage.scss";

const Branch = (props) => {
  const { branch } = props;
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
      <div className="branch-list">
        {branch && branch.length > 0
          ? branch.map((item, index) => (
              <div key={index} onClick={() => handleLink(item.urlSlug)}>
                <img
                  src={item.imageUrl}
                  alt={item.name}
                  className="branch-list-logo"
                />
              </div>
            ))
          : null}
      </div>
    </>
  );
};

export default Branch;
