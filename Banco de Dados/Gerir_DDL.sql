CREATE TABLE Usuarios (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Nome VARCHAR(150) not null,
	Email VARCHAR(150) not null,
	Senha VARCHAR(150) not null,
	Tipo VARCHAR(150) not null)

	CREATE TABLE Tarefas (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(150) not null,
	Descricao TEXT not null,
	Categoria VARCHAR(150) not null,
	DataEntrega DATETIME not null,
	Status BIT,
	Usuario_Id UNIQUEIDENTIFIER FOREIGN KEY (Usuario_Id) REFERENCES Usuarios(Id) ON DELETE CASCADE)


