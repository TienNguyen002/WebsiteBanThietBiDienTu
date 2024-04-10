import React, { useEffect } from "react";
import Header from "../../Components/header/Header";
import Banner from "../../Components/banner/Banner";

const HomePage = () => {
  useEffect(() => {
    document.title = "Trang chủ";
  }, []);

  return (
    <div>
      <Header />
      <Banner />
    </div>
  );
};

export default HomePage;
