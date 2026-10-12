# EmployeeManagerOOP

Ví dụ console nhỏ bằng .NET 8, minh họa sự khác nhau giữa lập trình hướng đối tượng và lập trình có cấu trúc trong quản lý nhân viên.

## Yêu cầu

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git, nếu clone repository

Kiểm tra cài đặt:

```bash
dotnet --version
git --version
```

## Cài đặt

Clone repository và đi tới thư mục project:

```bash
git clone https://github.com/chung9920/a1oop.git
cd a1oop/OOP/EmployeeManagerOOP
```

Khôi phục dependencies và build project:

```bash
dotnet restore
dotnet build
```

## Chạy chương trình

```bash
dotnet run
```

Chọn một kiểu lập trình khi chương trình yêu cầu:

1. **OOP** — class `EmployeeManagerOOP` quản lý dữ liệu và các thao tác với nhân viên.
2. **Structured** — struct `EmployeeManager` lưu dữ liệu, các procedure bên ngoài thực hiện thao tác.

Sau đó dùng menu để thao tác trực tiếp:

1. **Add employee** — nhập tên, tuổi và chức vụ.
2. **Remove employee** — xóa nhân viên theo tên.
3. **Search employee** — tìm và hiển thị nhân viên theo tên.
4. **Display all employees** — hiển thị toàn bộ nhân viên.
5. **Exit** — thoát chế độ hiện tại.

Cả hai kiểu đều có cùng chức năng. Khác biệt nằm ở nơi lưu dữ liệu và cách gọi thao tác: OOP gọi method trên `EmployeeManagerOOP`, còn Structured gọi procedure bên ngoài `EmployeeManager`.

Tuổi phải là số nguyên dương; tên và chức vụ không được để trống.

## Kiểm tra

Chạy kiểm tra tương tác cho cả hai kiểu:

```bash
dotnet run --project Tests/EmployeeManagerOOP.Tests.csproj
```

Kết quả hợp lệ: `PASS`.

## Các file chính

- `Program.cs` — điểm khởi chạy console và hai ví dụ
- `EmployeeManagerOOP.cs` — triển khai manager theo hướng đối tượng
- `EmployeeManager.cs` — model `Employee` và dữ liệu manager theo kiểu structured
- `EmployeeManagerOOP.csproj` — cấu hình project .NET
