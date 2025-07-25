// NgRx Configuration

// State
import { ActionReducerMap } from '@ngrx/store';
import {
  loginReducer,
  LoginState,
} from './presentation/state/login/login.reducer';
import { LoginEffects } from './presentation/state/login/login.effects';
import {
  registerReducer,
  RegisterState,
} from './presentation/state/register/register.reducer';
import { RegisterEffects } from './presentation/state/register/register.effects';

export interface AppState {
  login: LoginState;
  register: RegisterState;
}

// Reducers
export const appReducers: ActionReducerMap<AppState> = {
  login: loginReducer,
  register: registerReducer,
};

// Effects
export const appEffects = [LoginEffects, RegisterEffects];
