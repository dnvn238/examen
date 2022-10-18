--  Se deben crear 3 usuarios (2 alumnos, 1 docentes).
--  Se deben crear 4 libros.

INSERT INTO Usuario(Nombres,Apellidos,Dni,Email,Telefono,Estado,TipoUsuario) VALUES ('Jhon','Smith','Jhon.smith@gmail.com','987456321',1,'alumno');
INSERT INTO Usuario(Nombres,Apellidos,Dni,Email,Telefono,Estado,TipoUsuario) VALUES ('William','Smith','William.smith@gmail.com','987456321',1,'alumno');
INSERT INTO Usuario(Nombres,Apellidos,Dni,Email,Telefono,Estado,TipoUsuario) VALUES ('Emily','Brown','Emily.Brown@gmail.com','987456321',1,'docente');

INSERT INTO Libro(ISBN,Nombre,Categoria,Autor,Pais,FechaPublicacion,Editorial) VALUES ('123456789','Machine Learning','Informatica','Sarah','US','10-10-2019','Oreilly');
INSERT INTO Libro(ISBN,Nombre,Categoria,Autor,Pais,FechaPublicacion,Editorial) VALUES ('123456789','Big Data','Informatica','Emma','US','30-12-2021','Oreilly');
INSERT INTO Libro(ISBN,Nombre,Categoria,Autor,Pais,FechaPublicacion,Editorial) VALUES ('123456789','Redes Neuronales','Informatica','Adam','US','25-10-2022','Oreilly');
INSERT INTO Libro(ISBN,Nombre,Categoria,Autor,Pais,FechaPublicacion,Editorial) VALUES ('123456789','IA','Informatica','Ashley','US','29-10-2019','Oreilly');
COMMIT;