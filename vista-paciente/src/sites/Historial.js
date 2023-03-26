import React, { Component } from 'react'
import Historiales from './funcionHistorial'


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