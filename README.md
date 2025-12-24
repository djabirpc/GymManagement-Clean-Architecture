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
