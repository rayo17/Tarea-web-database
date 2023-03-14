/*ver tratamientos*/
SELECT 
    Elementos_tratamiento.Medicamento,
    Elementos_tratamiento.Indicaciones
FROM PACIENTE
JOIN Paciente_toma_para
    ON Paciente.Cedula = Paciente_toma_para.Cedula_Paci
JOIN Elementos_tratamiento
    ON Elementos_tratamiento.Id = Paciente_toma_para.Id_trat
WHERE Paciente.Cedula = 604560524;