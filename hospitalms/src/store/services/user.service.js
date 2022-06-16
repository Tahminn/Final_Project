import axios from "axios";
import authHeader from "./auth-header";
import api from "./api.json"

const getDoctorsBoard = () => {

  const config = {
    headers: authHeader()
  };
  return axios
    .post(`${api.serverNameForDoctors}/get-all`,
    config
   )
};


const getNursesBoard = () => {
  const config = {
    headers: authHeader()
  };
  return axios
    .post(`${api.serverNameForNurses}/get-all`,
    config
   )
};


const getReceptionistsBoard = () => {
  const config = {
    headers: authHeader()
  };
  return axios
    .post(`${api.serverNameForReceptionists}/get-all`,
    config
   )
};

const getPatientsBoard = () => {
  const config = {
    headers: authHeader()
  };
  return axios
    .post(`${api.serverNameForPatients}/get-all`,
    config
   )
};


// const login = (email, password) => {
//   return axios
//     .post(`${serverApi.serverNameForAccount}/login`, {
//       email,
//       password,
//     })
//     .then((response) => {
//       if (response.data) {
//         console.log(response.data)
//         localStorage.setItem("user", JSON.stringify(response.data));
//       }
//       return response.data;
//     });
// };
const userService = {
    getPatientsBoard,
    getDoctorsBoard,
    getNursesBoard,
    getReceptionistsBoard
};
export default userService