import React, { useState } from 'react'
import axios from 'axios';
import '../Agregar.css'
function Agregar() {
    const [direct, setdirect] = useState('')
    const [name, setName] = useState('')
    const [patologia, setpatologia] = useState('')
    const [fecha, setfecha] = useState('')
    const [apellido1, setapellido1] = useState('')
    const [apellido2, setapellido2] = useState('')
    const [cedula, setcedula] = useState('')
    const [tratamiento, settratamiento] = useState('')
    const [loading, setloading] = useState(false)
    const [error, seterror] = useState(null)
    const condiciones_iniciales = () => {
        setName('')
        setapellido1('')
        setapellido2('')
        setpatologia('')
        setfecha('')
        setcedula('')
        setdirect('')
        settratamiento('')
    }

    const cambiarDireccion = (e) => {
        console.log(e.target.value)
        setdirect(e.target.value)
    }
    const cambiarNombre = (e) => {
        console.log(e.target.value)
        setName(e.target.value)
    }
    const cambiarPatologia = (e) => {
        console.log(e.target.value)
        setpatologia(e.target.value)
    }
    const cambiarApellido1 = (e) => {
        console.log(e.target.value)
        setapellido1(e.target.value)
    }
    const cambiarApellido2 = (e) => {
        console.log(e.target.value)
        setapellido2(e.target.value)
    }
    const cambiarTratamiento = (e) => {
        console.log(e.target.value)
        settratamiento(e.target.value)
        console.log(tratamiento)
    }
    const cambiarCedula = (e) => {
        console.log(e.target.value)
        setcedula(e.target.value)
    }
    const cambiarFecha = (e) => {
        console.log(e.target.value)
        setfecha(e.target.value)
    }
    const submit = (event) => {
        event.preventDefault();

        // Enviar los datos al backend para crear un nuevo registro
        axios
            .post("https://localhost:44362/api/Paciente", {
                cedula: cedula,
                nombre: name,
                primer_apellido: apellido1,
                segundo_apellido: apellido2,
                fecha_nacimiento: fecha,
            })
            .then((response) => {
                // Agregar la dirección del paciente
                axios
                    .post("https://localhost:44362/api/Paciente_Direcciones", {
                        paciente: cedula,
                        ubicacion: direct
                    })
            }
            ).then((response) => {
                // Agregar la dirección del paciente
                axios
                    .post("https://localhost:44362/api/Patologia", {
                        Paciente: cedula,
                        Nombre: patologia,
                        Tratamiento: tratamiento
                    })
            }
            )
            .catch((error) => {
                console.log('error')
            })

    }
    return (
        <div>

            <form onSubmit={submit} className='container-form'>
                <div>
                    <h1>Crear cuenta</h1>
                </div>
                <div className='calendario'>
                    <label>Fecha de nacimiento</label>
                    <input type='date' name='calendario' value={fecha} onChange={cambiarFecha} />
                </div>

                <div className='nombre'>
                    <label>nombre</label>
                    <input name='nombre' placeholder='nombre' value={name} onChange={cambiarNombre} />
                    <div className='alert alert-danger'>
                        erorr el el nombre
                    </div>
                </div>
                <div className='apellido1'>
                    <label>apellido1</label>
                    <input name='apellido1' placeholder='apellido1' value={apellido1} onChange={cambiarApellido1} />
                    <div className='alert alert-danger'>
                        erorr el el nombre
                    </div>
                </div>
                <div className='apellido2'>
                    <label>apellido2</label>
                    <input name='apellido2' placeholder='apellido2' value={apellido2} onChange={cambiarApellido2} />
                    <div className='alert alert-danger'>
                        erorr apellido2
                    </div>
                </div>
                <div className='direccion'>
                    <label>direccion</label>
                    <input name='direccion' placeholder='direccion' value={direct.direcciones} onChange={cambiarDireccion} />
                    <div className='alert alert-danger'>
                        Erorr direccion
                    </div>

                </div>
                <div className='cedula'>
                    <label>cedula</label>
                    <input name='cedula' placeholder='cedula' value={cedula} onChange={cambiarCedula} />
                    <div className='alert alert-danger'>
                        Erorr el cedula
                    </div>
                </div>
                <div className='patologias'>
                    <label>patologias</label>
                    <input name='patologias' placeholder='patologias' value={patologia} onChange={cambiarPatologia} />

                    <div className='alert alert-danger'>
                        Error patologia
                    </div>
                </div>
                <div className='Tratamientos'>
                    <label>Tratamientos</label>
                    <input name='tratamientos' placeholder='tratamientos' value={tratamiento} onChange={cambiarTratamiento} />

                    <div className='alert alert-danger'>
                        Erorr el el tratamiento
                    </div>
                </div>
                <button type="submit">crear paciente</button>
            </form>
            <div className='cuentas'>

            </div>
        </div>
    )
}
export default Agregar