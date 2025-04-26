using bookrental.core.Interfaces.Repositories;
using bookrental.core.Interfaces;
using bookrental.infrastructure.Data;
using bookrental.infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using bookrental.core.Interfaces.Services;
using bookrental.services;
using Microsoft.AspNetCore.Hosting;
using bookrental.web.Mappers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(ILoanRepository), typeof(LoanRepository));
builder.Services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));


builder.Services.AddScoped(typeof(ILoanService), typeof(LoanService));

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly("bookrental.infrastructure"))
);


builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
