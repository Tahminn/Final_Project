import axios from "axios";
import authHeader from "./auth-header";
import api from "../../api/api.json"

const getPatientBoard = () => {
  debugger;
  const take = 1;
  const page = 1;
  const lastPatientId = 6;
  console.log(authHeader());
  return axios
    .post(`${api.serverNameForPatients}/get-all`,
   {headers: authHeader(),
    body: {take , page, lastPatientId}
   })
};

console.log(getPatientBoard);


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
    getPatientBoard
};
export default userService