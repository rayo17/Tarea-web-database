/**
 * Componente de clase que representa el formulario para agregar datos de un paciente.
 * @class
 * @extends Component
 */

import React, { Component } from "react";
import axios from "axios";
import { Form} from 'react-bootstrap';

class AñadirData extends Component {
  
  /**
   * Constructor de la clase.
   * @constructor
   * @param {object} props - Propiedades del componente.
   */
  
  constructor(props) {
    super(props);
    this.state = {
      cedula: "",
      direccion: "",
      telefono: "",
      patologia_nombre: "",
      patologia_tratamiento: "",
      showModal: false,
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleOuterClick = this.handleOuterClick.bind(this);
  }

  /**
   * Manejador del evento onSubmit del formulario.
   * @param {object} event - Evento del formulario.
   */

  handleSubmit = (event) => {
    event.preventDefault();

    // Agregar la dirección del paciente
    axios.post("http://localhost:5004/api/Paciente_Direcciones", {
      paciente: this.state.cedula,
      ubicacion: this.state.direccion ? this.state.direccion : null,
    });

    // Agregar el número de teléfono del paciente
    axios.post("http://localhost:5004/api/Paciente_Telefonos", {
      paciente: this.state.cedula,
      telefono: parseInt(this.state.telefono) ? this.state.telefono : null,
    });

    // Agregar la patología del paciente
    axios.post("http://localhost:5004/api/Patologia", {
      paciente: parseInt(this.state.cedula),
      nombre: this.state.patologia_nombre ? this.state.patologia_nombre : null,
      tratamiento: this.state.patologia_tratamiento ? this.state.patologia_tratamiento : null,
    });

    console.log("Datos paciente agregado");
    this.props.onClose();
    this.props.onAdd();
  };

  /**
   * Manejador del evento onChange de los campos del formulario.
   * @param {object} event - Evento del formulario.
   */

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value });
  };

  /**
   * Manejador del evento onClick en cualquier parte fuera del formulario.
   * @param {object} event - Evento del formulario.
   */

  handleOuterClick(event) {
    const container = document.querySelector('.container2');
    if (container && !container.contains(event.target)) {
      this.props.onClose();
    }
  };

  /**
   * Se añade el manejador del evento onClick en cualquier parte fuera del formulario.
   */

  componentDidMount() {
    document.addEventListener('mousedown', this.handleOuterClick);
  };

  /**
   * Se elimina el manejador del evento onClick en cualquier parte fuera del formulario.
   */

  componentWillUnmount() {
    document.removeEventListener('mousedown', this.handleOuterClick);
  };
  
  /**
   * Renderiza el formulario para agregar datos del paciente.
   * @returns {object} - Elemento con el formulario renderizado.
   */
  
  render() {    
    return (
      <div
        className="container2"
        style={{
          maxWidth: '300px',
          margin: '0 auto',
          marginTop: '20px',
          textAlign: 'center',
          position: 'absolute',
          top: '50%',
          left: '50%',
          transform: 'translate(-50%, -50%)',
          backgroundColor: 'white',
          padding: '20px',
          boxShadow: '0 2px 8px rgba(0, 0, 0, 0.2)',
          zIndex: '1',
        }}
      >
        <Form onSubmit={this.handleSubmit}>
          <h2>Añadir Datos</h2>
          <div className="form-input">
            <label htmlFor="cedula">Cédula:</label>
            <input
              type="text"
              name="cedula"
              value={this.state.cedula}
              onChange={this.handleChange}
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="direccion">Dirección:</label>
            <input
              type="text"
              name="direccion"
              value={this.state.direccion}
              onChange={this.handleChange}
              
            />
          </div>
          <div className="form-input">
            <label htmlFor="telefono">Teléfono:</label>
            <input
              type="tel"
              name="telefono"
              value={this.state.telefono}
              onChange={this.handleChange}
              
            />
          </div>
          <div className="form-input">
            <label htmlFor="patologia_nombre">Nombre de patología:</label>
            <input
              type="text"
              name="patologia_nombre"
              value={this.state.patologia_nombre}
              onChange={this.handleChange}
              
            />
          </div>
          <div className="form-input">
            <label htmlFor="patologia_tratamiento">Tratamiento de patología:</label>
            <input
              type="text"
              name="patologia_tratamiento"
              value={this.state.patologia_tratamiento}
              onChange={this.handleChange}
              
            />
            </div>
            <div style={{marginTop: "20px"}}>
            <button type="submit" style={{
              backgroundColor: "#fff",
              borderBottom: "1px solid #000",
              border: "1px solid #00008B",
              color: "#00008B",
              cursor: "pointer",
              display: "block",
              margin: "0 auto",
              padding: "10px 20px"
            }}>Add Data</button>
            </div>
      </Form>
    </div>
            );
    }
}

export default AñadirData;