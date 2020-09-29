USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Destination_Update]
    @SHRDZID int =0,
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
	IF @isDef=1
	BEGIN
		UPDATE SP_SHRDZ
		SET  isDef=0
		WHERE SHRID=@SHRID;
	END
	
	UPDATE SP_SHRDZ
	SET  DZMC=@DZMC,LXR=@LXR,LXDH=@LXDH,SJ=@SJ,isDef=@isDef,ZDID=@ZDID,ZDMC=@ZDMC
	WHERE SHRDZID = @SHRDZID;
	
	SELECT @SHRDZID ID;
END
GO