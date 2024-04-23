import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/userPage/HomePage";
import ProductDetail from "../Pages/userPage/ProductDetail";
import AdminPage from "../Pages/adminPage/AdminPage";
import HomeLayout from "../Layout/HomeLayout";
import MorePage from "../Pages/userPage/MorePage";
import SearchPage from "../Pages/userPage/SearchPage";
import SalePage from "../Pages/userPage/SalePage";
import BranchPage from "./../Pages/userPage/BranchPage";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomeLayout />}>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="/detail" element={<ProductDetail />}></Route>
          <Route path="/sale" element={<SalePage />}></Route>
          <Route path="/more" element={<MorePage />}></Route>
          <Route path="/:urlSlug" element={<MorePage />}></Route>
          <Route path="/branch" element={<BranchPage />}></Route>
          <Route path="/search" element={<SearchPage />}></Route>
        </Route>
      </Routes>
      <Routes>
        <Route path="/admin" element={<AdminPage />}></Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
