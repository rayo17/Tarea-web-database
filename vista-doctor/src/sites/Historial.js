import React, { Component, useState, setHistoriales  } from 'react'
import Historiales from './funcionHistorial'
import DialogAddHistorial from './dialogAddHistorial'
import DialogEditHistorial from './dialogEditHistorial'
import { CSSTransition } from 'react-transition-group';
import  './Historial.css'
import  Menu  from '../sites/Menu';
import axios from 'axios';


class Historial extends Component {
  constructor(props) {
    super(props)
  
    this.state = {
       posts: [],
       showDialog: false, // variable para mostrar/ocultar el diálogo para añadir información adicional a un paciente existente
       showtwoDialog: false, // variable para mostrar/ocultar el diálogo para añadir información adicional a un paciente existente
       showtwoForm: false, // variable para mostrar/ocultar el formulario para añadir información adicional a un paciente existente
    }
  }
  componentDidMount() {
    this.handleNewPatient();
  }
  handleNewPatient = () => {
    // Aquí se realiza la llamada al backend para obtener los datos y actualizar el estado de posts
    axios.get('http://localhost:5004/api/historial')
      .then(response => {
        this.setState({ posts: response.data })
      })
      .catch(error => {
        console.log(error)
      })
  }

 // función para alternar la visibilidad del formulario para añadir información adicional a un paciente existente
 toggletwoForm = () => {
  this.setState({ showtwoForm: !this.state.showtwoForm });
};

// función para alternar la visibilidad del diálogo para añadir información adicional a un paciente existente
toggletwoDialog = async () => {
  this.setState(prevState => ({ showtwoDialog: !prevState.showtwoDialog }));
};
// función para alternar la visibilidad del formulario para añadir información adicional a un paciente existente
toggleForm = async () => {
  this.setState({ showForm: !this.state.showForm });
};
// función para alternar la visibilidad del diálogo para añadir información adicional a un paciente existente
toggleDialog = async () => {
  this.setState(prevState => ({ showDialog: !prevState.showDialog }));
};
  

  render() {
    const{showtwoDialog, showDialog, posts} = this.state;

    return (
      <div>
      <Menu/>
        <h1>Historiales</h1>
        <Historiales/>
        <div className="row">
        </div>
        <button style={{ marginTop: '20px', padding: '10px 20px', borderRadius: '5px', backgroundColor: '#fff', color: '#007bff', border: '2px solid #007bff', cursor: 'pointer' }} 
      onClick={this.toggletwoDialog}>Agregar</button>
      {showtwoDialog && (
          <div
            style={{
              position: "fixed",
              top: 0,
              left: 0,
              width: "100%",
              height: "100%",
              background: "rgba(0, 0, 0, 0.5)", // fondo semitransparente
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              zIndex: 999 // asegurarse de que el diálogo esté por encima del resto del contenido
            }}
          >
            <div>
          <CSSTransition in={this.state.isOpen} classNames="dialog" timeout={500}>
          <div
            className="dialog"
            style={{
              backgroundColor: "#fff",
              padding: "20px",
              borderRadius: "5px",
              maxWidth: "80%",
              maxHeight: "80%",
              overflow: "auto",
              marginBottom: "5px",
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.5)", // sombra para dar profundidad
            }}
          >
            {/* contenido del diálogo */}
            <DialogAddHistorial
              onClose={this.toggletwoDialog}
            />
          </div>
        </CSSTransition>
          </div>
        </div>
        )}
        <button style={{ marginTop: '20px', padding: '10px 20px', borderRadius: '5px', backgroundColor: '#fff', color: '#007bff', border: '2px solid #007bff', cursor: 'pointer' }} 
      onClick={this.toggleDialog}>Editar</button>
      {showDialog && (
          <div
            style={{
              position: "fixed",
              top: 0,
              left: 0,
              width: "100%",
              height: "100%",
              background: "rgba(0, 0, 0, 0.5)", // fondo semitransparente
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              zIndex: 999 // asegurarse de que el diálogo esté por encima del resto del contenido
            }}
          >
            <div>
          <CSSTransition in={this.state.isOpen} classNames="dialog" timeout={500}>
          <div
            className="dialog"
            style={{
              backgroundColor: "#fff",
              padding: "20px",
              borderRadius: "5px",
              maxWidth: "80%",
              maxHeight: "80%",
              overflow: "auto",
              marginBottom: "5px",
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.5)", // sombra para dar profundidad
            }}
          >
            {/* contenido del diálogo */}
            <DialogEditHistorial
              onClose={this.toggleDialog}
              update = {this.handleNewPatient}
            />
          </div>
        </CSSTransition>
          </div>
        </div>
        )}
      </div>
    )
  }
}

export default Historial