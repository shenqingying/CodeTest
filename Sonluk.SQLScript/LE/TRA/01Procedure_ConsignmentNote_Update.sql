USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_ConsignmentNote_Update]
	@TYDID int,
	@GSID int =0,
	@GSJC varchar(50)=' ' ,
	@GSMC varchar(200)=' ' ,
	@isSAP bit =false,
	@TYRQ datetime =' ',
	@SN varchar(100)=' ' ,
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
	UPDATE SP_TYD
	SET GSID=@GSID, GSJC=@GSJC, GSMC=@GSMC, isSAP=@isSAP, 
	TYRQ=@TYRQ, SN=@SN, DH=@DH, TYDH=@TYDH, FZDID=@FZDID, 
	FZDMC=@FZDMC, DZDID=@DZDID, DZDMC=@DZDMC, YZDID=@YZDID, YZDMC=@YZDMC, 
	ZZDID=@ZZDID, ZZDMC=@ZZDMC, TYRID=@TYRID, TYRJC=@TYRJC, TYRDW=@TYRDW, 
	TYRDZ=@TYRDZ, LXR=@LXR, LXDH=@LXDH, SJ=@SJ, SHRID=@SHRID, 
	SHRJC=@SHRJC, SHRDW=@SHRDW, SHRDZ=@SHRDZ, SLXR=@SLXR, SLXDH=@SLXDH, 
	SSJ=@SSJ, JFZL=@JFZL, JFDJ=@JFDJ, YF=@YF, BXF=@BXF, 
	ZSF=@ZSF, QTF=@QTF, HJ=@HJ, PCBS=@PCBS, WDTZ=@WDTZ, 
	SHD=@SHD, FP=@FP, ZM=@ZM, BDRQ=@BDRQ, SAPDN=@SAPDN, 
	TBSM=@TBSM, ZT=@ZT, SHSM=@SHSM, PZJT=@PZJT, PCZT=@PCZT, 
	TYDHZ=@TYDHZ, SHDHZ=@SHDHZ, BXGZ=@BXGZ, JJ=@JJ, QTYQ=@QTYQ, 
	fillID=@fillID ,fillName=@fillName,fillTime=getdate(),ZZF=@ZZF, BZ=@BZ
	WHERE TYDID = @TYDID;
				
	DELETE 
	FROM SP_TYDMX 
	WHERE TYDID=@TYDID;
END
GO