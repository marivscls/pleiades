import { createAction, props } from '@ngrx/store';

export const loginButtonClicked = createAction(
  '[Login Button] Login Button Clicked',
  props<{ username: string; password: string }>(),
);

export const loginSuccess = createAction(
  '[Login Effects] Login Success',
  props<{ accessToken: string }>(),
);

export const loginError = createAction(
  '[Login Effects] Login Error',
  props<{ errorMessage: string }>(),
);
