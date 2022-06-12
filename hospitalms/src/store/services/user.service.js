import axios from "axios";
import authHeader from "./auth-header";
import { serverNameForPatients } from "../../api/api.json"

const getPatientBoard = () => {
  return axios.get(`${serverNameForPatients}/get-patients`, { headers: authHeader() });
};

const userService = {
    getPatientBoard
};
export default userService