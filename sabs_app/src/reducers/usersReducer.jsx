import jwt_decode from "jwt-decode";
const users = [];
export const usersReducer = (state = null, action) => {
  switch (action.type) {
    case "LOGIN_USER":
      localStorage.setItem("user_info", JSON.stringify(action.payload));
      const user = jwt_decode(action.payload);
      return user;
    case "LOGOUT_USER":
      localStorage.setItem("user_info", "");
      state = null;
      return state;
    case "LOAD_USERS":
      const newUsers = [...users, action.payload];
      return newUsers;
    default:
      return state;
  }
};
