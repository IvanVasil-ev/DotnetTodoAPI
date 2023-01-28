using Microsoft.OpenApi.Models;
using SharpTodoApi.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sharp Todo API",
        Description = "Simple ASP.NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Author",
            Url = new Uri("https://github.com/IvanVasil-ev")
        }
    });
});

builder.Services.AddScoped<TodoListContext>();

builder.Services.AddRouting(options => options.LowercaseUrls= true);
builder.Services.AddControllers();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
