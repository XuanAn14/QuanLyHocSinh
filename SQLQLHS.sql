Create Database QLHS

Use QLHS

Create Table MonHoc
(
	MaMH varchar(10) not null,
	TenMH nvarchar(50) not null,
	primary key(MaMH)
)

Create Table Lop
(
	MaLop varchar(10) primary key,
	KhoiLop varchar(5) not null,
	TenLop varchar(5) not null
)

Create Table HocSinh
(
	MaHS varchar(10) primary key,
	HoVaTen nvarchar(50) not null,
	GioiTinh nvarchar(3) not null,
	NgaySinh varchar(30) not null,
	DiaChi nvarchar(50) not null,
	Email varchar(50) not null,
	MaLop varchar(10) foreign key references Lop(MaLop)
)

Create Table Diem
(
	MaDiem varchar(10) primary key,
	MaHS varchar(10) foreign key references HocSinh(MaHS),
	MaMH varchar(10) foreign key references MonHoc(MaMH),
	HocKy int check(HocKy>0) not null,
	Diem15p float not null,
	Diem1Tiet float not null
)

Create Table BCTongKetMon
(
	MaBCTongKetMon varchar(10) primary key,
	MaLop varchar(10) foreign key references Lop(MaLop),
	HocKy int check(HocKy>0) not null,
	MaMH varchar(10) foreign key references MonHoc(MaMH),
	SoLuongDat int not null,
	TiLe float not null
)

Create Table ThayDoiQuyDinh
(
	TuoiToiThieu int not null,
	TuoiToiDa int not null,
	SiSoMax int not null,
	SoLuongLop int not null,
	SoLuongMon int not null,
	DiemDat int not null
	
)

Create Table TaiKhoan
(
	MaTK varchar(10) primary key,
	TenNguoiDung varchar(30) not null,
	MatKhau varchar(30) not null,

)

Insert into MonHoc
values
('MH01',N'Thiết kế đồ họa'),
('MH02',N'Lập trình cơ bản'),
('MH03',N'Xây dựng ứng dụng cơ bản')

Insert into Lop
values 
('LH01','CNT', '08'),
('LH02','TKD', '01')

Insert into HocSinh
values 
('SV01', N'Nguyễn Xuân An', N'Nam', '14/03/2003', N'Hà Nội', 'anxuan1234@gmail.com', 'LH01'),
('SV02', N'Nguyễn Thái Hà', N'Nam', '01/08/2003', N'Hà Nội', 'thaiha1234@gmail.com', 'LH01'),
('SV03', N'Phạm Ngọc Huy', N'Nam', '01/01/2003', N'Hà Nội', 'phamhuy1234@gmail.com', 'LH02'),
('SV04', N'Ngô Quý Tuấn', N'Nam', '01/10/2002', N'Hà Nội', 'ngoqtuan@gmail.com', 'LH01'),
('SV05', N'Đinh Văn Tú', N'Nam', '02/02/2001', N'Hà Nội', 'vantu@gmail.com', 'LH02')

Insert into Diem
values 
('MD01', 'SV01', 'MH01',1, 8,9),
('MD02', 'SV02', 'MH02',1, 7,7),
('MD03', 'SV03', 'MH03',1, 8,7)

Insert into ThayDoiQuyDinh
values
(17,50,70,10,9, 5)

Insert into TaiKhoan
values 
('ADMIN', 'admin','admin1234')


create proc [dbo].[ThemMH]
	@MaMH varchar(10),
	@TenMH nvarchar(20)
as
begin
    insert into MonHoc values (@MaMH, @TenMH)
end

create proc [dbo].[ThemHocSinh]
@MaHS varchar(10),
@HoVaTen nvarchar(50),
@GioiTinh nvarchar(3) ,
@NgaySinh date,
@DiaChi nvarchar(50),
@Email varchar(50),
@MaLop varchar(10)
as
begin
    insert into HocSinh values (@MaHS,@HoVaTen,@GioiTinh, @NgaySinh, @DiaChi, @Email,@MaLop)
end

create proc [dbo].[ThemLop]
@MaLop varchar(10),
@KhoiLop varchar(5),
@TenLop varchar(5),
@SiSo int
as
begin
    insert into Lop values (@MaLop,@KhoiLop,@TenLop, @SiSo)
end

create proc [dbo].[ThemDiem]
	@MaDiem varchar(10),
	@MaHS varchar(10),
	@MaMH varchar(10),
	@HocKy int,
	@Diem15p float,
	@Diem1Tiet float
as
begin
    insert into Diem values (@MaDiem,@MaHS,@MaMH, @HocKy,@Diem15p, @Diem1Tiet)
end

create proc [dbo].[ThemBCMon]
	@MaBCTongKetMon varchar(10),
	@MaLop varchar(10),
	@HocKy int,
	@MaMH varchar(10),
	@SoLuongDat int,
	@TiLe float
as
begin
    insert into BCTongKetMon values (@MaBCTongKetMon,@MaLop,@HocKy,@MaMH,@SoLuongDat, @TiLe)
end

create proc [dbo].[ThemTaiKhoan]
	@MaTK varchar(10),
	@TenNguoiDung varchar(30),
	@MatKhau varchar(30)
as
begin
    insert into TaiKhoan values (@MaTK,@TenNguoiDung,@MatKhau)
end

create proc [dbo].[ThemThayDoiQuyDinh]
	@TuoiToiThieu int,
	@TuoiToiDa int,
	@SiSoMax int,
	@SoLuongLop int,
	@SoLuongMon int,
	@DiemDat int
as
begin
    insert into ThayDoiQuyDinh values (@TuoiToiThieu,@TuoiToiDa,@SiSoMax,@SoLuongLop,@SoLuongMon,@DiemDat)
end
