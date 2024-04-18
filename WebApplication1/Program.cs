using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Book_Web.Data;
using Book_Web.Service;
using Book_Web.Service.Service_Foramt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Book_Web.Tools.Token;
using Book_Web.Tools.HashGen;
//跨域请求
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//
var builder = WebApplication.CreateBuilder(args);
var TokenConfig = builder.Configuration.GetSection("TokenOption").Get<TokenOption_Format>();
builder.Services.AddSingleton(TokenConfig);
//日志
builder.Logging.AddConsole();
//跨域请求
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:7000",
                                              "http://www.contoso.com").AllowAnyHeader().AllowAnyMethod(); ;
                      });
});
//JWT令牌

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = TokenConfig.Issuer,
        ValidateAudience = true,
        ValidAudience = TokenConfig.Audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfig.IssuerSigningKey))
    };
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    opt.AddPolicy("FactoryOnly", policy => policy.RequireRole("Factory"));
    opt.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});
//Jwt end

builder.Services.AddDbContext<Book_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Book_WebContext") ?? throw new InvalidOperationException("Connection string 'Book_WebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//注入Service层接口和依赖
builder.Services.AddScoped<BookService,BookServiceA>();
builder.Services.AddScoped<Log, LogA>();
builder.Services.AddScoped<TokenFe, Token_Gen>();
builder.Services.AddScoped<Hash_Interface, Hash_Gen>();
builder.Services.AddScoped<CreateUser, CreateuserA>();
builder.Services.AddScoped<InfoMationService,InfoMationA>();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//跨域访问
app.UseCors(MyAllowSpecificOrigins);
//JWT令牌
app.UseAuthentication();
//
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
