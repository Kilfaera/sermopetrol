-- Crear la base de datos y usarla
CREATE DATABASE ConsumoEmpleado;
USE ConsumoEmpleado;

-- Crear la tabla Empleado (sin columna Imagen)
CREATE TABLE Empleado (
    IdEmpleado INT AUTO_INCREMENT PRIMARY KEY,
    NumeroDocumento VARCHAR(25),
    NombreCompleto VARCHAR(30),
    ZonaDeTrabajo VARCHAR(20),
    NumeroConsumos INT,
    Estado BOOLEAN,
    FechaRegistro DATETIME
);

-- Crear la tabla Consumo con bit de registro
CREATE TABLE Consumo (
    IdConsumo INT AUTO_INCREMENT PRIMARY KEY,
    IdEmpleado INT,
    TipoConsumo VARCHAR(25),
    FechaRegistro DATETIME,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleado(IdEmpleado),
    Registro BIT
);

-- Crear tabla Configuraciones
CREATE TABLE Configuraciones (
    IdConfiguracion INT AUTO_INCREMENT PRIMARY KEY,
    UbicacionImagenes VARCHAR(255),
    UbicacionPDF VARCHAR(255),
    UbicacionPlantilla VARCHAR(255),
    UbicacionExcel VARCHAR(255),
    PermisoEliminacionRegistros BOOLEAN,
    UbicacionCopiasSeguridad VARCHAR(255),
    FechaModificacion DATETIME
);
-- Procedimiento almacenado para actualizar la tabla Configuraciones
DELIMITER $$
CREATE PROCEDURE ActualizarConfiguraciones(
    IN p_UbicacionImagenes VARCHAR(255),
    IN p_UbicacionPDF VARCHAR(255),
    IN p_UbicacionPlantilla VARCHAR(255),
    IN p_UbicacionExcel VARCHAR(255),
    IN p_PermisoEliminacionRegistros BOOLEAN,
    IN p_UbicacionCopiasSeguridad VARCHAR(255)
)
BEGIN
    UPDATE Configuraciones
    SET UbicacionImagenes = p_UbicacionImagenes,
        UbicacionPDF = p_UbicacionPDF,
        UbicacionPlantilla = p_UbicacionPlantilla,
        UbicacionExcel = p_UbicacionExcel,
        PermisoEliminacionRegistros = p_PermisoEliminacionRegistros,
        UbicacionCopiasSeguridad = p_UbicacionCopiasSeguridad,
        FechaModificacion = NOW()
    WHERE IdConfiguracion = 1; -- Asumiendo que solo hay un registro de configuración.
END$$
DELIMITER ;

-- Procedimiento almacenado: ObtenerConsumo
DELIMITER $$
CREATE PROCEDURE ObtenerConsumo()
BEGIN
    SELECT c.IdConsumo,
           e.NombreCompleto AS NombreEmpleado,
           e.NumeroDocumento AS DocumentoEmpleado,
           e.ZonaDeTrabajo AS ZonaTrabajoEmpleado,
           c.TipoConsumo,
           c.FechaRegistro,
           c.Registro
    FROM Consumo c
    JOIN Empleado e ON c.IdEmpleado = e.IdEmpleado;
END$$
DELIMITER;

-- Procedimiento almacenado: ObtenerConsumoCS
DELIMITER $$
CREATE PROCEDURE ObtenerConsumoCS()
BEGIN
    SELECT * FROM Consumo;
END$$
DELIMITER ;

-- Procedimiento almacenado: InsertarEmpleado (sin Imagen)
DELIMITER $$
CREATE PROCEDURE InsertarEmpleado(
    IN NumeroDocumento VARCHAR(25),
    IN NombreCompleto VARCHAR(30),
    IN ZonaDeTrabajo VARCHAR(20),
    IN NumeroConsumos INT,
    IN Estado BOOLEAN,
    IN FechaRegistro DATETIME
)
BEGIN
    INSERT INTO Empleado (NumeroDocumento, NombreCompleto, ZonaDeTrabajo, NumeroConsumos, Estado, FechaRegistro)
    VALUES (NumeroDocumento, NombreCompleto, ZonaDeTrabajo, NumeroConsumos, Estado, FechaRegistro);
END$$
DELIMITER ;

-- Procedimiento almacenado: InsertarConsumo (ahora incluye 'Registro')
DELIMITER $$
CREATE PROCEDURE InsertarConsumo(
    IN IdEmpleado INT,
    IN TipoConsumo VARCHAR(25)
    IN Registro VARCHAR(25)
)
BEGIN
    INSERT INTO Consumo (IdEmpleado, TipoConsumo, FechaRegistro, Registro)
    VALUES (IdEmpleado, TipoConsumo, NOW(), Registro);
END$$
DELIMITER ;

-- Procedimiento almacenado: AgregarConsumoCS (ahora incluye 'Registro')
DELIMITER $$
CREATE PROCEDURE AgregarConsumoCS(
    IN IdEmpleado INT,
    IN TipoConsumo VARCHAR(25),
    IN FechaRegistro DATETIME,
    IN Registro BIT
)
BEGIN
    INSERT INTO Consumo (IdEmpleado, TipoConsumo, FechaRegistro, Registro)
    VALUES (IdEmpleado, TipoConsumo, FechaRegistro, Registro);
END$$
DELIMITER ;

-- Procedimiento almacenado: ActualizarEmpleado (sin Imagen)
DELIMITER $$
CREATE PROCEDURE ActualizarEmpleado(
    IN IdEmpleado INT,
    IN NumeroDocumento VARCHAR(25),
    IN NombreCompleto VARCHAR(30),
    IN ZonaDeTrabajo VARCHAR(20)
)
BEGIN
    UPDATE Empleado
    SET NumeroDocumento = NumeroDocumento,
        NombreCompleto = NombreCompleto,
        ZonaDeTrabajo = ZonaDeTrabajo
    WHERE IdEmpleado = IdEmpleado;
END$$
DELIMITER ;

-- Procedimiento almacenado: ActualizarEmpleadoCS (sin Imagen)
DELIMITER $$
CREATE PROCEDURE ActualizarEmpleadoCS(
    IN IdEmpleado INT,
    IN NumeroDocumento VARCHAR(25),
    IN NombreCompleto VARCHAR(30),
    IN ZonaDeTrabajo VARCHAR(20),
    IN NumeroConsumos INT,
    IN Estado BOOLEAN,
    IN FechaRegistro DATETIME
)
BEGIN
    UPDATE Empleado
    SET NumeroDocumento = NumeroDocumento,
        NombreCompleto = NombreCompleto,
        ZonaDeTrabajo = ZonaDeTrabajo,
        NumeroConsumos = NumeroConsumos,
        Estado = Estado,
        FechaRegistro = FechaRegistro
    WHERE IdEmpleado = IdEmpleado;
END$$
DELIMITER ;

-- Procedimiento almacenado: IncrementarConsumo
DELIMITER $$
CREATE PROCEDURE IncrementarConsumo(
    IN IdEmpleado INT
)
BEGIN
    UPDATE Empleado
    SET NumeroConsumos = NumeroConsumos + 1
    WHERE IdEmpleado = IdEmpleado;
END$$
DELIMITER ;

-- Procedimiento almacenado: CambiarEstadoEmpleado
DELIMITER $$
CREATE PROCEDURE CambiarEstadoEmpleado(
    IN IdEmpleado INT,
    IN NuevoEstado BOOLEAN
)
BEGIN
    UPDATE Empleado
    SET Estado = NuevoEstado
    WHERE IdEmpleado = IdEmpleado;
END$$
DELIMITER ;