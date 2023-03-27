import React, {useState} from 'react'
import { useParams } from 'react-router-dom'
import axios from 'axios'
function Edit() {
    const parametros=useParams()
    const [fecha, setfecha] = useState('')

    const changeFecha = (e) => {
        console.log(fecha)
        setfecha(e.target.value)
    }
    const peticion_modif = (event) => {
        event.preventDefault()
        console.log('modificandoooooo')
        
        axios.put(`https://localhost:44362/api/Reservacion/${parametros.paciente}/${parametros.procedimiento}`, {
            id: parametros.id,
            paciente: parametros.paciente,
            procedimiento: parametros.procedimiento,
            fecha: fecha
        })

            .then(response => {
                console.log(response.data)

            }).catch(error => console.log(error))

    }
    console.log('parametros',parametros)
    return (
        <div>
            <div>
                <label>Fecha</label>
                <input type={'date'} value={fecha} onChange={changeFecha}/>
            </div>
            <div>
                <label>cedula</label>
                <input value={parametros.paciente} />
            </div>
            <div>
                <label>Procedimiento</label>
                <input value={parametros.procedimiento} />
            </div>
            <button onClick={peticion_modif}></button>

        </div>

    )
}

export default Edit