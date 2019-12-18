USE FISH
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[CreateProduct]'))
   EXEC('CREATE PROCEDURE [CreateProduct] AS BEGIN SET NOCOUNT ON; END')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoi Phan
-- Create date: 11-9-2019
-- Description:	Creates product
-- =============================================
ALTER PROCEDURE [CreateProduct]
	-- Add the parameters for the stored procedure here
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@Price DECIMAL(10,2) = 0,
	@PromotionPrice DECIMAL(10,2) = 0,
	@Quality INT = 0,
	@IsActive BIT = 1,
	@SeoPageTitle VARCHAR(255),
	@SeoAlias VARCHAR(150),
	@SeoKeywords VARCHAR(50),
	@SeoDescription VARCHAR(255),
	@ImageId BIGINT = NULL,
	@CategoryId BIGINT = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Product.Products] (
		  [Name]
		, [Description]
		, Price
		, PromotionPrice
		, Quality
		, IsActive
		, SeoPageTitle
		, SeoAlias
		, SeoKeywords
		, SeoDescription
		, ImageId
		, CategoryId)
	VALUES (
		  @Name
		, @Description
		, @Price
		, @PromotionPrice
		, @Quality
		, @IsActive
		, @SeoPageTitle
		, @SeoAlias
		, @SeoKeywords
		, @SeoDescription
		, @ImageId
		, @CategoryId)
	SELECT SCOPE_IDENTITY()
END
GO
