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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[GetAllProductByPaging]'))
   EXEC('CREATE PROCEDURE [GetAllProductByPaging] AS BEGIN SET NOCOUNT ON; END')
   
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoi Phan
-- Create date: 11-17-2019
-- Description:	Gets all product info.
------------------------------------------------
-- 12-15-2019     KP      Update store
-- =============================================

ALTER PROCEDURE [GetAllProductByPaging]
	-- Add the parameters for the stored procedure here
	 @PageNumber INT = 1
	,@PageSize   INT = 100
	,@GetLatest  BIT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	;WITH data_cte AS(
		SELECT * FROM Product
	),
	count_cte AS (
		SELECT count(*) AS ToalRows FROM data_cte
	)
	SELECT * FROM data_cte
	CROSS JOIN count_cte
	ORDER BY
		CASE WHEN @GetLatest = 0 THEN  Id END,
		CASE WHEN @GetLatest = 1 THEN  Id END DESC
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
END
GO