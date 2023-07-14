using System.Reflection;
using System.Text.Json.Serialization;
using API.Extensions;
using Application;
using Core;
using FluentValidation.AspNetCore;
using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;
        options.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ApplicationExtensions)));
    })
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCoreExtensions();
builder.Services.AddPersistenceExtensions(builder.Configuration);
builder.Services.AddApplicationExtensions();
builder.Services.AddJwtAuthenticationExtensions(builder.Configuration);
builder.Services.AddCustomSwaggerExtensions();
builder.Services.AddInfrastructureExtensions(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoreMiddlewares();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();