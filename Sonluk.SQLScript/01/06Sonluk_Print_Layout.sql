--01插入布局，并返回其ID
CREATE OR REPLACE PROCEDURE Sonluk_Print_Layout_Insert(
  v_Doc IN VARCHAR2,
  v_Mac IN VARCHAR2,
  v_Name IN NVARCHAR2,
  v_Background IN NVARCHAR2,
  v_Style IN VARCHAR2,
  v_Remark IN VARCHAR2,
  v_ID OUT INT)
AS
BEGIN 
  INSERT 
  INTO Sonluk_Print_Layout
  VALUES(Sonluk_Print_Layout_ID.NEXTVAL,v_Doc,v_Mac,v_Name,v_Background,v_Style,v_Remark,1);

  SELECT Sonluk_Print_Layout_ID.CURRVAL
  INTO v_ID 
  FROM DUAL; 
  
  COMMIT;
END;

--02更新布局
CREATE OR REPLACE PROCEDURE Sonluk_Print_Layout_Update(
  v_ID IN INT,
  v_Doc IN VARCHAR2,
  v_Mac IN VARCHAR2,
  v_Name IN NVARCHAR2,
  v_Background IN NVARCHAR2,
  v_Style IN VARCHAR2,
  v_Remark IN VARCHAR2)
AS
BEGIN
  UPDATE Sonluk_Print_Layout
  SET Doc=v_Doc,Mac=v_Mac,Name=v_Name,Background=v_Background,Style=v_Style,Remark=v_Remark
  WHERE ID = v_ID;
	COMMIT;
END;

--03删除布局
CREATE OR REPLACE PROCEDURE Sonluk_Print_Layout_Delete(v_ID IN INT)
AS
BEGIN  
  DELETE
  FROM Sonluk_Print_Control
  WHERE  Layout= v_ID;
  
  DELETE
  FROM Sonluk_Print_Layout
  WHERE ID = v_ID;
  COMMIT;
END;