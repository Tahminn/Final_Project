import React from 'react';
import './loader';
import Layout from './components/Layout';
import Login from './components/Account/Login';
import Register from './components/Account/Register';

import { Route, Routes, Navigate, Link } from 'react-router-dom';
import ProtectedRoute from './pages/ProtectedRoute'
import PatientsBoard from './pages/PatientsBoard'
import DoctorsBoard from './pages/doctors/DoctorsBoard'
import DoctorsCreate from './pages/doctors/DoctorCreate'
import DoctorsList from './pages/doctors/DoctorsList'

import NursesBoard from './pages/nurses/NursesBoard'
import NursesCreate from './pages/nurses/NurseCreate'
import NursesList from './pages/nurses/NursesList'

import ReceptionistsBoard from './pages/receptionists/ReceptionistsBoard'
import ReceptionistsCreate from './pages/receptionists/ReceptionistCreate'
import ReceptionistsList from './pages/receptionists/ReceptionistsList'

import Error404 from './pages/errors/Error404'
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
            <Route path="/doctors" element={<DoctorsBoard />} >
              <Route path="/doctors/create" element={<DoctorsCreate />} />
              <Route path="/doctors/list" element={<DoctorsList />} />
            </Route>
            <Route path="/nurses/" element={<NursesBoard />} >
              <Route path="/nurses/create" element={<NursesCreate />} />
              <Route path="/nurses/list" element={<NursesList />} />
            </Route>
            <Route path="/receptionists/" element={<ReceptionistsBoard />} >
              <Route path="/receptionists/create" element={<ReceptionistsCreate />} />
              <Route path="/receptionists/list" element={<ReceptionistsList />} />
            </Route>
          </Route>
        </Route>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="*" element={<Error404 />} />
      </Routes>
    </div>
  )
}

export default App