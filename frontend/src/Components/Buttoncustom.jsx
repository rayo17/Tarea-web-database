import React from 'react'
import { Button } from 'react-bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import PropTypes from 'prop-types'
function Buttoncustom ({ name }) {
  return (
  <div><Button>{name}
  </Button></div>
  )
}
Buttoncustom.propTypes = {
  name: PropTypes.string.isRequired
}
export default Buttoncustom
