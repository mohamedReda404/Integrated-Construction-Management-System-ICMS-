

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddSwagger();
builder.Services.AddDBContext(builder.Configuration);
//builder.Services
//    .AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();
//builder.Services.AddapplicationServices();


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateIssuer = true,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidIssuer = "Integrated_Construction_Management_System_ICMS",
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sk_live_TVN1rkjqmdbjSTV2McHrKctC8csmbbPC"))
//    };
//});

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


//app.UseAuthentication();
//app.UseAuthorization();
app.MapIdentityApi<ApplicationUser>();
app.MapControllers();


app.Run();