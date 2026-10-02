CREATE DATABASE PlataformaStreamingDB
GO 
USE PlataformaStreamingDB;
GO

CREATE TABLE [Roles] (
	[IDRol] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,

	CONSTRAINT CHK_Nombre_Rol CHECK (Nombre IN ('Administrador','Soporte','Usuario'))
);

CREATE TABLE [Usuarios] (
	[IDUsuario] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	[Correo] NVARCHAR(254) NOT NULL UNIQUE,
	[ContraseñaHash] VARBINARY(64) NOT NULL,
	[FechaRegistro] SMALLDATETIME NOT NULL,
	[Rol] INT NOT NULL REFERENCES [Roles]([IDRol]),
);

USE PlataformaStreamingDB;

SELECT *
FROM Usuarios
WHERE Correo = 'Simon@gmail.com';

USE PlataformaStreamingDB;

DELETE FROM Usuarios
WHERE Correo = 'Simon@gmail.com';

CREATE TABLE [PlanesSuscripcion] (
	[IDPlan] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	[Precio] DECIMAL(10, 2) NOT NULL,
	[ResolucionMaxima] NVARCHAR(10) NOT NULL,
	[PantallasSimultaneas] INT NOT NULL,

	CONSTRAINT CHK_Nombre_Plan CHECK (Nombre IN ('Básico','Estándar','Premium')),
	CONSTRAINT CHK_Resolucion CHECK (ResolucionMaxima IN ('720p','1080p','4k'))
);

USE PlataformaStreamingDB;

DELETE FROM PlanesSuscripcion
WHERE Nombre = 'Premium';

CREATE TABLE [PagosSuscripcion] (
	[IDPago] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Monto] DECIMAL(10, 2) NOT NULL,
	[FechaPago] SMALLDATETIME NOT NULL,
	[EstadoPago] NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
	[Usuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
	[PlanSuscripcion] INT NOT NULL REFERENCES [PlanesSuscripcion]([IDPlan]),

	CONSTRAINT CHK_Estado_Pago CHECK (EstadoPago IN ('Aprobado','Rechazado','Pendiente'))
);

CREATE TABLE [Perfiles] (
	[IDPerfil] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[AvatarURL] NVARCHAR(200) NOT NULL,
	[EsInfantil] BIT NOT NULL,
	[Usuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
);

CREATE TABLE [Generos] (
	[IDGenero] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE [PeliculasSeries] (
	[IDContenido] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Titulo] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(1000) NOT NULL,
	[Tipo] NVARCHAR(50) NOT NULL,
	[AnioLanzamiento] INT NOT NULL,
	[ClasificacionEdad] NVARCHAR(5) NOT NULL,

	CONSTRAINT CHK_Tipo CHECK (Tipo IN ('Pelicula','Serie')),
	CONSTRAINT CHK_Clasificacion CHECK (ClasificacionEdad IN ('ALL','7+','10+', '13+', '16+', '18+'))
);

CREATE TABLE [ContenidoGeneros] (
	[IDContenidoGenero] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[Genero] INT NOT NULL REFERENCES [Generos]([IDGenero]),
);

CREATE TABLE [Temporadas] (
	[IDTemporada] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Numero] INT NOT NULL,
	[Titulo] NVARCHAR(200) NOT NULL,
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
);

CREATE TABLE [Episodios] (
	[IDEpisodio] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Numero] INT NOT NULL,
	[Titulo] NVARCHAR(200) NOT NULL,
	[Duracion] INT NOT NULL,
	[URLArchivoVideo] NVARCHAR(200) NOT NULL,
	[Temporada] INT NOT NULL REFERENCES [Temporadas]([IDTemporada]),
);

CREATE TABLE [Personas] (
	[IDPersona] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Apellido] NVARCHAR(50) NOT NULL,
);

CREATE TABLE [ContenidoReparto] (
	[IDReparto] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[RolPersona] NVARCHAR(50) NOT NULL,
	[NombrePersonaje] NVARCHAR(50) NULL,
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[Persona] INT NOT NULL REFERENCES [Personas]([IDPersona]),

	CONSTRAINT CHK_Rol CHECK (RolPersona IN ('Actor','Director'))
);

CREATE TABLE [Idiomas] (
	[IDIdioma] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	[CodigoIso] NVARCHAR(15) NOT NULL UNIQUE,
);

USE PlataformaStreamingDB;

SELECT *
FROM Idiomas
WHERE CodigoIso = 'ES';

DELETE FROM Idiomas
WHERE CodigoIso = 'ES';

CREATE TABLE [AudioSubtitulosContenido] (
	[IDConfig] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[TipoConfig] NVARCHAR(50) NOT NULL,
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[Idiomas] INT NOT NULL REFERENCES [Idiomas]([IDIdioma]),

	CONSTRAINT CHK_TipoConfig CHECK (TipoConfig IN ('Audio','Subtitulos'))
);

SELECT 
    COLUMN_NAME,
    DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'AudioSubtitulosContenido'
ORDER BY ORDINAL_POSITION;

CREATE TABLE [ServidoresCDN] (
	[ID_CDN] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	[EspacioGeografico] NVARCHAR(10) NOT NULL,
	[Estado] NVARCHAR(10) NOT NULL DEFAULT 'Activo',

	CONSTRAINT CHK_Servidor_Estado CHECK (Estado IN ('Activo','Apagado','Mantenimiento'))
);

USE PlataformaStreamingDB;
GO

DELETE FROM ServidoresCDN
WHERE Nombre = 'StreamingServer';

USE PlataformaStreamingDB;
GO

SELECT *
FROM ServidoresCDN
WHERE Nombre = 'StreamingServer';

ALTER TABLE ServidoresCDN
ALTER COLUMN EspacioGeografico NVARCHAR(100) NOT NULL;

ALTER TABLE ServidoresCDN
ALTER COLUMN Estado NVARCHAR(100) NOT NULL;

CREATE TABLE [HistorialReproduccion] (
	[IDHistorial] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ProgresoSegundo] INT NOT NULL,
	[UltimaReproduccion] SMALLDATETIME NULL,
	[Completado] BIT NULL,
	[Perfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[Episodio] INT NULL REFERENCES [Episodios]([IDEpisodio]),
);

CREATE TABLE [MiLista] (
	[IDLista] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	[Perfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
);

CREATE TABLE [CalificacionesResenias] (
	[IDResenia] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Calificacion] INT NULL,
	[Comentario] NVARCHAR(1000) NULL,
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	[Perfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[PeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),

	CONSTRAINT CHK_Calificacion CHECK (Calificacion >= 1 AND Calificacion <= 5)
);

CREATE TABLE [DispositivosConectados] (
	[IDDispositivo] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NULL,
	[Tipo] NVARCHAR(50) NOT NULL,
	[TokenSesion] NVARCHAR(2048) NOT NULL,
	[UltimoAcceso] SMALLDATETIME NOT NULL,
	[Usuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
);

CREATE TABLE [TicketsSoporte] (
	[IDTicket] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Asunto] NVARCHAR(100) NOT NULL,
	[Descripcion] NVARCHAR(1000) NOT NULL,
	[Estado] NVARCHAR(50) NOT NULL DEFAULT 'En proceso',
	[Fecha] SMALLDATETIME NOT NULL,
	[Usuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),

	CONSTRAINT CHK_Ticket_Estado CHECK (Estado IN ('Abierto','En proceso','Resuelto'))
);

USE PlataformaStreamingDB;
GO

SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = 'ContenidoGeneros';