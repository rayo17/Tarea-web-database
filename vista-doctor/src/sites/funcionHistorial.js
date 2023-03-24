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
    <div>
      <ul>
        {historiales.map(historial => (
          <li key={historial.id}>{historial.procedimiento} {historial.fecha} {historial.tratamiento}</li>
        ))}
      </ul>
    </div>
  );
}

export default Historiales;