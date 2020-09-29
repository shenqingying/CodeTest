USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Complaint_Update]
    @YCDJID int =0,
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
	@CLWC bit = 0
AS
BEGIN
	UPDATE SP_YCDJ
	SET GSID=@GSID,GSJC=@GSJC,TYDID=@TYDID,TSFSMC=@TSFSMC,TSFS=@TSFS, SHRID=@SHRID,
		SHRJC=@SHRJC, THRQ=@THRQ,LXHBH=@LXHBH,YDRQ=@YDRQ, SDRQ=@SDRQ,CDTS=@CDTS,
		HWLS=@HWLS,BZPS=@BZPS,BZWR=@BZWR, WLSH=@WLSH, WLDQ=@WLDQ,SHJE=@SHJE,
		CGF=@CGF,XYPC=@XYPC,PCHJ=@PCHJ,CLWC=@CLWC
	WHERE YCDJID = @YCDJID;
				
	DELETE 
	FROM SP_YCDJQD
	WHERE YCDJID = @YCDJID;
	
	SELECT @YCDJID ID;
END
GO