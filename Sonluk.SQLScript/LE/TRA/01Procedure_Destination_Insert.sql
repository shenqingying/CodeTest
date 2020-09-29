USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Destination_Insert]
	@SHRID int =0,
	@DZMC varchar(200)= ' ',
	@LXR varchar(50)= ' ',
	@ZDID int =0,
	@ZDMC varchar(100)= ' ',
	@LXDH varchar(50)= ' ',
	@SJ varchar(50)= ' ',
	@isDef bit=0
AS
BEGIN
	DECLARE @ID INT;
				
	SELECT @ID=MAX(SHRDZID)+1 
	FROM SP_SHRDZ;
	
	UPDATE HG_SYSINS
	SET SYSINT = @ID
	WHERE SYSNAME='SP_SHRDZ';
	
	IF @isDef=1
	BEGIN
		UPDATE SP_SHRDZ
		SET  isDef=0
		WHERE SHRID=@SHRID;
	END
		
	INSERT 
	INTO SP_SHRDZ
	(SHRDZID,SHRID,DZMC,LXR,LXDH,SJ,ZDID,ZDMC,isDef)
	VALUES
	(@ID,@SHRID,@DZMC,@LXR,@LXDH,@SJ,@ZDID,@ZDMC,@isDef)
	
	SELECT @ID ID;
END
GO