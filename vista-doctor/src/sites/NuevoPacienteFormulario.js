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
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
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

  render() {
    return (
      <div className="container" style={{maxWidth: "300px", margin: "0 auto", marginTop: "20px", textAlign: "center"}}>
      <Form onSubmit={this.handleSubmit}>
        <h2>Nuevo paciente</h2>
        <Form.Group>
          <Form.Label>Nombre:</Form.Label>
          <Form.Control
            type="text"
            name="nombre"
            value={this.state.nombre}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Primer apellido:</Form.Label>
          <Form.Control
            type="text"
            name="primer_apellido"
            value={this.state.primer_apellido}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Segundo apellido:</Form.Label>
          <Form.Control
            type="text"
            name="segundo_apellido"
            value={this.state.segundo_apellido}
            onChange={this.handleChange}
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Cédula:</Form.Label>
          <Form.Control
            type="text"
            name="cedula"
            value={this.state.cedula}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Fecha de nacimiento:</Form.Label>
          <Form.Control
            type="date"
            name="fecha_nacimiento"
            value={this.state.fecha_nacimiento}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Dirección:</Form.Label>
          <Form.Control
            type="text"
            name="direccion"
            value={this.state.direccion}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Teléfono:</Form.Label>
          <Form.Control
            type="tel"
            name="telefono"
            value={this.state.telefono}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Nombre de patología:</Form.Label>
          <Form.Control
            type="text"
            name="patologia_nombre"
            value={this.state.patologia_nombre}
            onChange={this.handleChange}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label>Tratamiento de patología:</Form.Label>
          <Form.Control
            type="text"
            name="patologia_tratamiento"
            value={this.state.patologia_tratamiento}
            onChange={this.handleChange}
            required
            />
            </Form.Group>
            <div style={{marginTop: "20px"}}>
              <Button type="submit" variant="primary" style={{display: "block", margin: "0 auto"}}>Agregar paciente</Button>
            </div>
      </Form>
    </div>
            );
    }
}
export default NuevoPacienteFormulario;