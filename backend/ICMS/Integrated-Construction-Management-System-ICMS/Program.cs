using Integrated_Construction_Management_System_ICMS.Mapping;

var builder = WebApplication.CreateBuilder(args);
var confi = builder.Configuration;
builder.Services.AddControllers();

//builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
//    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddSwagger();
builder.Services.AddDBContext(confi);
builder.Services.AddapplicationServices(confi);

builder.Services.AddFluentValidationAutoValidation();
TypeAdapterConfig.GlobalSettings.Scan(typeof(MappingConf).Assembly);
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();