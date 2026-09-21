# Lab 04 - Quản lý sản phẩm 

## Mô tả
Chương trình Console quản lý sản phẩm, dữ liệu lưu trong bộ nhớ bằng Repository<T>.
Chương trình xử lý lỗi nhập liệu, mã sản phẩm trùng và sản phẩm không tồn tại bằng exception phù hợp.

## Cấu trúc project
Entities/IEntity.cs Interface IEntity (string Id { get; }) - ràng buộc generic 
Entities/Product.cs MaSP, TenSP, Price, Quantity; kiểm tra dữ liệu, ToString 
Exceptions/DuplicateProductException.cs Exception khi thêm sản phẩm trùng mã 
Exceptions/ProductNotFoundException.cs Exception khi xóa/sửa sản phẩm không tồn tại 
Exceptions/InvalidProductDataException.cs Exception khi dữ liệu sản phẩm không hợp lệ (rỗng, số âm) 
Repositories/Repository.cs Repository<T> where T : IEntity: Add, Remove, FindById, Find(Func<T,bool>), GetAll 
Services/ProductService.cs Nghiệp vụ: AddProduct, RemoveProduct, Search, Filter; phát event ProductAdded, ProductRemoved
Program.cs Menu, nhập/xuất dữ liệu, bắt exception 

## Chức năng
1. Thêm sản phẩm
2. Xuất danh sách
3. Tìm theo mã
4. Tìm theo tên
5. Lọc theo khoảng giá
6. Xóa sản phẩm
7. Tính tổng giá trị kho
0. Thoát

## Chạy chương trình


