USE [HGMM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Route_Update]
	@SXID int = 0,
	@BZDID int = 0, 
	@BZDMC varchar(100)=' ',
	@EZDID int = 0, 
	@EZDMC varchar(100)=' ',
	@LIC int = 0, 
	@SX int = 0, 
	@GSID int = 0, 
	@GSJC varchar(50)=' '
AS
BEGIN
	UPDATE SP_SXB
	SET BZDID=@BZDID,BZDMC=@BZDMC,EZDID=@EZDID,EZDMC=@EZDMC,LIC=@LIC,SX=@SX,GSID=@GSID,GSJC=@GSJC
	WHERE SXID=@SXID;

			
	SELECT @SXID ID;
END
