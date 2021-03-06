USE [master]
GO
/****** Object:  Database [Test]    Script Date: 16.8.2017 г. 15:34:57 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'E:\MSSQLServerData\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'E:\MSSQLServerData\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY FULL 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Test', N'ON'
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 16.8.2017 г. 15:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Color] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[OrderNo] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 16.8.2017 г. 15:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (1, N'Fruits                                                                                                                                                ', NULL, CAST(N'2010-01-01T00:00:00.000' AS DateTime), 0, 0, CAST(N'2017-08-16T08:11:31.717' AS DateTime), 25)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (2, N'Alcohol', N'good old booze', CAST(N'2007-08-09T00:00:00.000' AS DateTime), 2, 0, CAST(N'2017-08-16T12:22:12.297' AS DateTime), 2)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (20, N'Vegetables                                                                                                                                            ', NULL, CAST(N'2017-08-02T10:02:29.153' AS DateTime), 0, 0, CAST(N'2017-08-16T10:47:51.633' AS DateTime), 3)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (21, N'Toys                                                                                                                                                  ', NULL, CAST(N'2017-08-02T10:14:50.280' AS DateTime), 2, 1, CAST(N'2017-08-11T14:14:43.817' AS DateTime), 33)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (24, N'Computers                                                                                                                                             ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-02T10:18:40.593' AS DateTime), 1, 0, CAST(N'2017-08-16T10:47:45.327' AS DateTime), 1)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (25, N'Water', N'Essential', CAST(N'2017-08-02T10:19:56.897' AS DateTime), 0, 0, CAST(N'2017-08-16T11:56:51.940' AS DateTime), 24)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (30, N'Bread                                                                                                                                                 ', NULL, CAST(N'2015-08-02T00:00:00.000' AS DateTime), 0, 0, CAST(N'2017-08-11T14:14:45.643' AS DateTime), 30)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (31, N'Pastries                                                                                                                                              ', NULL, CAST(N'2017-08-03T10:37:56.697' AS DateTime), 1, 0, CAST(N'2017-08-16T10:47:51.617' AS DateTime), 20)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (32, N'Miscelaneous                                                                                                                                          ', NULL, CAST(N'2017-08-03T10:40:49.263' AS DateTime), 0, 1, CAST(N'2017-08-11T14:14:45.643' AS DateTime), 31)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (33, N'Some stuff                                                                                                                                            ', NULL, CAST(N'2017-08-03T14:30:05.793' AS DateTime), 1, 1, CAST(N'2017-08-16T09:23:55.560' AS DateTime), 32)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (34, N'Nova                                                                                                                                                  ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-11T14:17:34.697' AS DateTime), 0, 1, CAST(N'2017-08-11T14:17:34.727' AS DateTime), 34)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (35, N'nova                                                                                                                                                  ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-11T14:18:13.787' AS DateTime), 0, 1, CAST(N'2017-08-11T14:18:13.803' AS DateTime), 35)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (36, N'nova                                                                                                                                                  ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-11T14:19:36.413' AS DateTime), 0, 1, CAST(N'2017-08-11T14:19:36.447' AS DateTime), 36)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (37, N'drufjhgjgjg                                                                                                                                           ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-11T14:21:42.073' AS DateTime), 0, 1, CAST(N'2017-08-11T14:21:42.087' AS DateTime), 37)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [CreatedDate], [Color], [IsDeleted], [ModifiedDate], [OrderNo]) VALUES (38, N'Garden tools                                                                                                                                          ', N'                                                                                                                                                                                                                                                                                                            ', CAST(N'2017-08-16T09:23:47.167' AS DateTime), 0, 0, CAST(N'2017-08-16T09:23:55.560' AS DateTime), 38)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1, N'Bananas', CAST(2.70 AS Decimal(12, 2)), CAST(N'2015-07-08T00:00:00.000' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (2, N'Cherries', CAST(3.50 AS Decimal(12, 2)), CAST(N'2014-09-08T00:00:00.000' AS DateTime), 1, 0, CAST(N'2017-08-03T14:41:41.197' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (3, N'Oranges', CAST(2.20 AS Decimal(12, 2)), CAST(N'2016-08-07T00:00:00.000' AS DateTime), 1, 0, CAST(N'2017-08-11T14:33:52.237' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (4, N'Smirnoff', CAST(21.00 AS Decimal(12, 2)), CAST(N'2010-07-06T00:00:00.000' AS DateTime), 2, 0, CAST(N'2017-08-16T10:54:43.513' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (5, N'Flirt', CAST(9.00 AS Decimal(12, 2)), CAST(N'2012-07-06T00:00:00.000' AS DateTime), 2, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (6, N'Figs', CAST(7.50 AS Decimal(12, 2)), CAST(N'2017-08-01T13:13:47.450' AS DateTime), 1, 0, CAST(N'2017-08-01T13:14:13.897' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (7, N'Strawberries', CAST(6.00 AS Decimal(12, 2)), CAST(N'2017-08-01T13:14:07.767' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (11, N'Onion', CAST(0.90 AS Decimal(12, 2)), CAST(N'2017-08-02T10:02:51.490' AS DateTime), 20, 0, CAST(N'2017-08-02T10:03:00.063' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (12, N'Cucumber', CAST(2.20 AS Decimal(12, 2)), CAST(N'2017-08-02T10:04:06.170' AS DateTime), 20, 0, CAST(N'2017-08-02T10:04:21.173' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (13, N'Tomato', CAST(1.80 AS Decimal(12, 2)), CAST(N'2017-08-02T10:04:15.863' AS DateTime), 20, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (14, N'Bazooka', CAST(20.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:14:58.587' AS DateTime), 21, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (15, N'Samurai sword', CAST(17.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:15:09.553' AS DateTime), 21, 0, CAST(N'2017-08-11T12:54:00.280' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (16, N'Tank', CAST(55.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:15:25.337' AS DateTime), 21, 0, CAST(N'2017-08-11T12:53:52.747' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (17, N'Grandpa Frost', CAST(2.20 AS Decimal(12, 2)), CAST(N'2017-08-02T10:15:40.073' AS DateTime), 21, 0, CAST(N'2017-08-11T12:53:16.983' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (18, N'HP', CAST(3000.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:18:50.530' AS DateTime), 24, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (19, N'Dell', CAST(3000.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:18:56.753' AS DateTime), 24, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (20, N'Lenovo', CAST(2500.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:19:02.730' AS DateTime), 24, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (21, N'Mineral', CAST(2.00 AS Decimal(12, 2)), CAST(N'2017-08-02T10:20:08.450' AS DateTime), 25, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (22, N'Spring', CAST(1.80 AS Decimal(12, 2)), CAST(N'2017-08-02T10:20:32.057' AS DateTime), 25, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1014, N'Bananas', CAST(2.20 AS Decimal(12, 2)), CAST(N'2017-08-03T08:38:34.313' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1015, N'small stuff', CAST(4.00 AS Decimal(12, 2)), CAST(N'2017-08-03T14:30:18.897' AS DateTime), 33, 0, CAST(N'2017-08-11T13:25:51.857' AS DateTime))
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1016, N'Tomatoes', CAST(2.00 AS Decimal(12, 2)), CAST(N'2017-08-03T14:39:34.200' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1017, N'Tomatoes', CAST(2.00 AS Decimal(12, 2)), CAST(N'2017-08-03T14:39:43.537' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1018, N'Berries', CAST(5.00 AS Decimal(12, 2)), CAST(N'2017-08-03T14:41:19.787' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1019, N'Captain Morgan', CAST(20.00 AS Decimal(12, 2)), CAST(N'2017-08-16T08:33:35.823' AS DateTime), 2, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1020, N'Vodka Aheloy', CAST(5.00 AS Decimal(12, 2)), CAST(N'2017-08-16T12:19:32.003' AS DateTime), 2, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1021, N'Shovel', CAST(8.00 AS Decimal(12, 2)), CAST(N'2017-08-16T12:22:30.237' AS DateTime), 38, 0, NULL)
INSERT [dbo].[Products] ([ID], [Name], [Price], [CreatedDate], [CategoryID], [IsDeleted], [ModifiedDate]) VALUES (1022, N'Paprika', CAST(2.00 AS Decimal(12, 2)), CAST(N'2017-08-16T12:32:26.563' AS DateTime), 20, 0, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
/****** Object:  Index [IX_Categories_CreatedDate]    Script Date: 16.8.2017 г. 15:34:57 ******/
CREATE NONCLUSTERED INDEX [IX_Categories_CreatedDate] ON [dbo].[Categories]
(
	[CreatedDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 16.8.2017 г. 15:34:57 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CreatedDate]    Script Date: 16.8.2017 г. 15:34:57 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CreatedDate] ON [dbo].[Products]
(
	[CreatedDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [CK_Categories_Name] CHECK  (([Name]<>N''))
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [CK_Categories_Name]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Name] CHECK  (([Name]<>N''))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Name]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Price] CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Price]
GO
/****** Object:  StoredProcedure [dbo].[GetFilteredCategories]    Script Date: 16.8.2017 г. 15:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFilteredCategories](
	@itemsCount int = 5,
	@nameFilter nvarchar(150) = NULL)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    IF(@nameFilter IS NULL)
		SELECT TOP (@itemsCount) c.ID, c.[Name], c.Color, c.OrderNo, SUM(p.Price) AS [ProductsTotalPrice]  
		FROM Categories c
		LEFT OUTER JOIN Products p
		ON c.ID = p.CategoryID
		WHERE c.IsDeleted = 0
		GROUP BY c.ID, c.[Name], c.Color, c.OrderNo
	ELSE
		SELECT TOP (@itemsCount) c.ID, c.[Name], c.Color, c.OrderNo, SUM(p.Price) AS [ProductsTotalPrice]   
		FROM Categories c
		LEFT OUTER JOIN Products p
		ON c.ID = p.CategoryID
		WHERE c.IsDeleted = 0 AND c.[Name] = @nameFilter
		GROUP BY c.ID, c.[Name], c.Color, c.OrderNo
END




GO
/****** Object:  StoredProcedure [dbo].[GetProductsByCategoryID]    Script Date: 16.8.2017 г. 15:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsByCategoryID](
	@categoryId int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    SELECT ID, [Name], CreatedDate, Price
	FROM Products
	WHERE CategoryID = @categoryId AND IsDeleted = 0
	ORDER BY CreatedDate DESC
END


GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
