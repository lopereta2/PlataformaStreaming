/*
CREATE DATABASE PlataformaStreamingDB
GO 
USE PlataformaStreamingDB;
GO

CREATE TABLE [Roles] (
	[IDRol] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,

	CONSTRAINT CHK_Nombre_Rol CHECK (Nombre IN ('Administrador', 'Soporte', 'Usuario', 'AdministradorPrueba', 'UsuarioPrueba'))
);

CREATE TABLE [Usuarios] (
	[IDUsuario] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,
	[Correo] NVARCHAR(254) NOT NULL UNIQUE,
	[ContraseñaHash] VARBINARY(64) NOT NULL,
	[FechaRegistro] SMALLDATETIME NOT NULL,
	[IDRol] INT NOT NULL REFERENCES [Roles]([IDRol]),
);

CREATE TABLE [PlanesSuscripcion] (
	[IDPlan] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,
	[Precio] DECIMAL(10, 2) NOT NULL,
	[ResolucionMaxima] NVARCHAR(10) NOT NULL,
	[PantallasSimultaneas] INT NOT NULL,

	CONSTRAINT CHK_Nombre_Plan CHECK (Nombre IN ('Básico', 'Estándar', 'Premium', 'PremiumPrueba')),
	CONSTRAINT CHK_Resolucion CHECK (ResolucionMaxima IN ('720p','1080p','4k'))
);

CREATE TABLE [PagosSuscripcion] (
	[IDPago] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Monto] DECIMAL(10, 2) NOT NULL,
	[FechaPago] SMALLDATETIME NOT NULL,
	[EstadoPago] NVARCHAR(50) NOT NULL DEFAULT 'Pendiente',
	[IDUsuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
	[IDPlanSuscripcion] INT NOT NULL REFERENCES [PlanesSuscripcion]([IDPlan]),

	CONSTRAINT CHK_Estado_Pago CHECK (EstadoPago IN ('Aprobado','Rechazado','Pendiente'))
);

CREATE TABLE [Perfiles] (
	[IDPerfil] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL,
	[AvatarURL] NVARCHAR(200) NOT NULL,
	[EsInfantil] BIT NOT NULL,
	[IDUsuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
);

CREATE TABLE [Generos] (
	[IDGenero] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,
);

CREATE TABLE [PeliculasSeries] (
	[IDContenido] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Titulo] NVARCHAR(200) NOT NULL,
	[Descripcion] NVARCHAR(1000) NOT NULL,
	[Tipo] NVARCHAR(200) NOT NULL,
	[AnioLanzamiento] INT NOT NULL,
	[ClasificacionEdad] NVARCHAR(5) NOT NULL,

	CONSTRAINT CHK_Tipo CHECK (Tipo IN ('Pelicula','Serie')),
	CONSTRAINT CHK_Clasificacion CHECK (ClasificacionEdad IN ('ALL','7+','10+', '13+', '16+', '18+'))
);

CREATE TABLE [ContenidoGeneros] (
	[IDContenidoGenero] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[IDGenero] INT NOT NULL REFERENCES [Generos]([IDGenero]),
);

CREATE TABLE [Temporadas] (
	[IDTemporada] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Numero] INT NOT NULL,
	[Titulo] NVARCHAR(200) NOT NULL,
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
);

CREATE TABLE [Episodios] (
	[IDEpisodio] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Numero] INT NOT NULL,
	[Titulo] NVARCHAR(200) NOT NULL,
	[Duracion] INT NOT NULL,
	[URLArchivoVideo] NVARCHAR(200) NOT NULL,
	[IDTemporada] INT NOT NULL REFERENCES [Temporadas]([IDTemporada]),
);

CREATE TABLE [Personas] (
	[IDPersona] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL,
	[Apellido] NVARCHAR(200) NOT NULL,
);

CREATE TABLE [ContenidoReparto] (
	[IDReparto] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[RolPersona] NVARCHAR(200) NOT NULL,
	[NombrePersonaje] NVARCHAR(200) NULL,
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[IDPersona] INT NOT NULL REFERENCES [Personas]([IDPersona]),

	CONSTRAINT CHK_Rol CHECK (RolPersona IN ('Actor','Director'))
);

CREATE TABLE [Idiomas] (
	[IDIdioma] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,
	[CodigoIso] NVARCHAR(15) NOT NULL UNIQUE,
);

CREATE TABLE [AudioSubtitulosContenido] (
	[IDConfig] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[TipoConfig] NVARCHAR(50) NOT NULL,
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[IDIdioma] INT NOT NULL REFERENCES [Idiomas]([IDIdioma]),

	CONSTRAINT CHK_TipoConfig CHECK (TipoConfig IN ('Audio','Subtitulos'))
);

CREATE TABLE [ServidoresCDN] (
	[ID_CDN] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NOT NULL UNIQUE,
	[EspacioGeografico] NVARCHAR(100) NOT NULL,
	[Estado] NVARCHAR(100) NOT NULL DEFAULT 'Activo',

	CONSTRAINT CHK_Servidor_Estado CHECK (Estado IN ('Activo','Apagado','Mantenimiento'))
);

CREATE TABLE [HistorialReproduccion] (
	[IDHistorial] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ProgresoSegundo] INT NOT NULL,
	[UltimaReproduccion] SMALLDATETIME NULL,
	[Completado] BIT NULL,
	[IDPerfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
	[IDEpisodio] INT NULL REFERENCES [Episodios]([IDEpisodio]),
);

CREATE TABLE [MiLista] (
	[IDLista] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	[IDPerfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),
);

CREATE TABLE [CalificacionesResenias] (
	[IDResenia] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Calificacion] INT NULL,
	[Comentario] NVARCHAR(1000) NULL,
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	[IDPerfil] INT NOT NULL REFERENCES [Perfiles]([IDPerfil]),
	[IDPeliculaSerie] INT NOT NULL REFERENCES [PeliculasSeries]([IDContenido]),

	CONSTRAINT CHK_Calificacion CHECK (Calificacion >= 1 AND Calificacion <= 5)
);

CREATE TABLE [DispositivosConectados] (
	[IDDispositivo] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] NVARCHAR(200) NULL,
	[Tipo] NVARCHAR(200) NOT NULL,
	[TokenSesion] NVARCHAR(2048) NOT NULL,
	[UltimoAcceso] SMALLDATETIME NOT NULL,
	[IDUsuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),
);

CREATE TABLE [TicketsSoporte] (
	[IDTicket] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Asunto] NVARCHAR(100) NOT NULL,
	[Descripcion] NVARCHAR(1000) NOT NULL,
	[Estado] NVARCHAR(100) NOT NULL DEFAULT 'En proceso',
	[Fecha] SMALLDATETIME NOT NULL,
	[IDUsuario] INT NOT NULL REFERENCES [Usuarios]([IDUsuario]),

	CONSTRAINT CHK_Ticket_Estado CHECK (Estado IN ('Abierto','En proceso','Resuelto'))
);
*/