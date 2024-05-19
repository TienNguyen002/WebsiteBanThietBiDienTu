import { configureStore } from "@reduxjs/toolkit";
import { gridReducer } from "./Grid";
import { authReducer } from "./Account";
import { cartReducer } from "./Cart";

const store = configureStore({
  reducer: {
    gridChange: gridReducer,
    auth: authReducer,
    cart: cartReducer,
  },
});

export default store;
