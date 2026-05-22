# Copilot Instructions for play112

This is a library management system built with C# .NET 8, demonstrating clean architecture with separation of concerns and dependency injection.

## Build, Test, and Lint Commands

### Build
```bash
dotnet build
```

### Run the Console Application
```bash
dotnet run --project src/Library.Console/Library.Console.csproj
```

### Run All Tests
```bash
dotnet test
```

### Run a Single Test Class or Test
```bash
# Run all tests in a specific class
dotnet test --filter "FullyQualifiedName~TestClassName"

# Run a specific test method
dotnet test --filter "FullyQualifiedName~TestClassName.TestMethodName"
```

### Run with Release Configuration
```bash
dotnet build --configuration Release
dotnet test --configuration Release
```

### Restore Dependencies
```bash
dotnet restore
```

## Architecture Overview

The project follows **Clean Architecture** with three main layers:

### 1. **Library.ApplicationCore** (Business Logic Layer)
- **Entities/**: Domain models (Patron, Book, BookItem, Loan, Author)
- **Enums/**: Enumeration types for return/extension statuses
- **Interfaces/**: Repository and service interfaces
- **Services/**: Business logic (LoanService, PatronService)

Key dependencies: None on infrastructure; defines contracts through interfaces.

### 2. **Library.Infrastructure** (Data Access Layer)
- **Data/JsonData.cs**: Centralized JSON file management for persistence
- **JsonPatronRepository & JsonLoanRepository**: Repository implementations using JSON files for storage
- Uses file-based persistence instead of a database

### 3. **Library.Console** (Presentation Layer)
- **Program.cs**: Sets up dependency injection container and bootstraps the app
- **ConsoleApp.cs**: Main console application logic and menu system
- **ConsoleState.cs**: Manages current user session state
- **CommonActions.cs**: Reusable console operations
- **Json/**: Contains JSON data files for patrons and loans
- **appSettings.json**: Configuration file

## Dependency Injection Setup

The console app uses Microsoft.Extensions.DependencyInjection to wire up dependencies. In **Program.cs**:
- Repositories are registered as scoped (JsonPatronRepository, JsonLoanRepository)
- Services are registered as scoped (LoanService, PatronService)
- JsonData is registered as a singleton for shared file access

When adding new services, follow this pattern:
```csharp
services.AddScoped<IMyService, MyServiceImplementation>();
```

## Key Conventions

### Repository Pattern
All data access goes through repository interfaces (ILoanRepository, IPatronRepository). Implementations use JSON files stored in `src/Library.Console/Json/`. This allows swapping storage mechanisms without changing business logic.

### Service Layer Pattern
Services contain business logic and validate state before calling repositories. Examples:
- `LoanService.ReturnLoan()` checks if loan exists and isn't already returned
- `LoanService.ExtendLoan()` validates membership expiration and loan status
- Services return status enums (LoanReturnStatus, LoanExtensionStatus) instead of throwing exceptions for validation failures

### Async/Await
All repository methods and services are async (Task-based). Always use `await` when calling them.

### JSON Persistence
The JsonData singleton manages reading/writing to JSON files:
- Patrons stored in `patrons.json`
- Loans stored in `loans.json`
Each repository uses JsonData to serialize/deserialize objects.

### Testing
Tests use **xUnit** and **NSubstitute** for mocking. Test structure mirrors source: `tests/UnitTests/ApplicationCore/` for testing Library.ApplicationCore classes.

### Configuration
The console app reads configuration from **appSettings.json** using Microsoft.Extensions.Configuration. Access configuration in services via injected IConfiguration.

## Project Dependencies

**NuGet Packages:**
- Microsoft.Extensions.DependencyInjection (8.0.0)
- Microsoft.Extensions.Configuration (8.0.0)
- Microsoft.Extensions.Configuration.Json (8.0.0)
- xUnit (2.5.3) for testing
- NSubstitute (5.1.0) for test mocking
- coverlet.collector (6.0.0) for code coverage

**.NET Target:** net8.0

## Quick Start for New Contributors

1. Clone and restore: `dotnet restore`
2. Build: `dotnet build`
3. Run tests: `dotnet test`
4. Run app: `dotnet run --project src/Library.Console/Library.Console.csproj`
5. When modifying repositories, update both the interface and the JsonRepository implementation
6. When adding services, register them in Program.cs and write unit tests using NSubstitute
