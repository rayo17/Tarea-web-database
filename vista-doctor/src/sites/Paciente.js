import React, { Component } from 'react'
import axios from 'axios'
import Pacientes from './funcion'

class Paciente extends Component {
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
        <div><Pacientes/></div>
        {
          posts.length ?
          posts.map(post => <div key={post.id}>{post.id} {post.title} </div>) :
          null
        }
        {
          errorMsg ?
          <div>{errorMsg}</div> :
          null
        }
      </div>
    )
  }
}

export default Paciente