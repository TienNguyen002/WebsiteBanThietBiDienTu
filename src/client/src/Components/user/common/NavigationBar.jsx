import React from "react";
import { ChevronRight } from "lucide-react";
import { useNavigate } from "react-router-dom";
import "../styles/homePage.scss";

const NavigationBar = ({
  title,
  category,
  categorySlug,
  branch,
  branchSlug,
  serie,
  serieSlug,
  name,
}) => {
  const navigate = useNavigate();

  const handleTitle = () => {
    let path = "";
    switch (title) {
      case "Ưu đãi":
        path = "/sale";
        break;
      case "Sản phẩm đánh giá cao":
        path = "/high-rating";
        break;
      case "Sản phẩm mới":
        path = "/new";
        break;
      case "Sản phẩm bán chạy":
        path = "/top";
        break;
      default:
        path = "/";
        break;
    }
    navigate(path);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleCategory = () => {
    let path = "";
    switch (title) {
      case "Ưu đãi":
        path = `/sale/${categorySlug}`;
        break;
      case "Sản phẩm đánh giá cao":
        path = `/high-rating/${categorySlug}`;
        break;
      case "Sản phẩm mới":
        path = `/new/${categorySlug}`;
        break;
      case "Sản phẩm bán chạy":
        path = `/top/${categorySlug}`;
        break;
      default:
        path = `/list/${categorySlug}`;
        break;
    }
    navigate(path);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleBranch = () => {
    let path = "";
    switch (title) {
      case "Ưu đãi":
        path = `/sale/${categorySlug}/${branchSlug}`;
        break;
      case "Sản phẩm đánh giá cao":
        path = `/high-rating/${categorySlug}/${branchSlug}`;
        break;
      case "Sản phẩm mới":
        path = `/new/${categorySlug}/${branchSlug}`;
        break;
      case "Sản phẩm bán chạy":
        path = `/top/${categorySlug}/${branchSlug}`;
        break;
      default:
        path = `/list/${categorySlug}/${branchSlug}`;
        break;
    }
    navigate(path);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleSerie = () => {
    navigate(`/list/${categorySlug}/${branchSlug}/${serieSlug}`);
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  const handleHome = () => {
    navigate("/");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="navigation-bar">
        <div className="navigation-bar-item">
          <div onClick={handleHome} className="navigation-bar-item-home">
            <i className="fa-solid fa-house"></i>
            Trang chủ
          </div>
          {title ? (
            <>
              <ChevronRight />
              <div onClick={handleTitle} className="navigation-bar-item-link">
                {title}
              </div>
            </>
          ) : null}
          {category ? (
            <>
              <ChevronRight />
              <div
                onClick={handleCategory}
                className="navigation-bar-item-link"
              >
                {category}
              </div>
            </>
          ) : null}
          {branch ? (
            <>
              <ChevronRight />
              <div onClick={handleBranch} className="navigation-bar-item-link">
                {branch}
              </div>
            </>
          ) : null}
          {serie ? (
            <>
              <ChevronRight />
              <div onClick={handleSerie} className="navigation-bar-item-link">
                {serie}
              </div>
            </>
          ) : null}
          {name ? (
            <>
              <ChevronRight />
              {name}
            </>
          ) : null}
        </div>
      </div>
    </>
  );
};

export default NavigationBar;
