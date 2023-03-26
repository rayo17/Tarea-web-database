import React, { Component } from 'react'
import axios from 'axios'

class DeleteReservacion extends Component {
    constructor(props) {
        super(props)

        this.state = {
            id: '',
            paciente: ''
        }
    }   

    changeHandler = (e) => {
        this.setState({[e.target.name]: e.target.value})
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.delete('http://localhost:5004/api/reservacion/'+this.state.paciente+'/'+this.state.id)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

  
  render() {
    const { id, paciente } = this.state
    return (
      <div>
        <h2>Editar historial</h2>
        <br></br>
        <form onSubmit={this.submitHandler}>
            <div>
                <label>Id:</label>
                <br></br>
                <input 
                    type="text"
                    
                    name="id" 
                    value={id}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
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
            <button type="submit">Eliminar</button>
        </form>
      </div>
    )
  }
}

export default DeleteReservacion