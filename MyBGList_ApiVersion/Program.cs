using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]);
        cfg.AllowAnyHeader();
        cfg.AllowAnyMethod();
    });
    options.AddPolicy(name: "AnyOrigin",
        cfg =>
        {
            cfg.AllowAnyOrigin();
            cfg.AllowAnyHeader();
            cfg.AllowAnyMethod();
        });
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo { Title = "MyBGList", Version = "v1.0" });
    options.SwaggerDoc(
        "v2",
        new OpenApiInfo { Title = "MyBGList", Version = "v2.0" });
});

builder.Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});


builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            $"/swagger/v1/swagger.json",
            $"MyBGList v1");
        options.SwaggerEndpoint(
            $"/swagger/v2/swagger.json",
            $"MyBGList v2");
    });
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.UseHttpsRedirection(); //Middle ware
//Get http://__/weatherforecast then this middleware 'UseHttpsRedirection'  will response / return with "Nope, I need HTTPS, not HTTP

app.UseCors("AnyOrigin");
app.UseAuthorization();

app.MapGet("/v{version:ApiVersion}/add",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    (int num1, int num2) => 
    num1 + num2);

app.MapGet("/v{version:ApiVersion}/greet",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    (string name) => 
    $"Greetings {name}! Have you heard of the hapalopilus-nidulans partier? He was a fun guy.");

app.MapGet("/v{version:ApiVersion}/error",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableCors("AnyOrigin")] 
    [ResponseCache(NoStore = true)] 
    () => Results.Problem());

app.MapGet("/v{version:ApiVersion}/error/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableCors("AnyOrigin")] 
    [ResponseCache(NoStore = true)] () => 
    { throw new Exception("test"); });

app.MapGet("/v{version:ApiVersion}/cod/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)] () =>
    Results.Text("<script>" +
    "window.alert('Your client supports JavaScript!" +
    $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
    "\\r\\n" +
    "Client time (UTC): ' + new Date().toISOString());" + 
    "</script>" + 
    "<boscript>Your cllient does not support JavaScript</noscript>", 
    "text/html"));

app.MapControllers().RequireCors("AnyOrigin");

app.Run();
