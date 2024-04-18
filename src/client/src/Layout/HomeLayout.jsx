import React, {useState, useRef, useEffect} from "react";
import { Outlet } from "react-router-dom";
import Header from "../Components/header/Header";
import Footer from "../Components/footer/Footer";
import { ArrowUp } from "lucide-react";

const HomeLayout = () => {
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
    <>
      <Header />
      <div>
        <Outlet />
      </div>
      {show ? (
        <button
          ref={buttonRef}
          onClick={goToTop}
          className="home-page-top-button"
        >
          <ArrowUp />
        </button>
      ) : null}
      <Footer />
    </>
  );
};

export default HomeLayout;
