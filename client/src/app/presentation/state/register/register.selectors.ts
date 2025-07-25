import { createFeatureSelector, createSelector } from '@ngrx/store';
import { RegisterState } from './register.reducer';

export const selectRegisterState =
  createFeatureSelector<RegisterState>('register');

export const selectRegisterLoading = createSelector(
  selectRegisterState,
  (state: RegisterState) => state.loading,
);

export const selectRegisterError = createSelector(
  selectRegisterState,
  (state: RegisterState) => state.error,
);
