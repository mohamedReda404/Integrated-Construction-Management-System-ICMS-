var builder = WebApplication.CreateBuilder(args);
var confi = builder.Configuration;
builder.Services.AddControllers();

//builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
//    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddSwagger();
builder.Services.AddDBContext(confi);
builder.Services.AddapplicationServices(confi);

builder.Services.AddFluentValidationAutoValidation();

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