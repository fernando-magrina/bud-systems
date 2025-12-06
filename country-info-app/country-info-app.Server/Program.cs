using AutoMapper;

using country_info_app.server.Mapper;
using country_info_app.server.Mapper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("worldbank", client =>
{
    client.BaseAddress = new Uri("https://api.worldbank.org");
    client.Timeout = TimeSpan.FromSeconds(3);
});

builder.Services.AddOpenApi();
builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
));

var configExp = new MapperConfigurationExpression();
configExp.AddProfile<CountryMapperProfile>();

var mapperConfig = new MapperConfiguration(configExp);
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<ICountryMapper, CountryMapper>();

var app = builder.Build();
app.UseCors();

app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
