using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/add", (int num1, int num2) => num1 + num2);
app.MapGet("/greet", (string name) => $"Greetings {name}! Have you heard of the hapalopilus-nidulans partier? He was a fun guy.");
app.MapGet("/error", () => Results.Problem());
app.MapGet("/error/test", () => { throw new Exception("test");  });
app.MapControllers();

app.Run();
