using ProductApiAot.Features.Products.Endpoints;
using ProductApiAot.Infrastructure.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// 🔥 modular DI
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddRepositories()
    .AddServices();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapProductEndpoint();

app.Run();


