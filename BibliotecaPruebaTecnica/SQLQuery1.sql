CREATE DATABASE biblioteca;
GO
USE biblioteca;
GO
CREATE TABLE Autores (
    AutorID INT PRIMARY KEY IDENTITY(1,1),  
    Nombre NVARCHAR(255) NOT NULL            
);
GO
CREATE TABLE Libros (
    ID INT PRIMARY KEY IDENTITY(1,1),        
    Titulo NVARCHAR(255) NOT NULL,           
    AutorID INT,                             
    CONSTRAINT FK_Libros_Autores FOREIGN KEY (AutorID) REFERENCES Autores(AutorID) 
);
GO