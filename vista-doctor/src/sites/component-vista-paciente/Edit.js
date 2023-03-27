import React, {useState} from 'react'
import { useParams } from 'react-router-dom'
function Edit() {
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
}