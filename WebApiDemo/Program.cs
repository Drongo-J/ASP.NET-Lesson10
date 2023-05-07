using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Repositories.Abstract;
using WebApiDemo.Repositories.Concrete;
using WebApiDemo.Services.Abstract;
using WebApiDemo.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Connection to StudentDB database
var connection = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

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
