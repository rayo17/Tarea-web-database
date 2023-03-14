/*paciente con cedula 123456789*/

/*ver procedimientos*/
SELECT 
    Procedimiento_medico.Nombre_proc,
    Paci_tiene_proc.Fecha
FROM Paciente
JOIN Paci_tiene_proc
    ON Paciente.Cedula = Paci_tiene_proc.Cedula
JOIN Procedimiento_medico
    ON Procedimiento_medico.Id = Paci_tiene_proc.Id_proc
WHERE Paciente.Cedula = 604560524;

