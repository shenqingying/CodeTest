USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Feedback_Item_Insert]
	@HDQRID int =0,
	@TYDID int =0,
	@FHRQ datetime =' ',
	@DZ varchar(50)=' ',
	@PM varchar(50) =' ',
	@JS int =0,
	@ZL numeric(19, 3)=0,
	@TJ numeric(19, 3)=0,
	@JFZL numeric(19, 3)=0,
	@DJ numeric(19, 3)=0,
	@YF numeric(19, 3)=0,
	@ZSF numeric(19, 3)=0,
	@ZXF numeric(19, 3)=0,
	@QTF numeric(19, 3)=0,
	@FYXJ numeric(19, 3)=0,
	@SJZF numeric(19, 3)=0,
	@QR bit =0,
	@ZF bit =0,
	@BZ varchar(500) =' '
AS
BEGIN
	
	INSERT 
	INTO SP_HDQRMX
	(HDQRID,TYDID,FHRQ,DZ,PM,JS ,ZL ,TJ ,JFZL ,DJ ,YF ,ZSF ,ZXF ,QTF ,FYXJ ,SJZF,QR,ZF,BZ)
	VALUES
	(@HDQRID,@TYDID,@FHRQ,@DZ,@PM ,@JS,@ZL,@TJ ,@JFZL ,@DJ ,@YF ,
	@ZSF ,@ZXF ,@QTF ,@FYXJ ,@SJZF ,@QR,@ZF,@BZ);
	
	UPDATE SP_TYD
	SET HDQR = 1,TYDZT=7
	WHERE TYDID = @TYDID;	
END
GO