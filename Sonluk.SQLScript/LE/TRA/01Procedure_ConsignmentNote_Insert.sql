USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_ConsignmentNote_Insert]
	@GSID int =0,
	@GSJC varchar(50)=' ' ,
	@GSMC varchar(200)=' ' ,
	@isSAP bit =false,
	@TYRQ datetime =' ',
	@DH varchar(100)=' ' ,
	@TYDH int =0,
	@FZDID int =0,
	@FZDMC varchar(100) =' ',
	@DZDID int =0,
	@DZDMC varchar(100)=' ' ,
	@YZDID int =0,
	@YZDMC varchar(100) =' ',
	@ZZDID int =0,
	@ZZDMC varchar(100)=' ' ,
	@TYRID int =0,
	@TYRJC varchar(50) =' ',
	@TYRDW varchar(200) =' ',
	@TYRDZ varchar(300) =' ',
	@LXR varchar(50) =' ',
	@LXDH varchar(50)=' ' ,
	@SJ varchar(50) =' ',
	@SHRID int =0,
	@SHRJC varchar(50) =' ',
	@SHRDW varchar(200) =' ',
	@SHRDZ varchar(300)=' ' ,
	@SLXR varchar(50)=' ' ,
	@SLXDH varchar(50) =' ',
	@SSJ varchar(50)=' ' ,
	@JFZL numeric(19, 3) ,
	@JFDJ numeric(19, 3) ,
	@YF numeric(19, 2) ,
	@BXF numeric(19, 2) ,
	@ZSF numeric(19, 2) ,
	@ZZF numeric(19, 2) ,
	@QTF numeric(19, 2) ,
	@HJ numeric(19, 2) ,
	@PCBS smallint =0,
	@WDTZ smallint =0,
	@SHD smallint =0,
	@FP smallint =0,
	@ZM smallint =0,
	@BDRQ datetime =' ',
	@SAPDN varchar(200) =' ',
	@TBSM varchar(300) =' ',
	@ZT bit =false,
	@SHSM bit =false,
	@PZJT bit =false,
	@PCZT bit =false,
	@TYDHZ bit =false,
	@SHDHZ bit =false,
	@BXGZ bit =false,
	@JJ bit =false,
	@QTYQ varchar(200) =' ',
	@fillID int =0,
	@fillName varchar(20) =' ',
	@BZ varchar(500) =' '
AS
BEGIN
	DECLARE 
		@ID INT,
		@SN varchar(100);
				
	SELECT @ID=MAX(TYDID)+1 
	FROM SP_TYD;
	
	UPDATE HG_SYSINS
	SET SYSINT = @ID
	WHERE SYSNAME='SP_TYD';
	
	SELECT @SN=YDH+1 
	FROM SP_WLGS
	WHERE GSID=@GSID;
	
	UPDATE SP_WLGS
	SET YDH = YDH+1
	WHERE GSID=@GSID;
	
	INSERT INTO SP_TYD
	(TYDID, GSID, GSJC, GSMC, isSAP
	, TYRQ, SN, DH, TYDH, FZDID
	, FZDMC, DZDID, DZDMC, YZDID, YZDMC
	, ZZDID, ZZDMC, TYRID, TYRJC, TYRDW
	, TYRDZ, LXR, LXDH, SJ, SHRID
	, SHRJC, SHRDW, SHRDZ, SLXR, SLXDH
	, SSJ, JFZL, JFDJ, YF, BXF
	, ZSF, QTF, HJ, PCBS, WDTZ
	, SHD, FP, ZM, BDRQ, SAPDN
	, TBSM, ZT, SHSM, PZJT, PCZT
	, TYDHZ, SHDHZ, BXGZ, JJ, QTYQ
	, TYDZT, fillID, fillName, fillTime, ZZF
	, BZ,YCDJ,HDQR)
	VALUES
	(@ID, @GSID, @GSJC, @GSMC, @isSAP
	, @TYRQ, @SN, @DH, @TYDH, @FZDID
	, @FZDMC, @DZDID, @DZDMC, @YZDID, @YZDMC
	, @ZZDID, @ZZDMC, @TYRID, @TYRJC, @TYRDW
	, @TYRDZ, @LXR, @LXDH, @SJ, @SHRID
	, @SHRJC, @SHRDW, @SHRDZ, @SLXR, @SLXDH
	, @SSJ, @JFZL, @JFDJ, @YF, @BXF
	, @ZSF, @QTF, @HJ, @PCBS, @WDTZ
	, @SHD, @FP, @ZM, @BDRQ, @SAPDN
	, @TBSM, @ZT, @SHSM, @PZJT, @PCZT
	, @TYDHZ, @SHDHZ, @BXGZ, @JJ, @QTYQ
	, 1, @fillID, @fillName, getdate(), @ZZF
	, @BZ,0,0)
	
	SELECT @ID ID;
END
GO