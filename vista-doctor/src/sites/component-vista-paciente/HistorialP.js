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
                                <label>Fecha</label>
                                <input value={usuario.fecha} />
                            </div>
                            <div>
                                <label>Procedimiento</label>
                                <input value={usuario.Procedimiento} />
                            </div>
                            <div>
                                <label>Tratamiento</label>
                                <input value={usuario.Tratamiento} />
                            </div>

                        </div>
                    )
                })

            }


        </div>

    )
}
export default HistorialP