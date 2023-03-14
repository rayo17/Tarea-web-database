import React from 'react'
import Gestion from './Gestion'
import Menu from './Menu'
function Vistapaciente () {
  return (
    <div>
        <Menu/>
        <div>
        <Gestion titulo='Crear cuenta'/>
        <Gestion titulo='Reservacion'/>
        <Gestion titulo='Historial'/>
        </div>
    </div>
  )
}
export default Vistapaciente
