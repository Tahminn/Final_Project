import React from 'react'
import { Link } from "react-router-dom"
import avatar2 from "../../assets/images/users/avatar-3.jpg"
import SidebarContent from './SidebarContent'


function Sidebar() {
  return (
    <React.Fragment>
      <div className="vertical-menu">
        <div className="h-100">
          <div className="user-wid text-center py-4">
            <div className="user-img">
              <img src={avatar2} alt="" className="avatar-md mx-auto rounded-circle" />
            </div>
              <div className="mt-3">
                <Link to="#" className="text fw-medium font-size-16">Tahmin Fatiyev</Link>
                <p className="text-body mt-1 mb-0 font-size-13">Super Admin</p>
              </div>
            </div>
            <div data-simplebar className="h-100">
            <SidebarContent />
          </div>
          </div>
        </div>
    </React.Fragment>
  )
}

export default Sidebar