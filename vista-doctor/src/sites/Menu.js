import React from 'react'
import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import NavDropdown from 'react-bootstrap/NavDropdown'
function Menu () {
  return (
    <Navbar bg="light" expand="lg">
      <a href='/'>
        {' '}
        <img
          src="https://cdn0.iconfinder.com/data/icons/medical-health-care-6/256/5-64.png"
          alt="f"
        />{' '}
      </a>
      <Container>
        <Navbar.Brand href="#home" className="space">
          Hospital
        </Navbar.Brand>
        <Navbar.Collapse id="basic-navbar-nav" className='space'>
          <Nav className="me-auto">
            <Nav.Link href="/Vistadoctor">Doctor</Nav.Link>
            <Nav.Link href="/Vistapaciente">Paciente</Nav.Link>
            <NavDropdown title="Gestion" id="basic-nav-dropdown">
              <NavDropdown.Item href="#action/3.">A</NavDropdown.Item>
              <NavDropdown.Item href="#action/3.2">r</NavDropdown.Item>
              <NavDropdown.Item href="#action/3.3"></NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">Doctor</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  )
}
export default Menu
