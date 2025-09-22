-- Tabla de Roles
CREATE TABLE Roles
(
  id_rol INT NOT NULL CONSTRAINT PK_Roles PRIMARY KEY,
  nombre_rol VARCHAR(30) NOT NULL,
  CONSTRAINT CK_Roles CHECK (id_rol IN (1,2,3)) -- Solo 3 roles
);
INSERT INTO Roles (id_rol, nombre_rol) VALUES (1,'Administrador');
INSERT INTO Roles (id_rol, nombre_rol) VALUES (2,'Canchero');
INSERT INTO Roles (id_rol, nombre_rol) VALUES (3,'Fiscal');
-- Tabla de Usuarios
CREATE TABLE Usuarios
(
  id_usuario INT NOT NULL CONSTRAINT PK_Usuarios PRIMARY KEY IDENTITY (1,1),
  nombre_usuario VARCHAR(30) NOT NULL,
  contraseña VARCHAR(30) NOT NULL,
  estado CHAR(1) NOT NULL 
      CONSTRAINT CK_Usuarios_Estado CHECK (estado IN ('A','I'))  -- A=Activo  I=Inactivo
);

-- Usuarios - Roles
CREATE TABLE Usuarios_Roles
(
  id_rol INT NOT NULL,--1=admin 2=canchero 3=fiscal
  id_usuario INT NOT NULL,
  CONSTRAINT PK_Usuarios_Roles PRIMARY KEY (id_rol, id_usuario),
  CONSTRAINT FK_Usuarios_Roles_Roles FOREIGN KEY (id_rol) REFERENCES Roles(id_rol),
  CONSTRAINT FK_Usuarios_Roles_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);

-- Tabla Categoría
CREATE TABLE Categoria
(
  id_categoria INT NOT NULL CONSTRAINT PK_Categoria PRIMARY KEY,
  nombre_cat VARCHAR(30) NOT NULL
);

-- Tabla Jugador
CREATE TABLE Jugador
(
  id_jugador INT NOT NULL CONSTRAINT PK_Jugador PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  id_categoria INT NOT NULL,
  CONSTRAINT FK_Jugador_Categoria FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
);

-- Tabla Parejas (dos jugadores por pareja)
CREATE TABLE Parejas
(
  id_pareja INT NOT NULL CONSTRAINT PK_Parejas PRIMARY KEY IDENTITY (1,1),
  id_jugador1 INT NOT NULL,
  id_jugador2 INT NOT NULL,
  CONSTRAINT FK_Parejas_Jugador1 FOREIGN KEY (id_jugador1) REFERENCES Jugador(id_jugador),
  CONSTRAINT FK_Parejas_Jugador2 FOREIGN KEY (id_jugador2) REFERENCES Jugador(id_jugador),
  CONSTRAINT CK_Parejas_Jugadores CHECK (id_jugador1 <> id_jugador2)  -- no pueden ser la misma persona
);

-- Tabla Torneos (con un canchero y un fiscal)
CREATE TABLE Torneos
(
  id_torneo INT NOT NULL CONSTRAINT PK_Torneos PRIMARY KEY IDENTITY (1,1),
  nombre_torneo VARCHAR(100) NOT NULL,
  fecha DATE NOT NULL CONSTRAINT DF_Torneos_Fecha DEFAULT (GETDATE()),
  id_categoria INT NOT NULL,
  id_canchero INT NOT NULL, 
  id_fiscal INT NOT NULL, 
  CONSTRAINT FK_Torneos_Categoria FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria),
  CONSTRAINT FK_Torneos_Canchero FOREIGN KEY (id_canchero) REFERENCES Usuarios(id_usuario),
  CONSTRAINT FK_Torneos_Fiscal FOREIGN KEY (id_fiscal) REFERENCES Usuarios(id_usuario)
);

-- Tabla Inscripción
CREATE TABLE Inscripcion
(
  id_inscripcion INT NOT NULL CONSTRAINT PK_Inscripcion PRIMARY KEY IDENTITY (1,1),
  estado_validacion VARCHAR(20) NOT NULL 
      CONSTRAINT CK_Inscripcion_Estado CHECK (estado_validacion IN ('Pendiente','Validado','Rechazado')),
  id_pareja INT NOT NULL,
  id_torneo INT NOT NULL,
  CONSTRAINT FK_Inscripcion_Parejas FOREIGN KEY (id_pareja) REFERENCES Parejas(id_pareja),
  CONSTRAINT FK_Inscripcion_Torneos FOREIGN KEY (id_torneo) REFERENCES Torneos(id_torneo)
);
insert into Usuarios(nombre_usuario,contraseña,estado) values ('Pablo', 1234, 'A')
insert into Usuarios(nombre_usuario,contraseña,estado) values ('Roberto', 1234, 'A')
insert into Usuarios(nombre_usuario,contraseña,estado) values ('Roxana', 1234, 'A')

insert into Usuarios_Roles(id_rol,id_usuario) values (1,1)
insert into Usuarios_Roles(id_rol,id_usuario) values (2,2)
insert into Usuarios_Roles(id_rol,id_usuario) values (3,3)





ALTER TABLE Usuarios
ADD id_rol INT NULL;
GO  

UPDATE u
SET u.id_rol = ur.id_rol
FROM Usuarios u
INNER JOIN Usuarios_Roles ur ON u.id_usuario = ur.id_usuario;
GO  

ALTER TABLE Usuarios
ALTER COLUMN id_rol INT NOT NULL;
GO

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Rol
FOREIGN KEY (id_rol) REFERENCES Roles(id_rol);
GO


DROP TABLE Usuarios_Roles;
GO