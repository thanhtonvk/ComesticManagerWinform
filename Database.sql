use master
go
create database qlmypham
go
use qlmypham
go
create table TaiKhoan(
    TenDangNhap nvarchar(20) primary key ,
    MatKhau nvarchar(20) not null,
    LoaiTK nvarchar(10)
)
go
create table LoaiSanPham(
    MaLoai int identity primary key ,
    TenLoai nvarchar(50)
)
go
create table DaiLy(
    MaDL int identity primary key ,
    TenDL nvarchar(50),
    SDT char(10),
    DiaChi nvarchar(100)
)
go
create table NhanVien(
    MaNV int identity  primary key ,
    TenNV nvarchar(50),
    SDT char(10),
    DiaChi nvarchar(50),
)
go
create table SanPham(
    MaSP int identity primary key ,
    TenSP nvarchar(50),
    MaLoai int not null,
    NgaySX date,
    HanSD date,
    SoLo int,
    DonGia int
)
go
create table HoaDonBan(
    MaHD int primary key ,
    NgayBan date,
    TenKhach nvarchar(50),
    SDT char(10),
    DiaChi nvarchar(100),
    MaNV int not null,
    TongTien int
)
go
create table ChiTietHDB(
    MaHD int not null,
    MaSP int not null,
    constraint pk_chitiethdb primary key (MaHD,MaSP),
    GiaBan int,
    SoLuong int,
    ThanhTien int
)
go
create table HoaDonNhap(
    MaHD int not null primary key ,
    NgayNhap date,
    MaDL int,
    TongTien int
)
go
create table ChiTietHDN(
    MaHD int not null,
    MaSP int not null,
    GiaNhap int,
    SoLuong int,
    ThanhTien int
)