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

    PRIMARY KEY(Paciente, Ubicacion)
);

-- Telefonos del paciente
CREATE TABLE PACIENTE_TELEFONOS(
    Paciente VARCHAR(10) NOT NULL,
    Telefono INT NOT NULL,

    PRIMARY KEY(Paciente, Telefono)
);


-- Patologia
CREATE TABLE PATOLOGIA(
    Paciente VARCHAR(10) NOT NULL,
    --Id INT NOT NULL,
    Nombre VARCHAR(20) NOT NULL,
    Tratamiento VARCHAR(20) NOT NULL,

    PRIMARY KEY(Tratamiento)
);


-- Procedimiento
CREATE TABLE PROCEDIMIENTO_MEDICO(
    Paciente VARCHAR(10) NOT NULL,
    Nombre VARCHAR(20) NOT NULL,
    Fecha DATE NOT NULL,

    PRIMARY KEY(Nombre, Fecha)
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

    PRIMARY KEY(Id)
);


-- Historial clinico
CREATE TABLE HISTORIAL(
    Id int NOT NULL,
    Procedimiento VARCHAR (20) NOT NULL,
    Fecha DATE NOT NULL,
    Tratamiento VARCHAR (20),

    PRIMARY KEY(Id)
);





-- Paciente
ALTER TABLE PACIENTE_DIRECCIONES
    ADD FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula);
ALTER TABLE PACIENTE_TELEFONOS
    ADD FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula);

-- Patologia
ALTER TABLE PATOLOGIA
    ADD FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula);

-- Procedimiento
ALTER TABLE PROCEDIMIENTO_MEDICO
    ADD FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula);

-- Reservacion
ALTER TABLE RESERVACION
    ADD FOREIGN KEY (Paciente) REFERENCES PACIENTE(Cedula);
ALTER TABLE RESERVACION
    ADD FOREIGN KEY (Procedimiento, Fecha) REFERENCES PROCEDIMIENTO_MEDICO(Nombre, Fecha);

-- Historial
ALTER TABLE HISTORIAL
    ADD FOREIGN KEY (Procedimiento, Fecha) REFERENCES PROCEDIMIENTO_MEDICO(Nombre, Fecha);
ALTER TABLE HISTORIAL
    ADD FOREIGN KEY (Tratamiento) REFERENCES PATOLOGIA(Tratamiento);