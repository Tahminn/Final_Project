import React, { useState, useEffect } from "react";
import UserService from "../store/services/user.service";

const PaitentsBoard = () => {
  const [content, setContent] = useState("");
  useEffect(() => {
    UserService.getPatientBoard().then(
      (response) => {
        setContent(response.data);
      },
      (error) => {
        const _content =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();
        setContent(_content);
      }
    );
  }, []);
  return (
    <>
      <div className="row">
        <div className="col-12 col">
          <div className="page-title-box d-flex align-items-start align-items-center justify-content-between">
            <h4 className="page-title mb-0 font-size-18">Patients</h4>
            <div className="page-title-right">
              {/* <ol className="breadcrumb m-0">
                <li className="breadcrumb-item">
                  <a href="/dashboard2">Dashboard</a>
                </li>
                <li className="active breadcrumb-item" aria-current="page">
                  <a href="/dashboard2">Dashboard 2</a>
                </li>
              </ol> */}
            </div>
           </div>
        </div>
      </div>
      <div className="container">
        <header className="jumbotron">
          <h3>{content}</h3>
        </header>
      </div>
    </>
  );
};
export default PaitentsBoard;
