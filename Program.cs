using CredexAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

string allowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.DateFormatString = "yyyy. MM. dd.";
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CredexConnection");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(allowSpecificOrigins);
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseAuthorization();

app.MapControllers();

app.Run();
