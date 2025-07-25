export type JwtAuthUserDto = {
  id: string;
  credentials: {
    email: {
      value: string;
    };
  };
  role: 'OWNER' | 'ADMIN' | 'MODERATOR' | 'USER';
};
