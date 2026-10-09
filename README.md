# EmployeeManagerOOP

Small .NET 8 console example comparing object-oriented and structured programming styles for employee management.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git, if cloning the repository

Check installation:

```bash
dotnet --version
git --version
```

## Setup

Clone repository and enter project directory:

```bash
git clone https://github.com/chung9920/a1oop.git
cd a1oop/OOP/EmployeeManagerOOP
```

Restore dependencies and build:

```bash
dotnet restore
dotnet build
```

## Run

```bash
dotnet run
```

Choose one option when prompted:

1. **OOP** — `EmployeeManagerOOP` class owns employee data and operations.
2. **Structured** — `EmployeeManager` struct stores data while separate procedures perform operations.

Both examples add three employees, display them, search for `Jane Smith`, remove `Mike Johnson`, and display the updated list.

## Project files

- `Program.cs` — console entry point and both examples
- `EmployeeManagerOOP.cs` — OOP manager implementation
- `EmployeeManager.cs` — `Employee` model and structured manager data
- `EmployeeManagerOOP.csproj` — .NET project configuration
