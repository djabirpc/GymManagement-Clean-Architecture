
## Commands

Run Project
```bash
  dotnet run --project .\src\GymManagement.Api\
```

Install Package
```bash
  dotnet add package <PACKAGE_NAME> -v <VERSION>
  dotnet add .\src\GymManagement.Infrastructure\ package Microsoft.EntityFrameworkCore
```

Make Migreation
```bash
dotnet ef migrations add InitialCreate -p .\src\GymManagement.Infrastructure\ -s .\src\GymManagement.Api\
dotnet ef database update -p .\src\GymManagement.Infrastructure\ -s .\src\GymManagement.Api\
```

Check .NET Environment
```bash
dotnet --info
dotnet --list-sdks
dotnet --list-runtimes
```

Restore / Build / Clean
```bash
dotnet restore
dotnet build
dotnet build -c Release
dotnet clean
```
Build a specific project:
```bash
dotnet build .\src\GymManagement.Api\
```

Run Project (with environment)
```bash
dotnet run --project .\src\GymManagement.Api\ --environment Development
dotnet run --project .\src\GymManagement.Api\ --configuration Release
```

Add / Remove / List Packages
```bash
dotnet add package <PACKAGE_NAME>
dotnet add .\src\GymManagement.Infrastructure\ package Microsoft.EntityFrameworkCore.SqlServer

dotnet remove package <PACKAGE_NAME>

dotnet list package
dotnet list .\src\GymManagement.Infrastructure\ package
```

Update Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet list package --outdated
```

