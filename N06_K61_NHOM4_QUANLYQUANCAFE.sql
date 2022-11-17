Create database QLCafe
--drop database QLCafe

Go
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
	Luong           money not null
)
go
create table CaLam
(
	MaCa		varchar(100) primary key not null,
	TenCa         nvarchar(100) not null,
)
go
create table ChiTietCaLam(
	MaNV varchar(100) not null,
	MaCa varchar(100) not null,
	NgayLamViec date not null,
	primary key (MaNV,MaCa,NgayLamViec),
	foreign key(MaNV) references NhanVien(MaNV),
	foreign key(MaCa) references CaLam(MaCa)
)
go
create table ChiTietLuong(
	MaNV varchar(100) not null,
	Thang int not null,
	Nam  int not null,
	SoNgayLamViec int null,
	Luong money null,
	primary key (MaNV,Thang,Nam),
	foreign key(MaNV) references NhanVien(MaNV)
)
go
create table TaiKhoan
(
	TenTK	nvarchar(100) primary key not null,
	MaNV	varchar(100) references NhanVien(MaNV) not null,
	MatKhau varchar(100) not null default 1,
	LoaiTK	bit not null default 1, --0: Quản lý, 1: Nhân viên
	Email varchar(100) not null
)
go
create table NhaCungCap
(
	MaNCC	varchar(100) primary key not null,
	TenNCC	nvarchar(255) not null,
	SDT		varchar(255) not null,
	DiaChi	nvarchar(255) not null
)
go
create table NguyenLieu
(
	MaNL		varchar(100) primary key not null,
	TenNL		nvarchar(255) not null,
	DonVi		nvarchar(10) not null,
	DonGia		money not null,
	SoLuongTon  float not null
)
go
create table DoUong
(
	MaDU	varchar(100) primary key not null,
	TenDU	nvarchar(255) not null default N'Đồ uống chưa có tên',
	DonGia	money not null
)
go
create table CongThucDoUong
(
	MaDU	varchar(100) references DoUong(MaDU) not null,
	MaNL	varchar(100) references NguyenLieu(MaNL) not null,
	SoLuong float null
	constraint pk_CongThucDoUong primary key(MaDU, MaNL)
)
go
create table HoaDonNhap
(
	MaHDN	varchar(100) primary key not null,
	MaNCC	varchar(100) references NHACUNGCAP(MaNCC) not null,
	MaNV	varchar(100) references NhanVien(MaNV) not null,
	NgayLap datetime not null
)
go
create table ChiTietHDN
(
	MaHDN	varchar(100) references HoaDonNhap(MaHDN) not null,
	MaNL	varchar(100) references NguyenLieu(MaNL) not null,
	SoLuongNhap float null
	constraint pk_ChiTietHDN primary key(MaHDN, MaNL)
)
go

create table Ban 
(
	MaBan       varchar(100) primary key not null,
	TrangThai   bit not null default 0 --0: Còn bàn , 1: Hết bàn 
)
go
create table HoaDonBan
(
	MaHDB		varchar(100) primary key not null,
	MaBan       varchar(100) references Ban(MaBan) not null,
	MaNV		varchar(100) references NhanVien(MaNV) not null,
	NgayLap		datetime not null,
	TrangThai	bit not null default 1 --1: Đã thanh toán, 0: Chưa thanh toán
)
go
create table ChiTietHDB
(
	MaHDB		varchar(100) references HoaDonBan(MaHDB) not null,
	MaDU		varchar(100) references DoUong(MaDU) not null,
	SoLuongBan  int null,
	KhuyenMai	nvarchar(255) null
	constraint pk_ChiTietHDB primary key(MaHDB, MaDU)
)
go
-- Nhập dữ liệu NhanVien
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV00', N'Nguyễn Ngọc Linh', N'Hà Nội', '0387486325', cast(N'1990-08-08T00:00:00.000' as datetime), cast(N'2015-05-20T00:00:00.000' as datetime),300000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV01', N'Nguyễn Ngọc Mai', N'Hà Nội', '0358233135', cast(N'1997-06-28T00:00:00.000' as datetime), cast(N'2018-09-11T00:00:00.000' as datetime),100000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV02', N'Trần Hoàng An', N'Hải Phòng', '0378524368', cast(N'1995-08-19T00:00:00.000' as datetime), cast(N'2019-10-12T00:00:00.000' as datetime),200000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV03', N'Lê Minh Đức', N'Thanh Hóa', '0363472536', cast(N'1998-05-09T00:00:00.000' as datetime), cast(N'2020-08-15T00:00:00.000' as datetime),100000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV04', N'Đỗ Thanh Tùng', N'Quảng Ninh', '0394057256', cast(N'1997-10-16T00:00:00.000' as datetime), cast(N'2019-03-11T00:00:00.000' as datetime),200000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV05', N'Nguyễn Mai Anh', N'Hà Nội', '0398024523', cast(N'1997-06-24T00:00:00.000' as datetime), cast(N'2018-09-15T00:00:00.000' as datetime),100000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV06', N'Hoàng Tiến Thành', N'Nghệ An', '0371402536', cast(N'2000-08-25T00:00:00.000' as datetime), cast(N'2021-10-16T00:00:00.000' as datetime),200000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV07', N'Đặng Đình Trung', N'Hà Nam', '0324578386', cast(N'1998-08-29T00:00:00.000' as datetime), cast(N'2020-08-20T00:00:00.000' as datetime),100000)
insert NhanVien(MaNV, HoTen, DiaChi, SDT, NgaySinh, NgayNhanViec,Luong) values ('NV08', N'Nguyễn Đức Minh', N'Hà Nội', '0378458236', cast(N'1996-10-08T00:00:00.000' as datetime), cast(N'2017-03-20T00:00:00.000' as datetime),200000)
go
--Nhập dữ liệu CaLam
insert CaLam(MaCa,TenCa) values('CL01','Ca 1');
insert CaLam(MaCa,TenCa) values('CL02','Ca 2');
insert CaLam(MaCa,TenCa) values('CL03','Ca 3');
insert CaLam(MaCa,TenCa) values('CL04','Ca 4');
go
--Nhập dữ liệu ChiTietCaLam
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV01','CL01','2022-11-07');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV02','CL02','2022-11-07');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV03','CL03','2022-11-07');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV04','CL04','2022-11-07');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV01','CL02','2022-11-08');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV02','CL01','2022-11-08');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV03','CL03','2022-11-08');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV04','CL02','2022-11-10');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV02','CL01','2022-11-11');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV03','CL02','2022-11-11');
insert ChiTietCaLam(MaNV,MaCa,NgayLamViec) values ('NV04','CL04','2022-11-11');
go
--Nhập dữ liệu ChiTietLuong
insert into ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong) values(N'NV01',11,2022,0,0) 
insert into ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong) values(N'NV02',11,2022,0,0) 
insert into ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong) values(N'NV03',11,2022,0,0) 
insert into ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong) values(N'NV04',11,2022,0,0)
go
-- Nhập dữ liệu TaiKhoan
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'NguyenNgocLinh', 'NgocLinh00', 'NV00',0,'LinhNguyen00@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'NguyenNgocMai', 'NgocMai01', 'NV01',1,'MaiNguyen01@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'TranHoangAn', 'HoangAn02', 'NV02',1,'HoangAn02@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'LeMinhDuc', 'MinhDuc03', 'NV03',1,'MinhDuc03@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'DoThanhTung', 'ThanhTung04', 'NV04',1,'ThanhTung04@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'NguyenMaiAnh', 'MaiAnh05', 'NV05',1,'MaiAnh05@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'HoangTienThanh', 'TienThanh06', 'NV06',1,'TienThanh06@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'DangDinhTrung', 'DinhTrung07', 'NV07',1,'TrungDang07@gmail.com')
insert TaiKhoan(TenTK, MatKhau, MaNV, LoaiTK, Email) values (N'NguyenDucMinh', 'DucMinh08', 'NV08',1,'DucMinh08@gmail.com')
go
-- Nhập dữ liệu NhaCungCap
insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values (N'NCC01',N'HorecaVN',N'Số 48 Ngõ 279 Đội Cấn, Ba Đình, Hà Nội','0919906266')
insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values (N'NCC02',N'ToMaTo Việt Nam',N'H34 đường Ngô Thì Nhậm, Phường Hà Cầu, Hà Đông, Hà Nội','0972599572')
insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values (N'NCC03',N'Trùm Nguyên Liệu',N'Số 226A La Thành, P. Ô Chợ Dừa, Q. Đống Đa, TP Hà Nội','0931813883')
insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values (N'NCC04',N'Lạc Đà Vàng',N'Số 1A ngõ 137 Đường Mỹ Đình, Q. Nam Từ Liêm, Hà Nội','0965001686')
insert NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) values (N'NCC05',N'Vietblend',N'Số 10/1, ngõ 55 Huỳnh Thúc Kháng, P. Láng Hạ, Q. Đống Đa, Hà Nội','0348888589')
go
-- Nhập dữ liệu NguyenLieu
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL01',N'Sữa tươi',N'Lít',50000,10)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL02',N'Bột trà xanh',N'Kg',100000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL03',N'Bột khoai môn',N'Kg',120000,6)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL04',N'Bột cà phê Trung Nguyên',N'Kg',80000,10)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL05',N'Bột cacao Nestle',N'Kg',90000,8)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL06',N'Việt Quất',N'Kg',110000,7)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL07',N'Dưa hấu',N'Kg',30000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL08',N'Chanh leo',N'Kg',20000,7)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL09',N'Bơ',N'Kg',25000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL10',N'Cam',N'Kg',50000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL11',N'Quýt',N'Kg',30000,6)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL12',N'Táo',N'Kg',70000,8)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL13',N'Bột Socola',N'Kg',70000,6)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL14',N'Ổi',N'Kg',40000,3)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL15',N'Trứng',N'Kg',30000,7)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL16',N'Sữa chua',N'Hộp',10000,100)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL17',N'Bí đao',N'Kg',30000,7)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL18',N'Bạc hà',N'Kg',20000,20)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL19',N'Xoài',N'Kg',40000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL20',N'Dâu tây',N'Kg',50000,10)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL21',N'Bột cafe Arabica',N'Kg',100000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL22',N'Bột cafe Lavazza Club',N'Kg',120000,6)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL23',N'Bột cafe Qualità Rossa',N'Kg',130000,4)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL24',N'Bột cafe K Phiêu',N'Kg',100000,7)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL25',N'Bột cafe Arabica Cầu Đất',N'Kg',100000,5)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL26',N'Chanh',N'Kg',10000,8)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL27',N'Nước ngọt',N'Lon',15000,100)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL28',N'Sữa ông thọ',N'Lon',20000,50)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL29',N'Đường',N'Kg',20000,10)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL30',N'Nước',N'Thùng',200000,10)
insert NguyenLieu(MaNL, TenNL, DonVi, DonGia, SoLuongTon) values (N'NL31',N'Đá',N'Bao',20000,5)
go
--Nhập dữ liệu DoUong
insert DoUong(MaDU, TenDU, DonGia) values (N'DU01',N'Sinh tố bơ',50000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU02',N'Cà phê nâu đá truyền thống',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU03',N'Cà phê đen đá truyền thống',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU04',N'Cà phê sữa đá',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU05',N'Sinh tố xoài',60000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU06',N'Nước bí đao',30000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU07',N'Nước dưa hấu',35000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU08',N'Nước chanh leo',30000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU09',N'Siro bạc hà',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU10',N'Cà phê trứng',50000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU11',N'Cà phê capuchino',70000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU12',N'Nước cam',45000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU13',N'Nước quýt',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU14',N'Nước dâu tây',50000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU15',N'Nước ổi',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU16',N'Sữa chua đá bào',30000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU17',N'Sữa chua hoa quả',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU18',N'Nước chanh',20000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU19',N'Nước soda chanh',25000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU20',N'Nước siro dâu tây',30000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU21',N'Nước việt quất',35000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU22',N'Cacao nóng',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU23',N'Socola nóng',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU24',N'Trà xanh',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU25',N'Cà phê Việt Nam truyền thống',40000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU26',N'Cà phê ngoại nhập',50000)
insert DoUong(MaDU, TenDU, DonGia) values (N'DU27',N'Nước siro việt quất',40000)
go
--Nhập dữ liệu CongThucDoUong
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU01',N'NL09',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU02',N'NL24',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU03',N'NL25',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU04',N'NL04',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU04',N'NL28',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU05',N'NL19',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU05',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU06',N'NL17',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU07',N'NL07',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU08',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU08',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU08',N'NL08',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU09',N'NL18',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU09',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU09',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU10',N'NL22',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU10',N'NL15',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU10',N'NL01',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU11',N'NL22',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU11',N'NL01',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU12',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU12',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU12',N'NL10',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU13',N'NL11',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU13',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU13',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU14',N'NL20',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU14',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU14',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU15',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU15',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU15',N'NL14',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU16',N'NL31',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU16',N'NL16',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU17',N'NL16',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU17',N'NL19',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU17',N'NL20',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU17',N'NL12',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU18',N'NL26',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU18',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU18',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU19',N'NL26',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU19',N'NL31',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU19',N'NL27',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU20',N'NL20',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU20',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU20',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU20',N'NL31',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU21',N'NL06',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU21',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU21',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU22',N'NL05',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU23',N'NL13',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU24',N'NL02',3)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU25',N'NL04',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU26',N'NL22',2)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU27',N'NL06',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU27',N'NL29',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU27',N'NL30',1)
insert CongThucDoUong(MaDU, MaNL, SoLuong) values (N'DU27',N'NL31',1)
go
-- Nhập dữ liệu Ban
insert Ban(MaBan, TrangThai) values (N'B01',1)
insert Ban(MaBan, TrangThai) values (N'B02',0)
insert Ban(MaBan, TrangThai) values (N'B03',1)
insert Ban(MaBan, TrangThai) values (N'B04',0)
insert Ban(MaBan, TrangThai) values (N'B05',1)
insert Ban(MaBan, TrangThai) values (N'B06',0)
insert Ban(MaBan, TrangThai) values (N'B07',0)
insert Ban(MaBan, TrangThai) values (N'B08',0)
insert Ban(MaBan, TrangThai) values (N'B09',0)
insert Ban(MaBan, TrangThai) values (N'B10',1)
insert Ban(MaBan, TrangThai) values (N'B11',1)
insert Ban(MaBan, TrangThai) values (N'B12',0)
go
-- Nhập dữ liệu HoaDonBan
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB01',N'B01',N'NV01', CAST(N'2022-08-11T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB02',N'B02',N'NV02', CAST(N'2020-08-05T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB03',N'B01',N'NV03', CAST(N'2021-06-08T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB04',N'B02',N'NV04', CAST(N'2022-09-11T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB05',N'B03',N'NV05', CAST(N'2022-10-11T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB06',N'B04',N'NV06', CAST(N'2022-08-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB07',N'B03',N'NV07', CAST(N'2022-05-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB08',N'B04',N'NV08', CAST(N'2022-09-05T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB09',N'B05',N'NV01', CAST(N'2021-07-06T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB10',N'B06',N'NV02', CAST(N'2020-04-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB11',N'B05',N'NV03', CAST(N'2022-02-15T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB12',N'B06',N'NV04', CAST(N'2022-01-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB13',N'B07',N'NV05', CAST(N'2022-09-12T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB14',N'B08',N'NV06', CAST(N'2022-01-16T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB15',N'B07',N'NV07', CAST(N'2022-09-17T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB16',N'B08',N'NV08', CAST(N'2022-06-11T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB17',N'B09',N'NV02', CAST(N'2020-08-19T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB18',N'B10',N'NV02', CAST(N'2020-08-15T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB19',N'B09',N'NV04', CAST(N'2022-09-20T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB20',N'B10',N'NV06', CAST(N'2022-08-25T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB21',N'B11',N'NV02', CAST(N'2022-09-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB22',N'B12',N'NV01', CAST(N'2022-08-15T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB23',N'B11',N'NV04', CAST(N'2022-08-20T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB24',N'B12',N'NV06', CAST(N'2022-09-15T00:00:00.000' AS DateTime),1)
-- insert them
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB25',N'B11',N'NV03', CAST(N'2022-11-10T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB26',N'B05',N'NV08', CAST(N'2022-11-06T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB27',N'B02',N'NV05', CAST(N'2022-11-07T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB28',N'B02',N'NV01', CAST(N'2022-11-25T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB29',N'B04',N'NV07', CAST(N'2022-12-12T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB30',N'B10',N'NV02', CAST(N'2022-12-24T00:00:00.000' AS DateTime),1)
insert HoaDonBan(MaHDB, MaBan, MaNV, NgayLap, TrangThai) values (N'HDB31',N'B06',N'NV01', CAST(N'2022-12-12T00:00:00.000' AS DateTime),1)
go
delete from chitiethdb
where MaHDB = N'HDB31'
go
delete from HoaDonBan
where MaHDB = N'HDB31'
select * from hoadonban
-- Nhập dữ liệu ChiTietHDB
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB01',N'DU01',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB01',N'DU02',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB02',N'DU03',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB02',N'DU04',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB03',N'DU05',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB03',N'DU06',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB04',N'DU07',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB05',N'DU12',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB06',N'DU15',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB07',N'DU12',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB07',N'DU16',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB08',N'DU20',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB08',N'DU21',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB09',N'DU26',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB09',N'DU27',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB10',N'DU10',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB10',N'DU21',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB11',N'DU15',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB11',N'DU16',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB12',N'DU11',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB12',N'DU12',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB13',N'DU09',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB13',N'DU07',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB14',N'DU02',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB14',N'DU03',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB15',N'DU02',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB15',N'DU03',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB15',N'DU04',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB16',N'DU03',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB16',N'DU22',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB17',N'DU11',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB17',N'DU12',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB18',N'DU03',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB18',N'DU22',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB19',N'DU12',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB19',N'DU13',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB20',N'DU10',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB20',N'DU15',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB21',N'DU03',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB21',N'DU16',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB22',N'DU10',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB22',N'DU22',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB23',N'DU03',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB23',N'DU21',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB23',N'DU20',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB24',N'DU10',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB24',N'DU16',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB24',N'DU17',2,null)
-- insert them
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB25',N'DU25',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB25',N'DU10',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB25',N'DU05',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB25',N'DU15',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB25',N'DU22',4,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB26',N'DU11',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB26',N'DU12',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB26',N'DU08',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB26',N'DU09',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB26',N'DU19',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB27',N'DU06',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB27',N'DU12',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB27',N'DU18',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB28',N'DU14',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB28',N'DU20',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB28',N'DU21',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB29',N'DU11',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB29',N'DU14',6,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB29',N'DU10',3,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB29',N'DU01',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB30',N'DU03',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB30',N'DU05',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB30',N'DU26',2,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB30',N'DU27',6,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB31',N'DU09',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB31',N'DU24',9,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB31',N'DU21',1,null)
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB31',N'DU16',1,null)
go
-- Nhập dữ liệu HoaDonNhap
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN01',N'NCC01','NV01',CAST(N'2021-09-04T00:00:00.000' AS DateTime))
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN02',N'NCC02','NV02',CAST(N'2020-07-04T00:00:00.000' AS DateTime))
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN03',N'NCC03','NV04',CAST(N'2022-08-15T00:00:00.000' AS DateTime))
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN04',N'NCC04','NV05',CAST(N'2022-01-20T00:00:00.000' AS DateTime))
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN05',N'NCC05','NV08',CAST(N'2022-09-12T00:00:00.000' AS DateTime))
insert HoaDonNhap(MaHDN, MaNCC, MaNV, NgayLap) values (N'HDN06',N'NCC05','NV07',CAST(N'2022-07-12T00:00:00.000' AS DateTime))
go
-- Nhập dữ liệu ChiTietHDN
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN01',N'NL29',10)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN02',N'NL10',20)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN03',N'NL22',30)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN04',N'NL02',5)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN05',N'NL10',6)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN06',N'NL03',8)
insert ChiTietHDN(MaHDN, MaNL, SoLuongNhap) values (N'HDN06',N'NL07',5)
go
---------------------------
select * from NhanVien
select * from CaLam
select * from ChiTietCaLam
select * from ChiTietLuong
select * from TaiKhoan
select * from NhaCungCap
select * from NguyenLieu
select * from DoUong
select * from CongThucDoUong
select * from Ban
select * from HoaDonBan
select * from ChiTietHDB
select * from HoaDonNhap
select * from ChiTietHDN

