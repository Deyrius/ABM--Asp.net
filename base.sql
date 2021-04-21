USE [master]
GO
/****** Object:  Database [poo]    Script Date: 12/12/2020 01:53:01 ******/
CREATE DATABASE [poo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'poo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\poo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'poo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\poo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [poo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [poo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [poo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [poo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [poo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [poo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [poo] SET ARITHABORT OFF 
GO
ALTER DATABASE [poo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [poo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [poo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [poo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [poo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [poo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [poo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [poo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [poo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [poo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [poo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [poo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [poo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [poo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [poo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [poo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [poo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [poo] SET RECOVERY FULL 
GO
ALTER DATABASE [poo] SET  MULTI_USER 
GO
ALTER DATABASE [poo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [poo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [poo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [poo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [poo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'poo', N'ON'
GO
ALTER DATABASE [poo] SET QUERY_STORE = OFF
GO
USE [poo]
GO
/****** Object:  Table [dbo].[participantes]    Script Date: 12/12/2020 01:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NOT NULL,
	[apellido] [nchar](10) NOT NULL,
	[puntaje] [int] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [poo] SET  READ_WRITE 
GO
