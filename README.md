# EmpresaProyectos
Tabla SQL:

CREATE DATABASE EmpresaProyectosDB;
GO

USE EmpresaProyectosDB;

CREATE TABLE Proyectos (
    Id INT PRIMARY KEY IDENTITY,     -- Identificador único del proyecto
    Nombre NVARCHAR(100),            -- Nombre del proyecto
    FechaInicio DATETIME,            -- Fecha de inicio del proyecto
    FechaFin DATETIME,               -- Fecha de finalización del proyecto
    Estado NVARCHAR(50)              -- Estado del proyecto (activo, completado, cancelado)
);
