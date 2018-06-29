use master
drop database QLDL
GO

create database [QLDL]
GO
use [QLDL]
GO


create table [HOSODAILY](
[MaDaiLy] int identity (1000,1) primary key,
[TenDaiLy] varchar(20),
[MaLoaiDaiLy] int,
[DienThoai] varchar(10),
[DiaChi] varchar(50),
[MaQuan] int,
[NgayTiepNhan] smalldatetime,
[Email] varchar(50),
[NoCuaDaiLy] int,
)
GO

create table [LOAIDAILY](
[MaLoaiDaiLy] int identity (1,1) primary key,
[TenLoaiDaiLy] varchar(20),
[NoToiDa] int,
)
GO
drop table LOAIDAILY 

create table [QUAN](
[MaQuan] int identity (1,1) primary key,
[TenQuan] varchar(20),
[SoLuongDaiLyToiDa] int,
)
drop table QUAN
GO

create table [THAMSO](
[SoLuongDaiLyToiDa] int,
)
GO

create table [PHIEUXUAT](
[MaPhieuXuat] int identity (1000,1) primary key,
[NgayLapPhieu]smalldatetime,
[TongTriGia] int,
)

GO

create table [MATHANG](
[MaMatHang] int identity (1000,1) primary key,
[TenMatHang] varchar(20),
[SoLuongTon] int,
)
GO

create table [DONVITINH](
[MaDonViTinh] int identity (1,1) primary key,
[TenDonViTinh] varchar(20),
)
GO


create table [CHITIETPHIEUXUAT](
[MaChiTietPhieu]int identity (1000,1) primary key,
[MaPhieuXuat]int,
[MaMatHang]int,
[MaDonViTinh]int,
[SoLuongXuat]int,
[DonGia]int,
[ThanhTien]int,
)
GO

create table [PHIEUTHUTIEN](
[MaPhieuThuTien] int identity(1,1) primary key,
[MaDaiLy] int,
[NgayThuTien]smalldatetime,
[SoTienThu] int,
)
GO
 
create table [BAOCAODOANHSO](
[MaPhieuDoanhSo] int identity(1,1) primary key,
[MaDaiLy] int,
[Thang]smalldatetime,
[SoPhieuXuat] int,
[TongTriGia] int,
[TyLe] float, 
)
GO

create table[BAOCAOCONGNO](
[MaPhieuCongNo]int identity (1,1) primary key,
[MaDaiLy] int,
[Thang]smalldatetime,
[NoDau]int,
[PhatSinh]int,
[NoCuoi]int,
)
GO
DROP TABLE BAOCAOCONG
insert into [QUAN] ([TenQuan],[SoLuongDaiLyToiDa]) values ('quan 1', '1')
insert into [QUAN] ([TenQuan],[SoLuongDaiLyToiDa]) values ('quan 2', '4')
insert into [QUAN] ([TenQuan],[SoLuongDaiLyToiDa]) values ('quan 3', '2')
insert into [LOAIDAILY] ([TenLoaiDaiLy],[NoToiDa]) values ('Loai1','20000')
insert into [LOAIDAILY] ([TenLoaiDaiLy],[NoToiDa]) values ('Loai2','30000')
insert into [LOAIDAILY] ([TenLoaiDaiLy],[NoToiDa]) values ('Loai3','40000')

DELETE FROM HOSODAILY 
WHERE MaDaiLy =1008;
GO