--01µÇÂ¼ÑéÖ¤£¬·µUID
CREATE OR REPLACE PROCEDURE Sonluk_Account_SignIn(
	v_Name_Confirm IN VARCHAR2,
	v_PasswordHash_Confirm IN VARCHAR2,
  v_SN OUT INT)
AS
  v_PasswordHash VARCHAR2(100);
  v_Count INT;
BEGIN
  v_SN:=0;

  SELECT COUNT(STAFFID)
  INTO v_Count
  FROM HG_STAFF
  WHERE STAFFUSER=v_Name_Confirm;

  IF v_Count=1 THEN
    SELECT STAFFPW
    INTO v_PasswordHash
    FROM HG_STAFF
    WHERE STAFFUSER=v_Name_Confirm;
    
    IF v_PasswordHash = v_PasswordHash_Confirm THEN
      SELECT STAFFID
      INTO v_SN
      FROM HG_STAFF
      WHERE STAFFUSER=v_Name_Confirm AND STAFFPW=v_PasswordHash_Confirm;
    END IF;   
  END IF;
END;


--02ÐÞ¸ÄÃÜÂë
CREATE OR REPLACE PROCEDURE Sonluk_Account_ChangePassword(
	v_SN IN VARCHAR2,
  v_PasswordHash_Confirm IN VARCHAR2,
	v_New_PasswordHash IN VARCHAR2,
  v_Success OUT NUMBER)
AS
  v_PasswordHash VARCHAR2(100);
  v_Count INT;
BEGIN
  v_Success:=0;
  
  SELECT COUNT(STAFFID)
  INTO v_Count
  FROM HG_STAFF
  WHERE STAFFID=v_SN;

  IF v_Count=1 THEN
    SELECT STAFFPW
    INTO v_PasswordHash
    FROM HG_STAFF
    WHERE STAFFID=v_SN; 
    
    IF v_PasswordHash = v_PasswordHash_Confirm AND v_PasswordHash_Confirm<>v_New_PasswordHash THEN
      UPDATE HG_STAFF
      SET STAFFPW = v_New_PasswordHash
      WHERE STAFFID =v_SN;
      
      v_Success:=1;
    END IF;   
  END IF;
END;


