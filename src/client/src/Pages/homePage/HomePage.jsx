import React, { useEffect, useRef, useState } from "react";
import Category from "../../Components/category/Category";
import FlashSale from "./../../Components/flashSale/FlashSale";
import TopCategory from "../../Components/topCategory/TopCategory";
import "../../styles/homePage.scss";
import NewProduct from "./../../Components/newProduct/NewProduct";
import Product from "../../Components/product/Product";
import Privacy from "../../Components/privacy/Privacy";
import { ArrowUp } from "lucide-react";

const HomePage = () => {
  const buttonRef = useRef(null);
  const [show, setShow] = useState(false);

  useEffect(() => {
    document.title = "Trang chủ";

    const handleScroll = () => {
      if (window.scrollY > 0) {
        setShow(true);
        if (buttonRef.current) {
          buttonRef.current.style.bottom = "0";
        }
      } else {
        setShow(false);
      }
      if (window.scrollY >= 100) {
      }

      if (
        window.innerHeight + window.pageYOffset >=
        document.body.offsetHeight
      ) {
        buttonRef.current.style.bottom = "8%";
        // buttonRef.current.style.bottom = "33%";
      }
    };

    window.addEventListener("scroll", handleScroll);

    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  const goToTop = () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
  };

  return (
    <div className="home-page">
      <Category />
      <FlashSale />
      <TopCategory />
      <NewProduct />
      <Product />
      <Product />
      <Product />
      <Privacy />
      {show ? (
        <button
          ref={buttonRef}
          onClick={goToTop}
          className="home-page-top-button"
        >
          <ArrowUp />
        </button>
      ) : null}
    </div>
  );
};

export default HomePage;
