USE [master]
GO
/****** Object:  Database [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement]    Script Date: 11/25/2024 12:34:32 PM ******/
CREATE DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement]
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
/****** Object:  Table [dbo].[CustomerHistory]    Script Date: 11/25/2024 12:34:32 PM ******/
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
/****** Object:  Table [dbo].[Designs]    Script Date: 11/25/2024 12:34:32 PM ******/
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
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 11/25/2024 12:34:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceOrProjectID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Orders]    Script Date: 11/25/2024 12:34:32 PM ******/
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
	[DeliveryAddress] [nvarchar](1) NULL,
	[DeliveryDate] [datetime] NULL,
	[OrderStatus] [nvarchar](1) NULL,
	[FinalCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Orders__C3905BAF8EABEC02] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/25/2024 12:34:32 PM ******/
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
/****** Object:  Table [dbo].[Projects]    Script Date: 11/25/2024 12:34:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ConsultingStaffID] [int] NULL,
	[DesignStaffID] [int] NULL,
	[ConstructionStaffID] [nvarchar](max) NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
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
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 11/25/2024 12:34:32 PM ******/
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
/****** Object:  Table [dbo].[Services]    Script Date: 11/25/2024 12:34:32 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 11/25/2024 12:34:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([ConsultingStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([DesignStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([DesignID])
REFERENCES [dbo].[Designs] ([DesignID])
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK__Projects__Paymen__5535A963] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK__Projects__Paymen__5535A963]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK__Projects__Promot__5629CD9C] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotions] ([PromotionID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK__Projects__Promot__5629CD9C]
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
ALTER TABLE [dbo].[CustomerHistory]  WITH CHECK ADD CHECK  (([OrderType]='Service' OR [OrderType]='Project'))
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
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD CHECK  (([Status]='Maintenance' OR [Status]='Completed' OR [Status]='UnderConstruction' OR [Status]='Designed' OR [Status]='Quoted' OR [Status]='Consulted' OR [Status]='Requested'))
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
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Manager' OR [Role]='ConstructionStaff' OR [Role]='DesignStaff' OR [Role]='ConsultingStaff' OR [Role]='Customer' OR [Role]='Guest'))
GO
USE [master]
GO
ALTER DATABASE [FA24_PRN221_3W_G5_KoiPondOrderSystemManagement] SET  READ_WRITE 
GO
