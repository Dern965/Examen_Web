using Examen.Context;

var builder = WebApplication.CreateBuilder(args);

BancoContext database = new BancoContext();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Examen",
        Version = "v0.1",
        Description = "Examen sobre un sistema bancario",
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Examen",
            Url = new Uri("https://localhost:7239")
        },
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

database.Database.EnsureCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
