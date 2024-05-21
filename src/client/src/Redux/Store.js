import { configureStore } from "@reduxjs/toolkit";
import { gridReducer } from "./Grid";
import { authReducer } from "./Account";
import { cartReducer } from "./Cart";
import { stepReducer } from "./Step";

const store = configureStore({
  reducer: {
    gridChange: gridReducer,
    auth: authReducer,
    cart: cartReducer,
    step: stepReducer,
  },
});

export default store;
