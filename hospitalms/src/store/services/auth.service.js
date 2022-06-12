import axios from "axios";
import serverApi from "../../api/api.json"

const register = (username, email, password) => {
  return axios.post(`${serverApi.serverNameForAccount}/Register`, {
    username,
    email,
    password,
  });
};
const login = (email, password) => {
  return axios
    .post(`${serverApi.serverNameForAccount}/Login`, {
      email,
      password,
    })
    .then((response) => {
      if (response.data.result) {
        localStorage.setItem("user", JSON.stringify(response.data.result));
      }
      return response.data.result;
    });
};
const logout = () => {
  localStorage.removeItem("user");
};
const authService = {
  register,
  login,
  logout,
};
export default authService;
