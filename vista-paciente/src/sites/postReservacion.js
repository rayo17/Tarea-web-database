import React, { Component } from 'react'
import axios from 'axios'

class PostReservacion extends Component {
    constructor(props) {
        super(props)

        this.state = {
            id: '',
            paciente: '',
            fecha: '',
            procedimiento: ''
        }
    }   

    changeHandler = (e) => {
        this.setState({[e.target.name]: e.target.value})
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post('http://localhost:5004/api/reservacion', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

  
  render() {
    const { id, paciente, fecha, procedimiento } = this.state
    return (
      <div>
        <h2>Agregar reservacion</h2>
        <br></br>
        <form onSubmit={this.submitHandler}>
            <div>
                <label>Id</label>
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
                <label>Procedimiento:</label>
                <br></br>
                <input 
                    type="text" 
                    name="procedimiento" 
                    value={procedimiento}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <button type="submit">Agregar</button>
        </form>
      </div>
    )
  }
}

export default PostReservacion