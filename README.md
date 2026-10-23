# EmployeeManagerOOP

Hai ví dụ console minh họa cùng bài toán quản lý nhân viên bằng hai kiểu lập trình:

- **C# / OOP** — class `OopEmployee` lưu dữ liệu nhân viên; class `EmployeeManagerOOP` đóng gói danh sách và các method thao tác.
- **C / Structured** — struct `Employee` và `EmployeeManager` lưu dữ liệu; các procedure bên ngoài thực hiện thao tác. Không còn phiên bản structured bằng C#.

## Yêu cầu

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) để chạy phiên bản C#.
- Compiler hỗ trợ C11, ví dụ GCC hoặc Clang, để chạy phiên bản C.
- Python 3 để chạy kiểm tra tương tác cho C.

## Cài đặt

```bash
git clone https://github.com/chung9920/a1oop.git
cd a1oop
```

## Chạy phiên bản OOP (C#)

```bash
dotnet build CSharp/EmployeeManagerOOP.csproj
dotnet run --project CSharp/EmployeeManagerOOP.csproj
```

Chương trình chạy trực tiếp menu OOP, không cần chọn kiểu lập trình.

## Chạy phiên bản Structured (C)

```bash
mkdir -p bin
cc -std=c11 -Wall -Wextra -pedantic C/EmployeeManager.c -o bin/employee-manager
./bin/employee-manager
```

Chỉ dùng thư viện chuẩn C, không cần cài thêm dependency.

## Chức năng

Cả hai phiên bản có cùng menu:

1. **Add employee** — nhập tên, tuổi và chức vụ.
2. **Remove employee** — xóa nhân viên theo tên.
3. **Search employee** — tìm và hiển thị nhân viên theo tên.
4. **Display all employees** — hiển thị toàn bộ nhân viên.
5. **Exit** — thoát chương trình.

Tuổi phải là số nguyên dương trong phạm vi `int`; tên và chức vụ không được để trống. Khoảng trắng đầu/cuối được loại bỏ. Tìm kiếm phân biệt chữ hoa/thường; nếu trùng tên, tìm hoặc xóa nhân viên đầu tiên có tên đó.

Phiên bản C giới hạn tên và chức vụ ở 127 byte mỗi trường; dữ liệu quá dài được từ chối thay vì cắt ngắn. Danh sách tự tăng dung lượng khi thêm nhân viên và được giải phóng khi thoát. EOF kết thúc chương trình mà không lưu nhân viên đang nhập dở. Cả hai phiên bản chỉ lưu dữ liệu trong bộ nhớ, không lưu lại sau khi thoát.

## Kiểm tra

```bash
dotnet run --project CSharp/Tests/EmployeeManagerOOP.Tests.csproj
python3 -I C/Tests/test_structured.py
```

Mỗi lệnh in `PASS` khi thành công. Kiểm tra C tự biên dịch vào thư mục tạm rồi chạy các tình huống thêm, tìm, xóa, hiển thị, nhập sai, EOF và tăng dung lượng danh sách. Có thể đặt `CC` và `CFLAGS` để chọn compiler và cờ kiểm tra bổ sung.

## Các file chính

- `CSharp/Program.cs` — console OOP bằng C#.
- `CSharp/EmployeeManagerOOP.cs` — class nhân viên và manager OOP.
- `CSharp/EmployeeManagerOOP.csproj` — cấu hình project .NET.
- `C/EmployeeManager.c` — struct, procedure và console structured bằng C.
- `CSharp/Tests/Program.cs` — kiểm tra phiên bản C#.
- `C/Tests/test_structured.py` — kiểm tra phiên bản C.
