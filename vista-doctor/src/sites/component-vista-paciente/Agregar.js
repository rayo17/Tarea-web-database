import React, { useState } from 'react'
import axios from 'axios';
function Agregar() {
    const [direct, setdirect]=useState('')
    const [name, setName]=useState('')
    const [patologia, setpatologia]= useState('')
    const [fecha, setfecha]=useState('')
    const [apellido1, setapellido1]=useState('')
    const [apellido2, setapellido2]=useState('')
    const [cedula, setcedula]=useState('')
    const [tratamiento, settratamiento]=useState('')

    const condiciones_iniciales =()=>{
        setName('')
        setapellido1('')
        setapellido2('')
        setpatologia('')
        setfecha('')
        setcedula('')
        setdirect('')
        settratamiento('')
    }

    const cambiarDireccion = (e) =>{
        console.log(e.target.value)
        setdirect(e.target.value)
    }
    const cambiarNombre = (e) =>{
        console.log(e.target.value)
        setName(e.target.value)
    }
    const cambiarPatologia = (e) =>{
        console.log(e.target.value)
        setpatologia(e.target.value)
    }
    const cambiarApellido1 = (e) =>{
        console.log(e.target.value)
        setapellido1(e.target.value)
    }
    const cambiarApellido2 = (e) =>{
        console.log(e.target.value)
        setapellido2(e.target.value)
    }
    const cambiarTratamiento = (e) =>{
        console.log(e.target.value)
        settratamiento(e.target.value)
        settratamiento([...tratamiento,{tratamientos:''}])
        console.log(tratamiento)
    }
    const cambiarCedula = (e) =>{
        console.log(e.target.value)
        setcedula(e.target.value)
    }
    const cambiarFecha = (e) =>{
        console.log(e.target.value)
        setfecha(e.target.value)
    }
    const task = (event) => {
        event.preventDefault();
        condiciones_iniciales()
    
        // Enviar los datos al backend para crear un nuevo registro
        axios
          .post("http://localhost:5004/api/paciente", {
            cedula: cedula,
            nombre: name,
            primer_apellido: apellido1,
            segundo_apellido: apellido2,
            fecha_nacimiento: fecha,
          })
          .then((response) => {
            // Agregar la dirección del paciente
            axios
              .post("http://localhost:5004/api/Paciente_Direcciones", {
                paciente: cedula,
                ubicacion: direct})}
              ).catch((error) => {
                console.log('error')
              })
            
            }
    return (
        <div>
            <div>
                <h1>Crear cuenta</h1>
            </div>
            <form onSubmit={task}>
                <div className='calendario'>
                    <label>Fecha de nacimiento</label>
                    <input type='date' name='calendario' value={fecha} onChange={cambiarFecha}/>
                </div>

                <div className='nombre'>
                    <label>nombre</label>
                    <input name='nombre' placeholder='nombre' value={name} onChange={cambiarNombre}/>
                </div>
                <div className='apellido1'>
                    <label>apellido1</label>
                    <input name='apellido1' placeholder='apellido1' value={apellido1} onChange={cambiarApellido1}/>
                </div>
                <div className='apellido2'>
                    <label>apellido2</label>
                    <input name='apellido2' placeholder='apellido2' value={apellido2} onChange={cambiarApellido2}/>
                </div>
                <div className='direccion'>
                    <label>direccion</label>
                    <input name='direccion' placeholder='direccion' value={direct.direcciones} onChange={cambiarDireccion}/>
                </div>
                <div className='direccion'>
                    <label>cedula</label>
                    <input name='cedula' placeholder='cedula'value={cedula} onChange={cambiarCedula} />
                </div>
                <div className='patologias'>
                    <label>patologias</label>
                    <input name='patologias' placeholder='patologias' value={patologia} onChange={cambiarPatologia}/>
                </div>
                <div className='Tratamientos'>
                    <label>Tratamientos</label>
                    <input name='tratamientos' placeholder='tratamientos' value={tratamiento.tratamientos} onChange={cambiarTratamiento} />
                </div>
                <button type="submit">crear paciente</button>
            </form>
        </div>
    )
}
export default Agregar