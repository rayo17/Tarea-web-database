<<<<<<< HEAD
import React, { Component } from 'react'
//import axios from 'axios'
import Pacientes from './funcion'
=======
import React, { Component } from 'react';
import axios from 'axios';
import NuevoPacienteFormulario from "./NuevoPacienteFormulario.js";
>>>>>>> ff6b413adbc56db45a10e7c48f977836a33b8daf


class Paciente extends Component {
  constructor(props) {
    super(props);
  
    this.state = {
      pacientes: [],
      telefonos: [],
      patologias: [],
      direcciones: [],
      showForm: false,
      error: null,
    };
  }
  toggleForm = () => {
    this.setState({ showForm: !this.state.showForm });
  };

  
  componentDidMount() {
    this.handleNewPatient()
  }
  handleNewPatient = () => {
    axios.get('http://localhost:5004/api/paciente')
      .then(response => {
        this.setState({ pacientes: response.data });
      })
      .catch(error => {
        this.setState({ error: error.message });
      });
      axios.get('http://localhost:5004/api/Paciente_Direcciones')
  .then(response => {
    const direcciones = {};
    response.data.forEach(direccion => {
      direcciones[direccion.paciente] = direccion.ubicacion;
    });
    axios.get('http://localhost:5004/api/Paciente_Telefonos')
      .then(response => {
        const telefonos = {};
        response.data.forEach(telefono => {
          if (!telefonos[telefono.paciente]) {
            telefonos[telefono.paciente] = [];
          }
          telefonos[telefono.paciente].push(telefono.telefono);
        });
        this.setState({ telefonos });
      })
      .catch(error => {
        this.setState({ error: error.message });
      });

    axios.get('http://localhost:5004/api/Patologia')
      .then(response => {
        const patologias = {};
        response.data.forEach(patologia => {
          if (!patologias[patologia.paciente]) {
            patologias[patologia.paciente] = [];
          }
          patologias[patologia.paciente].push({
            nombre: patologia.nombre,
            tratamiento: patologia.tratamiento
          });
        });
        this.setState({ patologias });
      })
      .catch(error => {
        this.setState({ error: error.message });
      });

    this.setState({ direcciones });
  })
  .catch(error => {
    this.setState({ error: error.message });
  });
}


  render() {
    const { pacientes, direcciones, error } = this.state;
  
    return (
      <div>
        <h1>Pacientes</h1>
        {error && <div>Error: {error}</div>}
        <table style={{ borderCollapse: 'collapse', width: '80%', margin: '20px' }}>
          <thead>
            <tr>
              <th style={{ border: '1px solid black', padding: '10px' }}>Nombre</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Apellidos</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Cédula</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Fecha de nacimiento</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Dirección</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Teléfonos</th>
              <th style={{ border: '1px solid black', padding: '10px' }}>Patologías</th>
            </tr>
          </thead>
          <tbody>
            {pacientes.map(paciente => (
              <tr key={paciente.cedula}>
                <td style={{ border: '1px solid black', padding: '10px' }}>{paciente.nombre}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{paciente.primer_apellido} {paciente.segundo_apellido}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{paciente.cedula}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{paciente.fecha_nacimiento}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{direcciones[paciente.cedula]}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{this.state.telefonos[paciente.cedula] ? this.state.telefonos[paciente.cedula].join(', ') : ''}</td>
                <td style={{ border: '1px solid black', padding: '10px' }}>{this.state.patologias[paciente.cedula] ? this.state.patologias[paciente.cedula].map(patologia => `${patologia.nombre} (${patologia.tratamiento})`).join(', ') : ''}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={this.toggleForm}>Nuevo Paciente</button>
        {this.state.showForm && <NuevoPacienteFormulario onClose={this.toggleForm} onNewPatient={this.handleNewPatient} />}
      </div>
    );
  }
  
}

export default Paciente;
