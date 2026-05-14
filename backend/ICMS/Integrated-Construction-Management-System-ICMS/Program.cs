
using Integrated_Construction_Management_System_ICMS.Mapping;

//using Integrated_Construction_Management_System_ICMS.Services.LLM.Integrated_Construction_Management_System_ICMS.Services.LLM;

var builder = WebApplication.CreateBuilder(args);
var confi = builder.Configuration;
builder.Services.AddControllers();

//builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
//    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGroqService, GroqService>();
builder.Services.AddSwagger();
builder.Services.AddDBContext(confi);
builder.Services.AddapplicationServices(confi);
builder.Services.AddScoped<QueryRouter>();
builder.Services.AddScoped<ProjectDataService>();
builder.Services.AddScoped<RagService>();
//builder.Services.AddScoped<ProjectDataService>();
builder.Services.AddScoped<QueryAnalyzer>();
builder.Services.AddScoped<ContextBuilder > ();
builder.Services.AddFluentValidationAutoValidation();
TypeAdapterConfig.GlobalSettings.Scan(typeof(MappingConf).Assembly);
builder.Services.AddHttpClient();

// 2. Register the named HttpClient for Anthropic
//builder.Services.AddHttpClient("Anthropic", client =>
//{
//    client.BaseAddress = new Uri("https://api.anthropic.com");
//    client.Timeout = TimeSpan.FromSeconds(60);
//});
// 3. Register the ChatBot service


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