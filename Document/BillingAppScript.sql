USE [master]
GO
/****** Object:  Database [BillingApp]    Script Date: 12/29/2019 9:57:11 PM ******/
CREATE DATABASE [BillingApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BillingApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS2017\MSSQL\DATA\BillingApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BillingApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS2017\MSSQL\DATA\BillingApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BillingApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BillingApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BillingApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BillingApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BillingApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BillingApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BillingApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BillingApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BillingApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BillingApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BillingApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BillingApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BillingApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BillingApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BillingApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BillingApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BillingApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BillingApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BillingApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BillingApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BillingApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BillingApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BillingApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BillingApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BillingApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BillingApp] SET  MULTI_USER 
GO
ALTER DATABASE [BillingApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BillingApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BillingApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BillingApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BillingApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BillingApp] SET QUERY_STORE = OFF
GO
USE [BillingApp]
GO
/****** Object:  UserDefinedTableType [dbo].[UT_OwnerAddress]    Script Date: 12/29/2019 9:57:11 PM ******/
CREATE TYPE [dbo].[UT_OwnerAddress] AS TABLE(
	[Id] [int] NULL,
	[Street1] [varchar](50) NULL,
	[Street2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[PostCode] [int] NULL,
	[OwnerState] [int] NULL,
	[OwnerId] [int] NULL,
	[IsCreated] [bit] NULL,
	[IsUpdated] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UT_OwnerBank]    Script Date: 12/29/2019 9:57:11 PM ******/
CREATE TYPE [dbo].[UT_OwnerBank] AS TABLE(
	[Id] [int] NULL,
	[BankName] [varchar](50) NULL,
	[BranchName] [varchar](50) NULL,
	[AccountNumber] [bigint] NULL,
	[IFSCCode] [varchar](50) NULL,
	[OwnerId] [int] NULL,
	[IsCreated] [bit] NULL,
	[IsUpdated] [bit] NULL
)
GO
/****** Object:  Table [dbo].[M_Owner]    Script Date: 12/29/2019 9:57:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Owner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerName] [varchar](50) NULL,
	[ContactNo] [bigint] NULL,
	[GSTNo] [varchar](50) NULL,
	[Juridication] [varchar](50) NULL,
	[BusinessType] [varchar](250) NULL,
 CONSTRAINT [PK_M_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_States]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](75) NULL,
 CONSTRAINT [PK_M_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerAddresses]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Street1] [varchar](50) NULL,
	[Street2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[PostCode] [int] NULL,
	[StateId] [int] NULL,
	[OwnerId] [int] NULL,
 CONSTRAINT [PK_OwnerAddresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerBanks]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerBanks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](50) NULL,
	[BranchName] [varchar](50) NULL,
	[AccountNumber] [bigint] NULL,
	[IFSCCode] [varchar](50) NULL,
	[OwnerId] [int] NULL,
 CONSTRAINT [PK_OwnerBanks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[M_Owner] ON 

INSERT [dbo].[M_Owner] ([Id], [OwnerName], [ContactNo], [GSTNo], [Juridication], [BusinessType]) VALUES (4, N'Patel Jayesh Himanshubhai', 827282822, N'24ADEDDISSOS1', N'Nadiad', N'Tobacco Merchant & Commission AgentLL')
INSERT [dbo].[M_Owner] ([Id], [OwnerName], [ContactNo], [GSTNo], [Juridication], [BusinessType]) VALUES (8, N'Zaid', 8000670004, N'24FXYPS9496GAZU', N'Nadiad', N'Retail')
SET IDENTITY_INSERT [dbo].[M_Owner] OFF
SET IDENTITY_INSERT [dbo].[M_States] ON 

INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (1, N'Andra Pradesh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (2, N'Arunachal Pradesh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (3, N'Assam')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (4, N'Bihar')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (5, N'Chhattisgarh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (6, N'Goa')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (7, N'Gujarat')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (8, N'Haryana')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (9, N'Himachal Pradesh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (10, N'Jammu and Kashmir')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (11, N'Jharkhand')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (12, N'Karnataka')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (13, N'Kerala')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (14, N'Madya Pradesh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (15, N'Maharashtra')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (16, N'Manipur')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (17, N'Meghalaya')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (18, N'Mizoram')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (19, N'Nagaland')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (20, N'Orissa')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (21, N'Punjab')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (22, N'Rajasthan')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (23, N'Sikkim')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (24, N'Tamil Nadu')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (25, N'Telagana')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (26, N'Tripura')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (27, N'Uttaranchal')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (28, N'Uttar Pradesh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (29, N'West Bengal')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (30, N'Andaman and Nicobar Islands')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (31, N'Chandigarh')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (32, N'Dadar and Nagar Haveli')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (33, N'Daman and Diu')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (34, N'Delhi')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (35, N'Lakshadeep')
INSERT [dbo].[M_States] ([Id], [StateName]) VALUES (36, N'Pondicherry')
SET IDENTITY_INSERT [dbo].[M_States] OFF
SET IDENTITY_INSERT [dbo].[OwnerAddresses] ON 

INSERT [dbo].[OwnerAddresses] ([Id], [Street1], [Street2], [City], [PostCode], [StateId], [OwnerId]) VALUES (4, N'Santram Market', N'Santram Road', N'Nadiad', 387001, 7, 4)
INSERT [dbo].[OwnerAddresses] ([Id], [Street1], [Street2], [City], [PostCode], [StateId], [OwnerId]) VALUES (18, N'Saiyed Vad', N'Near Nava Rao Pura', N'Nadiad', 387001, 7, 8)
SET IDENTITY_INSERT [dbo].[OwnerAddresses] OFF
SET IDENTITY_INSERT [dbo].[OwnerBanks] ON 

INSERT [dbo].[OwnerBanks] ([Id], [BankName], [BranchName], [AccountNumber], [IFSCCode], [OwnerId]) VALUES (8, N'HDFC ', N'Nadiad', 333984820283, N'HDFC0NADIAD', 8)
SET IDENTITY_INSERT [dbo].[OwnerBanks] OFF
ALTER TABLE [dbo].[OwnerAddresses]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAddresses_M_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[M_Owner] ([Id])
GO
ALTER TABLE [dbo].[OwnerAddresses] CHECK CONSTRAINT [FK_OwnerAddresses_M_Owner]
GO
ALTER TABLE [dbo].[OwnerAddresses]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAddresses_M_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[M_States] ([Id])
GO
ALTER TABLE [dbo].[OwnerAddresses] CHECK CONSTRAINT [FK_OwnerAddresses_M_States]
GO
ALTER TABLE [dbo].[OwnerBanks]  WITH CHECK ADD  CONSTRAINT [FK_OwnerBanks_M_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[M_Owner] ([Id])
GO
ALTER TABLE [dbo].[OwnerBanks] CHECK CONSTRAINT [FK_OwnerBanks_M_Owner]
GO
/****** Object:  StoredProcedure [dbo].[USP_CreateUpdateOwner]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[USP_CreateUpdateOwner]

@OwnerId int,
@OwnerName varchar(50),
@ContactNo bigint,
@GSTNo varchar(50),
@Juridication varchar(50),
@BusinessType varchar(250),
@OwnerAddresses UT_OwnerAddress Readonly,
@OwnerBankDetails UT_OwnerBank Readonly
AS
BEGIN
--BEGIN TRY

--BEGIN TRANSACTION

Declare @OwnerAddressesCount int
Declare @OwnerBankDetailCount int
Declare @IsCreate bit =0


select * into #OwnerAdress from @OwnerAddresses
select * into #OwnerBank	from @OwnerBankDetails

select @OwnerAddressesCount=Count(OwnerId) from #OwnerAdress
select @OwnerBankDetailCount=COUNT(OwnerId) from #OwnerBank


IF NOT EXISTS(Select Id from M_Owner where OwnerName=@OwnerName)
BEGIN

	set @IsCreate=1

	insert into M_Owner values(@OwnerName,@ContactNo,@GSTNo,@Juridication,@BusinessType)

	set @OwnerId = SCOPE_IDENTITY()

END

ELSE
	BEGIN

	Update M_Owner
	set OwnerName=@OwnerName,
	ContactNo=@ContactNo,
	GSTNo=@GSTNo,
	Juridication=@Juridication,
	BusinessType=@BusinessType
	where Id=@OwnerId
	END


if(@IsCreate=1)
	BEGIN
	Update #OwnerAdress set OwnerId=@OwnerId
	Update #OwnerBank set OwnerId=@OwnerId
	END

if(@OwnerAddressesCount > 0)
	BEGIN
	insert into OwnerAddresses(
	Street1,
	Street2,
	City,
	PostCode,
	StateId,
	OwnerId
	)
	Select Street1,
		   Street2,
		   City,
		   PostCode,
		   OwnerState,
		   OwnerId
	 from #OwnerAdress 
	 where IsCreated=1
	

	Update OA set 
		OA.Street1=TOA.Street1,
		OA.Street2=TOA.Street2,
		OA.City=TOA.City,
		OA.PostCode=TOA.PostCode,
		OA.StateId=TOA.OwnerState
	from #OwnerAdress TOA
	 inner join OwnerAddresses OA on OA.Id=TOA.Id and OA.OwnerId=TOA.OwnerId
	 where TOA.IsUpdated=1
	
	END

if(@OwnerBankDetailCount >0)
	BEGIN

	insert into OwnerBanks(
	
		BankName,
		BranchName,
		AccountNumber,
		IFSCCode,
		OwnerId
		)
	Select
	 BankName,
	 BranchName,
	 AccountNumber,
	 IFSCCode,
	 OwnerId
	from #OwnerBank
	where IsCreated=1
	
	Update OB set
	 OB.AccountNumber=TOB.AccountNumber,
	 OB.BankName=TOB.BankName,
	 OB.BranchName=TOB.BranchName,
	 OB.IFSCCode=TOB.IFSCCode

	from #OwnerBank TOB
	inner join OwnerBanks OB on OB.Id=TOB.Id and OB.OwnerId=TOB.OwnerId
	and IsUpdated=1



	END

--COMMIT TRANSACTION

--END TRY

--BEGIN CATCH
--ROLLBACK TRANSACTION 
--END CATCH



END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteBankDetail]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DeleteBankDetail]
@OwnerId int,
@BankId int
AS
BEGIN

Delete from OwnerBanks where Id=@BankId and OwnerId=@OwnerId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteOwner]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DeleteOwner]
@OwnerId int
AS
BEGIN

Delete from OwnerAddresses where OwnerId=@OwnerId

Delete from OwnerBanks where OwnerId=@OwnerId

Delete from M_Owner where Id=@OwnerId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteOwnerAddress]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DeleteOwnerAddress]
@OwnerId int,
@AddressId int
AS
BEGIN

Delete From OwnerAddresses where OwnerId=@OwnerId and Id=@AddressId
END


GO
/****** Object:  StoredProcedure [dbo].[USP_GetAllOwners]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[USP_GetAllOwners]

AS
BEGIN

Select
Distinct
MO.Id,
MO.OwnerName,
MO.GSTNo,
Mo.ContactNo,
OA.Street1 + ', '+ OA.Street2 + ', ' + OA.City +'-'+CAST (OA.PostCode AS varchar(50)) +', ' + MS.StateName as [OwnerAddress]
From M_Owner MO
Left join OwnerAddresses OA on OA.OwnerId=MO.Id
Left join M_States MS on MS.Id=OA.StateId

END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetBankDetailById]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetBankDetailById]
@BankId int
AS
BEGIN

Select 
Id,
BankName,
BranchName,
AccountNumber,
IFSCCode
From OwnerBanks
where Id=@BankId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetOwnerAddressById]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetOwnerAddressById]
@AdressId int
AS
BEGIN
Select 
Id,
Street1,
Street2,
City,
PostCode,
StateId

from  OwnerAddresses
where Id=@AdressId

END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetOwnerById]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetOwnerById] 
@OwnerId int
AS
BEGIN

Select 
Id,
OwnerName,
ContactNo,
GSTNo,
Juridication,
BusinessType
from M_Owner
where Id=@OwnerId

Select
OA.Id,
OA.Street1,
OA.Street2,
OA.City,
OA.PostCode,
OA.StateId
from OwnerAddresses OA
Inner join M_Owner MO on OA.OwnerId=MO.Id
where OA.OwnerId=@OwnerId

Select
OB.Id,
OB.BankName,
OB.BranchName,
OB.AccountNumber,
OB.IFSCCode
From OwnerBanks OB
Inner join M_Owner MO on OB.OwnerId=MO.Id
where OB.OwnerId=@OwnerId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_StateList]    Script Date: 12/29/2019 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_StateList]
AS
BEGIN
Select 
Id,
StateName 
from M_States

END

GO
USE [master]
GO
ALTER DATABASE [BillingApp] SET  READ_WRITE 
GO
