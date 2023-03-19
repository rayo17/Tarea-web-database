import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import { Navbar } from './Navbar'
import Paciente from './sites/Paciente';
import Historial from './sites/Historial';
import Principal from './sites/Principal';


function App() {
  return (
    <div className="App">
      <Router>
        <Navbar/>
        

          <Routes>
            <Route path='/' element={ <Principal/> }/>
            <Route path='/Paciente' element={ <Paciente/> }/>
            <Route path='/Historial' element={ <Historial/> }/>
          </Routes>
      </Router>
      
    </div>
  );
}

export default App;