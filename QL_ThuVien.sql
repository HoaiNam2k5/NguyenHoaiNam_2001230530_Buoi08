CREATE DATABASE QL_ThuVien;

GO

USE QL_ThuVien;
GO
-- Bảng Tác Giả
CREATE TABLE TacGia (
    MaTacGia INT IDENTITY(1,1) PRIMARY KEY,
    TenTacGia NVARCHAR(100) NOT NULL,
    GioiThieu NVARCHAR(MAX) NULL
);

-- Bảng Chủ Đề
CREATE TABLE ChuDe (
    MaChuDe INT IDENTITY(1,1) PRIMARY KEY,
    TenChuDe NVARCHAR(100) NOT NULL
);

-- Bảng Nhà Xuất Bản
CREATE TABLE NhaXuatBan (
    MaNXB INT IDENTITY(1,1) PRIMARY KEY,
    TenNXB NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(200) NULL,
    DienThoai VARCHAR(15) NULL
);

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(15)
);

-- Bảng Sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200) NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL,
    MoTa NVARCHAR(MAX),
    AnhBia NVARCHAR(250),
    NgayCapNhat DATE,
    SoLuong INT NOT NULL,
    MaChuDe INT NOT NULL,
    MaNXB INT NOT NULL,
    FOREIGN KEY (MaChuDe) REFERENCES ChuDe(MaChuDe),
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)
);

-- Bảng Đơn Đặt Hàng
CREATE TABLE DonDatHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NOT NULL,
    NgayDat DATE NOT NULL,
    NgayGiao DATE NULL,
    TrangThai NVARCHAR(50),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- Bảng Chi Tiết Đơn Hàng
CREATE TABLE ChiTietDonHang (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL,
    MaSach INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (MaDonHang) REFERENCES DonDatHang(MaDonHang),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Bảng Viết Sách (Quan hệ giữa Tác Giả và Sách, nhiều-nhiều)
CREATE TABLE VietSach (
    MaTacGia INT NOT NULL,
    MaSach INT NOT NULL,
    PRIMARY KEY (MaTacGia, MaSach),
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);
-- Dữ liệu bảng Tác Giả
INSERT INTO TacGia (TenTacGia, GioiThieu) VALUES
(N'Nguyễn Nhật Ánh', N'Nhà văn nổi tiếng với các tác phẩm dành cho thiếu nhi'),
(N'Haruki Murakami', N'Nhà văn Nhật Bản nổi tiếng với phong cách hiện thực huyền ảo'),
(N'J.K. Rowling', N'Tác giả bộ truyện Harry Potter'),
(N'George Orwell', N'Tác giả 1984 và Animal Farm'),
(N'Gabriel García Márquez', N'Nhà văn Colombia, tác phẩm tiêu biểu: Trăm năm cô đơn');

-- Dữ liệu bảng Chủ Đề
INSERT INTO ChuDe (TenChuDe) VALUES
(N'Văn học'),
(N'Khoa học'),
(N'Lịch sử'),
(N'Tâm lý học'),
(N'Công nghệ');

-- Dữ liệu bảng Nhà Xuất Bản
INSERT INTO NhaXuatBan (TenNXB, DiaChi, DienThoai) VALUES
(N'NXB Trẻ', N'123 Đường A, TP.HCM', '0281234567'),
(N'NXB Kim Đồng', N'456 Đường B, Hà Nội', '0247654321'),
(N'NXB Văn Học', N'789 Đường C, Đà Nẵng', '0511239876'),
(N'NXB Giáo Dục', N'135 Đường D, Cần Thơ', '0731123456'),
(N'NXB Tổng Hợp', N'246 Đường E, Hải Phòng', '0225123456');

-- Dữ liệu bảng Khách Hàng
INSERT INTO KhachHang (TenKH, DiaChi, DienThoai) VALUES
('Nguyễn Văn A', 'Hà Nội', '0987654321'),
('Trần Thị B', 'TP.HCM', '0912345678'),
('Lê Văn C', 'Đà Nẵng', '0933456789'),
('Phạm Thị D', 'Cần Thơ', '0978123456'),
('Hoàng Văn E', 'Hải Phòng', '0909876543');

-- Dữ liệu bảng Sách
INSERT INTO Sach (TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuong, MaChuDe, MaNXB) VALUES
(N'Dế Mèn Phiêu Lưu Ký', 50000, N'Truyện thiếu nhi kinh điển', '~/IMG/demo1.jpg', '2025-01-01', 50, 1, 2),
(N'Kafka bên bờ biển', 120000, N'Tiểu thuyết hiện thực huyền ảo', '~/IMG/demo2.jpg', '2025-02-15', 30, 1, 3),
(N'Harry Potter và Hòn đá phù thủy', 150000, N'Bắt đầu hành trình của Harry Potter', '~/IMG/demo3.jpg', '2025-03-20', 40, 1, 2),
(N'1984', 90000, N'Tiểu thuyết phản địa đàng', '~/IMG/demo4.jpg', '2025-04-10', 25, 3, 5),
(N'Trăm năm cô đơn', 110000, N'Tác phẩm văn học Mỹ Latinh nổi bật', '~/IMG/demo5.jpg', '2025-05-05', 20, 1, 1);

-- Dữ liệu bảng Đơn Đặt Hàng
INSERT INTO DonDatHang (MaKH, NgayDat, NgayGiao, TrangThai) VALUES
(1, '2025-10-01', '2025-10-10', 'Đã giao'),
(2, '2025-10-05', NULL, 'Đang xử lý'),
(3, '2025-10-07', '2025-10-15', 'Đã giao'),
(4, '2025-10-09', NULL, 'Đang xử lý'),
(5, '2025-10-10', NULL, 'Chờ xác nhận');

-- Dữ liệu bảng Chi Tiết Đơn Hàng
INSERT INTO ChiTietDonHang (MaDonHang, MaSach, SoLuong, DonGia) VALUES
(1, 1, 2, 50000),
(1, 3, 1, 150000),
(2, 2, 1, 120000),
(3, 4, 3, 90000),
(5, 5, 1, 110000);

-- Dữ liệu bảng Viết Sách (Quan hệ nhiều-nhiều TacGia - Sach)
INSERT INTO VietSach (MaTacGia, MaSach) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

