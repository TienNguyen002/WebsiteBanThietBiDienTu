import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/userPage/HomePage";
import ProductDetail from "../Pages/userPage/ProductDetail";
import HomeLayout from "../Layout/HomeLayout";
import MorePage from "../Pages/userPage/MorePage";
import SearchPage from "../Pages/userPage/SearchPage";
import ListPage from "../Pages/userPage/ListPage";
import BranchPage from "./../Pages/userPage/BranchPage";
import LoginPage from "../Pages/accountPage/LoginPage";
import RegisterPage from "../Pages/accountPage/RegisterPage";
import AdminLayout from "../Layout/AdminLayout";
import NotFound from "../Pages/common/NotFound";
import NotAccessPage from "../Pages/common/NotAccessPage";
import BadRequest from "../Pages/common/BadRequest";
import Dashboard from "../Pages/adminPage/Dashboard";
import CategoryManagement from "../Pages/adminPage/manage/CategoryManagement";
import BranchManagement from "../Pages/adminPage/manage/BranchManagement";
import SerieManagement from "../Pages/adminPage/manage/SerieManagement";
import OrderManagement from "../Pages/adminPage/manage/OrderManagement";
import FeedbackManagement from "../Pages/adminPage/manage/FeedbackManagement";
import UserManagement from "../Pages/adminPage/manage/UserManagement";
import DiscountManagement from "../Pages/adminPage/manage/DiscountManagement";
import SaleManagement from "../Pages/adminPage/manage/SaleManagement";
import SeriePage from "../Pages/userPage/SeriePage";
import ProductManagement from "../Pages/adminPage/manage/ProductManagement";
import { useSelector } from "react-redux";
import CartPage from "../Pages/userPage/CartPage";
import ProfilePage from "../Pages/common/ProfilePage";
import Feedback from "../Pages/common/Feedback";
import OrderPage from "../Pages/userPage/OrderPage";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomeLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route
            path="/profile"
            element={
              <UserRoute>
                <ProfilePage />
              </UserRoute>
            }
          ></Route>
          <Route
            path="/order"
            element={
              <LoginRoute>
                <OrderPage />
              </LoginRoute>
            }
          ></Route>
          <Route path="/cart" element={<CartPage />} />
          <Route path="/detail/:slug" element={<ProductDetail />} />
          <Route path="/sale">
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
              path="/sale/:category/:branch/:serie"
              element={
                <SeriePage
                  isSale={true}
                  isHighRating={false}
                  isNew={false}
                  isTop={false}
                />
              }
            />
          </Route>
          <Route path="/high-rating">
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
              path="/high-rating/:category/:branch/:serie"
              element={
                <SeriePage
                  isSale={false}
                  isHighRating={true}
                  isNew={false}
                  isTop={false}
                />
              }
            />
          </Route>
          <Route path="/new">
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
              path="/new/:category/:branch/:serie"
              element={
                <SeriePage
                  isSale={false}
                  isHighRating={false}
                  isNew={true}
                  isTop={false}
                />
              }
            />
          </Route>
          <Route path="/top">
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
              path="/top/:category/:branch/:serie"
              element={
                <SeriePage
                  isSale={false}
                  isHighRating={false}
                  isNew={false}
                  isTop={true}
                />
              }
            />
          </Route>
          <Route path="/list">
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
            <Route
              path="/list/:category/:branch/:serie"
              element={
                <SeriePage
                  isSale={false}
                  isHighRating={false}
                  isNew={false}
                  isTop={false}
                />
              }
            />
          </Route>
          <Route path="/feedback" element={<Feedback />} />
          <Route path="/search" element={<SearchPage />} />
        </Route>
        <Route
          path="/admin"
          element={
            <AdminRoute>
              <AdminLayout />
            </AdminRoute>
          }
        >
          <Route path="/admin" element={<Dashboard />} />
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/category" element={<CategoryManagement />} />
          <Route path="/admin/branch" element={<BranchManagement />} />
          <Route path="/admin/sale" element={<SaleManagement />} />
          <Route path="/admin/serie" element={<SerieManagement />} />
          <Route path="/admin/serie/:slug" element={<ProductManagement />} />
          <Route path="/admin/order" element={<OrderManagement />} />
          <Route path="/admin/discount" element={<DiscountManagement />} />
          <Route path="/admin/user" element={<UserManagement />} />
          <Route path="/admin/feedback" element={<FeedbackManagement />} />
          <Route path="/admin/profile" element={<ProfilePage />} />
        </Route>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="*" element={<NotFound />} />
        <Route path="400" element={<BadRequest />} />
      </Routes>
    </BrowserRouter>
  );
};

const AdminRoute = ({ children }) => {
  let user = useSelector((state) => state.auth.login.currentUser);
  if (user === null) {
    return <NotAccessPage />;
  }
  if (user.role === "Quản lý" || user.role === "Nhân viên") {
    return <>{children}</>;
  } else {
    return <NotAccessPage />;
  }
};

const LoginRoute = ({ children }) => {
  let user = useSelector((state) => state.auth.login.currentUser);
  if (user === null) {
    return <NotAccessPage />;
  }
  if (
    user.role === "Quản lý" ||
    user.role === "Nhân viên" ||
    user.role === "Người dùng"
  ) {
    return <>{children}</>;
  } else {
    return <NotAccessPage />;
  }
};

const UserRoute = ({ children }) => {
  let user = useSelector((state) => state.auth.login.currentUser);
  if (user === null) {
    return <NotAccessPage />;
  }
  if (user.role === "Người dùng") {
    return <>{children}</>;
  } else {
    return <NotAccessPage />;
  }
};

export default Router;
