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


//���
builder.Logging.AddLog4Net("CfgFile/log4net.Config");

//���UJWT
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
builder.Services.AddTransient<ICustomJWTService, CustomJWTService>();

#region jwt����
//�ĤG�B,�W�[Ų�v�޿�
JWTTokenOptions tokenOptions = new JWTTokenOptions();
builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>//�o�̨ưt�m��Ų�v���޿�
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //JWT���@���q�{���ݩ�,�N�O��Ų�v�ɴN�i�H�z��F
            ValidateIssuer= true,//�O�_����Issuer
            ValidateAudience = true,//�O�_����Audience
            ValidateLifetime = true,//�O�_���ҥ��Įɶ�
            ValidateIssuerSigningKey = true,//�O�_����SigningKey
            ValidAudience = tokenOptions.Audience,
            ValidIssuer = tokenOptions.Issuer,//Issuer,�o�G���M�e��ñ�ojwt���]�m�@�P
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))//����SecurityKey
        };
    });
#endregion

//�K�[��쵦��
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

//Automapper�M�g
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//�ϥθ�쵦��
app.UseCors(corsPolicyName);
//app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
