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
            ValidIssuer = "yourdomain.com", // JWT'nin do�ru oldu�unu do�rulamak i�in kullan�lan ge�erli veren
            ValidAudience = "yourdomain.com", // JWT'nin do�ru oldu�unu do�rulamak i�in kullan�lan ge�erli izleyici
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bitirmeASD@@bitirme!!!12345678@bitirme!!!1234...")),// JWT'nin do�ru oldu�unu do�rulamak i�in kullan�lan simetrik anahtar
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ilk ba�taki v1 SAB�TT�R DE���T�RME!!!!
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "B�T�RME PRJ", Version = "v0.0.3", Description = "B�T�RME PRJ" });
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
