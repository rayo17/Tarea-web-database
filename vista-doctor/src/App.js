import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import { Navbar } from './Navbar'
import Paciente from './sites/Paciente';
import Historial from './sites/Historial';
import Principal from './sites/Principal';
import  Menu  from './sites/Menu';
import Vistapaciente from './sites/VistaPaciente';
import Agregar from './sites/component-vista-paciente/Agregar';
import Reservacion from './sites/component-vista-paciente/Reservacion';


function App() {
  return (
    <div className="App">
      <Router>
        <Navbar/>
        
          <Routes>
            <Route path='/' element={ <Menu/> }/>
            <Route path='/Reservacion' element={ <Reservacion />}/>
            <Route path='/Vistapaciente' element={ <Vistapaciente/> }/>
            <Route path='/Agregar' element={ <Agregar/> }/>
            <Route path='/principal' element={ <Principal/> }/>
            <Route path='/Paciente' element={ <Paciente/> }/>
            <Route path='/Historial' element={ <Historial/> }/>
          </Routes>
      </Router>
      
    </div>
  );
}

export default App;