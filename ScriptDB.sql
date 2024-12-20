USE [master]
GO
/****** Object:  Database [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement]    Script Date: 12/9/2024 5:23:40 AM ******/
CREATE DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement]
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET  MULTI_USER 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement]
GO
/****** Object:  Table [dbo].[CustomerHistory]    Script Date: 12/9/2024 5:23:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerHistory](
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderType] [nvarchar](20) NOT NULL,
	[OrderID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderStatus] [nvarchar](20) NOT NULL,
	[TotalCost] [decimal](18, 2) NULL,
	[Rating] [int] NULL,
	[Feedback] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designs]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designs](
	[DesignID] [int] IDENTITY(1,1) NOT NULL,
	[DesignName] [nvarchar](100) NOT NULL,
	[DesignStyle] [nvarchar](50) NULL,
	[EstimatedCost] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](200) NULL,
	[PopularityScore] [int] NULL,
	[RecommendedUse] [nvarchar](50) NULL,
	[PromotionID] [int] NULL,
	[ApprovalStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DesignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceOrPondID] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Rating] [int] NULL,
	[SubmissionDate] [datetime] NOT NULL,
	[ApprovalStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[PaymentID] [int] NULL,
	[PromotionID] [int] NULL,
	[DeliveryAddress] [nvarchar](100) NULL,
	[DeliveryDate] [datetime] NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[FinalCost] [decimal](18, 2) NOT NULL,
	[OrderDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK__Orders__C3905BAF8EABEC02] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PaymentStatus] [nvarchar](20) NOT NULL,
	[CancellationReason] [nvarchar](200) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[FinalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Payments__9B556A58B7004E93] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ponds]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ponds](
	[PondID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ConsultingStaffID] [int] NULL,
	[DesignStaffID] [int] NULL,
	[ConstructionStaffID] [nvarchar](max) NULL,
	[PondName] [nvarchar](100) NOT NULL,
	[DesignStyle] [nvarchar](50) NULL,
	[DesignID] [int] NULL,
	[PaymentID] [int] NULL,
	[PromotionID] [int] NULL,
	[Status] [nvarchar](20) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[TotalCost] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[PondID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[PromotionID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionName] [nvarchar](100) NOT NULL,
	[DiscountPercentage] [decimal](5, 2) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[PointsRequired] [int] NULL,
	[MaxUsage] [int] NULL,
	[MinOrderValue] [decimal](18, 2) NULL,
	[PromotionStatus] [bit] NOT NULL,
	[RemainUsage] [int] NOT NULL,
 CONSTRAINT [PK__Promotio__52C42F2FE144C631] PRIMARY KEY CLUSTERED 
(
	[PromotionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[StaffID] [int] NULL,
	[ServiceType] [nvarchar](50) NOT NULL,
	[ServiceDate] [datetime] NOT NULL,
	[ServiceStatus] [nvarchar](20) NOT NULL,
	[PaymentID] [int] NULL,
	[PromotionID] [int] NULL,
	[Result] [nvarchar](200) NULL,
	[Feedback] [nvarchar](200) NULL,
	[Rating] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/9/2024 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Role] [nvarchar](20) NOT NULL,
	[PasswordHash] [nvarchar](256) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerHistory] ON 

INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (1, 9, N'Service', 1, CAST(N'2024-01-15T00:00:00.000' AS DateTime), N'Completed', CAST(2750000.00 AS Decimal(18, 2)), 5, N'Excellent service, highly recommend!')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (2, 10, N'Pond', 2, CAST(N'2024-02-12T00:00:00.000' AS DateTime), N'Pending', CAST(1650000.00 AS Decimal(18, 2)), 4, N'Waiting for the pond construction to be completed.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (3, 11, N'Service', 3, CAST(N'2024-03-20T00:00:00.000' AS DateTime), N'Completed', CAST(550000.00 AS Decimal(18, 2)), 4, N'Good service, but could be a bit quicker.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (4, 9, N'Pond', 4, CAST(N'2024-04-05T00:00:00.000' AS DateTime), N'Cancelled', CAST(3850000.00 AS Decimal(18, 2)), 3, N'Service was cancelled due to budget constraints.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (5, 10, N'Service', 5, CAST(N'2024-05-08T00:00:00.000' AS DateTime), N'Completed', CAST(1320000.00 AS Decimal(18, 2)), 5, N'Service was fine, but there were some delays.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (6, 11, N'Pond', 6, CAST(N'2024-06-12T00:00:00.000' AS DateTime), N'UnderConstruction', CAST(6600000.00 AS Decimal(18, 2)), 3, N'The pond is still under construction, hoping for good results.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (7, 9, N'Service', 7, CAST(N'2024-07-20T00:00:00.000' AS DateTime), N'Completed', CAST(4950000.00 AS Decimal(18, 2)), 4, N'Fantastic service, I am very satisfied with the outcome!')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (8, 11, N'Pond', 8, CAST(N'2024-08-10T00:00:00.000' AS DateTime), N'Completed', CAST(2200000.00 AS Decimal(18, 2)), 5, N'Pond looks great, but there were some minor issues with the design.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (9, 9, N'Service', 9, CAST(N'2024-09-25T00:00:00.000' AS DateTime), N'Pending', CAST(3300000.00 AS Decimal(18, 2)), 3, N'Service is pending, waiting for confirmation.')
INSERT [dbo].[CustomerHistory] ([HistoryID], [CustomerID], [OrderType], [OrderID], [OrderDate], [OrderStatus], [TotalCost], [Rating], [Feedback]) VALUES (10, 10, N'Pond', 10, CAST(N'2024-10-02T00:00:00.000' AS DateTime), N'Completed', CAST(440000.00 AS Decimal(18, 2)), 4, N'The pond installation was successful, but the cleanup could have been better.')
SET IDENTITY_INSERT [dbo].[CustomerHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Designs] ON 

INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (4, N'Modern Pond', N'Modern', CAST(1000000.00 AS Decimal(18, 2)), N'A sleek and contemporary pond design', N'/images/modern_pond.jpg', 8, N'Outdoor', 4, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (5, N'Classic Pond', N'Classic', CAST(800000.00 AS Decimal(18, 2)), N'A traditional pond with classic features', N'/images/classic_pond.jpg', 7, N'Indoor', NULL, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (6, N'Tropical Pond', N'Tropical', CAST(1200000.00 AS Decimal(18, 2)), N'A vibrant pond with tropical plants', N'/images/tropical_pond.jpg', 9, N'Outdoor', 2, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (7, N'Zen Pond', N'Zen', CAST(950000.00 AS Decimal(18, 2)), N'A peaceful pond with Japanese influences', N'/images/zen_pond.jpg', 6, N'Indoor', 3, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (8, N'Waterfall Pond', N'Waterfall', CAST(1300000.00 AS Decimal(18, 2)), N'A pond with a cascading waterfall', N'/images/waterfall_pond.jpg', 8, N'Outdoor', NULL, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (9, N'Desert Oasis', N'Desert', CAST(1100000.00 AS Decimal(18, 2)), N'A pond inspired by desert landscapes', N'/images/desert_oasis.jpg', 5, N'Outdoor', 5, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (10, N'Lotus Pond', N'Lotus', CAST(850000.00 AS Decimal(18, 2)), N'A serene pond with lotus flowers', N'/images/lotus_pond.jpg', 6, N'Indoor', NULL, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (11, N'Garden Pond', N'Garden', CAST(950000.00 AS Decimal(18, 2)), N'A beautiful garden pond with natural elements', N'/images/garden_pond.jpg', 7, N'Outdoor', 6, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (12, N'Island Pond', N'Island', CAST(1150000.00 AS Decimal(18, 2)), N'A pond with an island feature', N'/images/island_pond.jpg', 8, N'Outdoor', 3, 1)
INSERT [dbo].[Designs] ([DesignID], [DesignName], [DesignStyle], [EstimatedCost], [Description], [ImagePath], [PopularityScore], [RecommendedUse], [PromotionID], [ApprovalStatus]) VALUES (13, N'Luxury Pond', N'Luxury', CAST(1500000.00 AS Decimal(18, 2)), N'A high-end luxury pond with premium features', N'/images/luxury_pond.jpg', 10, N'Outdoor', NULL, 1)
SET IDENTITY_INSERT [dbo].[Designs] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (2, 9, 1, N'The pond looks fantastic after the cleaning service. Great job!', 5, CAST(N'2024-01-18T10:30:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (3, 10, 2, N'Service was good, but it took a bit longer than expected. Overall satisfied.', 4, CAST(N'2024-02-12T14:00:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (4, 11, 3, N'The consultation was helpful, but I still have a few questions about pond design options.', 4, CAST(N'2024-03-28T11:15:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (5, 9, 4, N'Waiting for the maintenance to be completed. Hope it will be as good as previous services.', 3, CAST(N'2024-04-06T09:00:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (6, 10, 5, N'Cleaning service was excellent, and the staff was very professional.', 5, CAST(N'2024-05-13T12:45:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (7, 11, 6, N'The service was okay, but I had to follow up several times to confirm the schedule.', 3, CAST(N'2024-06-10T16:00:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (8, 9, 7, N'The cleaning was thorough, but the staff could have been more courteous.', 4, CAST(N'2024-07-23T08:30:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (9, 10, 8, N'Great consultation! I am excited about the upcoming pond design project.', 5, CAST(N'2024-08-31T15:45:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (10, 11, 9, N'Maintenance is still in progress. Looking forward to seeing the results.', 3, CAST(N'2024-09-15T13:30:00.000' AS DateTime), 1)
INSERT [dbo].[Feedbacks] ([FeedbackID], [CustomerID], [ServiceOrPondID], [Content], [Rating], [SubmissionDate], [ApprovalStatus]) VALUES (11, 10, 10, N'The cleaning was completed well, but it took a bit longer than anticipated.', 4, CAST(N'2024-10-22T17:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (1, 9, CAST(N'2024-01-15T00:00:00.000' AS DateTime), CAST(2500000.00 AS Decimal(18, 2)), 15, NULL, N'123 Main St, City', CAST(N'2024-01-20T00:00:00.000' AS DateTime), N'Completed', CAST(2500000.00 AS Decimal(18, 2)), N'a')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (2, 10, CAST(N'2024-03-10T00:00:00.000' AS DateTime), CAST(1500000.00 AS Decimal(18, 2)), NULL, NULL, N'456 Elm St, City', CAST(N'2024-03-15T00:00:00.000' AS DateTime), N'Pending', CAST(1500000.00 AS Decimal(18, 2)), N'b')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (3, 11, CAST(N'2024-06-05T00:00:00.000' AS DateTime), CAST(500000.00 AS Decimal(18, 2)), NULL, NULL, N'789 Oak St, City', CAST(N'2024-06-10T00:00:00.000' AS DateTime), N'Pending', CAST(500000.00 AS Decimal(18, 2)), N'c')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (4, 9, CAST(N'2024-11-20T00:00:00.000' AS DateTime), CAST(3500000.00 AS Decimal(18, 2)), NULL, NULL, N'321 Pine St, City', CAST(N'2024-11-25T00:00:00.000' AS DateTime), N'Pending', CAST(3500000.00 AS Decimal(18, 2)), N'd')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (5, 10, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(1200000.00 AS Decimal(18, 2)), NULL, NULL, N'654 Birch St, City', CAST(N'2024-12-15T00:00:00.000' AS DateTime), N'Pending', CAST(1200000.00 AS Decimal(18, 2)), N'e')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (6, 11, CAST(N'2024-08-01T00:00:00.000' AS DateTime), CAST(6000000.00 AS Decimal(18, 2)), NULL, NULL, N'987 Cedar St, City', CAST(N'2024-08-05T00:00:00.000' AS DateTime), N'Pending', CAST(6000000.00 AS Decimal(18, 2)), N'f')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (7, 9, CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(4500000.00 AS Decimal(18, 2)), NULL, NULL, N'135 Maple St, City', CAST(N'2024-02-20T00:00:00.000' AS DateTime), N'Pending', CAST(4500000.00 AS Decimal(18, 2)), N'g')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (8, 10, CAST(N'2024-09-01T00:00:00.000' AS DateTime), CAST(2000000.00 AS Decimal(18, 2)), NULL, NULL, N'246 Willow St, City', CAST(N'2024-09-05T00:00:00.000' AS DateTime), N'Pending', CAST(2000000.00 AS Decimal(18, 2)), N'h')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (9, 11, CAST(N'2024-04-10T00:00:00.000' AS DateTime), CAST(3000000.00 AS Decimal(18, 2)), NULL, NULL, N'369 Fir St, City', CAST(N'2024-04-15T00:00:00.000' AS DateTime), N'Pending', CAST(3000000.00 AS Decimal(18, 2)), N'i')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalCost], [PaymentID], [PromotionID], [DeliveryAddress], [DeliveryDate], [OrderStatus], [FinalCost], [OrderDescription]) VALUES (10, 9, CAST(N'2024-07-25T00:00:00.000' AS DateTime), CAST(400000.00 AS Decimal(18, 2)), NULL, NULL, N'147 Redwood St, City', CAST(N'2024-07-30T00:00:00.000' AS DateTime), N'Pending', CAST(400000.00 AS Decimal(18, 2)), N'k')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (1, 1, N'Card', CAST(2500000.00 AS Decimal(18, 2)), CAST(N'2024-01-18T10:30:00.000' AS DateTime), N'Paid', NULL, CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2750000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (2, 2, N'BankTransfer', CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2024-03-12T14:45:00.000' AS DateTime), N'Paid', NULL, CAST(150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1650000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (3, 3, N'Cash', CAST(500000.00 AS Decimal(18, 2)), CAST(N'2024-06-07T11:00:00.000' AS DateTime), N'Cancelled', N'Customer cancelled the payment', CAST(50000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(550000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (4, 4, N'Card', CAST(3500000.00 AS Decimal(18, 2)), CAST(N'2024-11-22T16:20:00.000' AS DateTime), N'Pending', NULL, CAST(350000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(3850000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (5, 5, N'BankTransfer', CAST(1200000.00 AS Decimal(18, 2)), CAST(N'2024-02-12T09:30:00.000' AS DateTime), N'Paid', NULL, CAST(120000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1320000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (6, 6, N'Card', CAST(6000000.00 AS Decimal(18, 2)), CAST(N'2024-08-02T13:15:00.000' AS DateTime), N'Paid', NULL, CAST(600000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(6600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (7, 7, N'Cash', CAST(4500000.00 AS Decimal(18, 2)), CAST(N'2024-02-18T12:00:00.000' AS DateTime), N'Paid', NULL, CAST(450000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(4950000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (8, 8, N'BankTransfer', CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2024-09-03T15:30:00.000' AS DateTime), N'Cancelled', N'Payment issue', CAST(200000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2200000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (9, 9, N'Card', CAST(3000000.00 AS Decimal(18, 2)), CAST(N'2024-04-13T17:40:00.000' AS DateTime), N'Pending', NULL, CAST(300000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(3300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (10, 10, N'Cash', CAST(400000.00 AS Decimal(18, 2)), CAST(N'2024-07-27T08:50:00.000' AS DateTime), N'Paid', NULL, CAST(40000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(440000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (11, 1, N'Card', CAST(2500000.00 AS Decimal(18, 2)), CAST(N'2024-12-07T04:07:27.000' AS DateTime), N'Paid', NULL, CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2750000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (12, 2, N'BankTransfer', CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2024-12-07T04:34:45.000' AS DateTime), N'Cancelled', N'het tien', CAST(150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1650000.00 AS Decimal(18, 2)))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [PaymentMethod], [Amount], [PaymentDate], [PaymentStatus], [CancellationReason], [Tax], [Discount], [FinalAmount]) VALUES (15, 1, N'Card', CAST(2500000.00 AS Decimal(18, 2)), CAST(N'2024-12-09T00:00:00.000' AS DateTime), N'Paid', NULL, CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2750000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Ponds] ON 

INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (4, 9, 7, 5, N'4', N'Green Paradise', N'Modern', 4, 1, NULL, N'UnderConstruction', CAST(N'2024-01-10T08:00:00.000' AS DateTime), NULL, CAST(2750000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (5, 10, 8, 6, N'3', N'Crystal Waters', N'Natural', 5, 2, NULL, N'Maintenance', CAST(N'2024-02-15T09:30:00.000' AS DateTime), NULL, CAST(1650000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (6, 11, 7, 6, N'3', N'Blue Oasis', N'Contemporary', 6, 3, NULL, N'Completed', CAST(N'2024-03-20T10:15:00.000' AS DateTime), CAST(N'2024-08-20T12:00:00.000' AS DateTime), CAST(550000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (7, 9, 8, 5, N'4', N'Ocean View', N'Minimalist', 7, 4, NULL, N'Designed', CAST(N'2024-04-05T07:45:00.000' AS DateTime), NULL, CAST(3850000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (8, 10, 8, 6, N'3', N'Mountain Retreat', N'Traditional', 8, 5, NULL, N'Requested', CAST(N'2024-05-10T14:30:00.000' AS DateTime), NULL, CAST(1320000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (9, 11, 7, 5, N'4', N'Lakeside Paradise', N'Rustic', 9, 6, NULL, N'Quoted', CAST(N'2024-06-14T13:00:00.000' AS DateTime), NULL, CAST(6600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (10, 9, 8, 6, N'3', N'Riverbend Retreat', N'Classic', 10, 7, NULL, N'UnderConstruction', CAST(N'2024-07-08T11:45:00.000' AS DateTime), NULL, CAST(4950000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (11, 10, 7, 5, N'4', N'Sunny Shores', N'Tropical', 11, 8, NULL, N'Maintenance', CAST(N'2024-08-01T10:30:00.000' AS DateTime), NULL, CAST(2200000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (12, 9, 8, 6, N'3', N'Desert Escape', N'Modern', 12, 9, NULL, N'Completed', CAST(N'2024-09-05T16:20:00.000' AS DateTime), CAST(N'2024-12-10T17:00:00.000' AS DateTime), CAST(3300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Ponds] ([PondID], [CustomerID], [ConsultingStaffID], [DesignStaffID], [ConstructionStaffID], [PondName], [DesignStyle], [DesignID], [PaymentID], [PromotionID], [Status], [StartDate], [EndDate], [TotalCost]) VALUES (13, 10, 7, 5, N'4', N'Hidden Cove', N'Beachfront', 13, 10, NULL, N'Consulted', CAST(N'2024-10-15T08:00:00.000' AS DateTime), NULL, CAST(440000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Ponds] OFF
GO
SET IDENTITY_INSERT [dbo].[Promotions] ON 

INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (2, N'New Year Sale', CAST(20.00 AS Decimal(5, 2)), CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-31T00:00:00.000' AS DateTime), 500, 1000, CAST(100.00 AS Decimal(18, 2)), 1, 500)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (3, N'Spring Discount', CAST(15.00 AS Decimal(5, 2)), CAST(N'2024-03-01T00:00:00.000' AS DateTime), CAST(N'2024-03-31T00:00:00.000' AS DateTime), 300, 500, CAST(150.00 AS Decimal(18, 2)), 1, 400)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (4, N'Summer Special', CAST(30.00 AS Decimal(5, 2)), CAST(N'2024-06-01T00:00:00.000' AS DateTime), CAST(N'2024-06-30T00:00:00.000' AS DateTime), 700, 2000, CAST(50.00 AS Decimal(18, 2)), 1, 200)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (5, N'Black Friday', CAST(50.00 AS Decimal(5, 2)), CAST(N'2024-11-01T00:00:00.000' AS DateTime), CAST(N'2024-11-30T00:00:00.000' AS DateTime), 1000, 3000, CAST(200.00 AS Decimal(18, 2)), 1, 1500)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (6, N'Christmas Offer', CAST(25.00 AS Decimal(5, 2)), CAST(N'2024-12-01T00:00:00.000' AS DateTime), CAST(N'2024-12-25T00:00:00.000' AS DateTime), 600, 1500, CAST(120.00 AS Decimal(18, 2)), 1, 700)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (7, N'Back to School', CAST(10.00 AS Decimal(5, 2)), CAST(N'2024-08-01T00:00:00.000' AS DateTime), CAST(N'2024-08-31T00:00:00.000' AS DateTime), 200, 500, CAST(80.00 AS Decimal(18, 2)), 1, 300)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (8, N'Halloween Sale', CAST(40.00 AS Decimal(5, 2)), CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-10-31T00:00:00.000' AS DateTime), 900, 2500, CAST(130.00 AS Decimal(18, 2)), 1, 1000)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (9, N'Early Bird Discount', CAST(5.00 AS Decimal(5, 2)), CAST(N'2024-01-15T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), NULL, 300, CAST(50.00 AS Decimal(18, 2)), 1, 600)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (10, N'Valentines Day Offer', CAST(18.00 AS Decimal(5, 2)), CAST(N'2024-02-01T00:00:00.000' AS DateTime), CAST(N'2024-02-14T00:00:00.000' AS DateTime), 400, 800, CAST(100.00 AS Decimal(18, 2)), 1, 350)
INSERT [dbo].[Promotions] ([PromotionID], [PromotionName], [DiscountPercentage], [StartDate], [EndDate], [PointsRequired], [MaxUsage], [MinOrderValue], [PromotionStatus], [RemainUsage]) VALUES (11, N'End of Year Clearance', CAST(10.00 AS Decimal(5, 2)), CAST(N'2024-12-26T00:00:00.000' AS DateTime), CAST(N'2024-12-31T00:00:00.000' AS DateTime), NULL, 500, CAST(90.00 AS Decimal(18, 2)), 1, 250)
SET IDENTITY_INSERT [dbo].[Promotions] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (1, 9, 2, N'Maintenance', CAST(N'2024-01-15T08:00:00.000' AS DateTime), N'Completed', 1, NULL, N'Cleaned and serviced the pond', N'Very satisfied with the service', 5, CAST(2750000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (2, 10, 3, N'Cleaning', CAST(N'2024-02-10T09:30:00.000' AS DateTime), N'InProgress', 2, NULL, N'Cleaning in progress, will be completed shortly', N'Good communication', 4, CAST(1650000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (3, 11, 4, N'Others', CAST(N'2024-03-25T10:15:00.000' AS DateTime), N'Completed', 3, NULL, N'General consultation regarding pond maintenance', N'Helpful advice', 5, CAST(550000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (4, 9, 5, N'Maintenance', CAST(N'2024-04-05T11:00:00.000' AS DateTime), N'Pending', 4, NULL, N'Scheduled maintenance for the pond', N'Waiting for confirmation', 3, CAST(3850000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (5, 10, 6, N'Cleaning', CAST(N'2024-05-12T12:45:00.000' AS DateTime), N'Completed', 5, NULL, N'Pond cleaned and ready for use', N'Excellent work', 5, CAST(1320000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (6, 11, 7, N'Maintenance', CAST(N'2024-06-07T14:00:00.000' AS DateTime), N'InProgress', 6, NULL, N'Maintenance work ongoing', N'Service is good', 4, CAST(6600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (7, 9, 8, N'Cleaning', CAST(N'2024-07-22T08:30:00.000' AS DateTime), N'Completed', 7, NULL, N'Pond cleaned and debris removed', N'Happy with the outcome', 5, CAST(4950000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (8, 11, 9, N'Others', CAST(N'2024-08-30T15:00:00.000' AS DateTime), N'Pending', 8, NULL, N'General advice on pond decoration and design', N'Looking forward to the consultation', 3, CAST(2200000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (9, 9, 10, N'Maintenance', CAST(N'2024-09-10T13:30:00.000' AS DateTime), N'InProgress', 9, NULL, N'Maintenance on water filtration system', N'Service is going well so far', 4, CAST(3300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Services] ([ServiceID], [CustomerID], [StaffID], [ServiceType], [ServiceDate], [ServiceStatus], [PaymentID], [PromotionID], [Result], [Feedback], [Rating], [Cost]) VALUES (10, 10, 11, N'Cleaning', CAST(N'2024-10-20T16:00:00.000' AS DateTime), N'Completed', 10, NULL, N'Thorough cleaning of pond and surrounding area', N'Good work, but took longer than expected', 4, CAST(440000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (2, N'John Doe', N'john.doey@email.com', N'1234567890', N'123 Main St, City, Country', N'Manager', N'Temp', CAST(N'1000-01-01' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (3, N'Jane Smith', N'jane.smith@email.com', N'0987654321', N'456 Oak St, City, Country', N'ConstructionStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1990-02-02' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (4, N'Alice Brown', N'alice.brown@email.com', N'1122334455', N'789 Pine St, City, Country', N'ConstructionStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1985-03-03' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (5, N'Bob Johnson', N'bob.johnson@email.com', N'6677889900', N'101 Maple St, City, Country', N'DesignStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1987-04-04' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (6, N'Charlie White', N'charlie.white@email.com', N'5544332211', N'202 Birch St, City, Country', N'DesignStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1992-05-05' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (7, N'Eve Green', N'eve.green@email.com', N'2233445566', N'303 Cedar St, City, Country', N'ConsultingStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1995-06-06' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (8, N'David Black', N'david.black@email.com', N'4455667788', N'404 Willow St, City, Country', N'ConsultingStaff', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1989-07-07' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (9, N'Grace King', N'grace.king@email.com', N'5566778899', N'505 Elm St, City, Country', N'Customer', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1998-08-08' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (10, N'Henry Blue', N'henry.blue@email.com', N'6677889901', N'606 Fir St, City, Country', N'Customer', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'1997-09-09' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (11, N'Ivy Yellow', N'ivy.yellow@email.com', N'7788991122', N'707 Redwood St, City, Country', N'Customer', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'2000-10-10' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (17, N'customer', N'customer@gmail.com', N'0123456679', N'jhfkjhf', N'Customer', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'2000-08-08' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (18, N'admin', N'admin@gmail.com', N'0987654321', N'a b c d', N'Admin', N'$2a$11$9iiyr0L4IDTr74e3NPlvJOU2vA.Kq2/9dwMM9jDeyq2FHD3wNkhf2', CAST(N'2000-08-08' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (20, N'manager', N'manager@gmail.com', N'0341253462', N'2 duong so phuong 2', N'Manager', N'$2a$11$wsHwigBF9VCak86AMJ7QQehTgLT1BRn7c3OmnwGZTpbiprxy4QK7y', CAST(N'2000-12-12' AS Date), N'Male', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (26, N'Test', N'abcdee@gmail.com', N'0864213579', N'aji', N'ConsultingStaff', N'$2a$11$SQKPQJjPTH7W.vxBPKXkGuyviQzKXS70SfnhHxTOPyEdWFlwdgmye', CAST(N'2000-09-10' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (27, N'Nguyen Thuy Phuc Loc', N'min@gmail.com', N'0823120703', N'15A Tan Hoa 2, Hiep Phu, quan 9', N'ConstructionStaff', N'$2a$11$Gt86AImtOdWxu7obTFTPluK3JiIw0bn6oIg6RuFa3mOtbvE2GzO7W', CAST(N'2003-07-12' AS Date), N'Female', 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PhoneNumber], [Address], [Role], [PasswordHash], [DateOfBirth], [Gender], [Status]) VALUES (28, N'Hoang Duong Minh Phu', N'bin@gmail.com', N'0938901948', N'274/78 Nguyen Van Luong phuong 17', N'DesignStaff', N'$2a$11$bz5P06IFjoqG0UaT2f7yvOQfPAsAT9Xv2DjIRPFGAGwKyqujhWVZm', CAST(N'2003-07-12' AS Date), N'Male', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534A8AE7CF8]    Script Date: 12/9/2024 5:23:41 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Designs] ADD  DEFAULT ((0)) FOR [ApprovalStatus]
GO
ALTER TABLE [dbo].[Feedbacks] ADD  DEFAULT ((0)) FOR [ApprovalStatus]
GO
ALTER TABLE [dbo].[Promotions] ADD  CONSTRAINT [DF__Promotion__Activ__49C3F6B7]  DEFAULT ((1)) FOR [PromotionStatus]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CustomerHistory]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Designs]  WITH CHECK ADD  CONSTRAINT [FK__Designs__Promoti__4CA06362] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotions] ([PromotionID])
GO
ALTER TABLE [dbo].[Designs] CHECK CONSTRAINT [FK__Designs__Promoti__4CA06362]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Payments] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Payments]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Promotions] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotions] ([PromotionID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Promotions]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD FOREIGN KEY([ConsultingStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD FOREIGN KEY([DesignID])
REFERENCES [dbo].[Designs] ([DesignID])
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD FOREIGN KEY([DesignStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD  CONSTRAINT [FK__Ponds__Paymen__5535A963] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
GO
ALTER TABLE [dbo].[Ponds] CHECK CONSTRAINT [FK__Ponds__Paymen__5535A963]
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD  CONSTRAINT [FK__Ponds__Promot__5629CD9C] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotions] ([PromotionID])
GO
ALTER TABLE [dbo].[Ponds] CHECK CONSTRAINT [FK__Ponds__Promot__5629CD9C]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK__Services__Paymen__5812160E] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK__Services__Paymen__5812160E]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK__Services__Promot__59063A47] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotions] ([PromotionID])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK__Services__Promot__59063A47]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CustomerHistory]  WITH CHECK ADD CHECK  (([OrderType]='Service' OR [OrderType]='Pond'))
GO
ALTER TABLE [dbo].[CustomerHistory]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [CK_Orders_OrderStatus] CHECK  (([OrderStatus]='Cancelled' OR [OrderStatus]='Completed' OR [OrderStatus]='Pending'))
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [CK_Orders_OrderStatus]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [CK__Payments__Paymen__5EBF139D] CHECK  (([PaymentMethod]='BankTransfer' OR [PaymentMethod]='Card' OR [PaymentMethod]='Cash'))
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [CK__Payments__Paymen__5EBF139D]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [CK__Payments__Paymen__5FB337D6] CHECK  (([PaymentStatus]='Cancelled' OR [PaymentStatus]='Pending' OR [PaymentStatus]='Paid'))
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [CK__Payments__Paymen__5FB337D6]
GO
ALTER TABLE [dbo].[Ponds]  WITH CHECK ADD CHECK  (([Status]='Maintenance' OR [Status]='Completed' OR [Status]='UnderConstruction' OR [Status]='Designed' OR [Status]='Quoted' OR [Status]='Consulted' OR [Status]='Requested'))
GO
ALTER TABLE [dbo].[Promotions]  WITH CHECK ADD  CONSTRAINT [CK__Promotion__Disco__619B8048] CHECK  (([DiscountPercentage]>=(0) AND [DiscountPercentage]<=(100)))
GO
ALTER TABLE [dbo].[Promotions] CHECK CONSTRAINT [CK__Promotion__Disco__619B8048]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD CHECK  (([ServiceType]='Others' OR [ServiceType]='Maintenance' OR [ServiceType]='Cleaning'))
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD CHECK  (([ServiceStatus]='Completed' OR [ServiceStatus]='InProgress' OR [ServiceStatus]='Pending'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Gender]='Other' OR [Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Role__66603565] CHECK  (([Role]='Manager' OR [Role]='ConstructionStaff' OR [Role]='DesignStaff' OR [Role]='ConsultingStaff' OR [Role]='Customer' OR [Role]='Guest' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Role__66603565]
GO
USE [master]
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET  READ_WRITE 
GO
