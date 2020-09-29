USE [HGMM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Price_Insert]
	@SXID int = 0, 
	@DWMC varchar(10)=' ',
	@JLDWID int = 0, 
	@BJL numeric(19, 3)= 0,
	@EJL numeric(19, 3)= 0, 
	@DJ numeric(19, 6)= 0
AS
BEGIN
	DECLARE @ID INT;

	SELECT @ID=MAX(TYJGID)+1 
	FROM SP_TYJG;
		
	INSERT INTO SP_TYJG 
	VALUES (@ID, @SXID,@JLDWID, @DWMC, @BJL,@EJL ,@DJ);
			
	SELECT @ID ID;
END