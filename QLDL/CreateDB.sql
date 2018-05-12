use master
GO

create database [QLDL]
GO
use [QLDL]
GO

create table [HOSODAILY](
[MaDaiLy] int identity (1000,1) primary key,
[Ten] varchar(20),
[MaLoaiDaiLy] int,
[DienThoai] varchar(10),
[DiaChi] varchar(50),
[MaQuan] int,
[NgayTiepNhan] smalldatetime,
[Email] varchar(50)
)
GO

create table [LOAIDAILY](
[MaLoaiDaiLy] int identity (1,1) primary key,
[TenLoaiDaiLy] varchar(20),
)
GO

create table [QUAN](
[MaQuan] int identity (1,1) primary key,
[TenQuan] varchar(20),
[SoLuongDaiLyToida] int,
)

GO

insert into [QUAN] ([TenQuan],[SoLuongDaiLyToida]) values ('quan 1', '1')
insert into [QUAN] ([TenQuan],[SoLuongDaiLyToida]) values ('quan 2', '4')
insert into [QUAN] ([TenQuan],[SoLuongDaiLyToida]) values ('quan 3', '2')
insert into [LOAIDAILY] ([TenLoaiDaiLy]) values ('1')
insert into [LOAIDAILY] ([TenLoaiDaiLy]) values ('2')
GO