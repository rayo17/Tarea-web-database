import React, { useState, useEffect } from 'react';
import axios from 'axios';

function Pacientes() {
  const [pacientes, setPacientes] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5004/api/paciente')
      .then(response => {
        setPacientes(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

  return (
    <div>
      <h1>Listado de Pacientes</h1>
      <ul>
        {pacientes.map(paciente => (
          <li key={paciente.id}>{paciente.nombre} {paciente.primer_apellido}</li>
        ))}
      </ul>
    </div>
  );
}

export default Pacientes;