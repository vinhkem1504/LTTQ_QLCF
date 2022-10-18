Create database QLCafe

Use QLCafe
Go

create table NhanVien
(
	MaNV			varchar(100) primary key not null,
	HoTen			nvarchar(255) not null,
	DiaChi			nvarchar(255) not null,
	SDT				varchar(20) not null,
	NgaySinh		datetime not null,
	NgayNhanViec	datetime not null,
	Luong			money not null, -- Cần xem lại
)

Create table TaiKhoan
(
	TenTK	nvarchar(100) primary key not null,
	MaNV	varchar(100) references NhanVien(MaNV) not null,
	MatKhau varchar(100) not null default 1,
	LoaiTK	bit not null default 1, --0: Quản lý, 1: Nhân viên
)

Create table NhaCungCap
(
	MaNCC	varchar(100) primary key not null,
	TenNCC	nvarchar(255) not null,
	SDT		varchar(255) not null,
	DiaChi	nvarchar(255) not null
)

Create table NguyenLieu
(
	MaNL		varchar(100) primary key not null,
	TenNL		nvarchar(255) not null,
	DonVi		nvarchar(10) not null,
	DonGia		money not null,
	SoLuongTon  float not null
)

Create table DoUong
(
	MaDU	varchar(100) primary key not null,
	TenDU	nvarchar(255) not null default N'Đồ uống chưa có tên',
	DonGia	money not null
)

Create table CongThucDoUong
(
	MaDU	varchar(100) references DoUong(MaDU) not null,
	MaNL	varchar(100) references NguyenLieu(MaNL) not null,
	SoLuong float null
)

create table HoaDonNhap
(
	MaHDN	varchar(100) primary key not null,
	MaNCC	varchar(100) references NHACUNGCAP(MaNCC) not null,
	MaNV	varchar(100) references NhanVien(MaNV) not null,
	NgayLap datetime not null
)

Create table ChiTietHDN
(
	MaHDN	varchar(100) references HoaDonNhap(MaHDN) not null,
	MaNL	varchar(100) references NguyenLieu(MaNL) not null,
	SoLuong float null
)

create table HoaDonBan
(
	MaHDB		varchar(100) primary key not null,
	MaNV		varchar(100) references NhanVien(MaNV) not null,
	NgayLap		datetime not null,
	TrangThai	bit not null default 1 --0: Đã thanh toán, 1: Chưa thanh toán
)

create table ChiTietHDB
(
	MaHDB		varchar(100) references HoaDonBan(MaHDB) not null,
	MaDU		varchar(100) references DoUong(MaDU) not null,
	SoLuong		int null,
	KhuyenMai	nvarchar(255) null
)

-- Nhập dữ liệu NhanVien
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec, Luong) values ('NV01', N'Y Lon Mớt', N'New York', '03582331352', cast(N'1971-06-28T00:00:00.000' as datetime), cast(N'2014-09-11T00:00:00.000' as datetime), 3000000)

-- Nhập dữ liệu TaiKhoan
--insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK) values ()

-- Nhập dữ liệu NhaCungCap
--insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values ()

-- Nhập dữ liệu NguyenLieu
--insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values ()

--Nhập dữ liệu DoUong
--insert DoUong(MaDU, TenDU, DonGia) values ()

-- Nhập dữ liệu HoaDonBan
--insert HoaDonBan(MaHDB, MaNV, NgayLap) values ()

-- Nhập dữ liệu ChiTietHDB
--insert ChiTietHDB(MaHDB, MaDoUong, SoLuong, KhuyenMai) values ()

-- Nhập dữ liệu HoaDonNhap
--insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values ()

-- Nhập dữ liệu ChiTietHDN
--insert ChiTietHDN(MaHDN, MaNL, SoLuong) values ()
