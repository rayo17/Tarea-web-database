import React from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import pacienteIcon from '../paciente-icon.png';
import historialIcon from '../historial-icon.png';
import reservacionIcon from '../reservacion-icon.png';

import Paciente from './Paciente';
import Historial from './Historial';
import Card from '../Card';

const Principal = () => {
  return (
    <div>
        <div className='row'>

          <div className='col-md-2'></div>

          <div className='col-md-3'>
          <Card
          tittle='Pacientes'
          imageUrl={pacienteIcon}
          body='Mi información'
          url='/Paciente'/>
          </div>

          <div className='col-md-3'>
            <Card 
            tittle='Reservación'
            imageUrl={reservacionIcon}
            body='Mis reservaciones'
            url='/Reservacion'/>
          </div>

          <div className='col-md-3'>
          <Card
          tittle='Historiales médicos'
          imageUrl={historialIcon}
          body='Historial médico'
          url='/Historial'/>
          </div>

          <div className='col-md-2'></div>

        </div>

    </div>
  )
}

export default Principal