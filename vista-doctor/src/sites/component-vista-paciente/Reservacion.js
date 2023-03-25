import React, { useState } from 'react'
import axios from 'axios'
function Reservacion() {
    const [stateCama, setStateCama] = useState()
    const [condicion, setcondicion] = useState('create')
    const[nombre,setNombre]=useState('')
    const boton = (e) => {
        e.preventDefault()
    }

    const handlersend=()=>{
         if(condicion==='create'){
            axios.post(
                'ruta',
                {
                    nombre:'hola'
                }
            )
         }
    }

    const handlerChange = (e) => {
        const { name, value } = e.target
    }
    const RevisionCamas = () => {
    }

    const requestFecha = () => {
        axios
            .get("http://localhost:5004/api/paciente").then()
    }

    const cambioSeleccion=(e)=>{
        if(e.target.value==='create'){
            setcondicion('crear')
            console.log('create')
        }
        if(e.target.value==='modif'){
            setcondicion('modificar')
            console.log('modif')
        }
        else{
            setcondicion('Eliminar')
            console.log('delete')
        }
    }
    return (
        <div>
            <div>
                <label>Seleccione la opcion que desee:</label>

                <select  onChange={cambioSeleccion}>
                    <option value="create">crear Reservacion</option>
                    <option value="modif">modificar reservacion</option>
                    <option value="delete">eliminar reservacion</option>
                </select>
            </div>
            <div>
                <h1>Reservacion de camas</h1>
            </div>
            <form>
                <div>
                    <h3>fecha de entrada</h3>
                    <input type='date' name='calendario'/>
                </div>
                <div className='nombre'>
                    <label>nombre del paciente</label>
                    <input name='nombre' placeholder='nombre' />
                </div>
                <div className='procedimiento'>
                    <label>Procedimiento Medico</label>
                    <input name='procedimiento' placeholder='procedimiento' />

                </div>
                <button type='submit' onSubmit={boton}>{condicion}</button>
            </form>

        </div>
    )
}
export default Reservacion