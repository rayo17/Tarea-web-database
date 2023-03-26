import React, { Component } from 'react'
import axios from 'axios'

class DialogAddHistorial extends Component {
    constructor(props) {
        super(props)

        this.state = {
            paciente: '',
            procedimiento: '',
            fecha: '',
            tratamiento: '',
            showModal: false,

        }
    this.handleChange = this.handleChange.bind(this);
    this.handleOuterClick = this.handleOuterClick.bind(this);
    }   

    changeHandler = (e) => {
        this.setState({[e.target.name]: e.target.value})
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post('http://localhost:5004/api/historial', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
            this.props.onClose();

    }

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
      };
      handleOuterClick(event) {
        const dialog = document.querySelector('.dialog-add-historial');
        if (dialog && !dialog.contains(event.target.closest('.dialog-add-historial'))) {
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
    const { paciente, procedimiento, fecha, tratamiento } = this.state
    return (
        <div className="dialog-add-historial">
        <h2>Agregar historial</h2>
        <br></br>
        <form onSubmit={this.submitHandler}>
            <div>
                <label>Cédula paciente:</label>
                <br></br>
                <input 
                    type="text"
                    
                    name="paciente" 
                    value={paciente}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <div>
                <label>Procedimiento:</label>
                <br></br>
                <input 
                    type="text" 
                    name="procedimiento" 
                    value={procedimiento}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <div>
                <label>Fecha:</label>
                <br></br>
                <input 
                    type="text" 
                    name="fecha" 
                    value={fecha}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <div>
                <label>Tratamiento:</label>
                <br></br>
                <input 
                    type="text" 
                    name="tratamiento" 
                    value={tratamiento}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <button type="submit" className="button-minimalista">Agregar</button>
        </form>
      </div>
    )
  }
}

export default DialogAddHistorial