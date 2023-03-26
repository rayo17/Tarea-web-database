import React, { useState } from 'react'
import axios from 'axios'
import '../Reservacion.css'

function Reservacion() {
    /* se crean los state hook para los diferentes cambios de estos */
    const [create, setcreate] = useState('crear') // para crear
    const [modificar, setmodificar] = useState('null') // para modificar
    const [opcion, setopcion] = useState('crear') // para opciones como modificar, crear o eliminar
    const [cedula, setcedula] = useState('') // cedula
    const [modificaBody, setmodificarBody] = useState('null')
    const [name, setname] = useState('')
    const [fecha, setfecha] = useState('')
    const [proce, setproce] = useState('')
    const [contador, setcontador] = useState(1)
    const [eliminar, seteliminar] = useState('null')
    const [errors,seterror]=useState({})


    const boton = (e) => {
        e.preventDefault()// para no refrescar el form
    }
    const botonCedula = (e) => {
        e.preventDefault()
    }

    const changeName = (e) => {
        setname(e.target.value) // para actualizar el input de nombre
    }
    const changeFecha = (e) => {
        setfecha(e.target.value)
    }
    const changeProcedimiento = (e) => {
        setproce(e.target.value)//actualiza el texto del input procedimiento
    }

    const cambioSeleccion = (e) => {
        if (e.target.value === 'create') {
            setcreate('crear')
            setmodificar('null')
            setopcion('crear')
            seteliminar('null')

        }
        if (e.target.value === 'modificar') {
            setmodificar('modificar')
            setcreate('null')
            setopcion('modificar')
            seteliminar('null')
        }
        if (e.target.value === 'eliminar') {
            setopcion('eliminar')
            seteliminar('eliminar')
            setmodificar('null')
            setcreate('null')

        }
    }


    const change_cedula = (e) => {
        setcedula(e.target.value) //actualiza la cedula
    }

    const peticion_modificar = (event) => {
        event.preventDefault();

        axios.get(`https://localhost:44362/api/Reservacion/${cedula}`)
            .then(response => {console.log(response) 
            setmodificarBody('modificar')
            })
            .catch(error => alert('error'))

    }

    const validacion=()=>{
        let errors={}
    }

    const peticion_crear = (event) => {// petion para crear se hace con un post donde se envian un json
        event.preventDefault();
        setcontador(1 + contador)
        axios.post('https://localhost:44362/api/Reservacion',{
            paciente:cedula,
            procedimiento:proce,
            fecha:fecha,
            id: contador

        })
            .then(response => console.log('todo bien'))
            .catch(error => alert('error'))
    }
    const peticion_eliminar = (event) => {
        event.preventDefault()
        axios.delete(`https://localhost:44362/api/Reservacion/${cedula}/${proce}`).then(res=> res.data)


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
                        <label>cedula del paciente</label>
                        <input name='cedula' placeholder='cedula' value={cedula} onChange={change_cedula} />
                    </div>
                    <div className='procedimiento'>
                        <label>Procedimiento Medico</label>
                        <input name='procedimiento' placeholder='procedimiento' value={proce} onChange={changeProcedimiento} />

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
            <div>
                <form onSubmit={peticion_eliminar}>
                    <div className={eliminar}>
                        <div >
                            <label>Por favor ingrese su numerode cedula</label>
                            <input name='cedula' onChange={change_cedula} />
                        </div>
                        <div >
                            <label>Por favor ingrese su numerode cedula</label>
                            <input name='procedimiento' onChange={changeProcedimiento} />
                            <button type='submit' onSubmit={botonCedula}>{opcion}</button>
                        </div>
                    </div>
                </form>
            </div>

        </div>
    )
}
export default Reservacion