USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_ConsignmentNote_Select]
	@GSID int = 0,
	@DZDID int = 0,
	@SN varchar(100)=' ',
	@DH varchar(100)=' ',
	@TYRQ_LEFT varchar(10) = ' ',
	@TYRQ_RIGHT varchar(10) = ' ',
	@BDRQ_LEFT varchar(10) = ' ',
	@BDRQ_RIGHT varchar(10) = ' ',
	@SAPDN varchar(200) = ' ',
	@SHRDW varchar(200) = ' ',
	@SLXR varchar(50) = ' ',
	@SLXDH varchar(50) = ' ',
	@SSJ varchar(50) = ' ',
	@SHRDZ varchar(300) = ' ',
	@TBSM varchar(300) =' ',
	@BZ varchar(500) = ' ',
	@TYDZT int = 0
AS
BEGIN
	DECLARE 
		@sql nvarchar(2000),
		@prefix varchar(5); 
	
	SET @prefix = 'WHERE ';
	SET @sql = '';		
	SET @sql = @sql + 'SELECT * ';
	SET @sql = @sql + 'FROM SP_TYD ';
	
	IF @GSID>0
	BEGIN
		SET @sql = @sql + @prefix + ' GSID=' + CAST(@GSID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @DZDID>0
	BEGIN
		SET @sql = @sql + @prefix + ' DZDID=' + CAST(@DZDID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @SN<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SN=''' + @SN+'''';
		SET @prefix = ' AND ';
	END	

	IF @DH<>''
	BEGIN
		SET @sql = @sql + @prefix + ' DH=''' + @DH+'''';
		SET @prefix = ' AND ';
	END	
		
	IF @TYRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' TYRQ>=''' + @TYRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @TYRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' TYRQ<=''' + @TYRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @BDRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' BDRQ>=''' + @BDRQ_LEFT +'''';
		SET @prefix = ' AND ';
	END	
	
	IF @BDRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' BDRQ<=''' + @BDRQ_RIGHT +'''';
		SET @prefix = ' AND ';
	END	

	IF @SAPDN<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SAPDN LIKE ''%' + @SAPDN +'%''';
		SET @prefix = ' AND ';
	END
	
	IF @SHRDW<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SHRDW LIKE ''%' + @SHRDW +'%''';
		SET @prefix = ' AND ';
	END	
	
	IF @SLXR<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SLXR=''' + @SLXR+'''';
		SET @prefix = ' AND ';
	END

	IF @SLXDH<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SLXDH=''' + @SLXDH+'''';
		SET @prefix = ' AND ';
	END

	IF @SSJ<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SSJ=''' + @SSJ+'''';
		SET @prefix = ' AND ';
	END

	IF @SHRDZ<>''
	BEGIN
		SET @sql = @sql + @prefix + ' SHRDZ LIKE ''%' + @SHRDZ +'%''';
		SET @prefix = ' AND ';
	END

	IF @TBSM<>''
	BEGIN
		SET @sql = @sql + @prefix + ' TBSM LIKE ''%' + @TBSM +'%''';
		SET @prefix = ' AND ';
	END

	IF @BZ<>''
	BEGIN
		SET @sql = @sql + @prefix + ' BZ LIKE ''%' + @BZ +'%''';
		SET @prefix = ' AND ';
	END	
	
	IF @TYDZT=0
	BEGIN
		SET @sql = @sql + @prefix + ' TYDZT<>3 ';
		SET @prefix = ' AND ';
	END	
	
			
	SET @sql = @sql+';';
	--SELECT 	@sql;
	EXEC sp_executesql @sql;
END
GO