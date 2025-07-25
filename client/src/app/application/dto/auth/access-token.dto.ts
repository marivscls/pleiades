import { JwtAuthUserDto } from './jwt-auth-user.dto';

export type AccessTokenDto = {
  authUser: JwtAuthUserDto;
  iat: number;
  exp: number;
};
