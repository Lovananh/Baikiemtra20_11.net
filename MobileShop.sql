create database MobileShop
use MobileShop
create table Sanpham
(
 id int primary key identity(1,1),
 tenSP nvarchar (50) not null ,
 gia decimal not null,
 hangSX nvarchar(30) not null
)
go
INSERT INTO Sanpham (tenSP, gia, hangSX) VALUES
('iPhone 14', 999.99, 'Apple'),
('Samsung Galaxy S23', 899.99, 'Samsung'),
('Xiaomi Mi 13', 499.99, 'Xiaomi'),
('MacBook Pro', 1999.99, 'Apple'),
('Dell XPS 13', 1499.99, 'Dell');
go
create table Khachhang
(
 id int primary key identity(1,1),
 tenKH nvarchar (40) not null ,
 diachi nvarchar (50) not null ,
 sdt nvarchar (15) not null
)
go
INSERT INTO KhachHang (tenKH, diachi, sdt)
VALUES
('Nguyen Dang An',' Da Nang', '0905123456'),
('Tran Quoc Viet', 'Ha Noi', '0987654321'),
('Le Van Anh', ' Ho Chi Minh', '0912345678');
go
create table Donhang
(
 id int primary key identity(1,1) ,
 khachhangid int not null,
 sanphamid int not null,
 soluong int not null,
 ngaymua date not null,
  FOREIGN KEY (khachhangid) REFERENCES Khachhang(id),
  FOREIGN KEY (sanphamid) REFERENCES Sanpham(id)
)
go
INSERT INTO DonHang (khachhangid, sanphamid, soluong, ngaymua)
VALUES
(1, 1, 1, '2024-01-15'),
(2, 2, 2, '2024-02-20'),
(3, 3, 1, '2024-03-05'),
(1, 4, 1, '2024-04-10'),
(2, 5, 2, '2024-05-25');
go
create table Nguoidung
(
id int primary key identity(1,1),
tendangnhap nvarchar (30) not null,
matkhau nvarchar (10) not null
)
go
INSERT INTO NguoiDung (tendangnhap, matkhau)
VALUES
('admin', '123456'),
('anh', 'pass1'),
('user', 'pass2');
go