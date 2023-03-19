import icon from './doctor.png';
import React from 'react'
import { Link } from 'react-router-dom'


export const Navbar = () => {
  return (
    <div>
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link to='/'>
                    <img src={icon} width='35'/>
                </Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <a className="nav-link">Vista Doctor</a>
                    </li>

                    <li className="nav-item">
                        <Link className='nav-link' to='/Paciente'>Pacientes</Link>
                    </li>

                    <li className="nav-item">
                        <Link className="nav-link" to='/Historial'>Historiales clínicos</Link>
                    </li>
                </ul>
                </div>
            </div>
        </nav>        
    </div>
  )
}
