create database T_AutoPecas

use T_AutoPecas

CREATE TABLE Usuarios 
(
IdUsuario int primary key identity
,Email VarChar(255) not null unique 
,Senha varchar(255) not null
);

create table Fornecedores 
(
IdFornecedor int primary key identity 
,cnpj varchar (18) not null unique
,RazaoSocial varchar(255) not null
,NomeFantasia varchar(255) not null
,Endereco varchar(255) not null
,IdUsuario int foreign key references Usuarios (IdUsuario)
);

create table Pecas
(
idPeca int primary key identity
,CodigoDaPeca varchar(255) not null unique
,Descricao varchar (255) not null
,peso varchar (255) not null
,PrecoDeCusto varchar(255) not null
,idFornecedor int foreign key references Fornecedores (idFornecedor)
);

select * from Usuarios

alter table Usuarios add Permissao VarChar(255) 
--- Peças - código da peça (que o fornecedor define), descricao, peso, preço de custo, preço de venda e somente um fornecedor vinculado;