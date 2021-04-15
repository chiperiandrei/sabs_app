export const logInUser = (user) => {
  return {
    type: "LOGIN_USER",
    payload: user,
  };
};
export const logOutUser = () => {
  return {
    type: "LOGOUT_USER",
  };
};

export const loadUsers = (users) => {
  return {
    type: "LOAD_USERS",
    payload: users,
  };
};
