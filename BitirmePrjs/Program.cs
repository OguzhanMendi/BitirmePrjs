using BitirmePrjs.Context;
using BitirmePrjs.Repository.Abstract;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com", // JWT'nin doðru olduðunu doðrulamak için kullanýlan geçerli veren
            ValidAudience = "yourdomain.com", // JWT'nin doðru olduðunu doðrulamak için kullanýlan geçerli izleyici
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bitirmeASD@@bitirme!!!12345678@bitirme!!!1234...")),// JWT'nin doðru olduðunu doðrulamak için kullanýlan simetrik anahtar
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ilk baþtaki v1 SABÝTTÝR DEÐÝÞTÝRME!!!!
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BÝTÝRME PRJ", Version = "v0.0.3", Description = "BÝTÝRME PRJ" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (JWT). Example: \"bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});
builder.Services.AddSingleton<BContext>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IMarkaRepository, MarkaRepository>();


var app = builder.Build();
// Global CORS policy
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());
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
