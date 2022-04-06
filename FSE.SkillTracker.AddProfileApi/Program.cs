using FSE.SkillTracker.AddProfileApi;
using FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Commands;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces.Base;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories.Base;
using MediatR;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<CosmosDbSettings>(configuration.GetSection("CosmosDb"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateProfileCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(ICosmosDbService), typeof(CosmosDbService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
