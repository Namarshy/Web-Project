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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_SaveInventoryData1
	@ProductId int,
@ProductName varchar(100),
@AvailableQty int,
@ReOrderPoint int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  Insert Inventory
	(	ProductId ,
		ProductName ,
		AvailableQty ,
		ReOrderPoint 
	)
		VALUES
		(@ProductId,
		@ProductName,
		@AvailableQty,
		@ReOrderPoint
		)


END
GO
