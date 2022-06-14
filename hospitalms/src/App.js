import React from 'react';
import './loader';
import Layout from './components/Layout';
import Login from './components/Account/Login';
import Register from './components/Account/Register';

import { Route, Routes, Navigate, Link } from 'react-router-dom';
import ProtectedRoute from './pages/ProtectedRoute'
import PatientsBoard from './pages/PatientsBoard'
import Profile from './pages/Profile'
//style
import "../src/assets/scss/theme.scss";

/// var theme = import("../src/assets/scss/theme.scss");
// theme.use;


function App() {
  return (
    <div id="content">
      <Routes>
        <Route exact path="/" element={<ProtectedRoute />}>
          <Route exact path='/' element={<Layout />} >
            <Route path="/patients" element={<PatientsBoard />} />
            <Route path="/profile" element={<Profile />} />
          </Route>
        </Route>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="*" element={<div><p>There's nothing here: 404!</p><Link to="/">Go to Dashboard</Link></div>} />
      </Routes>
    </div>
  )
}

export default App