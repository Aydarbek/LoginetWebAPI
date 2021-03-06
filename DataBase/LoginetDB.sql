USE [LoginetDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.05.2019 13:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Albums]    Script Date: 16.05.2019 13:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AlbumName] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.05.2019 13:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](16) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](32) NOT NULL,
	[LastName] [nvarchar](32) NULL,
	[Occupation] [nvarchar](32) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190507120926_InitialDB', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190507175521_LoginetDBv2', N'2.1.8-servicing-32085')
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (1, 1, N'Peoples of Africa', N'description of the peoples inhabiting the African continent')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (2, 1, N'Animals of South America', N'overview of the fauna of the South American continent')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (3, 1, N'World Ocean', N'world ocean and its significance for the planet earth')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (4, 2, N'Bestsellers of 1980s', N'best novels written in the 80s')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (5, 2, N'Modern writers', N'portrait of a modern writer')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (6, 2, N'Golden age', N'golden age in literature')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (7, 3, N'Design Patterns', N'theory and practice of design patterns')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (8, 3, N'OOP', N'Objective-oriented programming')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (9, 3, N'ASP.NET Core', N'ASP.NET Core framework and its best practices')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (10, 4, N'Animal Trails', N'Photos of animal trails and with description')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (11, 4, N'Best photos', N'Best photos of nature')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (12, 4, N'Maps of Australia', N'Detailed maps of Australia')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (13, 5, N'SCRUM', N'SCRUM Metodology and its best practices')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (14, 5, N'Canban', N'Canban Metodology and its best practices')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (15, 5, N'Best cases', N'Interesting project management cases')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (16, 6, N'Black holes', N'Theory of black holes')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (17, 6, N'Saturn rings', N'results of observations of the rings of Saturn')
INSERT [dbo].[Albums] ([Id], [UserId], [AlbumName], [Description]) VALUES (18, 6, N'Best photos', N'Best space photos')
SET IDENTITY_INSERT [dbo].[Albums] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (1, N'jsmith', N'jsmiths@gmail.com', N'John', N'Smith', N'Geographer')
INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (2, N'alcarr', N'alcarr@gmail.com', N'Alex', N'Carr', N'Writer')
INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (3, N'zemelya777', N'dzemtsov@mail.ru', N'Dmitry', N'Zemtsov', N'Software Engineer')
INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (4, N'jango', N'jango@yahoo.com', N'Jango', N'', N'Pathfinder')
INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (5, N'zupab', N'zupabbb@gmail.com', N'Boris', N'Zupa', N'Project Manager')
INSERT [dbo].[Users] ([Id], [Account], [Email], [FirstName], [LastName], [Occupation]) VALUES (6, N'ivanivan', N'ivangalaxy@yandex.ru', N'Ivan', N'Ivanov', N'Astronomer')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Users_UserId]
GO
