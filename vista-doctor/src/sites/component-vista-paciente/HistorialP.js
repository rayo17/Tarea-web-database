import React, { useEffect, useState } from 'react'
import axios from 'axios'

function HistorialP() {
    let [usuario, setusuarios] = useState([])


    useEffect(()=>{
        cargar_historial()
    })
    const cargar_historial = async () => {
        const resp = await axios.get('https://localhost:44362/api/Historial')
        setusuarios(resp.data)

    }
   
    return (
        <div>
            {
                usuario.map((usuario, index) => {
                    return (
                        <div key={index}>
                            <div>
                                <label>nombre </label>
                                <input value={usuario.nombre} />
                            </div>
                            <div>
                                <label>Fecha</label>
                                <input value={usuario.fecha} />
                            </div>
                            <div>
                                <label>Fecha</label>
                                <input value={usuario.procedimiento} />
                            </div>

                        </div>
                    )
                })

            }


        </div>

    )
}
export default HistorialP