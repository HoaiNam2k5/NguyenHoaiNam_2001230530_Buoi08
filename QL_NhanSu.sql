CREATE DATABASE QL_NHANSU;
GO
USE QL_NHANSU;
GO

-- Bảng phòng ban
CREATE TABLE TBL_DEPARMENT (
    Deptld INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50)
);

-- Bảng nhân viên
CREATE TABLE TBL_EMPLOYEE (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50),
    Gender NVARCHAR(10),
    City NVARCHAR(100),
    ImgFace NVARCHAR(200),
    Deptld INT,
    FOREIGN KEY (Deptld) REFERENCES TBL_DEPARMENT(Deptld)
);

-- Thêm dữ liệu mẫu
INSERT INTO TBL_DEPARMENT (Name) VALUES
(N'Khoa CNTT'),
(N'Khoa Ngoại Ngữ'),
(N'Khoa Tài Chính'),
(N'Khoa Thực Phẩm'),
(N'Phòng Đào Tạo');

-- Vì Deptld tự tăng, nên chỉ cần nêu các cột cần thiết
INSERT INTO TBL_EMPLOYEE (Name, Gender, City, ImgFace, Deptld) VALUES
(N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', '~/IMG/NV1.jpg', 1),
(N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', '~/IMG/NV2.jpg', 2),
(N'Đinh Duy Mạnh', N'Nam', N'Thái Bình', '~/IMG/NV3.jpg', 1),
(N'Ngô Thị Nguyệt', N'Nữ', N'Long An', '~/IMG/NV4.jpg', 1),
(N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', '~/IMG/NV5.jpg', 4),
(N'Phan Ngọc Mai', N'Nữ', N'Bến Tre', '~/IMG/NV6.jpg', 3),
(N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'Đà Lạt', '~/IMG/NV7.jpg', 2),
(N'Lê Thanh Liêm', N'Nữ', N'TP.HCM', '~/IMG/NV8.jpg', 5);

-- Kiểm tra cấu trúc bảng nhân viên
EXEC sp_help TBL_EMPLOYEE;
GO