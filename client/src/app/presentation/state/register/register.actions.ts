import { createAction, props } from '@ngrx/store';

export const createAccountButtonClicked = createAction(
  '[Create Account Button] Create Account Button Clicked',
  props<{ email: string; password: string }>(),
);

export const registerSuccess = createAction(
  '[Register Effects] Register Success',
  props<{ accessToken: string }>(),
);

export const registerError = createAction(
  '[Register Effects] Register Error',
  props<{ errorMessage: string }>(),
);
