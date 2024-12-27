using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
				builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();


app.MapGet("api/todo",async (AppDbContext context)=>{

				var items = await context.ToDos.ToListAsync();
				return Results.Ok(items);

});
app.MapPost("api/todo",async (AppDbContext context, ToDo toDo)=>{

	 await context.ToDos.AddAsync(toDo);
				await context.SaveChangesAsync();
				return Results.Created($"api/todo/{toDo.Id}",toDo);

});
app.MapPut("api/todo/{id}",async (AppDbContext context, int id, ToDo toDo)=>{

				var toDoModel = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
				if (toDoModel==null)
				{
								return Results.BadRequest();
				}
				toDoModel.ToDoName = toDo.ToDoName;
				await context.SaveChangesAsync();
				return Results.NoContent();
});
app.MapDelete("api/todo/{id}",async (AppDbContext context, int id)=>{

				var toDoModel = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
				if (toDoModel==null)
				{
								return Results.BadRequest();
				}
				context.ToDos.Remove(toDoModel);
				await context.SaveChangesAsync();
				return Results.NoContent();
});










//app.UseHttpsRedirection();


app.Run();

