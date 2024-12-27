
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlite(conn));

builder.Services.AddTransient<UserService>();


var app = builder.Build();

app.MapGet("/users", (UserService users) => {
	return Results.Ok(users.GetAll()); 
	
});

app.MapGet("/users/{id}", (UserService users, int id) =>
{
	var user = users.GetById(id);

	if (user==null)
	{
		return Results.NotFound("User not found");

	}
	
	return Results.Ok(user);

});

//app.MapDelete("/users{id}", (UserService users, int id) => {

//	var user = users.DeleteUser(id);
//if (user == null)
//	{
//		return Results.NotFound("User not found");
//	}
//	return Results.NoContent();
//});

app.MapDelete("/users/{id}", (UserService users,int id) =>
{
	var result = users.DeleteUser(id);
	if (result)
	{
	return Results.NoContent();
	}
	return Results.BadRequest("User not found");
});
app.MapPost("/users", (UserService users, User newUser) => {
	users.AddUser(newUser);
	return Results.Created($"/users/{newUser.Id}",newUser);
});


app.MapPut("/users/{id}", (UserService users , User updateUser, int id) => {

	var currentUserExist = users.GetById(id);

	if (currentUserExist !=null)
	{
		users.UpdateUser(updateUser);
		return Results.Ok(users);
	}

	return Results.BadRequest("User not found");
});










//app.MapGet("Hello", () => "welcome to minimal api");


//Without DI 
////app.MapGet("/users", () =>
////	{
////		return Results.Ok(users);
////});
////app.MapGet("/users/{id}", (int id) =>
////	{
////		var user = users.FirstOrDefault(x => x.Id == id);
////		if (user==null)
////		{
////			return Results.NotFound("User does not exists");

////		}
////		return Results.Ok(user);
////});

////app.MapPost("/users", (User newUser) => {
////	//Validate user data
////	users.Add(newUser);

////	//saving to db


////	return Results.Created($"/users/{newUser.Id}",newUser);

////});

////app.MapDelete("/users/{id}", (int id) =>
////{
////	var user = users.FirstOrDefault(x => x.Id == id);
////	if (user==null)
////	{
////		return Results.NotFound("User not found");
////	}

////	users.Remove(user);

////	//	return Results.Ok($"/users {user.Id}, removed from list");
////	return Results.NoContent();
////});


////app.MapPut("/users/{id}", (int Id, User updateUser) =>
////{
////	var user = users.FirstOrDefault(x => x.Id == Id);
////	if (user==null)
////	{
////		return Results.NotFound("User not found");
////	}
////	user.FirstName = updateUser.FirstName;
////	user.LastName = updateUser.LastName;


////	return Results.Ok(users);
////}) ;
app.Run();


class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

class ApiDbContext : DbContext
{
	public virtual DbSet<User> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options ) 
		: base(options)
    {
	

	}
}
class UserService
{
	private readonly ApiDbContext _dbcontext;

	public UserService(ApiDbContext dbcontext)
	{
		_dbcontext = dbcontext;
	}

//	private readonly List<User> Users = new List<User>
//	//var users = new List<User>
//{
//	new User()
//	{
//		FirstName="Andrei",
//		LastName="Stan",
//		Id=1
//	},
//	new User()
//	{
//		FirstName="AAA",
//		LastName="BBB",
//		Id=2
//	},
//	new User()
//	{
//		FirstName="CCC",
//		LastName="DDD",
//		Id=3
//	},
//};

	public IEnumerable<User> GetAll() => _dbcontext.Users.ToList();

	public User? GetById(int id) => _dbcontext.Users.FirstOrDefault(x => x.Id == id);

	public void AddUser(User user)
	{


_dbcontext.Users.Add(user);
		_dbcontext.SaveChanges();

		

	}
	//public IEnumerable<User> GetAll() => Users.ToList();

	//public User? GetById(int id) => Users.FirstOrDefault(x => x.Id == id);

	//public void AddUser(User user)
	//=> Users.Add(user);
	


	//another way
	////public void DeleteUser(int id) =>
	//Users.Remove(Users.FirstOrDefault(x => x.Id == id));
	public bool DeleteUser(int id)
		{
		var userForDeletion = _dbcontext.Users.FirstOrDefault(x=>x.Id==id);
	if (userForDeletion !=null)
	{
			_dbcontext.Users.Remove(userForDeletion);
			_dbcontext.SaveChanges();

			return true;
		}
		return false;
	}

	public void UpdateUser(User userForUpdate)
	{
		var currentUser = _dbcontext.Users.FirstOrDefault(x => x.Id == userForUpdate.Id);

		if (currentUser != null)
		{
			currentUser.FirstName = userForUpdate.FirstName;
			currentUser.LastName = userForUpdate.LastName;
			_dbcontext.SaveChanges();

		}
	}
}