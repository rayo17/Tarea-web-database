import React, {useState} from 'react'
import { useParams } from 'react-router-dom'
import axios from 'axios'
function Edit() {
    const parametros = useParams()
    const [fecha, setfecha] = useState('')
    const [cedula, setcedula] = useState('') 
    const [proce, setproce] = useState('')
    const change_cedula = (e) => {
        setcedula(e.target.value) //actualiza la cedula
    }
    const changeProcedimiento = (e) => {
        setproce(e.target.value)//actualiza el texto del input procedimiento
    }

    const changeFecha = (e) => {
        console.log(fecha)
        setfecha(e.target.value)
    }
    const peticion_modif = (event) => {
        event.preventDefault()
        console.log('modificandoooooo')
        
        axios.put(`http://localhost:5004/api/Reservacion/${cedula}/${proce}`, {
            id: parametros.id,
            paciente: cedula,
            procedimiento: proce,
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
                <input value={cedula} onChange={change_cedula} />
            </div>
            <div>
                <label>Procedimiento</label>
                <input value={proce} onChange={changeProcedimiento} />
            </div>
            <button onClick={peticion_modif}></button>

        </div>

    )
}

export default Edit