USE [master]
GO
/****** Object:  Database [TrabajoCampo]    Script Date: 30/06/2018 17:30:32 ******/
CREATE DATABASE [TrabajoCampo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrabajoCampo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER2\MSSQL\DATA\TrabajoCampo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TrabajoCampo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER2\MSSQL\DATA\TrabajoCampo_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TrabajoCampo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrabajoCampo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrabajoCampo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrabajoCampo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrabajoCampo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrabajoCampo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrabajoCampo] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrabajoCampo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrabajoCampo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrabajoCampo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoCampo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrabajoCampo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrabajoCampo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrabajoCampo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrabajoCampo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrabajoCampo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrabajoCampo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrabajoCampo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrabajoCampo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrabajoCampo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrabajoCampo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrabajoCampo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrabajoCampo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrabajoCampo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrabajoCampo] SET RECOVERY FULL 
GO
ALTER DATABASE [TrabajoCampo] SET  MULTI_USER 
GO
ALTER DATABASE [TrabajoCampo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrabajoCampo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrabajoCampo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrabajoCampo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TrabajoCampo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TrabajoCampo]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Evento] [varchar](50) NOT NULL,
	[Mensaje] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIGITOVERTICAL]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DIGITOVERTICAL](
	[Id] [int] NOT NULL,
	[DigitoVerificador] [varchar](255) NOT NULL,
 CONSTRAINT [PK_DIGITOVERTICAL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[Id] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Pass] [varchar](255) NOT NULL,
	[DVH] [varchar](255) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ALTA_USUARIO]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ALTA_USUARIO]
@email varchar(100),@pass varchar(255),@DVH varchar(255)
as
begin
declare @id int
set @id = (select count(*) from USUARIO)
if @id>0
begin
set @id= (select max(Id) from USUARIO)
end
set @id+=1
insert into USUARIO(Id,Email,Pass,DVH)
values (@id,@email,@pass,@DVH)
end

GO
/****** Object:  StoredProcedure [dbo].[BITACORA_ALTA]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BITACORA_ALTA]
@email varchar(100), @fec datetime, @evento varchar(50), @mensaje varchar(100)
as
begin
declare @id int
set @id = (select count(*) from Bitacora)
if @id>0
begin
set @id=(select max(id) from Bitacora)
end
set @id+=1
insert into Bitacora(Id,Email,Fecha,Evento,Mensaje)
values(@id,@email,@fec,@evento,@mensaje)
end
GO
/****** Object:  StoredProcedure [dbo].[DIGITO_ACTUALIZAR]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DIGITO_ACTUALIZAR]
@DV varchar(255)
as
begin
update DIGITOVERTICAL set
DigitoVerificador=@DV
where Id=1
end
GO
/****** Object:  StoredProcedure [dbo].[DIGITO_LISTAR]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[DIGITO_LISTAR]
as
begin
select DigitoVerificador
from DIGITOVERTICAL
end
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_LISTAR]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[USUARIO_LISTAR]
as
begin
select Id,Email
from USUARIO
end
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_LISTARDIGITOS]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USUARIO_LISTARDIGITOS]
as
begin
select DVH
from USUARIO
end
GO
/****** Object:  StoredProcedure [dbo].[USUARIO_TRAERPASS]    Script Date: 30/06/2018 17:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[USUARIO_TRAERPASS]
@email varchar(100)
as
begin
select Pass
from USUARIO
where Email=@email
end
GO
USE [master]
GO
ALTER DATABASE [TrabajoCampo] SET  READ_WRITE 
GO
