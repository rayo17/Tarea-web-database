import React from 'react';
import {Link, link} from 'react-router-dom'
function Usuario({user}){
    return(
      <div className='container'>
        <div className='row'>
            <div className='col-sm-6 offset-3'>
               <ul>
                <li className='list-grup-item'>{user.nombre}</li>
                <li className='list-grup-item'>{user.tratamiento}</li>
                <li className='list-grup-item'></li>
                <li className='list-grup-item'></li>
                </ul> 
            </div>
        </div>

      </div>
    )
}
export default Usuario