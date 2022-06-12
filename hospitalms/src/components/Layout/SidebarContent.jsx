import PropTypes from "prop-types"
import React, { useEffect, useRef, useState, useCallback } from "react"
import { useSelector } from "react-redux";
// Import Scrollbar
import SimpleBar from "simplebar-react"

// MetisMenu
import MetisMenu from "metismenujs"
import { withRouter } from "react-router-dom"
import { Link } from "react-router-dom"


//i18n
import { withTranslation } from "react-i18next"

function SidebarContent() {

    const [showPatientsBoard, setShowPatientsBoard] = useState(false);
    const [showProfileBoard, setShowProfileBoard] = useState(false);
    const { user: currentUser } = useSelector((state) => state.auth);
    // const dispatch = useDispatch();

    useEffect(() => {
        if (currentUser) {
            setShowPatientsBoard(true);
            setShowProfileBoard(true);
        } else {
            setShowPatientsBoard(false);
            setShowProfileBoard(false);
        }
      }, [currentUser]);

    const ref = useRef()

    useEffect(() => {
        ref.current.recalculate()
    }, []);

    return (
        <React.Fragment>
            <SimpleBar ref={ref} className="vertical-simplebar">
                <div id="sidebar-menu">
                    <ul className="metismenu list-unstyled" id="side-menu">
                        <li className="menu-title">Menu"</li>
                        <li>
                            <Link to="/dashboard" className="waves-effect">
                                <i className="mdi mdi-airplay"></i>
                                <span>Dashboard</span>
                            </Link>
                        </li>
                        <li>
                        { showPatientsBoard && (
                                <Link to="/profile" className="waves-effect">
                                    <i className="mdi mdi-airplay"></i>
                                    <span>Profile</span>
                                </Link>
                        )}
                        </li>
                        <li>
                            { showPatientsBoard && (
                                <Link to="/patients" className="waves-effect">
                                    <i className="mdi mdi-airplay"></i>
                                    <span>Patients</span>
                                </Link>
                            )}
                        </li>
                    </ul>
                </div>
            </SimpleBar>
        </React.Fragment>
    )
}

export default SidebarContent