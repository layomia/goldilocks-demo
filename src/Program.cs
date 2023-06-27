using Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

RouteGroupBuilder todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => Todos.GetAllTodos());
todosApi.MapGet("/{id}", (int id) =>
    Todos.GetAllTodos().FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();