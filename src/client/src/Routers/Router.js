import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/userPage/HomePage";
import ProductDetail from "../Pages/userPage/ProductDetail";
import AdminPage from "../Pages/adminPage/AdminPage";
import HomeLayout from "../Layout/HomeLayout";
import MorePage from "../Pages/userPage/MorePage";
import SearchPage from "../Pages/userPage/SearchPage";
import ListPage from "../Pages/userPage/ListPage";
import BranchPage from "./../Pages/userPage/BranchPage";
import LoginPage from "../Pages/accountPage/LoginPage";
import RegisterPage from "../Pages/accountPage/RegisterPage";
import AdminLayout from "../Layout/AdminLayout";
import NotFound from "../Pages/common/NotFound";
import BadRequest from "../Pages/common/BadRequest";
import Dashboard from "../Pages/adminPage/Dashboard";
import CategoryManagement from "../Pages/adminPage/manage/CategoryManagement";
import BranchManagement from "../Pages/adminPage/manage/BranchManagement";
import SerieManagement from "../Pages/adminPage/manage/SerieManagement";
import CartManagement from "../Pages/adminPage/manage/CartManagement";
import FeedbackManagement from "../Pages/adminPage/manage/FeedbackManagement";
import UserManagement from "../Pages/adminPage/manage/UserManagement";
import DiscountManagement from "../Pages/adminPage/manage/DiscountManagement";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomeLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/detail/:slug" element={<ProductDetail />} />
          <Route
            path="/sale"
            element={
              <ListPage
                isSale={true}
                isHighRating={false}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/sale/:category"
            element={
              <MorePage
                isSale={true}
                isHighRating={false}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/sale/:category/:branch"
            element={
              <BranchPage
                isSale={true}
                isHighRating={false}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/high-rating"
            element={
              <ListPage
                isSale={false}
                isHighRating={true}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/high-rating/:category"
            element={
              <MorePage
                isSale={false}
                isHighRating={true}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/high-rating/:category/:branch"
            element={
              <BranchPage
                isSale={false}
                isHighRating={true}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/new"
            element={
              <ListPage
                isSale={false}
                isHighRating={false}
                isNew={true}
                isTop={false}
              />
            }
          />
          <Route
            path="/new/:category"
            element={
              <MorePage
                isSale={false}
                isHighRating={false}
                isNew={true}
                isTop={false}
              />
            }
          />
          <Route
            path="/new/:category/:branch"
            element={
              <BranchPage
                isSale={false}
                isHighRating={false}
                isNew={true}
                isTop={false}
              />
            }
          />
          <Route
            path="/top"
            element={
              <ListPage
                isSale={false}
                isHighRating={false}
                isNew={false}
                isTop={true}
              />
            }
          />
          <Route
            path="/top/:category"
            element={
              <MorePage
                isSale={false}
                isHighRating={false}
                isNew={false}
                isTop={true}
              />
            }
          />
          <Route
            path="/top/:category/:branch"
            element={
              <BranchPage
                isSale={false}
                isHighRating={false}
                isNew={false}
                isTop={true}
              />
            }
          />
          <Route
            path="/list/:category"
            element={
              <MorePage
                isSale={false}
                isHighRating={false}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route
            path="/list/:category/:branch"
            element={
              <BranchPage
                isSale={false}
                isHighRating={false}
                isNew={false}
                isTop={false}
              />
            }
          />
          <Route path="/search" element={<SearchPage />} />
        </Route>
        <Route path="/admin" element={<AdminLayout />}>
          <Route path="/admin" element={<AdminPage />} />
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/category" element={<CategoryManagement />} />
          <Route path="/admin/branch" element={<BranchManagement />} />
          <Route path="/admin/serie" element={<SerieManagement />} />
          <Route path="/admin/cart" element={<CartManagement/>} />
          <Route path="/admin/discount" element={<DiscountManagement />} />
          <Route path="/admin/user" element={<UserManagement />} />
          <Route path="/admin/feedback" element={<FeedbackManagement />} />
        </Route>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="*" element={<NotFound />} />
        <Route path="400" element={<BadRequest />} />
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
