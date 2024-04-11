CREATE TABLE public.persona (
	id serial NOT NULL,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL,
	cedula varchar(15) NOT NULL,
	fechanacimiento date NULL,
	correo varchar(100) NULL,
	estado varchar(10) NOT NULL,
	CONSTRAINT persona_pk PRIMARY KEY (id),
	CONSTRAINT persona_unique UNIQUE (nombre,cedula,apellido)
);
