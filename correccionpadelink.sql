-- 1. Agregar la columna id_rol en Usuarios
ALTER TABLE Usuarios
ADD id_rol INT NULL;
GO  -- <--- separador de lote

-- 2. Rellenar id_rol con los datos de Usuarios_Roles
UPDATE u
SET u.id_rol = ur.id_rol
FROM Usuarios u
INNER JOIN Usuarios_Roles ur ON u.id_usuario = ur.id_usuario;
GO  -- <--- separador de lote

-- 3. Hacer que id_rol sea NOT NULL y crear la FK
ALTER TABLE Usuarios
ALTER COLUMN id_rol INT NOT NULL;
GO

ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Rol
FOREIGN KEY (id_rol) REFERENCES Roles(id_rol);
GO

-- 4. (Opcional) Borrar la tabla intermedia
DROP TABLE Usuarios_Roles;
GO
