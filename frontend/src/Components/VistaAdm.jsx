import React from 'react'
import Gestion from './Gestion'
import Menu from './Menu'
import '../style/vistaAdm.css'

function VistaAdm () {
  return (
    <div className='container-big'>
      <div className="barra-nav">
        <Menu />
      </div>
      <div className='info'>
          1
      </div>
      <div className="container_class">
        <Gestion imagen='https://cdn0.iconfinder.com/data/icons/covid-19-14/64/Bed_hospital_medical_patient_icon-256.png' titulo="Gestion de camas" text="fwfwefeoi"/>
        <Gestion
          imagen='https://cdn0.iconfinder.com/data/icons/medical-checkup-2/512/MedicalCheckup_Patient-Information-medical-hospital-64.png'
          text="Gestion de Salones"
          titulo="Gestion de Salones"
        />
        <Gestion titulo="Procedimiento medico" text="fwojfwoefwn" imagen='https://cdn1.iconfinder.com/data/icons/medical-2-19/512/medical-healthcare-hospital-01-512.png'/>
        <Gestion titulo="Gestion Equipo medico" text="sfjwofw" imagen="https://cdn3.iconfinder.com/data/icons/virus-transmission-color/48/Crowd_Patient-64.png" />
        <Gestion titulo="Gestion Personal" text="fwefwef" imagen="https://cdn2.iconfinder.com/data/icons/covid-19-1/64/30-Doctor-64.png" />
      </div>
    </div>
  )
}
export default VistaAdm
