using E_Commerce.Core.Data;
using E_Commerce.Core.Utils;
using E_Commerce.ProductsApi.Application.CreateProducts;
using E_Commerce.ProductsApi.Application.UpdateProducts;
using E_Commerce.ProductsApi.Data.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


/*validations for fluent Api*/
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductsCommand>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductsCommand>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly
    );
});

#region  " Postgres "
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(
                   builder.Configuration.GetConnectionString("DefaultConnection")
               ).EnableSensitiveDataLogging()
                .UseLazyLoadingProxies()
           );
#endregion

DependencyResolver.RegisterDependencies(builder);
builder.Services.AddScoped<IDbContext, AppDbContext>();

builder.Services.AddCors(options =>
{

    options.AddPolicy("Development",
          builder =>
              builder
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              ); // allow credentials

    options.AddPolicy("Production",
        builder =>
            builder
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              ); // allow credentials
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {

        opt.SwaggerEndpoint("/openapi/v1.json", "Products api");
    });
    app.UseDeveloperExceptionPage();
    app.UseCors("Development");
}
else
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {

        opt.SwaggerEndpoint("/openapi/v1.json", "Products api");
    });
    app.UseCors("Production");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/*update database*/
using (var scope = app.Services.CreateScope())
{
    using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
    {
        try
        {
            appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
app.Run();
