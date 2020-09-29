USE [HGMM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Goods_Update]
	@HWID int=0 ,
	@HWMC varchar(100)=' ',
	@SAPBH varchar(18)=' ' ,
	@LBID int=0 ,
	@LBMC varchar(100)=' ',
	@DJSL numeric(19, 2),
	@SLDWID int=0 ,
	@SLDWMC varchar(10)=' ' ,
	@DJMZ numeric(19, 3)=0,
	@DJJZ numeric(19, 3)=0,
	@ZLDWID int =0,
	@ZLDW varchar(10)=' ' ,
	@DJTJ numeric(19, 3),
	@TJDWID int=0 ,
	@TJDW varchar(10)=' ' 
AS
BEGIN
	
	UPDATE SP_HWQD 
	SET HWMC=@HWMC, SAPBH=@SAPBH, LBID=@LBID, LBMC=@LBMC, 
		DJSL=@DJSL, SLDWID=@SLDWID, SLDWMC=@SLDWMC, DJMZ=@DJMZ, 
		DJJZ=@DJJZ, ZLDWID=@ZLDWID, ZLDW=@ZLDW, DJTJ=@DJTJ, TJDWID=@TJDWID, TJDW=@TJDW
	WHERE HWID=@HWID;	
END
