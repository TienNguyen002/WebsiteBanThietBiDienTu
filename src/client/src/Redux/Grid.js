import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  grid: true,
};

const gridChangeReducer = createSlice({
  name: "grid",
  initialState,
  reducers: {
    reset: (state, action) => {
      return initialState;
    },
    updateGrid: (state, action) => {
      return {
        ...state,
        grid: false,
      };
    },
  },
});

export const { reset, updateGrid } = gridChangeReducer.actions;

export const gridReducer = gridChangeReducer.reducer;
