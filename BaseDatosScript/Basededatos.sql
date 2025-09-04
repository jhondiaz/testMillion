IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TestMillionDB')
BEGIN
    PRINT 'La base de datos TestMillionDB no existe. Creándola...';
    CREATE DATABASE [TestMillionDB];
END
ELSE
BEGIN
    PRINT 'La base de datos TestMillionDB ya existe.';
END;

-- Usar la base de datos
USE [TestMillionDB];

GO
ALTER TABLE [dbo].[PropertyImage] DROP CONSTRAINT [DF_PropertyImage_DataCreate]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [DF_Property_DataCreate]
GO
ALTER TABLE [dbo].[Owner] DROP CONSTRAINT [DF_Owner_DataCreate]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PropertyTrace]') AND type in (N'U'))
DROP TABLE [dbo].[PropertyTrace]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PropertyImage]') AND type in (N'U'))
DROP TABLE [dbo].[PropertyImage]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Property]') AND type in (N'U'))
DROP TABLE [dbo].[Property]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Owner]') AND type in (N'U'))
DROP TABLE [dbo].[Owner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Photo] [nvarchar](max) NULL,
	[Birthday] [datetime] NOT NULL,
	[DataCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Price] [numeric](18, 0) NOT NULL,
	[CodeInternal] [nvarchar](max) NOT NULL,
	[Year] [int] NOT NULL,
	[DataCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[File] [nvarchar](max) NULL,
	[Enabled] [bit] NULL,
	[DataCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_PropertyImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTrace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[DateSale] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[Tax] [decimal](18, 2) NULL,
	[DataCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_PropertyTrace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Owner] ADD  CONSTRAINT [DF_Owner_DataCreate]  DEFAULT (getdate()) FOR [DataCreate]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_DataCreate]  DEFAULT (getdate()) FOR [DataCreate]
GO
ALTER TABLE [dbo].[PropertyImage] ADD  CONSTRAINT [DF_PropertyImage_DataCreate]  DEFAULT (getdate()) FOR [DataCreate]
GO


