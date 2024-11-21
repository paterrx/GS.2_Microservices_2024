using globalSolution2.Services;
using globalSolution2.Cache;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<MongoService>(sp =>
    new MongoService("mongodb://localhost:27017", "globalSolutionDB"));

builder.Services.AddSingleton<RedisCache>(sp =>
    new RedisCache("localhost:6379"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
