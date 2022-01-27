using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conString));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//Right click on IsDevelopment -> go to definition to view all four types of environments
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
