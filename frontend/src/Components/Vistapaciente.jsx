import React from 'react'
import Gestion from './Gestion'
import Menu from './Menu'
import '../style/Vistapaciente.css'
function Vistapaciente () {
  return (
    <div>
        <Menu/>
        <div className='container'>
        <Gestion titulo='Crear cuenta'/>
        <Gestion titulo='Reservacion'/>
        <Gestion titulo='Historial'/>
        </div>
    </div>
  )
}
export default Vistapaciente
