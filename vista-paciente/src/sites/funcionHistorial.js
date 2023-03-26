import React, { Component } from 'react'
import axios from 'axios'

class GetHistorial extends Component {
  constructor(props) {
      super(props)

      this.state = {
          paciente: '',
          procedimiento: '',
          fecha: '',
          tratamiento: ''
      }
  }   

  changeHandler = (e) => {
      this.setState({[e.target.name]: e.target.value})
  }

  submitHandler = e => {
      e.preventDefault()
      console.log(this.state)
      axios.get('http://localhost:5004/api/historial/'+this.state.paciente)
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
              <th>Paciente</th>
              <th>Procedimiento</th>
              <th>Fecha</th>
              <th>Tratamiento</th>
            </tr>
          </thead>
          <tbody>
                  <td>{this.state.paciente}</td>
                  <td>{this.state.procedimiento}</td>
                  <td>{this.state.fecha}</td>
                  <td>{this.state.tratamiento}</td>
          </tbody>
        </table>
      </div>
    </div>
  
    </div>
  )
}
}

export default GetHistorial