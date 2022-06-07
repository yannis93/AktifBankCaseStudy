# AktifBankCaseStudy
- This development was made for AktifBank
- Api documentation is developed with swagger. Available at the /swagger endpoint.
- Developed using .net 6
- Mssql preferred as database

# Database Install
```
dotnet ef database update --project AktifBankCaseStudy.Infrastructure.EFCore/AktifBankCaseStudy.Infrastructure.EFCore.csproj -s AktifBankCaseStudy.API/AktifBankCaseStudy.API.csproj --context AktifBankDbContext
```
