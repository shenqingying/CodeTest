USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Feedback_Insert]
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
	DECLARE @ID INT;
				
	SELECT @ID=MAX(HDQRID)+1 
	FROM SP_HDQR;
	
	UPDATE HG_SYSINS
	SET SYSINT = @ID
	WHERE SYSNAME='SP_HDQR';
		
	INSERT 
	INTO SP_HDQR
	(HDQRID,GSID ,GSJC ,HDRQ ,FKJE ,HDMEMO ,HDZT ,fillID ,fillName ,fillTime)
	VALUES
	(@ID,@GSID,@GSJC,@HDRQ,@FKJE,@HDMEMO,@HDZT,@fillID,@fillName,getdate())
	
	SELECT @ID ID;
END
GO