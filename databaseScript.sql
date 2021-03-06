USE [master]
GO
/****** Object:  Database [Eventter]    Script Date: 17/05/2019 4:33:27 p. m. ******/
CREATE DATABASE [Eventter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Eventter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.LOCALDB\MSSQL\DATA\NORTHWND.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Eventter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.LOCALDB\MSSQL\DATA\NORTHWND_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Eventter] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Eventter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Eventter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Eventter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Eventter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Eventter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Eventter] SET ARITHABORT OFF 
GO
ALTER DATABASE [Eventter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Eventter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Eventter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Eventter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Eventter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Eventter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Eventter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Eventter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Eventter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Eventter] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Eventter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Eventter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Eventter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Eventter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Eventter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Eventter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Eventter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Eventter] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Eventter] SET  MULTI_USER 
GO
ALTER DATABASE [Eventter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Eventter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Eventter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Eventter] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Eventter] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Eventter] SET QUERY_STORE = OFF
GO
USE [Eventter]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Eventter]
GO
/****** Object:  UserDefinedFunction [dbo].[GETFullName]    Script Date: 17/05/2019 4:33:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GETFullName] (@PersonalId uniqueidentifier)         
    RETURNS VARCHAR(500)
	AS BEGIN
    DECLARE @fullname VARCHAR(500)

    set @fullname = (select name + ' ' + lastname from dbo.Personal 
	where  PersonalId = @PersonalId);

    RETURN @fullname
END
GO
/****** Object:  Table [dbo].[Event]    Script Date: 17/05/2019 4:33:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [uniqueidentifier] NOT NULL,
	[PersonalId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[EventDate] [datetime] NOT NULL,
	[IsPrivate] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 17/05/2019 4:33:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[PersonalId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](256) NULL,
	[IsDeleted] [bit] NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[PersonalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Personal1] FOREIGN KEY([PersonalId])
REFERENCES [dbo].[Personal] ([PersonalId])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Personal1]
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Event]    Script Date: 17/05/2019 4:33:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsert_Event]
	@EventId uniqueidentifier, 
    @PersonalId uniqueidentifier,
	@Name nvarchar(200),
	@Description nvarchar(max),
	@EventDate datetime,
	@IsPrivate bit,	
	@Status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

EXEC sp_rename 'Eventter.Personal.Phone', 'Movil', 'COLUMN';  

INSERT INTO [dbo].[Event]
           ([EventId]
           ,[PersonalId]
           ,[Name]
           ,[Description]
           ,[EventDate]
           ,[IsPrivate]
           ,[Status])
     VALUES
           (@EventId
           ,@PersonalId
           ,@Name
           ,@Description 
		   ,@EventDate
		   ,@IsPrivate   
		   ,@Status)

END
GO
USE [master]
GO
ALTER DATABASE [Eventter] SET  READ_WRITE 
GO
