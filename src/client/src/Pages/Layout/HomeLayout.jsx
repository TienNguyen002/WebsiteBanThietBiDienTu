import React from "react";
import { Outlet } from "react-router-dom";
import Header from "../../Components/header/Header";
import Footer from "../../Components/footer/Footer";
import Privacy from "../../Components/privacy/Privacy";

const HomeLayout = () => {
  return (
    <>
      <Header />
      <div>
        <Outlet />
      </div>
      <Privacy />
      <Footer />
    </>
  );
};

export default HomeLayout;
