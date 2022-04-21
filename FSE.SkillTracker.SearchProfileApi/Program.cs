using FluentValidation.AspNetCore;
using FSE.SkillTracker.AddProfileApi.Application.Behaviors;
using FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Queries;
using FSE.SkillTracker.AddProfileApi.Application.Intefaces;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using FSE.SkillTracker.AddProfileApi.Application.Validators;
using FSE.SkillTracker.AddProfileApi.Domain.Configurations;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories.Base;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<CreateProfileCommandValidator>();
    s.RegisterValidatorsFromAssemblyContaining<SkillExpertiseValidator>();
});
ConfigurationManager configuration = builder.Configuration;

CosmosOptions cosmosConfig = configuration.GetSection(key: nameof(CosmosOptions)).Get<CosmosOptions>();
builder.Services.AddSingleton<ICosmosContainerFactory>(new CosmosContainerFactory(cosmosConfig.EndpointUrl, cosmosConfig.AuthKey, cosmosConfig.DatabaseName, cosmosConfig.Containers));

builder.Services.AddMediatR(typeof(GetProfilesByCriteriaQuery));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(FSE.SkillTracker.UpdateProfileApi.Middleware.ExceptionHandlingMiddleware));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IProfileRepository), typeof(ProfileRepository));
builder.Services.AddScoped(typeof(ISkillsetRepository), typeof(SkillsetRepository));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
    options.ReportApiVersions = true;
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
