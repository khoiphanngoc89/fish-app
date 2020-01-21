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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('[GetSubMenuByParentId]'))
   EXEC('CREATE PROCEDURE [GetSubMenuByParentId] AS BEGIN SET NOCOUNT ON; END')
   
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoi Phan
-- Create date: 17-12-2019
-- Description:	Get sub menu by parent id
-- =============================================
ALTER PROCEDURE GetSubMenuByParentId
	@ParentId INT
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM SubMenu WHERE ParentId = @ParentId
END
