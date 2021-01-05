INSERT INTO Usuarios(Id,Nome, Email, Senha, Tipo)
VALUES (NEWID(), 'Nayane do carmo', 'nayane.docarmo02@gmail.com', '1234567', 'comum')

INSERT INTO Tarefas (Id,Titulo, Descricao, Categoria,DataEntrega, Status,Usuario_Id)
VALUES (NEWID(), 'Tarefa 1',' Descrição da Tarefa 1', 'Pessoal', '04-10-21 18:00:00', 0 , '4A370344-E108-4A57-967B-BBABC806CDA9')


SELECT * FROM Usuarios
SELECT * FROM Tarefas

--inner join  

SELECT
u.Id as Id_Usuarios,
u.Nome,
u.Email,
t.Id as Id_Tarefas,
t.Titulo,
t.Descricao,
t.Categoria,
t.Status,
t.DataEntrega
FROM Usuarios u
inner join Tarefas t on t.Usuario_Id = u.Id
WHERE u.id = '4A370344-E108-4A57-967B-BBABC806CDA9'