import { configureStore } from "@reduxjs/toolkit";
import { payloadReducer } from "./Payload";
import { gridReducer } from "./Grid";

const store = configureStore({
  reducer: {
    gridChange: gridReducer,
    payloadFilter: payloadReducer,
  },
});

export default store;
