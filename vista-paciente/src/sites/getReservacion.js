import React, { Component } from 'react'
import axios from 'axios'

class GetReservacion extends Component {
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
        axios.get('http://localhost:5004/api/reservacion/'+this.state.paciente)
            .then(response => {
                console.log(response.data)
                this.setState(response.data)
            })
            .catch(error => {
                console.log(error)
            })
    }
  
  
  render() {
    const { paciente } = this.state
    return (
      <div>
        <form onSubmit={this.submitHandler}>
            <div>
                <label>Tu cédula:</label>
                <br></br>
                <input 
                    type="text"
                    
                    name="paciente" 
                    value={paciente}
                    onChange={this.changeHandler}/>
            </div>
            <br></br>
            <button type="submit">Buscar</button>
        </form>
  
        <div className="container">
        <div className="py-4">
          <table className="table border shadow">
          <thead>
              <tr>
                <th>Id</th>
                <th>Paciente</th>
                <th>Fecha</th>
                <th>Procedimiento</th>
              </tr>
            </thead>
            <tbody>
                <td>{this.state.id}</td>
                <td>{this.state.paciente}</td>
                <td>{this.state.fecha}</td>
                <td>{this.state.procedimiento}</td>
            </tbody>
          </table>
        </div>
      </div>
    
      </div>
    )
  }
  }

export default GetReservacion