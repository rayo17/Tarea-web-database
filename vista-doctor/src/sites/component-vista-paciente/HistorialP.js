import React, { useEffect, useState } from 'react'
import axios from 'axios'
import './historial.css'

function HistorialP() {
    let [usuario, setusuarios] = useState([])
    const [visible, setvible] = useState('null')
    const [cedula, setcedula] = useState('')
    const changeCedula = (e) => {
        setcedula(e.target.value)
    }

    /* useEffect(()=>{
         cargar_historial()
     })*/
    const cargar_historial = async () => {
        const resp = await axios.get('https://localhost:44362/api/Historial')
        setusuarios(resp.data)
        setvible('historial')

    }

    return (
        <div>
            <div>
                <form onSubmit={cargar_historial}>
                    <label>Ingresa tu cedula para ver tu historial clinico</label>
                    <input value={cedula} onChange={changeCedula} />
                    <button type='submit'>Enviar</button>
                </form>

            </div>
            <div className={visible}>
                {
                    usuario.map((usuario, index) => {
                        return (
                            <div key={index}>
                                <div>
                                    <label>Fecha</label>
                                    <input value={usuario.fecha} />
                                </div>
                                <div>
                                    <label>Procedimiento</label>
                                    <input value={usuario.procedimiento} />
                                </div>
                                <div>
                                    <label>Tratamiento</label>
                                    <input value={usuario.tratamiento} />
                                </div>

                            </div>
                        )
                    })

                }

            </div>


        </div>

    )
}
export default HistorialP