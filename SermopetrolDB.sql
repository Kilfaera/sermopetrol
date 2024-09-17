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
      IN p_NumeroDocumento VARCHAR(25),
    IN p_NombreCompleto VARCHAR(30),
    IN p_ZonaDeTrabajo VARCHAR(20),
    IN p_NumeroConsumos INT,
    IN p_Estado BOOLEAN,
    IN p_FechaRegistro DATETIME
)
BEGIN
    INSERT INTO Empleado (NumeroDocumento, NombreCompleto, ZonaDeTrabajo, NumeroConsumos, Estado, FechaRegistro)
    VALUES (p_NumeroDocumento, p_NombreCompleto, p_ZonaDeTrabajo, p_NumeroConsumos, p_Estado, p_FechaRegistro);
END$$
DELIMITER ;

-- Procedimiento almacenado: InsertarConsumo (ahora incluye 'Registro')
DELIMITER $$
CREATE PROCEDURE InsertarConsumo(
    IN IdEmpleado INT,
    IN TipoConsumo VARCHAR(25),
    IN Registro bit
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

DELIMITER $$
CREATE PROCEDURE FiltrarConsumos(
    IN p_documentoynombre VARCHAR(50),
    IN p_zona VARCHAR(20),
    IN p_tipoConsumo VARCHAR(25),
    IN p_fechaDesde DATETIME,
    IN p_fechaHasta DATETIME
)
BEGIN
    SELECT c.IdConsumo,
           e.NombreCompleto AS NombreEmpleado,
           e.NumeroDocumento AS DocumentoEmpleado,
           e.ZonaDeTrabajo AS ZonaTrabajoEmpleado,
           c.TipoConsumo,
           c.FechaRegistro,
           c.Registro AS FormaRegistro
    FROM Consumo c
    JOIN Empleado e ON c.IdEmpleado = e.IdEmpleado
    WHERE (p_documentoynombre = '' OR e.NumeroDocumento = p_documentoynombre OR e.NombreCompleto LIKE CONCAT('%', p_documentoynombre, '%'))
      AND (p_zona = '' OR e.ZonaDeTrabajo = p_zona)
      AND (p_tipoConsumo = '' OR c.TipoConsumo = p_tipoConsumo)
      AND (c.FechaRegistro BETWEEN p_fechaDesde AND p_fechaHasta);
END$$
DELIMITER ;


-- Procedimiento almacenado: ActualizarEmpleado (sin Imagen)
DELIMITER $$
CREATE PROCEDURE ActualizarEmpleado(
    IN p_IdEmpleado INT,
    IN p_NumeroDocumento VARCHAR(25),
    IN p_NombreCompleto VARCHAR(30),
    IN p_ZonaDeTrabajo VARCHAR(20)
)
BEGIN
    UPDATE Empleado
    SET NumeroDocumento = p_NumeroDocumento,
        NombreCompleto = p_NombreCompleto,
        ZonaDeTrabajo = p_ZonaDeTrabajo
    WHERE IdEmpleado = p_IdEmpleado;
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
    SET NumeroDocumento = p_NumeroDocumento,
        NombreCompleto = p_NombreCompleto,
        ZonaDeTrabajo = p_ZonaDeTrabajo,
        NumeroConsumos = p_NumeroConsumos,
        Estado = p_Estado,
        FechaRegistro = p_FechaRegistro
    WHERE IdEmpleado = p_IdEmpleado;
END$$
DELIMITER ;

-- Procedimiento almacenado: IncrementarConsumo
DELIMITER $$
CREATE PROCEDURE IncrementarConsumo(
    IN p_IdEmpleado INT
)
BEGIN
    UPDATE Empleado
    SET NumeroConsumos = NumeroConsumos + 1
    WHERE IdEmpleado = p_IdEmpleado;
END$$
DELIMITER ;

-- Procedimiento almacenado: CambiarEstadoEmpleado
DELIMITER $$
CREATE PROCEDURE CambiarEstadoEmpleado(
    IN p_IdEmpleado INT,
    IN NuevoEstado BOOLEAN
)
BEGIN
    UPDATE Empleado
    SET Estado = NuevoEstado
    WHERE IdEmpleado = p_IdEmpleado;
END$$
DELIMITER ;
INSERT INTO Configuraciones (
    UbicacionImagenes, 
    UbicacionPDF, 
    UbicacionPlantilla, 
    UbicacionExcel, 
    PermisoEliminacionRegistros, 
    UbicacionCopiasSeguridad, 
    FechaModificacion
) 
VALUES (
    'C:/',         -- Ubicación de las imágenes
    'C:/',           -- Ubicación de los archivos PDF
    'C:/',      -- Ubicación de las plantillas
    'C:/',         -- Ubicación de los archivos Excel
    FALSE,                                              -- Permiso para eliminación de registros (TRUE/FALSE)
    'C:/',                      -- Ubicación de las copias de seguridad
    NOW()                                              -- Fecha de modificación actual
);