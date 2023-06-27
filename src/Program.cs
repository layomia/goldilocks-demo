using Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
    //options.SerializerOptions.TypeInfoResolverChain.Add(TodosContext.Default);
});

builder.Services
    .Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)))
    .AddOptions<AppSettings>();

WebApplication app = builder.Build();

app.MapGet("/todos", () => Todos.GetAllTodos());
app.MapGet("/todos/{id}", (int id) =>
    Todos.GetAllTodos().FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();