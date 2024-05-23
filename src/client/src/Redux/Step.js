import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  currentStep: 0,
};

export const stepSlice = createSlice({
  name: "step",
  initialState,
  reducers: {
    setNextStep: (state) => {
      state.currentStep += 1;
    },
    setPrevStep: (state) => {
      state.currentStep -= 1;
    },
    resetStep: (state) => {
      state.currentStep = initialState.currentStep;
    },
  },
});

export const { setNextStep, setPrevStep, resetStep } = stepSlice.actions;

export const stepReducer = stepSlice.reducer;
