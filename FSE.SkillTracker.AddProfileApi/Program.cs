using FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Commands;
using FSE.SkillTracker.AddProfileApi.Application.Features.Skillset.Commands;
using FSE.SkillTracker.AddProfileApi.Application.Intefaces;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using FSE.SkillTracker.AddProfileApi.Domain.Configurations;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories.Base;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;

CosmosOptions cosmosConfig = configuration.GetSection(key: nameof(CosmosOptions)).Get<CosmosOptions>();
builder.Services.AddSingleton<ICosmosContainerFactory>(new CosmosContainerFactory(cosmosConfig.EndpointUrl, cosmosConfig.AuthKey, cosmosConfig.DatabaseName, cosmosConfig.Containers));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateSkillsetCommand));
builder.Services.AddMediatR(typeof(CreateProfileCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IProfileRepository), typeof(ProfileRepository));
builder.Services.AddScoped(typeof(ISkillsetRepository), typeof(SkillsetRepository));

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
