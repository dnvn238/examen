-- DROP TABLE PRESTAMO;
-- DROP TABLE LIBRO;
-- DROP TABLE USUARIO;
/**
* Estado (1-Habilitado, 0-Sancionado)
* Se deben crear 3 usuarios (2 alumnos, 1 docentes)
*/
CREATE TABLE Usuario (
    IdUsuario NUMBER GENERATED ALWAYS AS IDENTITY,
    Nombres  VARCHAR2(80) NOT NULL,
    Apellidos  VARCHAR2(80) NOT NULL,
    Dni  VARCHAR2(9) NOT NULL,
    Email  VARCHAR2(80) NOT NULL,
    Telefono  VARCHAR2(10) NOT NULL,
    Estado  number NOT NULL,
    TipoUsuario VARCHAR2(10) NOT NULL,

    CONSTRAINT PK_Usuario
    PRIMARY KEY(IdUsuario)
);

-- Se deben crear 4 libros.
CREATE TABLE Libro (
    IdLibro NUMBER GENERATED ALWAYS AS IDENTITY,
    ISBN VARCHAR2(10) NOT NULL,
    Nombre VARCHAR2(80) NOT NULL,
    Categoria VARCHAR2(80) NOT NULL,
    Autor VARCHAR2(80) NOT NULL,
    Pais VARCHAR2(80) NOT NULL,
    FechaPublicacion DATE DEFAULT sysdate NOT NULL, 
    Editorial VARCHAR2(80) NOT NULL,

    CONSTRAINT PK_Libro
    PRIMARY KEY(IdLibro)
);


/**
* TipoLectura:  biblioteca o casa
* Se puede realizar el préstamo como máximo de 3 libros.
* El reporte debe mostrar la totalidad de préstamos registrado
*/
CREATE TABLE Prestamo (
    IdPrestamo NUMBER GENERATED ALWAYS AS IDENTITY,
    IdLibro NUMBER NOT NULL,
    IdUsuario NUMBER NOT NULL,
    FechaPrestamo DATE DEFAULT sysdate NOT NULL, 
    FechaDevolucion DATE DEFAULT sysdate NOT NULL,
    TipoLectura VARCHAR2(30),

    CONSTRAINT PK_Prestamo
    PRIMARY KEY(IdPrestamo),

    CONSTRAINT FK_Prestamo_Usuario
    FOREIGN KEY (IdUsuario)
    REFERENCES Usuario(IdUsuario),

    CONSTRAINT FK_Prestamo_Libro
    FOREIGN KEY (IdLibro)
    REFERENCES Libro(IdLibro)
);

COMMIT;