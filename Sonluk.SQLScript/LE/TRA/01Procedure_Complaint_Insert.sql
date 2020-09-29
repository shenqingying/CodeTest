USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Complaint_Insert]
	@GSID int =0,
	@GSJC varchar(50)=' ',
	@TYDID int =0,
	@TSFSMC varchar(50) = ' ',
	@TSFS int =0,
	@SHRID int =0,
	@SHRJC varchar(50) = ' ', 
	@THRQ datetime = ' ',
	@LXHBH varchar(50) = ' ',
	@YDRQ datetime = ' ', 
	@SDRQ datetime = ' ',
	@CDTS int =0,
	@HWLS bit = 0,
	@BZPS bit = 0,
	@BZWR bit = 0, 
	@WLSH bit = 0,
	@WLDQ bit = 0,
	@SHJE numeric(19, 2) = 0,
	@CGF numeric(19, 2) = 0,
	@XYPC bit = 0,
	@PCHJ numeric(19, 2) = 0,
	@CLWC bit = 0,
	@fillID int =0,
	@fillName varchar(20) = ' ' 
AS
BEGIN
	DECLARE 
		@ID INT;
				
	SELECT @ID=MAX(YCDJID)+1 
	FROM SP_YCDJ;
	
	UPDATE HG_SYSINS
	SET SYSINT = @ID
	WHERE SYSNAME='SP_YCDJ';
	
	INSERT INTO SP_YCDJ
	(YCDJID,GSID,GSJC,TYDID,TSFSMC,TSFS, SHRID,SHRJC, THRQ,
	LXHBH,YDRQ, SDRQ,CDTS,HWLS,BZPS,BZWR, WLSH, WLDQ,
	SHJE,CGF,XYPC,PCHJ,CLWC,fillID,fillName,fillTime)
	VALUES
	(@ID,@GSID,@GSJC,@TYDID,@TSFSMC,@TSFS, @SHRID,@SHRJC, @THRQ,
	@LXHBH,@YDRQ, @SDRQ,@CDTS,@HWLS,@BZPS,@BZWR, @WLSH, @WLDQ,
	@SHJE,@CGF,@XYPC,@PCHJ,@CLWC,@fillID,@fillName,getdate());
	
	SELECT @ID ID;
END
GO