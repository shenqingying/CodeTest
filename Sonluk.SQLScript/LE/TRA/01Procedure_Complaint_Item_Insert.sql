USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Complaint_Item_Insert]
	@YCDJID int = 0,
	@VBELN varchar(10) = ' ',
	@WLBH varchar(10) = ' ',
	@WLMS varchar(100) = ' ', 
	@THJS int = 0, 
	@THSL int = 0, 
	@THYYMC  varchar(50) = ' ',
	@DJ numeric(19, 5) = 0,
	@SHSL int = 0, 
	@SHJE numeric(19, 5) = 0,
	@CGF numeric(19, 5) = 0,
	@YWY varchar(50)= ' ' 
AS
BEGIN
	DECLARE 
		@ID INT;
				
	SELECT @ID=MAX(YCQDID)+1 
	FROM SP_YCDJQD;
	
	UPDATE HG_SYSINS
	SET SYSINT = @ID
	WHERE SYSNAME='SP_YCDJQD';
	
	INSERT INTO SP_YCDJQD
	(YCQDID,YCDJID,VBELN,WLBH,WLMS, THJS, THSL, THYY,
	THYYMC,DJ,SHSL, SHJE,CGF,YWY)
	VALUES
	(@ID,@YCDJID,@VBELN,@WLBH,@WLMS, @THJS, @THSL, 0,
	@THYYMC,@DJ,@SHSL, @SHJE,@CGF,@YWY);
	
	SET @VBELN = '%'+@VBELN+'%';
	
	UPDATE SP_TYD
	SET YCDJ = 1
	WHERE SAPDN LIKE @VBELN;
	
	SELECT @ID ID;
END
GO