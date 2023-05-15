using CloudinaryDotNet;
using DATN_NguyenThiThuHuong.API.Helpers;
using DATN_NguyenThiThuHuong.BL;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.BL.Services;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Helpers;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using DATN_NguyenThiThuHuong.DL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Principal;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileDL, FileDL>();
builder.Services.AddScoped<IRegionDL, RegionDL>();
builder.Services.AddScoped<IAddressReceiveDL, AddressReceiveDL>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IAddressReceiveService, AddressReceiveService>();
builder.Services.AddScoped<IUserTokenDL, UserTokenDL>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDL, CustomerDL>();
builder.Services.AddScoped<IAdminDL, AdminDL>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserTokenService, UserTokenService>();
builder.Services.AddScoped<IUserTokenDL, UserTokenDL>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICartDL, CartDL>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<IStatisticDL, StatisticDL>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();

builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// tạo các public api
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowAnonymousPolicy", policy =>
        policy.RequireAssertion(context => true));
});
// Cấu hình redis
//var redis = ConnectionMultiplexer.Connect("localhost");
//builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Bỏ bắn lỗi mặc định Atrribute
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Config respone để không chuyển hết về chữ thường
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSingleton(new Cloudinary(new Account(
    "drcxu9mfu",
    "713212469833668",
    "BchAzmro5tCXwSd5nAlTB0hkPRU"
)));

// Get connectionString
DatabaseContext.connectionString = builder.Configuration.GetConnectionString("MySqlLocal");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.UseCors("corspolicy");
app.MapControllers();

app.Run();
