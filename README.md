# AktifBankCaseStudy
- This development was made for AktifBank
- Api documentation is developed with swagger. Available at the /swagger endpoint.
- Developed using .net 6
- Mssql preferred as database

# Database Install
To change the connection string, you can go to the appsettings.json file inside the AktifBankCaseStudy.Api project.
```
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AktifBankCaseStudyDb;User Id=sa;Password=MyPass@word;"
  }
```
After editing you can run the following command

```
dotnet ef database update --project AktifBankCaseStudy.Infrastructure.EFCore/AktifBankCaseStudy.Infrastructure.EFCore.csproj -s AktifBankCaseStudy.API/AktifBankCaseStudy.API.csproj --context AktifBankDbContext
```
