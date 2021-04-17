export const isAdmin = () => {
    if (localStorage.getItem("user_info") == null) {
        return false
    }
    else {
        try {
            const isAdmin = jwt(localStorage.getItem("user_info")).isOperator;
            return isAdmin;

        } catch (error) {
            return false
        }
    }
}