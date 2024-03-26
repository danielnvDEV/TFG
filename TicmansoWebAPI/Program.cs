using Microsoft.EntityFrameworkCore;
using TicmansoWebAPI.Models;
using Microsoft.Net.Http.Headers;

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
       {
           policy.WithOrigins("http://localhost:5130", "https://localhost:7144/api/Ticmanso/users")
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 .AllowAnyMethod();
       });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TicmansoProContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection(); 

app.UseRouting();  

app.UseCors(MyAllowSpecificOrigins); 

app.UseAuthorization(); 

app.MapControllers();

app.Run();
