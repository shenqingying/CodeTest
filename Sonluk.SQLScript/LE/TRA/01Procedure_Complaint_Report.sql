USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Complaint_Report]
	@GSID int = 0,
	@TSFS int = -1,
	@TYDID int = 0,
	@THRQ_LEFT varchar(10) = ' ',
	@THRQ_RIGHT varchar(10) = ' ',
	@YDRQ_LEFT varchar(10) = ' ',
	@YDRQ_RIGHT varchar(10) = ' ',
	@LXHBH varchar(50)= ' ',
	@VBELN varchar(10)= ' ',
	@WLBH varchar(10)= ' ',
	@WLMS varchar(100)= ' ',
	@CLWC int = 0
AS
BEGIN
	DECLARE 
		@sql nvarchar(2000),
		@prefix varchar(5); 
	
	
	SET @sql = '';		
	SET @sql = @sql + 'SELECT * ';
	SET @sql = @sql + 'FROM SP_YCDJ header ';
	SET @sql = @sql + 'RIGHT JOIN SP_YCDJQD item ';
	SET @sql = @sql + 'ON header.YCDJID = item.YCDJID ';
	
	SET @prefix = 'WHERE ';
	
	IF @GSID>0
	BEGIN
		SET @sql = @sql + @prefix + ' header.GSID=' + CAST(@GSID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @TSFS>-1
	BEGIN
		SET @sql = @sql + @prefix + ' header.TSFS=' + CAST(@TSFS AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @TYDID>0
	BEGIN
		SET @sql = @sql + @prefix + ' header.TYDID=' + CAST(@TYDID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @THRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' header.THRQ>=''' + @THRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @THRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' header.THRQ<=''' + @THRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @YDRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' header.YDRQ>=''' + @YDRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @YDRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' header.YDRQ<=''' + @YDRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	

    IF @LXHBH<>''
	BEGIN
		SET @sql = @sql + @prefix + ' header.LXHBH=''' + @LXHBH+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @CLWC=0 or @CLWC=1
	BEGIN
		SET @sql = @sql + @prefix + ' CLWC=' + CAST(@CLWC AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @VBELN<>''
	BEGIN
		SET @sql = @sql + @prefix + ' item.VBELN=''' + @VBELN+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @WLBH<>''
	BEGIN
		SET @sql = @sql + @prefix + ' item.LXHBH=''' + @WLBH+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @WLMS<>''
	BEGIN
		SET @sql = @sql + @prefix + ' item.WLMS LIKE ''%' + @WLMS +'%''';
		SET @prefix = ' AND ';
	END	
				
	SET @sql = @sql+';';
	--SELECT 	@sql;
	EXEC sp_executesql @sql;
END
GO