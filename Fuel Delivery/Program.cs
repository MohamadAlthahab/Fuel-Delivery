using AutoMapper;
using Fuel_Delivery;
using Fuel_Delivery.Configurations;
using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;
using Fuel_Delivery.Repository;
using Fuel_Delivery.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")
    ));

builder.Services.Configure<IdentityOptions>(o => o.SignIn.RequireConfirmedEmail = true);
builder.Services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(1));

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddIdentity<User , IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(MapperInitilizer));
builder.Services.AddScoped<IAuthManger, AuthManger>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fuel Delivery", Version = "v1" }));

builder.Services.AddControllers().AddNewtonsoftJson(op =>
                op.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "Fuel Delivery v1");
    });
}
app.UseSwagger(o => o.SerializeAsV2 = true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

