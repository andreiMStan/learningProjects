using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
				app.UseSwagger();
				app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRewriter(new RewriteOptions().AddRedirect("tasks/(.*)", "todos/"));

var todos = new List<ToDo>();
app.Use(async (context, next) =>
{
				Console.WriteLine($"[{context.Request.Method}{context.Request.Path}{DateTime.UtcNow} Started.");
				await next(context);
				Console.WriteLine($"[{context.Request.Method}{context.Request.Path}{DateTime.UtcNow} Finished.");
});
app.MapPost("/todos", (ToDo task) =>
{
				todos.Add(task);
				return TypedResults.Created("/todos/{id}", task);
}).AddEndpointFilter((context,next) =>
{
var taskArgument = context.GetArgument<ToDo>(0);
var errors = new Dictionary<string, string[]>();
				if (taskArgument.DateDue < DateTime.UtcNow)
{
				errors.Add(nameof(ToDo.DateDue),["Cannot have due date in the past"]);
}
if (taskArgument.IsCompleted)
{
				errors.Add(nameof(ToDo.IsCompleted),["Cannot add completed todo."]);
}
if (errors.Count > 0)
{
				return  Results.ValidationProblem(errors);
}

});
app.MapGet("/todos/{id}", Results<Ok<ToDo>, NotFound> (int id)
				=>
{
				var targetTodo = todos.SingleOrDefault(t => t.Id == id);
				return targetTodo is null
								? TypedResults.NotFound()
								: TypedResults.Ok(targetTodo);
});
app.MapGet("/todos", () => todos);

app.MapDelete("/todos/{id}", (int id) => {
				todos.RemoveAll(t => t.Id == id);
});



app.Run();

public record ToDo(int Id, string Name, DateTime DateDue, bool IsCompleted);
