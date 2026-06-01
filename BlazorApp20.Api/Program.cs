<<<<<<< HEAD
﻿var builder = WebApplication.CreateBuilder(args);
=======
using BlazorApp20.Api.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
=======
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDB")
    ?? "mongodb://localhost:27017";

builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));
builder.Services.AddScoped<MongoService>();

>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
<<<<<<< HEAD

app.Run();
=======
app.Run();
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
