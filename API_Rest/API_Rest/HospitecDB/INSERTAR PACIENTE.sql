/DATOS PACIENTE/
INSERT INTO Paciente(Nombre, Apellidos, Cedula, FechaNacimiento)
VALUES('paciente1', 'primerapellido1 segundoapellido1', '123456789', '9999-99-99');

/DIRECCIONES DEL PACIENTE/
INSERT INTO Direcciones(Cedula, Descripcion)
VALUES('123456789', '100m este del blah, blah');
INSERT INTO Direcciones(Cedula, Descripcion)
VALUES('123456789', '500m blah');

/PATOLOGIAS DEL PACIENTE/
INSERT INTO PacientePatologia(Cedula, Id_pat)
VALUES('123456789', 2);

/TRATAMIENTO QUE TOMA EL PACIENTE PARA CIERTA Patologia/
INSERT INTO PacienteTratamiento(Cedula, Id_trat, Id_pat)
VALUES('123456789', 1, 2);