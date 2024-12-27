using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ItemRepository>();
var app = builder.Build();




if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
var items = app.MapGroup("/items");

items.MapGet("/", ([FromServices] ItemRepository items) => 
{ 
    return items.GetAll();
 });

items.MapGet("/{id}", ([FromServices] ItemRepository items, int id)=>
     {
         return items.GetById(id);
         
         
         });

items.MapPost("/",([FromServices] ItemRepository items, Item item)=>
{
    if (items.GetById(item.id) == null) 

    {
		items.Add(item);
        return Results.Created($"/items/{item.id}", item);
	}
    return Results.BadRequest();
});

items.MapPut("/{id}", ([FromServices] ItemRepository items,Item item,int id)=>
{
	if (items.GetById(item.id) == null)
    {
		return Results.BadRequest();

	}
    items.Update(item);
    return Results.NoContent();
});

items.MapDelete("/{id}", ([FromServices] ItemRepository items, int id) => {

	if (items.GetById(id) == null)
     return Results.BadRequest();

items.Delete(id);
    return Results.NoContent();

});

app.UseHttpsRedirection();


app.Run();

record Item(int id, string title, bool completed);

class ItemRepository
{
    private readonly Dictionary<int, Item> _items = new();
    public ItemRepository()
    {
        var item1 = new Item(1, "go to gym", false);
        var item2 = new Item(2, "go to home", false);
        var item3 = new Item(3, "go to market", false);

        _items.Add(item1.id, item1);
        _items.Add(item2.id, item2);
        _items.Add(item3.id, item3);

    }
      public List<Item> GetAll() => _items.Values.ToList();

    public Item? GetById(int id) => _items.ContainsKey(id) ? _items[id] : null;

    //public Item GetById(int id)
    //{
    //    var result = _items.ContainsKey(id);
    //    if (result)
    //    {
    //        return _items[id];
    //    }
    //    return null; 
    //}

    public void Add(Item obj) => _items.Add(obj.id, obj);

    public void Update(Item obj) => _items[obj.id] = obj;

    public void Delete(int id) => _items.Remove(id);

}

//class Item2
//{
//    public int Id { get; set; }
//    public string Title { get; set; }

//    public bool Completed { get; set; }
//}