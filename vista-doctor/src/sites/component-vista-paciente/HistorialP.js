import React, { useEffect, useState } from 'react'
import axios from 'axios'
import './historial.css'
import  Menu  from '../Menu';


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
    const cargar_historial = async (event) => {
        event.preventDefault();
        const resp = await axios.get('http://localhost:5004/api/historial')
        setusuarios(resp.data)
        setvible('historial')

    }

    return (
        <div>
            <Menu/>
            <div>
                <form onSubmit={cargar_historial}>
                    <label>Ingresa tu cedula para ver tu historial clinico</label>
                    <input type='number' value={cedula} onChange={changeCedula} />
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