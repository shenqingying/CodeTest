USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Complaint_Select]
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
		@prefix varchar(5),
		@sub_sql nvarchar(1000),
		@sub_prefix varchar(5);
		
	SET @prefix = 'WHERE ';
	SET @sql = '';		
	SET @sql = @sql + 'SELECT * ';
	SET @sql = @sql + 'FROM SP_YCDJ ';
	
	IF @GSID>0
	BEGIN
		SET @sql = @sql + @prefix + ' GSID=' + CAST(@GSID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @TSFS>-1
	BEGIN
		SET @sql = @sql + @prefix + ' TSFS=' + CAST(@TSFS AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @TYDID>0
	BEGIN
		SET @sql = @sql + @prefix + ' TYDID=' + CAST(@TYDID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @THRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' THRQ>=''' + @THRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @THRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' THRQ<=''' + @THRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @YDRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' YDRQ>=''' + @YDRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @YDRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' YDRQ<=''' + @YDRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	

    IF @LXHBH<>''
	BEGIN
		SET @sql = @sql + @prefix + ' LXHBH=''' + @LXHBH+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @CLWC=0 or @CLWC=1
	BEGIN
		SET @sql = @sql + @prefix + ' CLWC=' + CAST(@CLWC AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	
	IF @VBELN<>'' or @WLBH<>'' or @WLMS<>''
	BEGIN
		SET @sql = @sql + @prefix +' YCDJID IN ( ';
		SET @sql = @sql + +'SELECT YCDJID ';
		SET @sql = @sql + +'FROM SP_YCDJQD ';
		SET @prefix = 'WHERE ';
		
		IF @VBELN<>''
		BEGIN
			SET @sql = @sql + @prefix + ' VBELN=''' + @VBELN+'''';
			SET @prefix = ' AND ';
		END	
	
		IF @WLBH<>''
		BEGIN
			SET @sql = @sql + @prefix + ' LXHBH=''' + @WLBH+'''';
			SET @prefix = ' AND ';
		END	
	
		IF @WLMS<>''
		BEGIN
			SET @sql = @sql + @prefix + ' WLMS LIKE ''%' + @WLMS +'%''';
			SET @prefix = ' AND ';
		END	
		
		SET @sql = @sql + +') ';
	END
			
	SET @sql = @sql+';';
	--SELECT 	@sql;
	EXEC sp_executesql @sql;
END
GO