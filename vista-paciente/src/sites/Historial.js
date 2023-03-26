import React, { Component, useState } from 'react'
import Historiales from './funcionHistorial'
import DialogAddHistorial from './dialogAddHistorial'
import DialogEditHistorial from './dialogEditHistorial'
import './Historial.css'


class Historial extends Component {
  constructor(props) {
    super(props)
  
    this.state = {
       posts: []
    }
  }
  

  render() {

    return (
      <div>
        <h1>Mi historial</h1>
        <Historiales/>
        
      </div>
    )
  }
}

export default Historial