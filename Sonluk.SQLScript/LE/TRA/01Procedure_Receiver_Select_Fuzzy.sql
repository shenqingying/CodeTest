USE [HGMM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LE_TRA_Receiver_Select_Fuzzy]
	@keyword varchar(100)= ' '
AS
BEGIN
	DECLARE 
		@keywordFuzzy varchar(100);

	SET @keywordFuzzy= '%' +@keyword+'%';
		
	SELECT b.SHRID SHRID,SHRJC,SHRDW,SAPNO,
		b.isDef SHRisDef,SHRDZID,DZMC,LXR,LXDH,
		SJ,ZDID,ZDMC,a.isDef SHRDZisDef 
	FROM SP_SHRDZ a 
		LEFT JOIN SP_SHR b 
		ON a.SHRID= b.SHRID 
	WHERE DZMC LIKE @keywordFuzzy 
		OR DZMC LIKE @keywordFuzzy
		OR LXR LIKE @keywordFuzzy
		OR LXDH LIKE @keywordFuzzy
		OR SJ LIKE @keywordFuzzy
		OR SHRDW LIKE @keywordFuzzy
		OR SAPNO = @keyword;			
		
END
GO