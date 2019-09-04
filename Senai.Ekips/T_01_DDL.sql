CREATE DATABASE T_Ekips

USE T_Ekips

CREATE TABLE Usuarios
(
IdUsuario INT PRIMARY KEY IDENTITY
,Nome VARCHAR(255) NOT NULL
,Email VARCHAR(255) NOT NULL UNIQUE
,Senha VARCHAR(255) NOT NULL 
,Permissao VARCHAR(255) NOT NULL
)

CREATE TABLE Departamentos
(
IdDepartamento INT PRIMARY KEY IDENTITY
,Nome VARCHAR(255) NOT NULL
);
CREATE TABLE Cargos
(
IdCargo INT PRIMARY KEY IDENTITY
,Nome VARCHAR(255)
,Ativo BIT DEFAULT (1)
);
CREATE TABLE Funcionarios
(
Nome VARCHAR(255) NOT NULL
,DataNascimento DATE NOT NULL
,CPF VARCHAR(15) NOT NULL
,Salario VARCHAR (255) NOT NULL
,IdDepartamento INT FOREIGN KEY REFERENCES Departamentos (IdDepartamento)
,IdCargo INT FOREIGN KEY REFERENCES Cargos (IdCargo)
,IdUsuario INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
);
insert into Funcionarios ()

alter table Funcionarios add IdFuncionario INT PRIMARY KEY IDENTITY
SELECT * FROM funcionarios






