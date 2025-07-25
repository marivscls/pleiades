import { createReducer, on } from '@ngrx/store';
import { loginButtonClicked, loginError, loginSuccess } from './login.actions';

export interface LoginState {
  loading: boolean;
  error: string;
}

const initialState: LoginState = {
  loading: false,
  error: '',
};

export const loginReducer = createReducer(
  initialState,
  on(
    loginButtonClicked,
    (): LoginState => ({
      ...initialState,
      loading: true,
    }),
  ),

  on(
    loginSuccess,
    (state): LoginState => ({
      ...state,
      loading: false,
    }),
  ),

  on(
    loginError,
    (state, action): LoginState => ({
      ...state,
      loading: false,
      error: action.errorMessage,
    }),
  ),
);
