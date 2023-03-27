import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Paciente from './sites/Paciente';
import Historial from './sites/Historial';
import Principal from './sites/Principal';
import  Menu  from './sites/Menu';
import Vistapaciente from './sites/VistaPaciente';
import Agregar from './sites/component-vista-paciente/Agregar';
import Reservacion from './sites/component-vista-paciente/Reservacion';
import HistorialP from './sites/component-vista-paciente/HistorialP';
import Edit from './sites/component-vista-paciente/Edit';
import React, { Component } from "react";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";


function App() {
  return (
    <div className="App">
      
      <Router>
          <Routes>
            <Route path='/' element={ <Menu/> }/>
            <Route path='/Reservacion' element={ <Reservacion />}/>
            <Route path='/Vistapaciente' element={ <Vistapaciente/> }/>
            <Route path='/Agregar' element={ <Agregar/> }/>
            <Route path='/Vistadoctor' element={ <Principal/> }/>
            <Route path='/Paciente' element={ <Paciente/> }/>
            <Route path='/Historial' element={ <Historial/> }/>
            <Route path='/historial-paciente'element={<HistorialP/>}/> 
            <Route path='/editar-reservacion/:id' element={<Edit/>}/>
          </Routes>
      </Router>
      
    </div>
  );
}

export default App;