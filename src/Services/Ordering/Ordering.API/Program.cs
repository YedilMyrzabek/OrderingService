using FluentValidation;
using FluentValidation.AspNetCore;
using Ordering.Application.Interfaces;
using Ordering.Application.Service;                 
using Ordering.Infrastructure.Extensions;           
using Ordering.Application.Mapping;
using Ordering.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(typeof(OrderMappingProfile).Assembly);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();