USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Feedback_Select]
	@GSID int = 0,
	@DZ varchar(50) = ' ',
	@TYDID int = 0,
	@FHRQ_LEFT varchar(10) = ' ',
	@FHRQ_RIGHT varchar(10) = ' ',
	@HDRQ_LEFT varchar(10) = ' ',
	@HDRQ_RIGHT varchar(10) = ' ',
	@HDMEMO varchar(1000) = ' ',
	@BZ varchar(500) = ' '
AS
BEGIN
	DECLARE 
		@sql nvarchar(2000),
		@prefix varchar(5); 
	
	SET @prefix = 'WHERE ';
	SET @sql = '';		
	SET @sql = @sql + 'SELECT * ';
	SET @sql = @sql + 'FROM SP_HDQR ';
	
	IF @GSID>0
	BEGIN
		SET @sql = @sql + @prefix + ' GSID=' + CAST(@GSID AS VARCHAR);
		SET @prefix = ' AND ';
	END	
	
	IF @HDRQ_LEFT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' HDRQ>=''' + @HDRQ_LEFT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @HDRQ_RIGHT<>''
	BEGIN
		SET @sql = @sql + @prefix + ' HDRQ<=''' + @HDRQ_RIGHT+'''';
		SET @prefix = ' AND ';
	END	
	
	IF @HDMEMO<>''
	BEGIN
		SET @sql = @sql + @prefix + ' HDMEMO LIKE ''%' + @HDMEMO +'%''';
		SET @prefix = ' AND ';
	END	
		
		
	IF @DZ<>'' or @TYDID<>0 or @FHRQ_LEFT<>'' or @FHRQ_RIGHT<>'' or @BZ<>''
	BEGIN
		SET @sql = @sql + @prefix +' HDQRID IN ( ';
		SET @sql = @sql + +'SELECT HDQRID ';
		SET @sql = @sql + +'FROM SP_HDQRMX ';
		SET @prefix = 'WHERE ';
		
		IF @DZ<>''
		BEGIN
			SET @sql = @sql + @prefix + ' DZ=''' + @DZ+'''';
			SET @prefix = ' AND ';
		END	
	
		IF @TYDID>0
		BEGIN
			SET @sql = @sql + @prefix + ' TYDID=' + CAST(@TYDID AS VARCHAR);
			SET @prefix = ' AND ';
		END	
		
		IF @FHRQ_LEFT<>''
		BEGIN
			SET @sql = @sql + @prefix + ' FHRQ>=''' + @FHRQ_LEFT+'''';
			SET @prefix = ' AND ';
		END	
	
		IF @FHRQ_RIGHT<>''
		BEGIN
			SET @sql = @sql + @prefix + ' FHRQ<=''' + @FHRQ_RIGHT+'''';
			SET @prefix = ' AND ';
		END	
		
		IF @BZ<>''
		BEGIN
			SET @sql = @sql + @prefix + ' BZ LIKE ''%' + @BZ +'%''';
			SET @prefix = ' AND ';
		END	
		
		SET @sql = @sql + +') ';
	END	
				
	SET @sql = @sql+';';
	--SELECT 	@sql;
	EXEC sp_executesql @sql;
END
GO