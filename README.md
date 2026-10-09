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

Chọn một tùy chọn khi chương trình yêu cầu:

1. **OOP** — class `EmployeeManagerOOP` quản lý dữ liệu và các thao tác với nhân viên.
2. **Structured** — struct `EmployeeManager` lưu dữ liệu, các procedure bên ngoài thực hiện thao tác.

Cả hai ví dụ đều thêm ba nhân viên, hiển thị danh sách, tìm `Jane Smith`, xóa `Mike Johnson`, rồi hiển thị danh sách cập nhật.

## Các file chính

- `Program.cs` — điểm khởi chạy console và hai ví dụ
- `EmployeeManagerOOP.cs` — triển khai manager theo hướng đối tượng
- `EmployeeManager.cs` — model `Employee` và dữ liệu manager theo kiểu structured
- `EmployeeManagerOOP.csproj` — cấu hình project .NET
