namespace Models;

using System.Text.Json.Serialization;

public class Todo
{
    public required int Id { get; init; }

    public required string? Title { get; init; }

    public required DateOnly? DueBy { get; init; }

    public required Status Status { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status 
{
    NotStarted,
    InProgress,
    Done
}

public static class Todos
{
    public static IEnumerable<Todo> GetAllTodos()
    {
        yield return new Todo { Id = 0, Title = "Wash the dishes.", DueBy = DateOnly.FromDateTime(DateTime.Now), Status = Status.Done };
        yield return new Todo { Id = 1, Title = "Dry the dishes.", DueBy = DateOnly.FromDateTime(DateTime.Now), Status = Status.Done };
        yield return new Todo { Id = 2, Title = "Turn the dishes over.", DueBy = DateOnly.FromDateTime(DateTime.Now), Status = Status.InProgress };
        yield return new Todo { Id = 3, Title = "Walk the kangaroo.", DueBy = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Status = Status.NotStarted };
        yield return new Todo { Id = 4, Title = "Call Grandma.", DueBy = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Status = Status.NotStarted };
    }
}

//[JsonSerializable(typeof(IEnumerable<Todo>))]
//public partial class TodosContext : JsonSerializerContext { }