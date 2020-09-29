--01插入控件，并返回其ID
CREATE OR REPLACE PROCEDURE Sonluk_Print_Control_Insert(
  v_Type IN VARCHAR2,
  v_Layout IN INT,
  v_Value IN VARCHAR2,
  v_Style IN NVARCHAR2,
  v_ID OUT INT)
AS
BEGIN 
  INSERT 
  INTO Sonluk_Print_Control
  VALUES(Sonluk_Print_Control_ID.NEXTVAL,v_Type,v_Layout,v_Value,v_Style,1);

  SELECT Sonluk_Print_Control_ID.CURRVAL
  INTO v_ID 
  FROM DUAL; 
  
  COMMIT;
END;

--02更新控件
CREATE OR REPLACE PROCEDURE Sonluk_Print_Control_Update(
  v_ID IN INT,
  v_Value IN VARCHAR2,
  v_Style IN NVARCHAR2)
AS
BEGIN
  UPDATE Sonluk_Print_Control
  SET Value=v_Value,Style=v_Style
  WHERE ID = v_ID;
	COMMIT;
END;

--03删除
CREATE OR REPLACE PROCEDURE Sonluk_Print_Control_Delete(v_ID IN INT)
AS
BEGIN  
  DELETE
  FROM Sonluk_Print_Control
  WHERE ID = v_ID;
  COMMIT;
END;