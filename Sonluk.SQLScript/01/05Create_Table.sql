--新建"打印布局"数据表01
CREATE TABLE Sonluk_Print_Layout(
  ID INT PRIMARY KEY ,
  Doc VARCHAR2(30),
  Mac VARCHAR2(30),
  Name NVARCHAR2(30),
  Background NVARCHAR2(50),
  Style NVARCHAR2(200),
  Remark NVARCHAR2(50),
  Status INT DEFAULT 1
  );
  
--新建"打印布局控件"数据表02
CREATE TABLE Sonluk_Print_Control(
  ID INT PRIMARY KEY ,
  Type VARCHAR2(30),
  Layout INT,
  Value VARCHAR2(30),
  Style NVARCHAR2(200),
  Status INT DEFAULT 1,
  FOREIGN KEY(Layout) REFERENCES Sonluk_Print_Layout(ID)
  );
   



  
  
  
  