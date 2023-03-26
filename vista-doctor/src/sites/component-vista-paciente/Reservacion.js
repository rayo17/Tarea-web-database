import React, { useState } from 'react'
import axios from 'axios'
import '../Reservacion.css'

function Reservacion() {
    const [create, setcreate] = useState('crear')
    const [modificar, setmodificar] = useState('null')
    const [opcion, setopcion] = useState('crear')
    const [cedula, setcedula] = useState('')
    const [modificaBody, setmodificarBody] = useState('null')
    const [name, setname] = useState('')
    const [fecha, setfecha]=useState('')
    const [proce, setproce]= useState('')


    const boton = (e) => {
        e.preventDefault()
    }
    const botonCedula = (e) => {
        e.preventDefault()
    }

    const changeName =(e)=>{
        setname(e.target.value)
    }
    const changeFecha = (e) =>{
        setfecha(e.target.value)
    }
    const changeProcedimiento = (e) =>{
        setproce(e.target.value)
    }

    const cambioSeleccion = (e) => {
        if (e.target.value === 'create') {
            setcreate('crear')
            setmodificar('null')
            setopcion('crear')

        }
        if (e.target.value === 'modificar') {
            setmodificar('modificar')
            setcreate('null')
            setopcion('modificar')
        }
        if (e.target.value === 'eliminar'){
            setopcion('eliminar')
        }
    }


    const change_cedula = (e) => {
        setcedula(e.target.value)
    }

    const peticion_modificar = (event) => {
     event.preventDefault();
     axios.get(`https://localhost:44362/api/Reservacion/${cedula}`)
            .then(response => {alert(response.data)})
            .catch(error => alert('error'))
            
    }
    const peticion_crear = (event)=>{
        event.preventDefault();
        axios.post('https://localhost:44362/api/Reservacion',{
            nombre:name,
            procedimiento:proce,

         })
        .then(response => console.log('todo bien'))
        .catch(error => alert('error'))
    }
    
    



    /*const { nombre, fecha, procedimiento } = info*/
    return (
        <div>
            <div>
                <label>Seleccione la opcion que desee:</label>

                <select onChange={cambioSeleccion}>
                     <option >Reservacion</option>
                    <option value="create">crear Reservacion</option>
                    <option value="modificar">modificar reservacion</option>
                    <option value="eliminar">eliminar reservacion</option>
                </select>
            </div>
            <div className={create}>
                <div>
                    <h1>Reservacion de camas</h1>
                </div>
                <form onSubmit={peticion_crear}> 
                    <div>
                        <h3>fecha de entrada</h3>
                        <input type='date' name='calendario' value={fecha} onChange={changeFecha} />
                    </div>
                    <div className='nombre'>
                        <label>nombre del paciente</label>
                        <input name='nombre' placeholder='nombre' value={name}  onChange={changeName}/>
                    </div>
                    <div className='procedimiento'>
                        <label>Procedimiento Medico</label>
                        <input name='procedimiento' placeholder='procedimiento' value={proce} onChange={changeProcedimiento}  />

                    </div>
                    <div>
                        <button type='submit'>{opcion}</button>
                    </div>

                </form>
            </div>

            <div>
                <form onSubmit={peticion_modificar}>
                    <div className={modificar}>
                        <div >
                            <label>Por favor ingrese su numerode cedula</label>
                            <input name='cedula' onChange={change_cedula} />
                            <button type='submit' onSubmit={botonCedula}>{opcion}</button>
                        </div>
                        <div>
                        <label>Por favor ingrese el nombre del procedimiento</label>
                            <input name='procedimiento' value={proce} onChange={changeProcedimiento} />
                            <button type='submit' onSubmit={botonCedula}>{opcion}</button>
                        </div>
                        <div className={modificaBody}>

                            <div >
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
                            <button type='submit'>{opcion}</button>
                        </div>
                    </div>


                </form>
            </div>
            
        </div>
    )
}
export default Reservacion