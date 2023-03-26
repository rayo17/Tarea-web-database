import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import { Navbar } from './Navbar'
import Paciente from './sites/Paciente';
import Historial from './sites/Historial';
import Principal from './sites/Principal';
import Reservacion from './sites/Reservacion';
import React from "react";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";


function App() {
  return (
    <div className="App">
      <Router>
        <Navbar/>
        

          <Routes>
            <Route path='/' element={ <Principal/> }/>
            <Route path='/Paciente' element={ <Paciente/> }/>
            <Route path='/Historial' element={ <Historial/> }/>
            <Route path='/Reservacion' element= { <Reservacion />} />
          </Routes>
      </Router>
      
    </div>
  );
}

export default App;