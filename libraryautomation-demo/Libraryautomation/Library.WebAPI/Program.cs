using Library.Business.Abstract;
using Library.Business.Concrete;
using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Context;
using Library.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IBookService,BookManager>();
builder.Services.AddScoped<IBorrowedRepository, BorrowedRepository>();
builder.Services.AddScoped<IBorrowedService, BorrowedManager>();

builder.Services.AddEndpointsApiExplorer(); // Swagger için gerekli
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Baþlýðý",
        Version = "v1",
        Description = "API açýklamasý"
    });
});

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Swagger UI'yi ana sayfada açar
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
