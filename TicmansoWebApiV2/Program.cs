using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using TicmansoV2.Shared;
using TicmansoV2.Shared.Contracts;
using TicmansoWebApiV2.Context;
using TicmansoWebApiV2.Controllers;
using TicmansoWebApiV2.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
       {
           policy.WithOrigins("https://localhost:7174", "http://localhost:5000", "http://localhost:7291", "https://localhost:7174/teams-chat",
                   "https://www.ticmanso.com:7174", "http://www.ticmanso.com:7174", "http://danielnv-001-site1.atempurl.com",
                   "https://danielnv-001-site1.atempurl.com", "http://localhost:5119", "https://clientewebtic-001-site1.etempurl.com", "http://clientewebtic-001-site1.etempurl.com")
                 .AllowAnyHeader()
                 //.AllowAnyOrigin()
                 .AllowAnyMethod();
                 
       });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicmansoDbContext>(options =>
{ 
        options.UseSqlServer(builder.Configuration.GetConnectionString("StringSQL2") ??
        throw new InvalidOperationException("Connection String is not found"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TicmansoDbContext>()
    .AddSignInManager()
     .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddScoped<IUserAccount, AccountRepository>();
builder.Services.AddScoped< IUrlHelper, UrlHelper>();
builder.Services.AddScoped<EmailController>();

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromHours(1));

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.UseStaticFiles();

app.MapControllers();
//Crear BBDD
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TicmansoDbContext>();
    dbContext.Database.Migrate();


    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminEmail = "admin@ticmanso.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            Name = "Administrador Ticmanso"
        };
        await userManager.CreateAsync(adminUser, "AdminPassword1!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
app.Run();
