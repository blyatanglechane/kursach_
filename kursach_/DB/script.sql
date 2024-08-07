USE [master]
GO
/****** Object:  Database [DBBIA]    Script Date: 15.06.2024 11:12:32 ******/
CREATE DATABASE [DBBIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBBIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBBIA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBBIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBBIA_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DBBIA] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBBIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBBIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBBIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBBIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBBIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBBIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBBIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBBIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBBIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBBIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBBIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBBIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBBIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBBIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBBIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBBIA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBBIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBBIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBBIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBBIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBBIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBBIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBBIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBBIA] SET RECOVERY FULL 
GO
ALTER DATABASE [DBBIA] SET  MULTI_USER 
GO
ALTER DATABASE [DBBIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBBIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBBIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBBIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBBIA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBBIA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBBIA', N'ON'
GO
ALTER DATABASE [DBBIA] SET QUERY_STORE = ON
GO
ALTER DATABASE [DBBIA] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DBBIA]
GO
/****** Object:  Table [dbo].[BIAEat]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIAEat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PancakesPies] [int] NULL,
	[PancakesPiesgr] [int] NULL,
	[DryingBagelsBreadRolls] [int] NULL,
	[DryingBagelsBreadRollsgr] [int] NULL,
	[CookiesGingerbreadWaffles] [int] NULL,
	[CookiesGingerbreadWafflesgr] [int] NULL,
	[WhiteBread] [int] NULL,
	[WhiteBreadgr] [int] NULL,
	[BlackBread] [int] NULL,
	[BlackBreadgr] [int] NULL,
	[Pizza] [int] NULL,
	[Pizzagr] [int] NULL,
	[Pasta] [int] NULL,
	[Pastagr] [int] NULL,
	[CerealsPorridgesExceptLegumes] [int] NULL,
	[CerealsPorridgesExceptLegumesgr] [int] NULL,
	[Legumes] [int] NULL,
	[Legumesgr] [int] NULL,
	[Potatoes] [int] NULL,
	[Potatoesgr] [int] NULL,
	[VegetablesNotPotatoesMushrooms] [int] NULL,
	[VegetablesNotPotatoesMushroomsgr] [int] NULL,
	[Fruits] [int] NULL,
	[Fruitsgr] [int] NULL,
	[JuicesNectarsCompotes] [int] NULL,
	[JuicesNectarsCompotesml] [int] NULL,
	[Nuts] [int] NULL,
	[Nutsgr] [int] NULL,
	[JamJamJamHoney] [int] NULL,
	[JamJamJamHoneygr] [int] NULL,
	[SweetsAndChocolate] [int] NULL,
	[SweetsAndChocolategr] [int] NULL,
	[CakesPiesCupcakes] [int] NULL,
	[CakesPiesCupcakesgr] [int] NULL,
	[VegetableOil] [int] NULL,
	[VegetableOilgr] [int] NULL,
	[Butter] [int] NULL,
	[Buttergr] [int] NULL,
	[PorkFat] [int] NULL,
	[PorkFatgr] [int] NULL,
	[MayonnaiseAndMayonnaiseSauces] [int] NULL,
	[MayonnaiseAndMayonnaiseSaucesgr] [int] NULL,
	[Soup] [int] NULL,
	[Soupgr] [int] NULL,
	[MeatRedItsLiver] [int] NULL,
	[MeatRedItsLivergr] [int] NULL,
	[MeatProductsSausages] [int] NULL,
	[MeatProductsSausagesgr] [int] NULL,
	[PoultryMeatItsOffal] [int] NULL,
	[PoultryMeatItsOffalgr] [int] NULL,
	[MeatDumplings] [int] NULL,
	[MeatDumplingsgr] [int] NULL,
	[FishSeafood] [int] NULL,
	[FishSeafoodgr] [int] NULL,
	[CannedFoodMeatAndFish] [int] NULL,
	[CannedFoodMeatAndFishgr] [int] NULL,
	[LacticAcidDrinks] [int] NULL,
	[LacticAcidDrinksgr] [int] NULL,
	[Milk] [int] NULL,
	[Milkml] [int] NULL,
	[CondensedMilk] [int] NULL,
	[CondensedMilkgr] [int] NULL,
	[SourCream] [int] NULL,
	[SourCreamgr] [int] NULL,
	[CottageCheeseAndCottageCheeseProducts] [int] NULL,
	[CottageCheeseAndCottageCheeseProductsgr] [int] NULL,
	[SweetSourMilkYoghurtsSnowballsCheesesEtc] [int] NULL,
	[SweetSourMilkYoghurtsSnowballsCheesesEtcgr] [int] NULL,
	[Cheese] [int] NULL,
	[Cheesegr] [int] NULL,
	[Eggs] [int] NULL,
	[Eggspcs] [int] NULL,
	[Coffee] [int] NULL,
	[Coffeeml] [int] NULL,
	[Tea] [int] NULL,
	[Teaml] [int] NULL,
	[NonAlcoholicBeerKvassKombucha] [int] NULL,
	[NonAlcoholicBeerKvassKombuchaml] [int] NULL,
	[Beer] [int] NULL,
	[Beerml] [int] NULL,
	[Wine] [int] NULL,
	[Wineml] [int] NULL,
	[StrongAlcoholVodkaWhiskey] [int] NULL,
	[StrongAlcoholVodkaWhiskeyml] [int] NULL,
	[Sugar] [int] NULL,
	[Sugargr] [int] NULL,
	[SweetSnacksSodaColdTeasEnergyDrinksLemonade] [int] NULL,
	[SweetSnacksSodaColdTeasEnergyDrinksLemonadegr] [int] NULL,
	[ChemicalSnacksChipsCrackersPopcornCornSticks] [int] NULL,
	[ChemicalSnacksChipsCrackersPopcornCornSticksgr] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BIAStudent]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIAStudent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patient] [varchar](50) NOT NULL,
	[gender] [varchar](1) NOT NULL,
	[age] [int] NOT NULL,
	[height] [decimal](18, 0) NOT NULL,
	[Weight] [decimal](18, 0) NOT NULL,
	[BMI] [decimal](18, 0) NOT NULL,
	[BMIassessment] [varchar](50) NOT NULL,
	[WaistCircumferenceCM] [int] NULL,
	[HipCircumferenceCM] [decimal](18, 0) NOT NULL,
	[TB] [decimal](18, 0) NOT NULL,
	[TBAssessment] [varchar](50) NOT NULL,
	[R50_OM] [decimal](18, 0) NOT NULL,
	[Xc50_Ом] [decimal](18, 0) NOT NULL,
	[PhasesAngleDeg] [decimal](18, 0) NOT NULL,
	[Evaluation] [varchar](50) NOT NULL,
	[LM_kg] [decimal](18, 0) NOT NULL,
	[GM_kg] [varchar](50) NOT NULL,
	[LMPercent] [decimal](18, 0) NOT NULL,
	[GMPercent] [varchar](50) NOT NULL,
	[АКМkg] [decimal](18, 0) NOT NULL,
	[АКМ_kg] [varchar](50) NOT NULL,
	[АКМPercent] [decimal](18, 0) NOT NULL,
	[АКМ_Percent] [varchar](50) NOT NULL,
	[SMMkg] [decimal](18, 0) NOT NULL,
	[SMM_kg] [varchar](50) NOT NULL,
	[SMMpercent] [decimal](18, 0) NOT NULL,
	[SMM_percent] [varchar](50) NOT NULL,
	[TMkg] [decimal](18, 0) NOT NULL,
	[TM_kg] [varchar](50) NOT NULL,
	[Waterkg] [decimal](18, 0) NOT NULL,
	[Water_kg] [varchar](50) NOT NULL,
	[ECMkg] [decimal](18, 0) NULL,
	[MainVolumeKcal] [int] NOT NULL,
	[FertilizerKcalSqm] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dopolnitelno]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dopolnitelno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PriceSignificance] [int] NULL,
	[SpeedSignificance] [int] NULL,
	[TasteSignificance] [int] NULL,
	[CompositionSignificance] [int] NULL,
	[TrademarkSignificance] [int] NULL,
	[HabitsImportance] [int] NULL,
	[AppearanceSignificance] [int] NULL,
	[IsTheDietBalanced] [varchar](50) NULL,
	[TheReasonsForTheImbalanceOfNutrition] [varchar](50) NULL,
	[WhatDietarySupplements] [varchar](50) NULL,
	[Habitation] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FRIDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FRIDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FRIMultiplicity] [int] NULL,
	[FRIProteins] [decimal](18, 0) NULL,
	[FRIFats] [decimal](18, 0) NULL,
	[FRICarbohydrates] [decimal](18, 0) NULL,
	[FRICalories] [decimal](18, 0) NULL,
	[FRIRegularity] [varchar](50) NULL,
	[FRIBreakfast] [varchar](50) NULL,
	[FRIThelastmeal] [varchar](50) NULL,
	[FRIThePreferredMethodofCooking] [varchar](50) NULL,
	[FRIHoursOfSitting] [decimal](18, 0) NULL,
	[FRITheTypeOfTraining] [varchar](50) NULL,
	[FRITheStartTime] [varchar](50) NULL,
	[FRIItsDurationH] [decimal](18, 0) NULL,
	[FRIStepsPerDayThousand] [int] NULL,
	[FRITimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MONMultiplicity] [int] NULL,
	[MONProteins] [decimal](18, 0) NULL,
	[MONFats] [decimal](18, 0) NULL,
	[MONCarbohydrates] [decimal](18, 0) NULL,
	[MONCalories] [decimal](18, 0) NULL,
	[MONRegularity] [varchar](50) NULL,
	[MONBreakfast] [varchar](50) NULL,
	[MONThelastmeal] [varchar](50) NULL,
	[MONThePreferredMethodofCooking] [varchar](50) NULL,
	[MONHoursOfSitting] [decimal](18, 0) NULL,
	[MONTheTypeOfTraining] [varchar](50) NULL,
	[MONTheStartTime] [varchar](50) NULL,
	[MONItsDurationH] [decimal](18, 0) NULL,
	[MONStepsPerDayThousand] [int] NULL,
	[MONTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SATDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SATDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SATMultiplicity] [int] NULL,
	[SATProteins] [decimal](18, 0) NULL,
	[SATFats] [decimal](18, 0) NULL,
	[SATCarbohydrates] [decimal](18, 0) NULL,
	[SATCalories] [decimal](18, 0) NULL,
	[SATRegularity] [varchar](50) NULL,
	[SATBreakfast] [varchar](50) NULL,
	[SATThelastmeal] [varchar](50) NULL,
	[SATThePreferredMethodofCooking] [varchar](50) NULL,
	[SATHoursOfSitting] [decimal](18, 0) NULL,
	[SATTheTypeOfTraining] [varchar](50) NULL,
	[SATTheStartTime] [varchar](50) NULL,
	[SATItsDurationH] [decimal](18, 0) NULL,
	[SATStepsPerDayThousand] [int] NULL,
	[SATTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUNDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUNDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SUNMultiplicity] [int] NULL,
	[SUNProteins] [decimal](18, 0) NULL,
	[SUNFats] [decimal](18, 0) NULL,
	[SUNCarbohydrates] [decimal](18, 0) NULL,
	[SUNCalories] [decimal](18, 0) NULL,
	[SUNRegularity] [varchar](50) NULL,
	[SUNBreakfast] [varchar](50) NULL,
	[SUNThelastmeal] [varchar](50) NULL,
	[SUNThePreferredMethodofCooking] [varchar](50) NULL,
	[SUNHoursOfSitting] [decimal](18, 0) NULL,
	[SUNTheTypeOfTraining] [varchar](50) NULL,
	[SUNTheStartTime] [varchar](50) NULL,
	[SUNItsDurationH] [decimal](18, 0) NULL,
	[SUNStepsPerDayThousand] [int] NULL,
	[SUNTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THURSDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THURSDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[THURSMultiplicity] [int] NULL,
	[THURSProteins] [decimal](18, 0) NULL,
	[THURSFats] [decimal](18, 0) NULL,
	[THURSCarbohydrates] [decimal](18, 0) NULL,
	[THURSCalories] [decimal](18, 0) NULL,
	[THURSRegularity] [varchar](50) NULL,
	[THURSBreakfast] [varchar](50) NULL,
	[THURSThelastmeal] [varchar](50) NULL,
	[THURSThePreferredMethodofCooking] [varchar](50) NULL,
	[THURSHoursOfSitting] [decimal](18, 0) NULL,
	[THURSTheTypeOfTraining] [varchar](50) NULL,
	[THURSTheStartTime] [varchar](50) NULL,
	[THURSItsDurationH] [decimal](18, 0) NULL,
	[THURSStepsPerDayThousand] [int] NULL,
	[THURSTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUESDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUESDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TUESMultiplicity] [int] NULL,
	[TUESProteins] [decimal](18, 0) NULL,
	[TUESFats] [decimal](18, 0) NULL,
	[TUESCarbohydrates] [decimal](18, 0) NULL,
	[TUESCalories] [decimal](18, 0) NULL,
	[TUESRegularity] [varchar](50) NULL,
	[TUESBreakfast] [varchar](50) NULL,
	[TUESThelastmeal] [varchar](50) NULL,
	[TUESThePreferredMethodofCooking] [varchar](50) NULL,
	[TUESHoursOfSitting] [decimal](18, 0) NULL,
	[TUESTheTypeOfTraining] [varchar](50) NULL,
	[TUESTheStartTime] [varchar](50) NULL,
	[TUESItsDurationH] [decimal](18, 0) NULL,
	[TUESStepsPerDayThousand] [int] NULL,
	[TUESTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WEDDayWeek]    Script Date: 15.06.2024 11:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEDDayWeek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WEDMultiplicity] [int] NULL,
	[WEDProteins] [decimal](18, 0) NULL,
	[WEDFats] [decimal](18, 0) NULL,
	[WEDCarbohydrates] [decimal](18, 0) NULL,
	[WEDCalories] [decimal](18, 0) NULL,
	[WEDRegularity] [varchar](50) NULL,
	[WEDBreakfast] [varchar](50) NULL,
	[WEDThelastmeal] [varchar](50) NULL,
	[WEDThePreferredMethodofCooking] [varchar](50) NULL,
	[WEDHoursOfSitting] [decimal](18, 0) NULL,
	[WEDTheTypeOfTraining] [varchar](50) NULL,
	[WEDTheStartTime] [varchar](50) NULL,
	[WEDItsDurationH] [decimal](18, 0) NULL,
	[WEDStepsPerDayThousand] [int] NULL,
	[WEDTimeInMotionH] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BIAEat]  WITH CHECK ADD  CONSTRAINT [FK_BIAEat_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[BIAEat] CHECK CONSTRAINT [FK_BIAEat_BIAStudent]
GO
ALTER TABLE [dbo].[Dopolnitelno]  WITH CHECK ADD  CONSTRAINT [FK_Dopolnitelno_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[Dopolnitelno] CHECK CONSTRAINT [FK_Dopolnitelno_BIAStudent]
GO
ALTER TABLE [dbo].[FRIDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_FRIDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[FRIDayWeek] CHECK CONSTRAINT [FK_FRIDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[MONDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_MONDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[MONDayWeek] CHECK CONSTRAINT [FK_MONDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[SATDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_SATDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[SATDayWeek] CHECK CONSTRAINT [FK_SATDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[SUNDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_SUNDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[SUNDayWeek] CHECK CONSTRAINT [FK_SUNDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[THURSDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_THURSDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[THURSDayWeek] CHECK CONSTRAINT [FK_THURSDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[TUESDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_TUESDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[TUESDayWeek] CHECK CONSTRAINT [FK_TUESDayWeek_BIAStudent]
GO
ALTER TABLE [dbo].[WEDDayWeek]  WITH CHECK ADD  CONSTRAINT [FK_WEDDayWeek_BIAStudent] FOREIGN KEY([id])
REFERENCES [dbo].[BIAStudent] ([id])
GO
ALTER TABLE [dbo].[WEDDayWeek] CHECK CONSTRAINT [FK_WEDDayWeek_BIAStudent]
GO
USE [master]
GO
ALTER DATABASE [DBBIA] SET  READ_WRITE 
GO
