import React from 'react'
import Menu from './Menu'
import Card from '../Card'
//import '../style/Vistapaciente.css'

function Vistapaciente () {
  return (
    <div>
        <Menu/>
        <div className='container'>
        <Card title='Crear cuenta' url='/Agregar'/>
        <Card title='Reservacion' url='/Reservacion'/>
        <Card title='Historial'/>
        </div>
    </div>
  )
}
export default Vistapaciente