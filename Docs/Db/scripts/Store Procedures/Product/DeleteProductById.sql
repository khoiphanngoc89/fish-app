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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[DeleteProductById]'))
   EXEC('CREATE PROCEDURE [DeleteProductById] AS BEGIN SET NOCOUNT ON; END')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoi Phan
-- Create date: 11-10-2019
-- Description:	Delete product by identifier
-- =============================================
ALTER PROCEDURE [DeleteProductById]
	-- Add the parameters for the stored procedure here
	@Id BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Product] WHERE Id = @Id
END
GO
