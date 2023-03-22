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
                          --Id INT NOT NULL,
                          Nombre VARCHAR(20) NOT NULL,
                          Tratamiento VARCHAR(20) NOT NULL,

                          PRIMARY KEY(Tratamiento),
                          FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula)
);


-- Procedimiento
CREATE TABLE PROCEDIMIENTO_MEDICO(
                                     Paciente VARCHAR(10) NOT NULL,
                                     Nombre VARCHAR(20) NOT NULL,
                                     Fecha DATE NOT NULL,

                                     PRIMARY KEY(Nombre, Fecha),
                                     FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula)
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
                            Procedimiento VARCHAR (20) NOT NULL,

                            PRIMARY KEY(Id),
                            FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula),
                            FOREIGN KEY (Procedimiento, Fecha) REFERENCES PROCEDIMIENTO_MEDICO(Nombre, Fecha)
);


-- Historial clinico
CREATE TABLE HISTORIAL(
                          Id int NOT NULL, -- Cambiar por Varchar para que coincida con Cedula de paciente
                          Procedimiento VARCHAR (20) NOT NULL,
                          Fecha DATE NOT NULL,
                          Tratamiento VARCHAR (20),

                          PRIMARY KEY(Id),
                          FOREIGN KEY (Id) REFERENCES PACIENTE(Cedula),
                          FOREIGN KEY (Procedimiento, Fecha) REFERENCES PROCEDIMIENTO_MEDICO(Nombre, Fecha),
                          FOREIGN KEY (Tratamiento) REFERENCES PATOLOGIA(Tratamiento)
);





