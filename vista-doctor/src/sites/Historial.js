import React, { Component } from 'react'
//import axios from 'axios'
import Historiales from './funcionHistorial'


class Historial extends Component {
  constructor(props) {
    super(props)
  
    this.state = {
       posts: []
    }
  }
  

  render() {
    const { posts, errorMsg } = this.state

    return (
      <div>
        <h1>Pacientes</h1>
        <div><Historiales/></div>
      </div>
    )
  }
}

export default Historial