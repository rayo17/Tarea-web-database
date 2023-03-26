import React, { Component } from 'react'
import GetReservacion from './getReservacion'
import PostReservacion from './postReservacion'
import PutReservacion from './putReservacion'
import DeleteReservacion from './deleteReservacion'

class Reservacion extends Component {
  constructor(props) {
    super(props)
  
    this.state = {
       posts: []
    }
  }
  

  render() {

    return (
      <div>
        <h1>Reservaciones</h1>
        <GetReservacion />
        <div className="row">
          <div className="col"> <PostReservacion/> </div>
          <div className="col"> <PutReservacion/> </div>
          <div className="col"> <DeleteReservacion/> </div>
        </div>
        
      </div>
    )
  }
}

export default Reservacion