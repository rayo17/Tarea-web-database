-- Paciente
CREATE TABLE PACIENTE (
                          Cedula VARCHAR(10) NOT NULL,
                          Nombre VARCHAR(15) NOT NULL,
                          Primer_apellido VARCHAR (15) NOT NULL,
                          Segundo_apellido VARCHAR (15) NOT NULL,
                          Fecha_nacimiento DATE NOT NULL,

                          PRIMARY KEY(Cedula)
);

-- Direcciones del paciente
CREATE TABLE PACIENTE_DIRECCIONES(
                                     Paciente VARCHAR(10) NOT NULL,
                                     Ubicacion VARCHAR(50) NOT NULL,

                                     PRIMARY KEY(Paciente, Ubicacion),
                                     FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula)
);

-- Telefonos del paciente
CREATE TABLE PACIENTE_TELEFONOS(
                                   Paciente VARCHAR(10) NOT NULL,
                                   Telefono INT NOT NULL,

                                   PRIMARY KEY(Paciente, Telefono),
                                   FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula)
);


-- Patologia
CREATE TABLE PATOLOGIA(
                          Paciente VARCHAR(10) NOT NULL,
                          -- Id INT NOT NULL,
                          Nombre VARCHAR(20) NOT NULL,
                          Tratamiento VARCHAR(20) NOT NULL,

                          PRIMARY KEY(Tratamiento),
                          FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula)
);


-- Procedimiento
CREATE TABLE PROCEDIMIENTO_MEDICO(
                                     Id int NOT NULL,
                                     Nombre VARCHAR(20) NOT NULL,

                                     PRIMARY KEY(Id)
);




-- Cama
CREATE TABLE CAMA(
    Cantidad INT NOT NULL
);


-- Reservacion
CREATE TABLE RESERVACION(
                            Id int NOT NULL,
                            Paciente VARCHAR(10) NOT NULL,
                            Fecha DATE NOT NULL,
<<<<<<< HEAD
                            Id_Procedimiento VARCHAR (20) NOT NULL,
=======
                            Id_Procedimiento int NOT NULL,
>>>>>>> ff6b413adbc56db45a10e7c48f977836a33b8daf

                            PRIMARY KEY(Id),
                            FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula),
                            FOREIGN KEY (Id_Procedimiento) REFERENCES PROCEDIMIENTO_MEDICO(Id)
);




-- Historial clinico
CREATE TABLE HISTORIAL(
                          Id int NOT NULL, -- Cambiar por Varchar para que coincida con Cedula de paciente
                          Procedimiento VARCHAR (20) NOT NULL,
                          Fecha DATE NOT NULL,
                          Tratamiento VARCHAR (20),

                          PRIMARY KEY(Id),
                          FOREIGN KEY (Id) REFERENCES PACIENTE(Cedula),
                          FOREIGN KEY (Procedimiento) REFERENCES PROCEDIMIENTO_MEDICO(Nombre),
                          FOREIGN KEY (Fecha) REFERENCES RESERVACION(Fecha),
                          FOREIGN KEY (Tratamiento) REFERENCES PATOLOGIA(Tratamiento)
);





