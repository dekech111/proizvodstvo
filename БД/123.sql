USE [master]
GO
/****** Object:  Database [Обработка_Заявок_Таболин]    Script Date: 29.05.2022 16:15:09 ******/
CREATE DATABASE [Обработка_Заявок_Таболин]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Обработка_Заявок', FILENAME = N'F:\Программирование\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Обработка_Заявок.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Обработка_Заявок_log', FILENAME = N'F:\Программирование\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Обработка_Заявок_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Обработка_Заявок_Таболин].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ARITHABORT OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET  MULTI_USER 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET QUERY_STORE = OFF
GO
USE [Обработка_Заявок_Таболин]
GO
/****** Object:  Table [dbo].[Вид_Услуги]    Script Date: 29.05.2022 16:15:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вид_Услуги](
	[Код_Услуги] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](50) NULL,
	[Цена_услуги] [money] NULL,
 CONSTRAINT [PK_Вид_Услуги] PRIMARY KEY CLUSTERED 
(
	[Код_Услуги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Город]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Город](
	[Код_Города] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](50) NULL,
 CONSTRAINT [PK_Город] PRIMARY KEY CLUSTERED 
(
	[Код_Города] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказ]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказ](
	[Код_Заказа] [int] IDENTITY(1,1) NOT NULL,
	[Код_Услуги] [int] NULL,
	[Краткое_описание] [varchar](max) NULL,
	[Код_исполнителя] [int] NULL,
	[Код_заказчика] [int] NULL,
	[Код_оборудования] [int] NULL,
	[КолВо_Оборудования] [int] NULL,
	[Дата] [date] NULL,
	[Сумма] [int] NULL,
	[Код_Статуса] [int] NULL,
	[СерийныйНомер] [nvarchar](50) NULL,
 CONSTRAINT [PK_Заказ] PRIMARY KEY CLUSTERED 
(
	[Код_Заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказчик]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказчик](
	[Код_Заказчика] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [varchar](50) NULL,
	[Телефон] [varchar](50) NULL,
	[Объект] [varchar](50) NULL,
	[Код_Города] [int] NULL,
	[Улица] [varchar](50) NULL,
 CONSTRAINT [PK_Заказчик] PRIMARY KEY CLUSTERED 
(
	[Код_Заказчика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Исполнитель]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Исполнитель](
	[Код_Исполнителя] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [varchar](50) NULL,
	[Телефон] [varchar](50) NULL,
	[Дата_Рождения] [date] NULL,
	[Код_Города] [int] NULL,
	[Улица] [varchar](50) NULL,
 CONSTRAINT [PK_Исполнитель] PRIMARY KEY CLUSTERED 
(
	[Код_Исполнителя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Используемое_Оборудование]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Используемое_Оборудование](
	[Код_Оборудования] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
	[Цена] [int] NULL,
 CONSTRAINT [PK_Используемое_Оборудование] PRIMARY KEY CLUSTERED 
(
	[Код_Оборудования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Статус]    Script Date: 29.05.2022 16:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Статус](
	[Код_Статуса] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
 CONSTRAINT [PK_Статус] PRIMARY KEY CLUSTERED 
(
	[Код_Статуса] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Вид_Услуги] ON 

INSERT [dbo].[Вид_Услуги] ([Код_Услуги], [Название], [Цена_услуги]) VALUES (1, N'Установка нового оборудования', 100.0000)
INSERT [dbo].[Вид_Услуги] ([Код_Услуги], [Название], [Цена_услуги]) VALUES (2, N'Ремонт оборудования', 250.0000)
INSERT [dbo].[Вид_Услуги] ([Код_Услуги], [Название], [Цена_услуги]) VALUES (3, N'Замена оборудования', 200.0000)
INSERT [dbo].[Вид_Услуги] ([Код_Услуги], [Название], [Цена_услуги]) VALUES (4, N'Снятие оборудования', 100.0000)
INSERT [dbo].[Вид_Услуги] ([Код_Услуги], [Название], [Цена_услуги]) VALUES (5, N'Демонтирование', 150.0000)
SET IDENTITY_INSERT [dbo].[Вид_Услуги] OFF
GO
SET IDENTITY_INSERT [dbo].[Город] ON 

INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (1, N'Орехово-Зуево')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (2, N'Ликино-Дулево')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (3, N'Шатура')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (4, N'Куровское')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (5, N'Егорьевск')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (6, N'Липецк')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (7, N'Абхазия')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (8, N'Рязань')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (9, N'Тюмень')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (10, N'Краснодар')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (11, N'Нижний новгород')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (12, N'Казань ')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (13, N'Пермь')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (14, N'Москва')
INSERT [dbo].[Город] ([Код_Города], [Название]) VALUES (15, N'Ярославль ')
SET IDENTITY_INSERT [dbo].[Город] OFF
GO
SET IDENTITY_INSERT [dbo].[Заказ] ON 

INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (1, 3, N'Порванный интернет кабель, нужна срочная замена', 2, 1, 2, 2, CAST(N'2021-07-06' AS Date), 500, 3, N'123')
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (2, 1, N'Требуется установка новой ФН', 1, 2, 1, 5, CAST(N'2021-09-10' AS Date), 35000, 3, N'321')
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (3, 1, N'Установка', 2, 3, 3, 14, CAST(N'2021-12-10' AS Date), 70000, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (4, 4, N'Замена', 3, 2, 1, 5, CAST(N'2022-02-08' AS Date), 35000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (5, 3, N'Ремонт', 5, 7, 2, 3, CAST(N'2022-03-07' AS Date), 750, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (6, 2, N'Порванный интернет кабель, нужна срочная замена', 7, 5, 3, 2, CAST(N'2021-05-09' AS Date), 10000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (7, 1, N'Требуется установка новой ФН', 6, 2, 4, 3, CAST(N'2021-06-30' AS Date), 13500, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (8, 4, N'Установка', 5, 6, 5, 6, CAST(N'2021-12-16' AS Date), 15600, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (9, 2, N'Замена', 3, 4, 6, 56, CAST(N'2020-10-06' AS Date), 364000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (10, 3, N'Ремонт', 4, 2, 6, 4, CAST(N'2021-03-22' AS Date), 26000, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (11, 2, N'Порванный интернет кабель, нужна срочная замена', 7, 4, 5, 34, CAST(N'2020-03-06' AS Date), 88400, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (12, 1, N'Требуется установка новой ФН', 9, 6, 4, 8, CAST(N'2020-10-21' AS Date), 36000, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (13, 4, N'Установка', 10, 1, 3, 7, CAST(N'2020-11-02' AS Date), 35000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (14, 5, N'Замена', 5, 5, 2, 6, CAST(N'2021-11-29' AS Date), 1500, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (17, 5, N'Ремонт', 8, 3, 1, 5, CAST(N'2020-11-24' AS Date), 35000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (18, 3, NULL, 4, 2, 1, 4, CAST(N'2020-12-17' AS Date), 28000, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (19, 4, NULL, 2, 4, 2, 1, CAST(N'2021-07-18' AS Date), 250, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (20, 2, N'Порванный интернет кабель, нужна срочная замена', 3, 5, 3, 3, CAST(N'2020-07-16' AS Date), 15000, 1, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (21, 4, N'Требуется установка новой ФН', 4, 8, 4, 5, CAST(N'2020-06-26' AS Date), 22500, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (22, 2, N'Установка', 5, 7, 5, 7, CAST(N'2020-02-12' AS Date), 18200, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (23, 1, N'Ремонт', 1, 6, 6, 6, CAST(N'2020-09-02' AS Date), 39000, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (24, 5, NULL, 4, 4, 6, 45, CAST(N'2020-03-01' AS Date), 292500, 2, NULL)
INSERT [dbo].[Заказ] ([Код_Заказа], [Код_Услуги], [Краткое_описание], [Код_исполнителя], [Код_заказчика], [Код_оборудования], [КолВо_Оборудования], [Дата], [Сумма], [Код_Статуса], [СерийныйНомер]) VALUES (26, 3, N'123', 2, 2, 3, 123, CAST(N'2030-01-31' AS Date), 615000, 1, NULL)
SET IDENTITY_INSERT [dbo].[Заказ] OFF
GO
SET IDENTITY_INSERT [dbo].[Заказчик] ON 

INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (1, N'Синицен Павел Вольфович', N'+7874518466', N'Остин ', 1, N'Остина, д5')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (2, N'Сережкина София Петровна', N'+7555947843', N'Евросеть', 2, N'Киреево, 17')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (3, N'Перьмяков Николай Васильевич', N'+7489652354', N'Третьяков', 3, N'Пермская')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (4, N'Беляев Лазарь Аркадьевич', N'+8965588446', N'Летуаль', 5, N'Кружкова,5к')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (5, N'Ильин Авраам Филиппович', N'+8954561534', N'МТН', 6, N'Никовская,85')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (6, N'Горбунов Вилли Миронович', N'+8513515115', N'HTC', 10, N'Церковная,8б')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (7, N'Назаров Виктор Митрофанович', N'+8335151531', N'Билайн', 12, N'Школьная,12')
INSERT [dbo].[Заказчик] ([Код_Заказчика], [ФИО], [Телефон], [Объект], [Код_Города], [Улица]) VALUES (8, N'Колесников Тимофей Фролович', N'+8315168655', N'Ростелеком', 13, N'Речная,12')
SET IDENTITY_INSERT [dbo].[Заказчик] OFF
GO
SET IDENTITY_INSERT [dbo].[Исполнитель] ON 

INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (1, N'Богатырев Иван Никитич', N'+78585484641', CAST(N'1978-05-10' AS Date), 1, N'Васильева,25к')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (2, N'Смешная Виктория Павловна', N'+78848496844', CAST(N'1981-01-19' AS Date), 2, N'Гагарина,77б')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (3, N'Семенов Николай Петрович', N'+78455846841', CAST(N'1990-12-05' AS Date), 3, N'Менделеева, 15')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (4, N'Степанов Андрей Степанович', N'+78555564894', CAST(N'1965-09-08' AS Date), 4, N'Зеленая, 5а')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (5, N'Круглый Василий Николаевич', N'+78945665555', CAST(N'1989-02-02' AS Date), 2, N'Матвеева,7б')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (6, N'Махненков Никита Никитич', N'+85845146854', CAST(N'1980-05-25' AS Date), 3, N'Киреева,85')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (7, N'Разерман Василий Николаевич', N'+84684684684', CAST(N'1950-05-29' AS Date), 8, N'Дмитревская,77а')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (8, N'Степанко Дмитрий Васильевич', N'+84651651511', CAST(N'1990-01-01' AS Date), 9, N'Парковая,1а')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (9, N'Карпенко Николай Вадимович', N'+84646516511', CAST(N'1995-05-03' AS Date), 10, N'Набережная,5б')
INSERT [dbo].[Исполнитель] ([Код_Исполнителя], [ФИО], [Телефон], [Дата_Рождения], [Код_Города], [Улица]) VALUES (10, N'Шабаршов Валентин Дмитреевич', N'+81616516511', CAST(N'2000-08-05' AS Date), 15, N'Комсомольская,11б')
SET IDENTITY_INSERT [dbo].[Исполнитель] OFF
GO
SET IDENTITY_INSERT [dbo].[Используемое_Оборудование] ON 

INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (1, N'ФН', 7000)
INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (2, N'Интернет Кабель', 250)
INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (3, N'УПД', 5000)
INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (4, N'Фискальный Контроллер', 4500)
INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (5, N'Отрезчик', 2600)
INSERT [dbo].[Используемое_Оборудование] ([Код_Оборудования], [Наименование], [Цена]) VALUES (6, N'Фрезировщик', 6500)
SET IDENTITY_INSERT [dbo].[Используемое_Оборудование] OFF
GO
SET IDENTITY_INSERT [dbo].[Статус] ON 

INSERT [dbo].[Статус] ([Код_Статуса], [Наименование]) VALUES (1, N'Активно')
INSERT [dbo].[Статус] ([Код_Статуса], [Наименование]) VALUES (2, N'Неактивно')
INSERT [dbo].[Статус] ([Код_Статуса], [Наименование]) VALUES (3, N'Закрыт')
SET IDENTITY_INSERT [dbo].[Статус] OFF
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Вид_Услуги] FOREIGN KEY([Код_Услуги])
REFERENCES [dbo].[Вид_Услуги] ([Код_Услуги])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Вид_Услуги]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Заказчик] FOREIGN KEY([Код_заказчика])
REFERENCES [dbo].[Заказчик] ([Код_Заказчика])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Заказчик]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Исполнитель] FOREIGN KEY([Код_исполнителя])
REFERENCES [dbo].[Исполнитель] ([Код_Исполнителя])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Исполнитель]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Используемое_Оборудование] FOREIGN KEY([Код_оборудования])
REFERENCES [dbo].[Используемое_Оборудование] ([Код_Оборудования])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Используемое_Оборудование]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Статус] FOREIGN KEY([Код_Статуса])
REFERENCES [dbo].[Статус] ([Код_Статуса])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Статус]
GO
ALTER TABLE [dbo].[Заказчик]  WITH CHECK ADD  CONSTRAINT [FK_Заказчик_Город] FOREIGN KEY([Код_Города])
REFERENCES [dbo].[Город] ([Код_Города])
GO
ALTER TABLE [dbo].[Заказчик] CHECK CONSTRAINT [FK_Заказчик_Город]
GO
ALTER TABLE [dbo].[Исполнитель]  WITH CHECK ADD  CONSTRAINT [FK_Исполнитель_Город] FOREIGN KEY([Код_Города])
REFERENCES [dbo].[Город] ([Код_Города])
GO
ALTER TABLE [dbo].[Исполнитель] CHECK CONSTRAINT [FK_Исполнитель_Город]
GO
USE [master]
GO
ALTER DATABASE [Обработка_Заявок_Таболин] SET  READ_WRITE 
GO
