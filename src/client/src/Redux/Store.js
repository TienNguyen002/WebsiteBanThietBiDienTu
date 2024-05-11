import { configureStore } from "@reduxjs/toolkit";
import { gridReducer } from "./Grid";

const store = configureStore({
  reducer: {
    gridChange: gridReducer,
  },
});

export default store;
