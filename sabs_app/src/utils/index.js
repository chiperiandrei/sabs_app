import jwt_decode from "jwt-decode";
export const isAdmin = () => {
  if (localStorage.getItem("user_info") == null) {
    return false;
  } else {
    try {
      const isAdmin = jwt_decode(localStorage.getItem("user_info")).role;

      if (isAdmin == "Admin") return true;
      else return false;
    } catch (error) {
      return false;
    }
  }
};
