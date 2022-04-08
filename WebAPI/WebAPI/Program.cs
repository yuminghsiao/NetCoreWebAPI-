using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Utility;
using WebAPIPractise.Service.Config;
using WebAPIPractise.Service.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService, UserService>();


//日志
builder.Logging.AddLog4Net("CfgFile/log4net.Config");

//註冊JWT
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
builder.Services.AddTransient<ICustomJWTService, CustomJWTService>();

#region jwt校驗
//第二步,增加鑑權邏輯
JWTTokenOptions tokenOptions = new JWTTokenOptions();
builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>//這裡事配置的鑑權的邏輯
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //JWT有一些默認的屬性,就是給鑑權時就可以篩選了
            ValidateIssuer= true,//是否驗證Issuer
            ValidateAudience = true,//是否驗證Audience
            ValidateLifetime = true,//是否驗證失效時間
            ValidateIssuerSigningKey = true,//是否驗證SigningKey
            ValidAudience = tokenOptions.Audience,
            ValidIssuer = tokenOptions.Issuer,//Issuer,這二項和前面簽發jwt的設置一致
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))//拿到SecurityKey
        };
    });
#endregion

//添加跨域策略
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//});

var corsPolicyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080", "*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

//Automapper映射
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//使用跨域策略
app.UseCors(corsPolicyName);
//app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
