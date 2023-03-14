import './App.css'
import React from 'react'
import 'react-bootstrap'
import VistaAdm from './Components/VistaAdm'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Salones from './Components/Salones'
import Menu from './Components/Menu'
import Formsalon from './Components/Formsalon'
function App () {
  return (
      <BrowserRouter>
      <Routes>
      <Route path='/' element={<Menu/>}/>
      <Route path='/vistaAdministrador' element={<VistaAdm/>}/>
      <Route path='/salones' element={<Salones/>}/>
      <Route path='/formsalon-crear' element={<Formsalon accion='crear'/>}/>
      </Routes>
      </BrowserRouter>

  )
}
export default App
