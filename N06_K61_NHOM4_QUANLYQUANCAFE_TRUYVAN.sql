Use QLCafe
Go
-- 2 cau duoc chon show bao cao BTL-------------------------------
/*câu 5: Tạo trigger khi thêm mã đồ uống vào chi tiết hóa đơn bán.Tăng số lượng bán nếu mã đồ uống đã tồn tại,
thêm mới dòng số lượng bán nếu mã đồ uống chưa tồn tại*/
create trigger Cau5_trigger on ChiTietHDB
instead of insert
as
begin
	declare @MaHDB nvarchar(10),@MaSP nvarchar(10),@SL int,@KhuyenMai nvarchar(100)
	select @MaHDB = MaHDB,@MaSP = MaDU,@SL = SoLuongBan,@KhuyenMai = KhuyenMai from inserted
	if not exists (select MaHDB from ChiTietHDB where MaHDB = @MaHDB and MaDU = @MaSP)
	begin
		insert into ChiTietHDB (MaHDB,MaDU,SoLuongBan,KhuyenMai) 
		values (@MaHDB,@MaSP,@SL,@KhuyenMai)
    end
	else
	begin
		update ChiTietHDB set SoLuongBan = SoLuongBan + @SL where MaHDB = @MaHDB and MaDU = @MaSP
	end
end
Go
--câu 8:  Tính lương 
create trigger Add_ctcl on ChiTietCaLam
for insert as
begin
	declare @MaNV nvarchar(255),@Thang int,@Nam int,@SoNgayLamViec int,@Luong int
	select @MaNV = MaNV, @Thang = month(NgayLamViec),@Nam = year(NgayLamViec) from inserted
	if exists (select Thang,Nam from ChiTietLuong where Thang = @Thang and Nam = @Nam and MaNV = @MaNV)
		begin
			update ChiTietLuong set SoNgayLamViec = isnull(SoNgayLamViec,0) + 1
										where Thang = @Thang and Nam = @Nam and MaNV = @MaNV
			update ChiTietLuong set Luong = A.Luong
			from (select nv.MaNV, ctl.Thang, ctl.Nam, SoNgayLamViec*nv.Luong as Luong
				from NhanVien nv join ChiTietLuong ctl
				on nv.MaNV = ctl.MaNV
				where Thang = @Thang and Nam = @Nam) A
			where ChiTietLuong.MaNV = a.MaNV
			and ChiTietLuong.Thang = A.Thang
			and ChiTietLuong.Nam = A.Nam
		end
	else
		begin
			set @SoNgayLamViec = 1
			select @Luong = Luong from NhanVien where MaNV = @MaNV
			insert ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong)
			values(@MaNV,@Thang,@Nam,@SoNgayLamViec,@Luong)
		end
end
Go
/*
select * from ChiTietHDB where MaHDB = N'HDB02'
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB02',N'DU05',2,null)
select * from ChiTietHDB where MaHDB = N'HDB02'
*/



--View--------------------------------------------------------------------------------------------------------------------------
/*Câu 1:Tạo view liệt kê những đồ uống có giá bán từ 35000VND đến 50000VND và có mã nguyên liệu NL29*/

create or alter view Cau1_view as
select DoUong.MaDU,TenDU,DonGia,MaNL
from DoUong join CongThucDoUong
on DoUong.MaDU = CongThucDoUong.MaDU
where DonGia >= 35000 and DonGia <= 50000 and MaNL = N'NL29'
Go
--select * from Cau1_view

/*Câu 2:Tạo view 5 đồ uống bán chạy nhất năm 2022*/
create view Cau2_view as
select top 5 with ties DoUong.MaDU,TenDU,sum(ChiTietHDB.SoLuongBan) as SLBan
from DoUong join ChiTietHDB on DoUong.MaDU = ChiTietHDB.MaDU
			join HoaDonBan  on ChiTietHDB.MaHDB = HoaDonBan.MaHDB
where year(HoaDonBan.NgayLap) = 2022
group by DoUong.MaDU,TenDU
order by SLBan desc
Go
--select * from Cau2_view


--Câu 3:Tạo view đưa ra tháng trong năm 2021 có doanh số bán hàng cao nhất ?
create or alter view Cau3_view
as
select top 1 with ties MONTH(HoaDonBan.NgayLap) as ThangDoanhSoCaoNhat2021
from (HoaDonBan inner join ChiTietHDB on ChiTietHDB.MaHDB= HoaDonBan.MaHDB 
					and  YEAR(HoaDonBan.NgayLap)=2021)
					inner join DoUong on ChiTietHDB.MaDU=DoUong.MaDU 
Group by MONTH(HoaDonBan.NgayLap)
order by sum(ChiTietHDB.SoLuongBan*DoUong.DonGia) desc
Go
--select * from Cau3_view

--Câu 4: Tạo view đưa ra danh sách các đồ uống có giá bán bằng 1 trong 3 mức giá cao nhất.
create or alter view Cau4_view
as
select *
from DoUong
where DonGia in (select distinct top 3 DonGia
					from DoUong
					order by DonGia desc)

--select * from Cau4_view
Go
/*Câu 5: Tạo view liệt kê số lượng tiêu thụ của nguyên liệu trong năm 2022*/
create view Cau5_view as
select NguyenLieu.MaNL, TenNL, DonVi, sum(isnull(SoLuong * SLBan, 0)) as SoLuongTieuThu
from CongThucDoUong join (
	select MaDU, sum(SoLuongBan) as SLBan
	from ChiTietHDB join HoaDonBan on ChiTietHDB.MaHDB = HoaDonBan.MaHDB
	where year(NgayLap) = 2022
	group by MaDU
) as ThongKeSoLuongBan on CongThucDoUong.MaDU = ThongKeSoLuongBan.MaDU
right join NguyenLieu on CongThucDoUong.MaNL = NguyenLieu.MaNL
group by NguyenLieu.MaNL, TenNL, DonVi
Go
--select * from Cau5_view

/*Câu 6: Tạo view liệt kê trị giá hóa đơn bán*/
create view Cau6_view as
select HoaDonBan.MaHDB, NgayLap, MaNV, sum(SoLuongBan * DonGia) as TriGia
from HoaDonBan join ChiTietHDB on HoaDonBan.MaHDB = ChiTietHDB.MaHDB
			   join DoUong on ChiTietHDB.MaDU = DoUong.MaDU
Group by HoaDonBan.MaHDB, NgayLap, MaNV
Go
--select * from Cau6_view
--Câu 7: tạo view tìm nhân viên đi làm nhiều nhất trong tháng 11 năm 2022
create view Cau7_view as
select top 1 with ties nv.MaNV, count(MaCa) as SoLanDiLam from NhanVien nv
join ChiTietCaLam ctcl on nv.MaNV = ctcl.MaNV
where year(NgayLamViec) = 2022
group by nv.MaNV
order by count(MaCa) desc
Go
--Câu 8: tạo view tìm nhân viên đi làm nhiều nhất trong năm 2022
create view Cau8_view as
select top 1 with ties nv.MaNV, count(MaCa) as SoLanDiLam from NhanVien nv
join ChiTietCaLam ctcl on nv.MaNV = ctcl.MaNV
where year(NgayLamViec) = 2022
group by nv.MaNV
order by count(MaCa) desc
Go
--select * from Cau8_view



--Thủ tục--------------------------------------------------------------------------------------------------------------------
/*Câu 1:Tạo thủ tục có đầu vào là mã đồ uống, năm,đầu ra là số lượng đồ uống đó bán được trong năm đó*/
create procedure Cau1_proc @MaDoUong nvarchar(20),@Nam int , @SL int output
as
begin
	select @SL = sum(ChiTietHDB.SoLuongBan)
	from ChiTietHDB join DoUong on ChiTietHDB.MaDU = DoUong.MaDU
		            join HoaDonBan  on ChiTietHDB.MaHDB = HoaDonBan.MaHDB				
	where @MaDoUong = DoUong.MaDU and @Nam = year(HoaDonBan.NgayLap)
end
Go
--gọi thủ tục
/*declare @SoLuong int
exec Cau1_proc 'DU03',2022, @SoLuong output
print @SoLuong
*/
/*Câu 2:Tạo thủ tục có đầu vào là mã nhân viên, năm,đầu ra là số hóa đơn nhập và số hóa đơn bán 
mà nhân viên đó lập ra trong năm đó*/
create procedure Cau2_proc @MaNhanVien nvarchar(20),@Nam int, @HDN int output , @HDB int output
as
begin
	select @HDN = count(HoaDonNhap.MaHDN)
	from NhanVien join HoaDonNhap
	on NhanVien.MaNV = HoaDonNhap.MaNV
	where @MaNhanVien = NhanVien.MaNV and @Nam = year(HoaDonNhap.NgayLap)

	select @HDB = count(HoaDonBan.MaHDB)
	from NhanVien join HoaDonBan
	on NhanVien.MaNV = HoaDonBan.MaNV
	where @MaNhanVien = NhanVien.MaNV and @Nam = year(HoaDonBan.NgayLap)
end
Go
--gọi thủ tục
/*declare @soHDN int , @soHDB int
exec Cau2_proc 'NV01',2021, @soHDN output,@soHDB output
print @soHDN
print @soHDB*/

/*Câu 3: Tạo thủ tục có đầu vào là mã nhân viên ,đầu ra là tên và số điện thoại của nhân viên đó*/
create procedure Cau3_proc @MaNhanVien nvarchar(20), @Ten nvarchar(50) output ,@SDT varchar(50) output
as
begin
	select @Ten = HoTen
	from NhanVien
	where @MaNhanVien = MaNV

	select @SDT = SDT
	from NhanVien 
	where @MaNhanVien = MaNV
end
Go
--gọi thủ tục
/*declare @tennv nvarchar(50) , @SDT varchar(50)
exec Cau3_proc 'NV02',@tennv output,@SDT output
print @tennv
print @SDT
*/

--Hàm-----------------------------------------------------------------------------------------------------------------------------------------
--Câu 1: Tạo hàm với đầu vào là năm, đầu ra là danh sách nhân viên sinh vào năm đó
create or alter function Cau1_function(@Nam int)
returns table
as
return
(
	select *
	from NhanVien
	where YEAR(NgaySinh)=@Nam
)
go

--select * from Cau1_function(1997)

--Câu 2: Tạo hàm với đầu vào là số năm đầu ra là danh sách nhân viên làm bằng hoặc nhiều hơn số năm đó
create or alter function cau2_function (@Sonam int)
returns table
as
return
(
	SELECT *
	FROM NhanVien
	where DATEDIFF(year, NgayNhanViec, CURRENT_TIMESTAMP)= @Sonam
)
go
--select * from Cau2_function(4)

--Câu 3: Tạo hàm đầu vào là nhà cung cấp đầu ra là những nguyên liệu cùng nhà cung cấp đó
create or alter function Cau3_function (@NCC nvarchar(255))
returns table
as
return
(
	select TenNL
	from NhaCungCap join HoaDonNhap on NhaCungCap.MaNCC=HoaDonNhap.MaNCC
					join ChiTietHDN on HoaDonNhap.MaHDN=ChiTietHDN.MaHDN
					join NguyenLieu on ChiTietHDN.MaNL=NguyenLieu.MaNL
	where TenNCC=@NCC
)
go
--select * from Cau3_function(N'Vietblend')

/*Câu 4: Tạo hàm phân trang bảng đồ uống có đầu vào là chỉ số trang, kích thước trang, hiển thị dữ liệu của trang đó*/
create function Cau4_func (@SoTrang int, @KichThuocTrang int)
returns table
as return
(
	select *
	from DoUong
	order by MaDU
	offset (@SoTrang - 1) * @KichThuocTrang rows /*@TrangHienTai = (@SoTrang - 1) * @KichThuocTrang*/
	fetch next @KichThuocTrang rows only
)
Go
--select * from Cau4_func(4,7)

/*Câu 5: Tạo hàm có đầu vào là mã đồ uống, đầu ra là số lượng tối đa mà đồ uống đó có thể pha chế được*/
create function Cau5_func(@MaDoUong nvarchar(max)) 
returns table
as return
(
	select min(SoLuongTon / SoLuong) as N'Số lượng tối đa có thể làm', N'Cốc' as N'Đơn vị'
	from CongThucDoUong join NguyenLieu on CongThucDoUong.MaNL = NguyenLieu.MaNL
	where @MaDoUong = MaDU
)
Go
--select * from Cau5_func(N'DU10')

/*Câu 6: Tạo hàm đầu vào là tháng, năm, đầu ra là thống kê số lượng khách ngồi trên mỗi bàn của tháng, năm đó*/
create function   Cau6_func(@thang int, @nam int)
returns table
as return
(
	select Ban.MaBan, isnull(SoKhachNgoi, 0) as SoKhachNgoi
	from Ban left join (
		select MaBan, count(MaBan) as SoKhachNgoi
		from HoaDonBan
		where year(NgayLap) = @nam and month(NgayLap) = @thang
		group by MaBan
	) as ThongKeKhachNgoi on Ban.MaBan = ThongKeKhachNgoi.MaBan
)
Go
--select * from Cau6_func(8, 2022)

-- cau 7:  tổng cac hóa đơn bán từ ngày ... đến ngày ....

create or alter function cau7_func (@ngaybd date, @ngaykt date)
returns table
as
return(
select month(hoadonban.NgayLap) as Thang, sum(SoLuongBan * DonGia) as DTBan
from HoaDonBan join ChiTietHDB on HoaDonBan.MaHDB = ChiTietHDB.MaHDB
			   join DoUong on ChiTietHDB.MaDU = DoUong.MaDU
			   where ngaylap between @ngaybd and @ngaykt 
			   group by month(hoadonban.NgayLap)
)
Go


--cau 8 tổng cac hóa nhap bán từ ngày ... đến ngày ....
create or alter function cau8_func (@ngaybd date, @ngaykt date)
returns table
as
return(
select month(HoaDonNhap.NgayLap) as Thang, sum(SoLuongNhap * DonGia) as DTNhap
from HoaDonNhap join ChiTietHDN on HoaDonNhap.MaHDN = ChiTietHDN.MaHDN
			   join NguyenLieu on ChiTietHDN.MaNL = NguyenLieu.MaNL
			   where ngaylap between @ngaybd and @ngaykt 
			   group by month(HoaDonNhap.NgayLap)
)
Go
-- ccau 9 function
create or alter function cau9_func (@nam int)
returns table
as
return (
select isnull(a.Thang,b.Thang) as Thanga, isnull(b.DTBan, 0)  as DTBan,  isnull(a.DTNhap, 0)  as DTNhap from
	(select month(HoaDonNhap.NgayLap) as Thang, sum(SoLuongNhap * DonGia) as DTNhap
	from HoaDonNhap join ChiTietHDN on HoaDonNhap.MaHDN = ChiTietHDN.MaHDN
			   join NguyenLieu on ChiTietHDN.MaNL = NguyenLieu.MaNL
			  where year(NgayLap) = @nam
			   group by month(HoaDonNhap.NgayLap) ) a full join 
	(select month(hoadonban.NgayLap) as Thang, sum(SoLuongBan * DonGia) as DTBan
	from HoaDonBan join ChiTietHDB on HoaDonBan.MaHDB = ChiTietHDB.MaHDB
			   join DoUong on ChiTietHDB.MaDU = DoUong.MaDU
			   where year(NgayLap) = @nam
			   group by month(hoadonban.NgayLap)) b 

			   on a.Thang = b.Thang
)
Go
/*
select * from cau9_func(2021)
select * from cau9_func(2022)
select * from hoadonban
(select * from cau8_func('2022-08-10', '2022-09-10')) a full join
(select * from cau7_func('2022-08-10', '2022-09-10')) b on a.Thang = b.Thang
*/
--Trigger--------------------------------------------------------------------
--Câu 1: Trigger cập nhật số lượng tồn của nguyên liệu khi thêm, xóa, sửa đồ uống trong chi tiết hóa đơn
create trigger edit_chitiethdb on ChiTietHDB
for insert, delete, update as
begin
	update NguyenLieu
	set
		SoLuongTon = isnull(SoLuongTon, 0) + 
					 isnull(
					 (select sum(SoLuongBan * SoLuong) 
					 from deleted D join CongThucDoUong ctdu on D.MaDU = ctdu.MaDU 
					 where ctdu.MaNL = NguyenLieu.MaNL)
					 , 0) - 
					  isnull(
					 (select sum(SoLuongBan * SoLuong) 
					 from inserted I join CongThucDoUong ctdu on I.MaDU = ctdu.MaDU 
					 where ctdu.MaNL = NguyenLieu.MaNL)
					 , 0)
end
Go
/*Thủ tục thêm bàn với transaction và try catch*/
create procedure pro @MaBan nvarchar(10),@TrangThai nvarchar(100)
as
begin
	begin try
		begin transaction	
			insert into Ban (MaBan,TrangThai) values(@MaBan,@TrangThai)
		commit transaction
	end try
	begin catch 
			print(error_message())
			rollback transaction
	end catch
end
Go
--execute pro @MaBan = 'B01',@TrangThai = 0

--trigger---------------------------------------------------------------------------------------------------------------
/*Câu 2: Tạo trigger nhằm đảm bảo giá trị cột đơn giá của bảng đồ uống khi chèn vào phải luôn luôn >= 20000*/
create trigger Cau2_trigger on DoUong
for insert as
begin 
	if exists (select * from inserted where DonGia < 20000)
	begin
		raiserror(N'Giá của đồ uống phải >= 20000',16,1)
		rollback transaction
	end
end
Go
--insert DoUong(MaDU, TenDU, DonGia) values (N'DU30',N'Sinh tố dưa hấu',10000)

/*Câu 3: Thêm trường SLDoUong vào bảng hóa đơn bán,cập nhật tự động
cho trường này mỗi khi thêm,sửa,xóa chi tiết hóa đơn bán */

alter table HoaDonBan
add SLDoUong int
Go
update HoaDonBan
set SLDoUong = (select sum(SoLuongBan)
				from ChiTietHDB
				where ChiTietHDB.MaHDB = HoaDonBan.MaHDB)
Go
create trigger Cau3_trigger on ChiTietHDB
for insert,update,delete 
as
begin
	declare @MaHDB_In nvarchar(10),@MaHDB_De nvarchar(10),@SLB_In int,@SLB_De int
	select @MaHDB_In = MaHDB,@SLB_In = SoLuongBan from inserted
	select @MaHDB_De = MaHDB,@SLB_De = SoLuongBan from deleted
	update HoaDonBan set SLDoUong = isnull(SLDoUong,0)+isnull(@SLB_In,0) -isnull(@SLB_De,0) where MaHDB = isnull(@MaHDB_In, @MaHDB_De)

end
Go
--câu 4: Trigger tự động xóa chi tiết hóa đơn bán khi xóa hóa đơn bán
create trigger Cau4_trigger on HoaDonBan
instead of delete as
begin
	delete ChiTietHDB where MaHDB in (select MaHDB from deleted)
	delete HoaDonBan where MaHDB in (select MaHDB from deleted)
end
Go
/*câu 5: Tạo trigger khi thêm mã đồ uống vào chi tiết hóa đơn bán.Tăng số lượng bán nếu mã đồ uống đã tồn tại,
thêm mới dòng số lượng bán nếu mã đồ uống chưa tồn tại*/
create trigger Cau5_trigger on ChiTietHDB
instead of insert
as
begin
	declare @MaHDB nvarchar(10),@MaSP nvarchar(10),@SL int,@KhuyenMai nvarchar(100)
	select @MaHDB = MaHDB,@MaSP = MaDU,@SL = SoLuongBan,@KhuyenMai = KhuyenMai from inserted
	if not exists (select MaHDB from ChiTietHDB where MaHDB = @MaHDB and MaDU = @MaSP)
	begin
		insert into ChiTietHDB (MaHDB,MaDU,SoLuongBan,KhuyenMai) 
		values (@MaHDB,@MaSP,@SL,@KhuyenMai)
    end
	else
	begin
		update ChiTietHDB set SoLuongBan = SoLuongBan + @SL where MaHDB = @MaHDB and MaDU = @MaSP
	end
end
Go

/*
select * from ChiTietHDB where MaHDB = N'HDB02'
insert ChiTietHDB(MaHDB, MaDU, SoLuongBan, KhuyenMai) values (N'HDB02',N'DU05',2,null)
select * from ChiTietHDB where MaHDB = N'HDB02'
*/
--câu 6 Trigger xóa nhân viên
create trigger Cau6_trigger on NhanVien
instead of delete as
begin
	delete TaiKhoan where MaNV in (Select MaNV from deleted)
	delete NhanVien where MaNV in (Select MaNV from deleted)
end
Go
/*Câu 7: Tạo trường thành tiền (ThanhTien) cho bảng ChitietHDB, tạo trigger cập nhật tự động 
cho trường này mỗi khi thêm,sửa biết ThanhTien=SoLuongBan * DonGia */
alter table ChiTietHDB
add ThanhTien money
Go
create trigger Cau7_trigger on ChiTietHDB
for insert, update as
begin
	declare @sohdb nvarchar(10), @dongia money, @thanhtien money, @madu nvarchar(10)
	select @sohdb = MaHDB, @madu = MaDU from inserted
	select @dongia = DonGia from DoUong where MaDU = @madu
	update ChiTietHDB set ThanhTien = SoLuongBan * @dongia 
	where MaHDB = @sohdb and MaDU = @madu
End
Go
--câu 8:  Tính lương 
create trigger Add_ctcl on ChiTietCaLam
for insert as
begin
	declare @MaNV nvarchar(255),@Thang int,@Nam int,@SoNgayLamViec int,@Luong int
	select @MaNV = MaNV, @Thang = month(NgayLamViec),@Nam = year(NgayLamViec) from inserted
	if exists (select Thang,Nam from ChiTietLuong where Thang = @Thang and Nam = @Nam and MaNV = @MaNV)
		begin
			update ChiTietLuong set SoNgayLamViec = isnull(SoNgayLamViec,0) + 1
										where Thang = @Thang and Nam = @Nam and MaNV = @MaNV
			update ChiTietLuong set Luong = A.Luong
			from (select nv.MaNV, ctl.Thang, ctl.Nam, SoNgayLamViec*nv.Luong as Luong
				from NhanVien nv join ChiTietLuong ctl
				on nv.MaNV = ctl.MaNV
				where Thang = @Thang and Nam = @Nam) A
			where ChiTietLuong.MaNV = a.MaNV
			and ChiTietLuong.Thang = A.Thang
			and ChiTietLuong.Nam = A.Nam
		end
	else
		begin
			set @SoNgayLamViec = 1
			select @Luong = Luong from NhanVien where MaNV = @MaNV
			insert ChiTietLuong(MaNV,Thang,Nam,SoNgayLamViec,Luong)
			values(@MaNV,@Thang,@Nam,@SoNgayLamViec,@Luong)
		end
end
Go
--câu 7 : cho biết số lượng nhập từ nhà cung cấp có mã là NCC05
create view Cau7_view as
select sum(ChiTietHDN.SoLuongNhap) from HoaDonNhap
join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC
join ChiTietHDN on HoaDonNhap.MaHDN = ChiTietHDN.MaHDN
where NhaCungCap.MaNCC = 'NCC05'
group by NhaCungCap.MaNCC
Go
--select * from Cau7_view
-- đưa ra thông tin các nhân viên cho mức lương cao thứ 2
create view Cau2_view as
SELECT * FROM NhanVien
WHERE Luong IN (
	SELECT MAX(Luong)
	FROM NhanVien
	WHERE Luong < (SELECT MAX(Luong)
                 FROM NhanVien)
)
GO
--select * from Cau2_view
--câu 5: tạo thủ tục có đầu vào là mã nguyên liệu, đầu ra là tên nguyên liệu và đơn giá
create procedure Cau5_proc @MaNguyenLieu varchar(100), @TenNguyenLieu nvarchar(255) output ,@DonGia money output
as
begin
	select @TenNguyenLieu = TenNL
	from NguyenLieu where MaNL = @MaNguyenLieu
	select @DonGia = DonGia
	from NguyenLieu where MaNL = @MaNguyenLieu
end
Go
/*
declare @TenNguyenLieu nvarchar(255) , @DonGia money
exec Cau4_proc 'NL10','Cam', @DonGia output
print @DonGia
*/
-- tạo thủ tục đầu vào là mã hdb, đầu ra là tên đồ uống và mã đồ uông

create procedure Cau5_proc @MaHoaDonBan varchar(100), @MaDoUong varchar(100) output ,@TenDoUong nvarchar(255) output
as
begin
	select @MaDoUong = DoUong.MaDU, @TenDoUong = DoUong.TenDU
	from DoUong join ChiTietHDB
	on DoUong.MaDU = ChiTietHDB.MaDU
end
Go
/*
declare @MaDoUong varchar(100)  ,@TenDoUong nvarchar(255) 
exec Cau5_proc 'HDB07','DU16', @TenDoUong output
print @MaDoUong
print @TenDoUong
*/
--câu 7: tạo thủ tục đứa ra tên nguyên liệu cần pha chế khi biết tên đồ uống
create procedure cau7_proc @tendouong nvarchar(255)
as
begin
	select TenNL from NguyenLieu nl
	join CongThucDoUong ctdu on nl.MaNL = ctdu.MaNL
	join DoUong du on du.MaDU = ctdu.MaDU
	where @tendouong = TenDU
	
end
Go
--exec cau7_proc N'Nước chanh' 

---Các câu lệnh quản trị
/*Câu 1: Tạo login NguyenNghiaVinh,tạo user NguyenNghiaVinh cho NguyenNghiaVinh tren CSDL QLCafe*/
/*exec sp_addlogin NguyenNghiaVinh, 123
exec sp_adduser NguyenNghiaVinh, NguyenNghiaVinh

/*Câu 2: - Phần quyền select,insert,update trên NhanVien,HoaDonNhap,HoaDonBan cho NguyenNghiaVinh và NguyenNghiaVinh được 
phép phân quyền cho người khác
 - Đăng nhập NguyenNghiaVinh để kiểm tra*/
grant select,insert,update on NhanVien to NguyenNghiaVinh with grant option
grant select,insert,update on HoaDonNhap to NguyenNghiaVinh with grant option
grant select,insert,update on HoaDonBan to NguyenNghiaVinh with grant option

/*Câu 3: Tạo login NguyenVietHoang,tạo user NguyenVietHoang cho NguyenVietHoang tren CSDL QLCafe*/
exec sp_addlogin NguyenVietHoang, 456
exec sp_adduser NguyenVietHoang, NguyenVietHoang

/*Câu 4: - Từ login NguyenNghiaVinh,phân quyền select,update,delete trên NhanVien cho NguyenVietHoang
 - Đăng nhập NguyenVietHoang để kiểm tra*/
grant select,insert,update on NhanVien to NguyenVietHoang
*/