import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/homePage/HomePage";
import AdminPage from "../Pages/adminPage/AdminPage";
import ProductDetail from "../Components/productDetail/ProductDetail";
import HomeLayout from "../Pages/Layout/HomeLayout";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomeLayout />}>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="/detail" element={<ProductDetail />}></Route>
        </Route>
      </Routes>
      <Routes>
        <Route path="/admin" element={<AdminPage />}></Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
