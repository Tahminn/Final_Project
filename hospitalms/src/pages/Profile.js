import React from "react";
import { Navigate } from 'react-router-dom';
import { useSelector } from "react-redux";
import jwt_decode from "jwt-decode";

const Profile = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  if (!currentUser) {
    return <Navigate to="/login" />;
  }

  var userr = jwt_decode(currentUser);

  console.log(userr);
  return (
    <div className="page-content">
      <div className="row">
        <div className="col-12">
          <div className="page-title-box d-flex align-items-center justify-content-between">
            <h4 className="page-title mb-0 font-size-18">Dashboard</h4>
            <div className="page-title-right">
              <ol className="breadcrumb m-0">
                <li className="breadcrumb-item active">Welcome to Qovex Dashboard</li>
              </ol>
            </div>
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-body">
              <div className="d-flex">
                <div className="ms-3">
                  <img src="/static/media/avatar-1.3921191a.jpg" alt="asdad" className="avatar-md rounded-circle img-thumbnail" />
                </div>
                <div className="flex-1 align-self-center">
                  <div className="text-muted">
                    <h5>{userr.given_name}</h5>
                    <p className="mb-1">{userr.given_name}</p>
                    <p className="mb-0">{userr.given_name}</p>
                    <ul>
                      {userr.sid.map((userrSid, i) => {
                        return <li>{userrSid}</li>
                      })}
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

  );
};
export default Profile;