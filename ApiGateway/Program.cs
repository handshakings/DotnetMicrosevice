using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
//Declaration of config ocelot routing file
builder.Host.ConfigureAppConfiguration((config) => config.AddJsonFile("ocelot.json"));
builder.Services.AddOcelot();
// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//ocelot
app.UseOcelot();
app.Run();
