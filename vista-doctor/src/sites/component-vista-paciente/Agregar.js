import React from 'react'
 function Agregar(){
    return (
        <div>
            <form>
                <div className='nombre'>
                    <label>nombre</label>
                    <input name='nombre' placeholder='nombre'/>
                </div>
                <div className='apellido1'>
                    <label>nombre</label>
                    <input name='apellido1' placeholder='apellido1'/>
                </div>
                <div className='apellido2'>
                    <label>nombre</label>
                    <input name='apellido2' placeholder='apellido2'/>
                </div>
            </form>
        </div>
    )
 }
 export default Agregar