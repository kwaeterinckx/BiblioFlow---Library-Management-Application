using BiblioFlow_API.Services;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Repositories;
using BiblioFlow_BLL.Services;
using BiblioFlow_DB.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!)),
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminRequired", policy => policy.RequireRole("Admin"))
    .AddPolicy("StaffRequired", policy => policy.RequireRole("Staff"))
    .AddPolicy("AdminOrStaffRequired", policy => policy.RequireRole("Admin", "Staff"))
    .AddPolicy("UserRequired", policy => policy.RequireRole("User"))
    .AddPolicy("LoginRequired", policy => policy.RequireAuthenticatedUser());

builder.Services.AddDbContext<BiblioFlowContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BiblioFlow"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserRepository, CurrentUserService>();

builder.Services.AddScoped<IAuthRepository<User>, AuthService>();
builder.Services.AddScoped<IUserRepository<User>, UserService>();
builder.Services.AddScoped<ILibraryRepository<Library>, LibraryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
