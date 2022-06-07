using AktifBankCaseStudy.Api.SeedWork.ProblemDetails;
using AktifBankCaseStudy.Application;
using AktifBankCaseStudy.Infrastructure.EfCore;
using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructureEFCore(builder.Configuration);
builder.Services.AddHttpContextAccessor();                               //Hellang.Middleware.ProblemDetails
builder.Services.ConfigureOptions<ProblemDetailsOptionsConfiguration>(); //Hellang.Middleware.ProblemDetails
builder.Services.AddProblemDetails();                                    //Hellang.Middleware.ProblemDetails

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails(); //Hellang.Middleware.ProblemDetails

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();