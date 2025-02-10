using AuthSample.Api.Controller.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITokenManager, TokenManager>();

builder.Services.AddAuthentication(opt => 
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt => 
{
    var jwtSettings = Configuration.JwtSettings;
    var tokenKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

    opt.TokenValidationParameters = new()
    {
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,

        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();