using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;
using Web.API;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Configuration.AddJsonFile("appsettings.json");
//var secretkey =builder.Configuration.GetSection("JWT").GetSection("KeySecrets").Value;
//var Issuer = builder.Configuration.GetSection("JWT").GetSection("ValidIssuer").Value;



builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    Opcion =>
{
    Opcion.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = Issuer,
        // ValidAudience = "https://localhost:44384",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:KeySecrets"]))
    };
}
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigrations();
}
app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler("/error");
//app.UseHttpsRedirection();



app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
