import React, { useEffect, useRef, useState } from "react";
import FlashSale from "./../../Components/flashSale/FlashSale";
import Product from "../../Components/product/Product";
import { ArrowUp } from "lucide-react";
import "../../styles/homePage.scss";
import TopSuggest from "../../Components/topSuggest/TopSuggest";
import TopBody from "../../Components/topBody/TopBody";
import Privacy from "../../Components/privacy/Privacy";
import Banner from "../../Components/banner/Banner";
import Category from "../../Components/category/Category";

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
        if (buttonRef.current) {
          buttonRef.current.style.bottom = "35%";
        }
        // buttonRef.current.style.bottom = "8%";
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
      <TopBody />
      <FlashSale />
      <Privacy />
      <TopSuggest />
      <Product />
      <Product />
      <Banner />
      <Product />
      <Product />
      <Category />
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
