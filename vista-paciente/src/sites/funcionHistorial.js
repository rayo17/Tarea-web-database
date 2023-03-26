import React, { useState, useEffect } from 'react';
import axios from 'axios';

function Historiales() {
  const [historiales, setHistoriales] = useState([]);

  
  useEffect(() => {
    axios.get('http://localhost:5004/api/historial')
      .then(response => {
        setHistoriales(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

  return (
    <div className="container">
      <div className="py-4">
        <table className="table border shadow">
        <thead>
            <tr>
              <th>Paciente</th>
              <th>Procedimiento</th>
              <th>Fecha</th>
              <th>Tratamiento</th>
            </tr>
          </thead>
          <tbody>
            {
              historiales.map((user) => (
                <tr>
                  <td>{user.paciente}</td>
                  <td>{user.procedimiento}</td>
                  <td>{user.fecha}</td>
                  <td>{user.tratamiento}</td>
                </tr>
              ))
            }
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default Historiales;