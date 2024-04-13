import React from "react";
import { Outlet } from "react-router-dom";
import Header from "../../Components/header/Header";
import Footer from "../../Components/footer/Footer";

const HomeLayout = () => {
  return (
    <>
      <Header />
      <div>
        <Outlet />
      </div>
      <Footer />
    </>
  );
};

export default HomeLayout;
