create database BookStore
use BookStore
go
CREATE TABLE THELOAITIN(
IDLoai int NOT NULL PRIMARY KEY ,
Tentheloai nvarchar(100));
CREATE TABLE TINTUC(
IdTin int NOT NULL PRIMARY KEY,
IDLoai int,
TieuDeTin nvarchar(100),
Noidungtin nText,
FOREIGN KEY (IDLoai) REFERENCES THELOAITIN(IDLoai)
);
INSERT INTO THELOAITIN VALUES 
(1,N'Thể thao'),
(2,N'Kinh tế'),
(3,N'Thế giới')
insert into TINTUC values 
(1,1,N'Giật gân','ABC'),
(2,2,N'Kinh tế nóng','ABC'),
(3,3,N'Ronando','ABC')
