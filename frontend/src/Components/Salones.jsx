import React, { useState } from 'react'
import Menu from './Menu'
import Form from 'react-bootstrap/Form'
import Formsalon from './Formsalon'
import '../style/Salones.css'
function Salones () {
  const [opcion, setopcion] = useState('hidden')
  const change = (e) => {
    const getvalue = e.target.value
    if (getvalue === 'create') {
      setopcion('create')
    }
    if (getvalue === 'modificar') {
      setopcion('modificar')
    }
    if (getvalue === 'hidden') {
      setopcion('hidden')
    } if (getvalue === 'delete') {
      setopcion('delete')
    }
  }
  return (
    <div>
      <Menu/>
      <Form.Select aria-label="Default select example" onChange={change}>
      <option value='hidden'>Open this select menu</option>
      <option value="create"><a href='/'>crear</a></option>
      <option value="modificar">Modificar</option>
      <option value="delete"><a href=''>eliminar</a></option>
    </Form.Select>
    <div className={opcion}>
     <Formsalon accion={opcion}/>
    </div>
    </div>)
}
export default Salones
