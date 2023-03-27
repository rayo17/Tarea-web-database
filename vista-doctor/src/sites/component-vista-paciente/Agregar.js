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
    const [errors, seterrors] = useState({})
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
    const onValidacion = () => {
        let errors = {}
        let regexName = /^[A-Za-zÑñÁáÉéÍíÓóÚúÜü\s]+$/
        let regexTamaño = /^.{1,50}$/
        let regexTamName = /^.{1,15}$/
        let regexTamTrata = /^.{1,15}$/

        if (!fecha.trim()) {
            errors.calendario = 'Selecione una fecha para poder enviar los datos'

        }
        if (!direct.trim()) {
            errors.direct = 'El campo direccion esta vacio'

        }
        else if (!regexTamaño.test(direct)) {
            errors.direct = 'El campo "Direccion" solo acepta 50 caracteres'
        }


        if (!name.trim()) {
            errors.nombre = 'El campo Nombre esta vacio'

        }

        else if (!regexName.test(name)) {
            errors.nombre = 'El campo "Nombre" solo acepta letras y espacios.'
        }
        else if (!regexTamName.test(name)) {
            errors.nombre = 'El campo "Nombre" solo acepta hasta 15 caracteres.'
        }
        if (!apellido1.trim()) {
            errors.apellido1 = 'El campo apellido1 esta vacio'
        }
        else if (!regexName.test(apellido1)) {
            errors.apellido1 = 'El campo "apellido1" solo acepta letras y espacios.'
        }
        else if (!regexTamName.test(apellido1)) {
            errors.apellido1 = 'El campo "Apellido1" solo acepta hasta 15 caracteres.'
        }
        if (!apellido2.trim()) {
            errors.apellido2 = 'El campo apellido esta vacio'

        }
        else if (!regexName.test(apellido2)) {
            errors.apellido2 = 'El campo "apellido2" solo acepta letras y espacios.'

        }
        else if (!regexTamName.test(apellido2)) {
            errors.apellido2 = 'El campo "Apellido2" solo acepta hasta 15 caracteres.'
        }
        if (!tratamiento.trim()) {
            errors.tratamiento = 'El campo tratamiento esta vacio'
        }
        else if (!regexName.test(tratamiento)) {
            errors.tratamiento = 'El campo "tratamiento" solo acepta letras y espacios.'
        }
        else if (!regexTamTrata.test(tratamiento)) {
            errors.tratamiento = 'El campo "tratamiento" solo acepta hasta 20 caracteres.'
        }
        if (!patologia.trim()) {
            errors.patologia = 'El campo patologia esta vacio'

        }
        else if (!regexTamTrata.test(patologia)) {
            errors.patologia = 'El campo "patologia" solo acepta hasta 20 caracteres.'
        }
        else if (!regexName.test(patologia)) {
            errors.patologia = 'El campo "patologia" solo acepta letras y espacios.'
        }
        if (!cedula.trim()) {
            errors.cedula = 'El campo patologia esta vacio'
        }
        if (!direct.trim()) {
            errors.direct = 'El campo patologia esta vacio'
        }


        return errors
    }
    const submit = (event) => {
        event.preventDefault();
        // Enviar los datos al backend para crear un nuevo registro
        let err = onValidacion()
        seterrors(err)
        if (Object.keys(err).length === 0) {
            console.log('enviando form')
            setloading(true)
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
                ).then(() => {
                    condiciones_iniciales()
                    setloading(false)
                }
                )
                .catch((error) => {
                    console.log('error')
                    setloading(false)
                })
        }
        else {
            seterrors(err)
        }
      
    }

    return (
        <div>

            <form onSubmit={submit} className='w-10' >
                <div>
                    <h1>Crear cuenta</h1>
                </div>
                <div className='calendario'>
                    <label className='form-label '>Fecha de nacimiento</label>
                    <input type='date' name='calendario' value={fecha} onChange={cambiarFecha} />

                </div>
                {errors.calendario && <div className='alert alert-danger p-1 error'>
                    {errors.calendario}
                </div>}

                <div className='nombre'>
                    <label>nombre</label>
                    <input name='nombre' placeholder='nombre' value={name} onChange={cambiarNombre} />
                    {errors.nombre && <div className='alert alert-danger p-1 error'>
                        {errors.nombre}
                    </div>}
                </div>
                <div className='apellido1'>
                    <label>apellido1</label>
                    <input name='apellido1' placeholder='apellido1' value={apellido1} onChange={cambiarApellido1} />
                    {errors.apellido1 && <div className='alert alert-danger error'>
                        {errors.apellido1}
                    </div>
                    }
                </div>
                <div className='apellido2'>
                    <label>apellido2</label>
                    <input name='apellido2' placeholder='apellido2' value={apellido2} onChange={cambiarApellido2} />
                    {errors.apellido2 && <div className='alert alert-danger error'>
                        {errors.apellido2}
                    </div>}
                </div>
                <div className='direccion'>
                    <label>direccion</label>
                    <input name='direccion' placeholder='direccion' value={direct} onChange={cambiarDireccion} />
                    {errors.direct && <div className='alert alert-danger error'>
                        {errors.direct}
                    </div>}

                </div>
                <div className='cedula'>
                    <label>cedula</label>
                    <input name='cedula' placeholder='cedula' value={cedula} onChange={cambiarCedula} type='number' />
                    {errors.cedula && <div className='alert alert-danger error'>
                        {errors.cedula}
                    </div>}

                </div>
                <div className='patologias'>
                    <label>patologias</label>
                    <input name='patologias' placeholder='patologias' value={patologia} onChange={cambiarPatologia} />
                    {errors.patologia &&
                        <div className='alert alert-danger error'>
                            {errors.patologia}
                        </div>}
                </div>
                <div className='Tratamientos'>
                    <label>Tratamientos</label>
                    <input name='tratamientos' placeholder='tratamientos' value={tratamiento} onChange={cambiarTratamiento} />
                    {errors.tratamiento &&
                        <div className='alert alert-danger error'>
                            {errors.tratamiento}
                        </div>
                    }
                </div>
                <div className='botonAgregar'>
                <button type="submit"  className='btn botonAgregar'  disabled={loading}>{loading ? 'Enviando...' : 'Crear paciente'}</button>
                 </div>
            </form>

        </div>
    )
}
export default Agregar