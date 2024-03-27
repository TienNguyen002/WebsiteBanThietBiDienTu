import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/homePage/HomePage";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />}></Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
