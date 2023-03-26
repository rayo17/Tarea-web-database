import React from 'react'
import Menu from './Menu'
import Card from '../Card'
import './vistapa.css'

function Vistapaciente () {
  return (
    <div>
        <Menu/>
        <div className='container'>
        <Card title='Crear cuenta' url='/Agregar' imageUrl='https://cdn-icons-png.flaticon.com/512/1512/1512910.png'/>
        <Card title='Reservacion' url='/Reservacion' imageUrl='https://cdn-icons-png.flaticon.com/128/2355/2355692.png'/>
        <Card title='Historial' url='/historial-paciente' imageUrl='https://cdn-icons-png.flaticon.com/128/1584/1584786.png'/>
        </div>
    </div>
  )
}
export default Vistapaciente