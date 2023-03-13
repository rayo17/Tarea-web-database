import React from 'react'
import Button from 'react-bootstrap/Button'
import Card from 'react-bootstrap/Card'
import 'bootstrap/dist/css/bootstrap.css'
import PropTypes from 'prop-types'
import '../style/Gestion.css'
function Gestion ({ imagen, titulo, text, direccion }) {
  return (
  <Card style={{ width: '10rem' }} className='card-style'>
      <Card.Img variant="top" src={imagen} className='imagen'/>
      <Card.Body>
        <Card.Title>{titulo}</Card.Title>
        <Card.Text>
            {text}
        </Card.Text>
        <Button variant="primary" href= { direccion }>acceder</Button>
      </Card.Body>
    </Card>
  )
}
Gestion.propTypes = {
  imagen: PropTypes.string.isRequired,
  titulo: PropTypes.string.isRequired,
  text: PropTypes.string.isRequired,
  className: PropTypes.string,
  direccion: PropTypes.string
}
export default Gestion
