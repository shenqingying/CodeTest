USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_ConsignmentNote_Item_Insert]
	@TYDMXID int=0,
	@TYDID int=0, 
	@LBID int=0, 
	@LBMC varchar(100) =' ', 
	@XSID int=0, 
	@XSMC varchar(50) =' ', 
	@ZJS int=0, 
	@LTJ int=0, 
	@ZS int=0, 
	@ZL numeric(19, 3) =0, 
	@TJ numeric(19, 3)=0, 
	@JFZL numeric(19, 3)=0, 
	@JFDJ numeric(19, 2)=0, 
	@DJID int=0, 
	@DJMC varchar(50)=' ', 
	@YF numeric(19, 2)=0, 
	@BJJE numeric(19, 2)=0, 
	@BJF numeric(19, 2)=0, 
	@ZSF numeric(19, 2)=0, 
	@ZZF numeric(19, 2)=0, 
	@QTF numeric(19, 2)=0, 
	@YFXJ numeric(19, 2)=0
AS
BEGIN	
	INSERT INTO SP_TYDMX
	(TYDMXID, TYDID, LBID, LBMC, XSID, XSMC, ZJS, LTJ, ZS, ZL, 
	TJ, JFZL, JFDJ, DJID, DJMC, YF, BJJE, BJF, ZSF, ZZF, QTF, YFXJ)
	VALUES
	(@TYDMXID, @TYDID, @LBID, @LBMC, @XSID, @XSMC, @ZJS, @LTJ, @ZS, @ZL, 
	@TJ, @JFZL, @JFDJ, @DJID, @DJMC, @YF, @BJJE, @BJF, @ZSF, @ZZF, @QTF, @YFXJ)
END
GO