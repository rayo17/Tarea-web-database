/*DATOS PACIENTE*/
INSERT INTO Paciente(Nombre, Primer_apellido, Segundo_apellido, Cedula, Fecha_nacimiento) 
VALUES("paciente1", "primerapellido1", "segundoapellido1", 123456789, "9999-99-99");

/*DIRECCIONES DEL PACIENTE*/
INSERT INTO Direcciones_paciente(Cedula_paci, Descripcion)
VALUES(123456789, "100m este del blah, blah");
INSERT INTO Direcciones_paciente(Cedula_paci, Descripcion)
VALUES(123456789, "500m blah");

/*PATOLOGIAS DEL PACIENTE*/
INSERT INTO Paci_tiene_pat(Cedula_paci, Id_pat) 
VALUES(123456789, 2);

/*TRATAMIENTO QUE TOMA EL PACIENTE PARA CIERTA Patologia*/
INSERT INTO Paciente_toma_para(Cedula_paci, Id_trat, Id_pat)
VALUES(123456789, 1, 2);