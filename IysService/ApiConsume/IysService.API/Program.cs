using IysService.BusinessLayer.Abstract;
using IysService.BusinessLayer.Concrete;
using IysService.BusinessLayer.Mappings;
using IysService.DataAccessLayer.Abstract;
using IysService.DataAccessLayer.Concrete;
using IysService.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IAppointmentDal, EfAppointmentDal>();
builder.Services.AddScoped<IAppointmentService, AppointmentManager>();

builder.Services.AddScoped<IXRayResultDal, EfXRayResultDal>();
builder.Services.AddScoped<IXRayResultService, XRayResultManager>();

builder.Services.AddScoped<IImageDal, EfImageDal>();
builder.Services.AddScoped<IImageService, ImageManager>();

var secretKey = Encoding.UTF8.GetBytes("LoginRegisterAPIJWT123LoginRegisterAPIJWT123"); // Replace with your secure key
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost", // Replace with your issuer
            ValidAudience = "http://localhost", // Replace with your audience
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            RoleClaimType = ClaimTypes.Role // Ensure Role claims are validated
        };
    });

// Add Authorization policies (if needed)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAll");

// Use Authentication and Authorization
app.UseAuthentication(); // Ensure this comes before UseAuthorization
app.UseAuthorization();

// Map Controllers
app.MapControllers();
app.Run();