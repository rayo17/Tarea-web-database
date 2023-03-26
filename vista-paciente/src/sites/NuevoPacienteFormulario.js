import React, { Component } from "react";
import axios from "axios";
import { Form, Button } from 'react-bootstrap';





class NuevoPacienteFormulario extends Component {
  constructor(props) {
    super(props);

    this.state = {
      nombre: "",
      primer_apellido: "",
      segundo_apellido: "",
      cedula: "",
      fecha_nacimiento: "",
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

  handleSubmit = (event) => {
    event.preventDefault();

    // Enviar los datos al backend para crear un nuevo registro
    axios
      .post("http://localhost:5004/api/paciente", {
        cedula: this.state.cedula,
        nombre: this.state.nombre,
        primer_apellido: this.state.primer_apellido,
        segundo_apellido: this.state.segundo_apellido,
        fecha_nacimiento: this.state.fecha_nacimiento,
      })
      .then((response) => {
        // Agregar la dirección del paciente
        axios
          .post("http://localhost:5004/api/Paciente_Direcciones", {
            paciente: this.state.cedula,
            ubicacion: this.state.direccion,
          })
          .then((response) => {
            // Agregar el número de teléfono del paciente
            axios
              .post("http://localhost:5004/api/Paciente_Telefonos", {
                paciente: this.state.cedula,
                telefono: parseInt(this.state.telefono),
              })
              .then((response) => {
                // Agregar la patología del paciente
                axios
                  .post("http://localhost:5004/api/Patologia", {
                    paciente: parseInt(this.state.cedula),
                    nombre: this.state.patologia_nombre,
                    tratamiento: this.state.patologia_tratamiento,
                  })
                  .then((response) => {
                    // Actualizar el estado de los pacientes con los nuevos datos ingresados
                    this.props.onNewPatient();
                  })
                  .catch((error) => {
                    this.setState({ error: error.message });
                  });
              })
              .catch((error) => {
                this.setState({ error: error.message });
              });
          })
          .catch((error) => {
            this.setState({ error: error.message });
          });
      })
      .catch((error) => {
        this.setState({ error: error.message });
      });

    console.log("Nuevo paciente agregado");
    this.props.onClose();
  };

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value });
  };
  handleOuterClick(event) {
    const container = document.querySelector('.container');
    if (container && !container.contains(event.target)) {
      this.props.onClose();
    }
  };
  componentDidMount() {
    document.addEventListener('mousedown', this.handleOuterClick);
  };

  componentWillUnmount() {
    document.removeEventListener('mousedown', this.handleOuterClick);
  };
  render() {    
    return (
      <div
        className="container"
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
          <h2>Nuevo paciente</h2>
          <div className="form-input">
            <label htmlFor="nombre">Nombre:</label>
            <input
              type="text"
              name="nombre"
              value={this.state.nombre}
              onChange={this.handleChange}
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="primer_apellido">Primer apellido:</label>
            <input
              type="text"
              name="primer_apellido"
              value={this.state.primer_apellido}
              onChange={this.handleChange}
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="segundo_apellido">Segundo apellido:</label>
            <input
              type="text"
              name="segundo_apellido"
              value={this.state.segundo_apellido}
              onChange={this.handleChange}
            />
          </div>
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
            <label htmlFor="fecha_nacimiento">Fecha de nacimiento:</label>
            <input
              type="date"
              name="fecha_nacimiento"
              value={this.state.fecha_nacimiento}
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
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="telefono">Teléfono:</label>
            <input
              type="tel"
              name="telefono"
              value={this.state.telefono}
              onChange={this.handleChange}
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="patologia_nombre">Nombre de patología:</label>
            <input
              type="text"
              name="patologia_nombre"
              value={this.state.patologia_nombre}
              onChange={this.handleChange}
              required
            />
          </div>
          <div className="form-input">
            <label htmlFor="patologia_tratamiento">Tratamiento de patología:</label>
            <input
              type="text"
              name="patologia_tratamiento"
              value={this.state.patologia_tratamiento}
              onChange={this.handleChange}
              required
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
            }}>Agregar paciente</button>
            </div>

      </Form>
    </div>
            );
    }
}
export default NuevoPacienteFormulario;