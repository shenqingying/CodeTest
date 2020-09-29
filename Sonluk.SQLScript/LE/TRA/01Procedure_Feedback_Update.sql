USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Feedback_Update]
	@HDQRID int =0,
	@GSID int =0,
	@GSJC varchar(50)=' ' ,
	@HDRQ datetime =' ',
	@FKJE numeric(19, 2)=0,
	@HDMEMO varchar(1000)=' ',
	@HDZT smallint=0,
	@fillID int=0,
	@fillName varchar(20)=' '
AS
BEGIN
	UPDATE SP_HDQR
	SET GSID=@GSID ,GSJC=@GSJC ,HDRQ=@HDRQ ,FKJE=@FKJE ,HDMEMO=@HDMEMO ,HDZT=@HDZT ,fillID=@fillID ,fillName=@fillName ,fillTime=getdate()
	WHERE HDQRID=@HDQRID;

	SELECT @HDQRID ID;
END
GO