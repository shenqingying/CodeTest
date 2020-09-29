USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_ConsignmentNote_Report]
	@GSID int = 0,
	@DZDID int = 0,
	@SN varchar(100)=' ',
	@DH varchar(100)=' ',
	@TYRQ_LEFT varchar(10) = ' ',
	@TYRQ_RIGHT varchar(10) = ' ',
	@BDRQ_LEFT varchar(10) = ' ',
	@BDRQ_RIGHT varchar(10) = ' ',
	@SAPDN varchar(200) =' ',
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
		@sql nvarchar(2000)
	
	SET @sql = '';		
	SET @sql = @sql + 'SELECT Z.*,Y.m0,Y.m1,Y.m2,Y.m3 ';
	SET @sql = @sql + 'FROM SP_TYD Z,(SELECT sum(m0) m0 ,sum(m1) m1,sum(m2) m2,sum(m3) m3,TYDID ';
	SET @sql = @sql + 'FROM(SELECT  ';
	SET @sql = @sql + 'case mtcol when ''m0'' then mtNumber end m0, ';
	SET @sql = @sql + 'case mtcol when ''m1'' then mtNumber end m1, ';
	SET @sql = @sql + 'case mtcol when ''m2'' then mtNumber end m2, ';
	SET @sql = @sql + 'case mtcol when ''m3'' then mtNumber end m3, ';
	SET @sql = @sql + 'TYDID ';
	SET @sql = @sql + 'FROM(SELECT TYDMXID, TYDID, ''m''+cast(isnull(LBID,0) as varchar) mtcol , ZS mtNumber ';
	SET @sql = @sql + 'FROM SP_TYDMX)M)X ';
	SET @sql = @sql + 'GROUP BY TYDID)Y ';
	SET @sql = @sql + 'WHERE Z.TYDID=Y.TYDID ';
	
	IF @GSID>0
	BEGIN
		SET @sql = @sql + ' AND GSID=' + CAST(@GSID AS VARCHAR);
	END	
	
	IF @DZDID>0
	BEGIN
		SET @sql = @sql + ' AND DZDID=' + CAST(@DZDID AS VARCHAR);
	END	
	
	IF @SN<>''
	BEGIN
		SET @sql = @sql + ' AND SN=''' + @SN+'''';
	END	

	IF @DH<>''
	BEGIN
		SET @sql = @sql + ' AND DH=''' + @DH+'''';
	END	
		
	IF @TYRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + ' AND TYRQ>=''' + @TYRQ_LEFT+'''';
	END	
	
	IF @TYRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + ' AND TYRQ<=''' + @TYRQ_RIGHT+'''';
	END	
	
	IF @BDRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + ' AND BDRQ>=''' + @BDRQ_LEFT +'''';
	END	
	
	IF @BDRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + ' AND BDRQ<=''' + @BDRQ_RIGHT +'''';
	END	

	IF @SAPDN<>''
	BEGIN
		SET @sql = @sql + ' AND SAPDN LIKE ''%' + @SAPDN +'%''';
	END
	
	IF @SHRDW<>''
	BEGIN
		SET @sql = @sql + ' AND SHRDW LIKE ''%' + @SHRDW +'%''';
	END	
	
	IF @SLXR<>''
	BEGIN
		SET @sql = @sql + ' AND SLXR=''' + @SLXR+'''';
	END

	IF @SLXDH<>''
	BEGIN
		SET @sql = @sql + ' AND SLXDH=''' + @SLXDH+'''';
	END

	IF @SSJ<>''
	BEGIN
		SET @sql = @sql + ' AND SSJ=''' + @SSJ+'''';
	END

	IF @SHRDZ<>''
	BEGIN
		SET @sql = @sql + ' AND SHRDZ LIKE ''%' + @SHRDZ +'%''';
	END

	IF @TBSM<>''
	BEGIN
		SET @sql = @sql + ' AND TBSM LIKE ''%' + @TBSM +'%''';
	END

	IF @BZ<>''
	BEGIN
		SET @sql = @sql  + ' AND BZ LIKE ''%' + @BZ +'%''';
	END	
	
	IF @TYDZT=0
	BEGIN
		SET @sql = @sql + ' AND TYDZT<>3 ';
	END	
		
	SET @sql = @sql+';';
	--SELECT 	@sql;
	EXEC sp_executesql @sql;
END
GO



--SELECT *
--FROM SP_TYD Z,(SELECT sum(m0) m0 ,sum(m1) m1,sum(m2) m2,sum(m3) m3,TYDID 
--				FROM(SELECT 
--						case mtcol when 'm0' then mtNumber end m0,
--						case mtcol when 'm1' then mtNumber end m1,
--						case mtcol when 'm2' then mtNumber end m2,
--						case mtcol when 'm3' then mtNumber end m3,
--						TYDID 
--					FROM(SELECT TYDMXID, TYDID, 'm'+cast(isnull(LBID,0) as varchar) mtcol , ZS mtNumber 
--						FROM SP_TYDMX)M)X 
--				GROUP BY TYDID)Y
--WHERE Z.TYDID=Y.TYDID