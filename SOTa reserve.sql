USE [master]
GO
/****** Object:  Database [Trade]    Script Date: 14.10.2022 12:44:41 ******/
CREATE DATABASE [Trade]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Trade', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Trade.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Trade_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Trade_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Trade] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Trade].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Trade] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Trade] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Trade] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Trade] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Trade] SET ARITHABORT OFF 
GO
ALTER DATABASE [Trade] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Trade] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Trade] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Trade] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Trade] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Trade] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Trade] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Trade] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Trade] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Trade] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Trade] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Trade] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Trade] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Trade] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Trade] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Trade] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Trade] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Trade] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Trade] SET  MULTI_USER 
GO
ALTER DATABASE [Trade] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Trade] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Trade] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Trade] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Trade] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Trade] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Trade] SET QUERY_STORE = OFF
GO
USE [Trade]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14.10.2022 12:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] NOT NULL,
	[OrderIssue] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderDeliveryDate] [datetime] NOT NULL,
	[OrderPickupPoint] [int] NOT NULL,
	[UserID] [int] NULL,
	[OrderCode] [nvarchar](50) NOT NULL,
	[OrderStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK__Order__C3905BAFFE65FEA1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderID] [int] NOT NULL,
	[ProductArticleNumber] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductArticleNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PP]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PP](
	[ID] [int] NOT NULL,
	[Adress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductArticleNumber] [nvarchar](100) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductPhoto] [varchar](max) NULL,
	[ProductManufacturerID] [int] NOT NULL,
	[ProductProviderID] [int] NOT NULL,
	[ProductCost] [decimal](19, 2) NOT NULL,
	[ProductDiscountAmount] [tinyint] NULL,
	[ProductDiscountActual] [tinyint] NULL,
	[ProductQuantityInStock] [int] NOT NULL,
	[ProductStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK__Product__2EA7DCD55EEF2FDE] PRIMARY KEY CLUSTERED 
(
	[ProductArticleNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.10.2022 12:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL,
	[UserSurname] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserPatronymic] [nvarchar](100) NOT NULL,
	[UserLogin] [nvarchar](max) NOT NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK__User__1788CCAC0DAF8127] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Кастрюли')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Сервиз')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Сковорода')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Посуда')
GO
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (1, N'Webber')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (2, N'Luminarc')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (3, N'Нева')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (4, N'Tefal')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (5, N'Solaris')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (6, N'Galaxy')
INSERT [dbo].[Manufacturer] ([ID], [Name]) VALUES (7, N'Эмаль')
GO
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (1, N'А112Т4, 2, D548T5, 2', CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-05-11T00:00:00.000' AS DateTime), 13, 7, N'301', N'Завершен')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (2, N'F735F5, 3, D644G3, 1', CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-05-11T00:00:00.000' AS DateTime), 12, 8, N'302', N'Новый ')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (3, N'H482Y6, 2, F836E5, 1', CAST(N'2022-05-06T00:00:00.000' AS DateTime), CAST(N'2022-05-12T00:00:00.000' AS DateTime), 13, 11, N'303', N'Завершен')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (4, N'N835F5, 5, F835F5, 5', CAST(N'2022-05-07T00:00:00.000' AS DateTime), CAST(N'2022-05-13T00:00:00.000' AS DateTime), 14, 11, N'304', N'Завершен')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (5, N'D036H2, 10, N835D4, 10', CAST(N'2022-05-09T00:00:00.000' AS DateTime), CAST(N'2022-05-15T00:00:00.000' AS DateTime), 15, 13, N'305', N'Новый ')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (6, N'K036S3, 1, C367R6, 1', CAST(N'2022-05-09T00:00:00.000' AS DateTime), CAST(N'2022-05-15T00:00:00.000' AS DateTime), 16, 14, N'306', N'Новый ')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (7, N'L346D4, 1, S257G5, 1', CAST(N'2022-05-10T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 16, 12, N'307', N'Завершен')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (8, N'G405K9, 20, S306J8, 20', CAST(N'2022-05-11T00:00:00.000' AS DateTime), CAST(N'2022-05-17T00:00:00.000' AS DateTime), 18, 10, N'308', N'Завершен')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (9, N'V493H5, 1, F835H6, 1', CAST(N'2022-05-12T00:00:00.000' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime), 20, 9, N'309', N'Новый ')
INSERT [dbo].[Order] ([OrderID], [OrderIssue], [OrderDate], [OrderDeliveryDate], [OrderPickupPoint], [UserID], [OrderCode], [OrderStatus]) VALUES (10, N'K935B6, 3, F934E5, 2', CAST(N'2022-05-12T00:00:00.000' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime), 20, 13, N'310', N'Завершен')
GO
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (1, N'344288, г. Краснокаменск, ул. Чехова, 1')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (2, N'614164, г.Краснокаменск,  ул. Степная, 30')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (3, N'394242, г. Краснокаменск, ул. Коммунистическая, 43')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (4, N'660540, г. Краснокаменск, ул. Солнечная, 25')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (5, N'125837, г. Краснокаменск, ул. Шоссейная, 40')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (6, N'125703, г. Краснокаменск, ул. Партизанская, 49')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (7, N'625283, г. Краснокаменск, ул. Победы, 46')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (8, N'614611, г. Краснокаменск, ул. Молодежная, 50')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (9, N'454311, г.Краснокаменск, ул. Новая, 19')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (10, N'660007, г.Краснокаменск, ул. Октябрьская, 19')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (11, N'603036, г. Краснокаменск, ул. Садовая, 4')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (12, N'450983, г.Краснокаменск, ул. Комсомольская, 26')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (13, N'394782, г. Краснокаменск, ул. Чехова, 3')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (14, N'603002, г. Краснокаменск, ул. Дзержинского, 28')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (15, N'450558, г. Краснокаменск, ул. Набережная, 30')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (16, N'394060, г.Краснокаменск, ул. Фрунзе, 43')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (17, N'410661, г. Краснокаменск, ул. Школьная, 50')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (18, N'625590, г. Краснокаменск, ул. Коммунистическая, 20')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (19, N'625683, г. Краснокаменск, ул. 8 Марта')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (20, N'400562, г. Краснокаменск, ул. Зеленая, 32')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (21, N'614510, г. Краснокаменск, ул. Маяковского, 47')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (22, N'410542, г. Краснокаменск, ул. Светлая, 46')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (23, N'620839, г. Краснокаменск, ул. Цветочная, 8')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (24, N'443890, г. Краснокаменск, ул. Коммунистическая, 1')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (25, N'603379, г. Краснокаменск, ул. Спортивная, 46')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (26, N'603721, г. Краснокаменск, ул. Гоголя, 41')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (27, N'410172, г. Краснокаменск, ул. Северная, 13')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (28, N'420151, г. Краснокаменск, ул. Вишневая, 32')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (29, N'125061, г. Краснокаменск, ул. Подгорная, 8')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (30, N'630370, г. Краснокаменск, ул. Шоссейная, 24')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (31, N'614753, г. Краснокаменск, ул. Полевая, 35')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (32, N'426030, г. Краснокаменск, ул. Маяковского, 44')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (33, N'450375, г. Краснокаменск ул. Клубная, 44')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (34, N'625560, г. Краснокаменск, ул. Некрасова, 12')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (35, N'630201, г. Краснокаменск, ул. Комсомольская, 17')
INSERT [dbo].[PP] ([ID], [Adress]) VALUES (36, N'190949, г. Краснокаменск, ул. Мичурина, 26')
GO
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'A395T3', N'Набор кастрюль', N'Набор кастрюль Эмаль Дача 2-3194/4 белый', 1, N'D644G3.jpg', 7, 2, CAST(2150.00 AS Decimal(19, 2)), 15, 2, 13, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'C367R6', N'Набор кастрюль', N'Набор кастрюль Webber BE-336/6 6 пр. серебристый', 1, N'D644G3.jpg', 1, 1, CAST(3600.00 AS Decimal(19, 2)), 15, 3, 7, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'C425F8', N'Набор посуды', N'Набор обеденной посуды Mason Cash Classic 12 предметов серый', 4, N'D548T5.jpg', 3, 2, CAST(5990.00 AS Decimal(19, 2)), 15, 5, 9, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'C432H7', N'Набор посуды', N'Набор посуды Tefal Ingenio Red 04162820 3 пр. красный', 4, N'D548T5.jpg', 4, 1, CAST(2700.00 AS Decimal(19, 2)), 30, 4, 6, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'D026R4', N'Сковорода', N'Сковорода НЕВА МЕТАЛЛ ПОСУДА Карелия 2328, 28 см', 3, N'D036H2.jpg', 3, 2, CAST(1800.00 AS Decimal(19, 2)), 25, 4, 2, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'D036H2', N'Сковорода', N'Сковорода НЕВА МЕТАЛЛ ПОСУДА Алтай индукционная, 26 см', 3, N'D036H2.jpg', 3, 1, CAST(1960.00 AS Decimal(19, 2)), 5, 5, 12, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'D548T5', N'Столовый сервиз', N'Столовый сервиз Luminarc Every Day G0566, 6 персон, 18 предм.', 2, N'H482Y6.jpg', 2, 2, CAST(1700.00 AS Decimal(19, 2)), 15, 4, 10, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'D630H5', N'Набор кастрюль', N'Набор кастрюль Webber BE-621/6 стальной', 1, N'D644G3.jpg', 1, 1, CAST(2000.00 AS Decimal(19, 2)), 10, 3, 8, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'D644G3', N'Набор кастрюль', N'Набор кастрюль Webber ВЕ-620/8 8 пр. стальной', 1, N'D644G3.jpg', 1, 2, CAST(3500.00 AS Decimal(19, 2)), 5, 3, 8, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'F735F5', N'Сковорода', N'Сковорода НЕВА МЕТАЛЛ ПОСУДА Домашняя 7424, съемная ручка, 24 см', 3, N'D036H2.jpg', 3, 2, CAST(1270.00 AS Decimal(19, 2)), 10, 2, 4, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'F835F5', N'Набор посуды', N'Набор посуды SOLARIS S1605: 6 тарелок 180мм в контейнере', 2, N'H482Y6.jpg', 5, 2, CAST(732.00 AS Decimal(19, 2)), 10, 2, 9, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'F835H6', N'Кастрюля для запекания', N'Кастрюля эмалированная, цветок Розы', 1, N'D644G3.jpg', 3, 2, CAST(2130.00 AS Decimal(19, 2)), 10, 2, 5, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'F836E5', N'Набор сковород', N'Набор сковород Tefal Ingenio Chef Red L6598672 3 пр. бордовый', 3, N'D036H2.jpg', 4, 1, CAST(4600.00 AS Decimal(19, 2)), 20, 2, 6, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'F934E5', N'Сервировочное блюдо', N'Сервировочное блюдо ROSSI для подачи из керамики 28х18 см ', 4, N'D548T5.jpg', 3, 1, CAST(1200.00 AS Decimal(19, 2)), 10, 3, 5, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'G405K9', N'Набор посуды', N'Набор посуды SOLARIS S1607: 6 стаканов 0,1л в контейнере', 4, N'D548T5.jpg', 5, 2, CAST(240.00 AS Decimal(19, 2)), 5, 4, 23, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'H482Y6', N'Столовый сервиз', N'Столовый сервиз Luminarc Cadix L0300, 6 персон, 19 предм.', 2, N'H482Y6.jpg', 2, 1, CAST(2300.00 AS Decimal(19, 2)), 15, 5, 12, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'J468K6', N'Набор сковород', N'Набор сковород GALAXY GL9801 2 пр. синий', 3, N'D036H2.jpg', 6, 2, CAST(1390.00 AS Decimal(19, 2)), 25, 2, 13, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'K036S3', N'Набор посуды', N'Набор посуды GALAXY GL9507 6 пр. коричневый', 2, N'H482Y6.jpg', 6, 1, CAST(2990.00 AS Decimal(19, 2)), 5, 5, 15, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'K935B6', N'Салатник', N'Салатник «Кото», 0,19 л 10 см красный, фарфор', 4, N'D548T5.jpg', 3, 2, CAST(1200.00 AS Decimal(19, 2)), 5, 3, 9, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'L346D4', N'Набор кружек', N'Набор кружек Pasabahce Basic, 370 мл, 2 предм., 2 персоны', 4, N'D548T5.jpg', 3, 1, CAST(329.00 AS Decimal(19, 2)), 5, 5, 18, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'M045H6', N'Набор кастрюль', N'Набор кастрюль СтальЭмаль 1с33/1 6 пр. белоснежный /маки ', 1, N'D644G3.jpg', 7, 1, CAST(1499.00 AS Decimal(19, 2)), 15, 4, 7, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'M527Y7', N'Казан', N'Казан 5 л Наша Посуда антипригарный', 1, N'D644G3.jpg', 3, 1, CAST(1999.00 AS Decimal(19, 2)), 30, 3, 6, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'N835D4', N'Набор кастрюль', N'Набор кастрюль GALAXY GL9512 4 пр. фиолетовый', 1, N'D644G3.jpg', 6, 2, CAST(2100.00 AS Decimal(19, 2)), 10, 3, 5, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'N835F5', N'Кастрюля для запекания', N'Кастрюля для запекания Tefal 208AC00/1043, 2.3 л, 23 см', 1, N'D644G3.jpg', 4, 2, CAST(744.00 AS Decimal(19, 2)), 5, 3, 13, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'S257G5', N'Набор посуды', N'Набор посуды для выпечки O CUISINE 333SA95/6142', 4, N'D548T5.jpg', 4, 1, CAST(2300.00 AS Decimal(19, 2)), 10, 4, 8, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'S306J8', N'Ковш', N'Ковш б/деколи(палевый) 17,5х8 см 1,5 л', 4, N'D548T5.jpg', 4, 2, CAST(409.00 AS Decimal(19, 2)), 10, 2, 14, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'S413D4', N'Набор кастрюль', N'Набор кастрюль СтальЭмаль 7DA025S 6 пр. слоновая кость', 1, N'D644G3.jpg', 7, 2, CAST(4500.00 AS Decimal(19, 2)), 15, 3, 15, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'S835H6', N'Кастрюля для запекания', N'Кастрюля Scovo Expert СЭ-008, 4.5 л', 1, N'D644G3.jpg', 4, 2, CAST(1600.00 AS Decimal(19, 2)), 15, 4, 13, N'')
INSERT [dbo].[Product] ([ProductArticleNumber], [ProductName], [ProductDescription], [ProductCategoryID], [ProductPhoto], [ProductManufacturerID], [ProductProviderID], [ProductCost], [ProductDiscountAmount], [ProductDiscountActual], [ProductQuantityInStock], [ProductStatus]) VALUES (N'V493H5', N'Набор посуды', N'Набор посуды Tefal Ingenio RED 9 предметов ', 4, N'D548T5.jpg', 4, 1, CAST(6000.00 AS Decimal(19, 2)), 15, 4, 18, N'')
GO
INSERT [dbo].[Provider] ([ID], [Name]) VALUES (1, N'Максидом')
INSERT [dbo].[Provider] ([ID], [Name]) VALUES (2, N'Домовой')
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Клиент')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'Федоров', N'Глеб', N'Михайлович', N'o@outlook.com', N'2L6KZG', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (2, N'Семенова', N'Софья', N'Дмитриевна', N'hr6zdl@yandex.ru', N'uzWC67', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (3, N'Васильев', N'НЕ Кита', N'Адольфович', N'n', N'1', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (4, N'Смирнова', N'Ирина', N'Александровна', N'dcu@yandex.ru', N'YOyhfR', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (5, N'Петров', N'Андрей', N'Владимирович', N'19dn@outlook.com', N'RSbvHv', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (6, N'Егоров', N'Максим', N'Андреевич', N'pa5h@mail.ru', N'rwVDh9', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (7, N'Никитин', N'Артур', N'Алексеевич', N'281av0@gmail.com', N'LdNyos', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (8, N'Киселев', N'Максим', N'Сергеевич', N'8edmfh@outlook.com', N'gynQMT', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (9, N'Борисов', N'Тимур', N'Егорович', N'sfn13i@mail.ru', N'AtnDjr', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (10, N'Климов', N'Арсений', N'Тимурович', N'g0orc3x1@outlook.com', N'JlFRCZ', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (11, N'Никулин', N'Антон', N'Фёдорович', N'katherine7@hotmail.com', N'8YIpv6', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (12, N'Копылова', N'Софья', N'Николаевна', N'marvin29@yahoo.com', N'ER2iai', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (13, N'Петров', N'Ибрагим', N'Романович', N'keyon33@gmail.com', N'XWmLmZ', 3)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (14, N'Овсянников', N'Никита', N'Сергеевич', N'clotilde29@gmail.com', N'BDAO2N', 3)
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PP] FOREIGN KEY([OrderPickupPoint])
REFERENCES [dbo].[PP] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PP]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Order__2D27B809] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Order__2D27B809]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Produ__2E1BDC42] FOREIGN KEY([ProductArticleNumber])
REFERENCES [dbo].[Product] ([ProductArticleNumber])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Produ__2E1BDC42]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([ProductManufacturerID])
REFERENCES [dbo].[Manufacturer] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Provider] FOREIGN KEY([ProductProviderID])
REFERENCES [dbo].[Provider] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Provider]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Trade] SET  READ_WRITE 
GO
