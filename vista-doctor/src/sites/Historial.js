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
        <h1>Historiales</h1>
        <Historiales/>
        <div className="row">
          <div className="col"> <DialogAddHistorial /> </div>
          <div className="col"> <DialogEditHistorial /> </div>
        </div>
        
      </div>
    )
  }
}

export default Historial