import { createReducer, on } from '@ngrx/store';
import { RegisterActions } from './action.types';

export interface RegisterState {
  loading: boolean;
  error: string;
}

const initialState: RegisterState = {
  loading: false,
  error: '',
};

export const registerReducer = createReducer(
  initialState,

  on(
    RegisterActions.createAccountButtonClicked,
    (): RegisterState => ({
      ...initialState,
      loading: true,
    }),
  ),

  on(
    RegisterActions.registerSuccess,
    (state): RegisterState => ({
      ...state,
      loading: false,
    }),
  ),

  on(
    RegisterActions.registerError,
    (state, action): RegisterState => ({
      ...state,
      loading: false,
      error: action.errorMessage,
    }),
  ),
);
