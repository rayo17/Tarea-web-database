import React, { useState } from 'react'
import axios from 'axios'
import '../Reservacion.css'
function Reservacion() {
    const [stateCama, setStateCama] = useState()
    const [create, setcreate] = useState('create')
    const [modificar, setmodificar] = useState('null')
    const [opcion, setopcion] = useState('create')
    const [name, setName] = useState('')
    const [cedula,setcedula]=useState('')
    const [modifacaBody, setmodificarBody]=useState('null')
    const boton = (e) => {
        e.preventDefault()
    }

    const cambioSeleccion = (e) => {
        if (e.target.value === 'create') {
            setcreate('crear')
            setmodificar('null')
            setopcion('create')
            
        }
        if (e.target.value === 'modificar') {
            setmodificar('modificar')
            setcreate('null')
            setopcion('modificar')
        }
        else {
            setopcion('Eliminar')
        }
    }


    const change_cedula = (e)=>{
        setcedula(e.target.value)
     }   


    const info = axios.post(`http://localhost:5004/api/${cedula}`).then(response => response.data).catch(error => alert('error'))
    

    const { nombre, fecha, procedimiento } = info
    return (
        <div>
            <div>
                <label>Seleccione la opcion que desee:</label>

                <select onChange={cambioSeleccion}>
                    <option value="create">crear Reservacion</option>
                    <option value="modificar">modificar reservacion</option>
                    <option value="Eliminar">eliminar reservacion</option>
                </select>
            </div>
            <div className={create}>
                <div>
                    <h1>Reservacion de camas</h1>
                </div>
                <form>
                    <div>
                        <h3>fecha de entrada</h3>
                        <input type='date' name='calendario' />
                    </div>
                    <div className='nombre'>
                        <label>nombre del paciente</label>
                        <input name='nombre' placeholder='nombre' />
                    </div>
                    <div className='procedimiento'>
                        <label>Procedimiento Medico</label>
                        <input name='procedimiento' placeholder='procedimiento' />

                    </div>
                    <div>
                        <button type='submit'>{opcion}</button>
                    </div>

                </form>
            </div>

            <div>
                <form >
                    <div className={modificar}>
                        <div >
                            <label>Por favor ingrese su numerode cedula</label>
                            <input name='cedula' onChange={change_cedula}/>
                        </div>
                        <div className={modifacaBody}>

                            <div >
                                <h3>fecha de entrada</h3>
                                <input type='date' name='calendario' value={fecha} />
                            </div>
                            <div className='nombre'>
                                <label>nombre del paciente</label>
                                <input name='nombre' placeholder='nombre' value={nombre} />
                            </div>
                            <div className='procedimiento'>
                                <label>Procedimiento Medico</label>
                                <input name='procedimiento' placeholder='procedimiento' value={procedimiento} />

                            </div>
                            <button type='submit' onSubmit={boton}>{opcion}</button>
                        </div>
                    </div>


                </form>
            </div>
        </div>
    )
}
export default Reservacion