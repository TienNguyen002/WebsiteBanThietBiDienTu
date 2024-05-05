import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  sortOrder: "",
  category: "",
  branch: "",
  minPrice: 50000,
  maxPrice: 50000000,
  rating: 0,
  color: "",
};

const payloadFilterReducer = createSlice({
  name: "payloadFilter",
  initialState,
  reducers: {
    reset: (state, action) => {
      return initialState;
    },
    resetColor: (state, action) => {
      return {
        ...state,
        color: "",
      };
    },
    updateSortOrder: (state, action) => {
      return {
        ...state,
        sortOrder: action.payload,
      };
    },
    updateCategory: (state, action) => {
      return {
        ...state,
        category: action.payload,
      };
    },
    updateBranch: (state, action) => {
      return {
        ...state,
        branch: action.payload,
      };
    },
    updateMinPrice: (state, action) => {
      return {
        ...state,
        minPrice: action.payload,
      };
    },
    updateMaxPrice: (state, action) => {
      return {
        ...state,
        maxPrice: action.payload,
      };
    },
    updateRating: (state, action) => {
      return {
        ...state,
        rating: action.payload,
      };
    },
    updateColor: (state, action) => {
      return {
        ...state,
        color: action.payload,
      };
    },
  },
});

export const {
  reset,
  resetColor,
  updateSortOrder,
  updateCategory,
  updateBranch,
  updateMinPrice,
  updateMaxPrice,
  updateRating,
  updateColor,
} = payloadFilterReducer.actions;

export const payloadReducer = payloadFilterReducer.reducer;
