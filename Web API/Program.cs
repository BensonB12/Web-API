using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.UseHttpsRedirection(); //Middle ware
//Get http://__/weatherforecast then this middleware 'UseHttpsRedirection'  will response / return with "Nope, I need HTTPS, not HTTP

app.UseCors("AnyOrigin");
app.UseAuthorization();

app.MapGet("/add", (int num1, int num2) => num1 + num2);
app.MapGet("/greet", (string name) => $"Greetings {name}! Have you heard of the hapalopilus-nidulans partier? He was a fun guy.");
app.MapGet("/error", [EnableCors("AnyOrigin")] [ResponseCache(NoStore = true)] () => Results.Problem());
//app.MapGet("/error", () => Results.Problem()).RequireCors("AnyOrigin");
//app.MapGet("/error/test", () => { throw new Exception("test");  }).RequireCors("AnyOrigin");
app.MapGet("/error/test", [EnableCors("AnyOrigin")] [ResponseCache(NoStore = true)] () => { throw new Exception("test"); });

app.MapGet("/cod/test",
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
