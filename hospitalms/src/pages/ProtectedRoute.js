import { Route, Navigate, Outlet } from 'react-router-dom'
import { useSelector } from "react-redux";


function ProtectedRoute({ component: Component, ...rest }) {
    const { user: currentUser } = useSelector((state) => state.auth);

    return currentUser ? <Outlet /> : <Navigate to="/login" />
}

export default ProtectedRoute;