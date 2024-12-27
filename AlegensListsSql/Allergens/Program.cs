

using System.Xml.Linq;
using System;
using System.Linq;

class Program
{
 class Recipe
 {
  public String recipeCode { get; set; }
  public String recipeName { get; set; }
  public List<String> ListOfAllergensInRecipe { get; set; }
 }
 class Allergens
 {
  public String code { get; set; }
  public string name { get; set; }

  public Allergens() { }

 }

    static void Main(string[] args)
    {

        List<Allergens> AllAllergens = new List<Allergens>()
            {
                new Allergens() { code = "A01", name= "Fish"},
                new Allergens() { code = "A02", name= "Soy beans"},
                new Allergens() { code = "A03", name= "Peanuts"},
                new Allergens() { code = "A04", name= "Eggs"},
                new Allergens() { code = "A05", name= "Gluten"}
            };

        List<Recipe> recipeCollection = new List<Recipe>()
            {
                 new Recipe() { recipeCode = "R001", recipeName = "Chicken pasta bake", ListOfAllergensInRecipe = new List<String> { "A04", "A05"} },
                 new Recipe() { recipeCode = "R002", recipeName = "chicken casserole", ListOfAllergensInRecipe = new List<String> {"A04", "A05", "A01", "A02" }},
                 new Recipe() { recipeCode = "R003", recipeName = "burgers", ListOfAllergensInRecipe = new List<String> { "A04"} },
                 new Recipe() { recipeCode = "R101", recipeName = "pork tacos", ListOfAllergensInRecipe = new List<String> { "A03", "A01"} },
                 new Recipe() { recipeCode = "R099", recipeName = "Prawn tikka masala", ListOfAllergensInRecipe = new List<String> { "A01"} },
                 new Recipe() { recipeCode = "R011", recipeName = "lasagne", ListOfAllergensInRecipe = new List<String> {"A05"} },
                 new Recipe() { recipeCode = "R012", recipeName = "Puttanesca", ListOfAllergensInRecipe = new List<String> { "A02", "A01"} },
  };


        //(d)Allow the user to enter a list of allergens, the program should then display the recipe names that do not contain these allergens.



        var disAl = recipeCollection.OrderBy(r => r.recipeName).ToList();
        foreach (var item in disAl)
        {
            Console.WriteLine(item.recipeName);
        }
        Console.WriteLine("Enter list allergens code sep by comma");
        string aaa = "";

        aaa = Console.ReadLine();
        var aa = aaa.Split(',').Select(a => a.Trim()).ToList();

        var recipesWithoutAllergens =
         recipeCollection
          .Where(recipe =>
          !recipe.ListOfAllergensInRecipe
          .Any(allergenCode => aa
          .Contains(allergenCode)))
          .ToList();

        foreach (var item in recipesWithoutAllergens)
        {
            Console.WriteLine(item.recipeName);
        }

        //  (c)Calculate and display the most common allergen(name) found in the recipe collection.

        var mostC = recipeCollection
                  .SelectMany(r => r.ListOfAllergensInRecipe)
                  .GroupBy(a => a)
                  .OrderByDescending(g => g.Count())
                  .FirstOrDefault();
        var allergen = AllAllergens.
          FirstOrDefault(item => item.code == mostC.Key);

        Console.WriteLine(allergen.name);
        Console.WriteLine(mostC.Count());


        var tnr = recipeCollection.Count();
        var avg = recipeCollection.Sum(r => r.ListOfAllergensInRecipe.Count);
        Console.WriteLine(Math.Round((double)avg / tnr, 2));


        var dic = AllAllergens
         .ToDictionary(c => c.code, c => c.name);

        var result = recipeCollection
         .Select(r => new
         {
             recipeName = r.recipeName,
             Allergens = string.Join(",", r.ListOfAllergensInRecipe
          .Select(cod => dic[cod]))
         });

        //foreach (var aaa in result)
        //{
        //    Console.WriteLine($"{aaa.recipeName} contains: {aaa.Allergens}");
        //}

  //var recNandAlg = from rec in recipeCollection
                   //.Select(rec => rec.recipeName)


  foreach (var recipe in recipeCollection)
        {
            var allergenNames = recipe.ListOfAllergensInRecipe
                .Select
                (allergenCode => AllAllergens.FirstOrDefault(a => a.code == allergenCode)?.name)
                .Where(name => !string.IsNullOrEmpty(name)) // Filter out nulls if any
                .ToList();

            Console.WriteLine($"{recipe.recipeName} contains: {string.Join(", ", allergenNames)}");

            var resulte = recipeCollection
             .Select(recipe => new
             {
                 RecipeName = recipe.recipeName,
                 Allergens = string
                    .Join(", ", recipe.ListOfAllergensInRecipe
                        .Select
                        (code => AllAllergens
                        .First
                        (a => a.code == code).name))
             });

            // Display the result
            foreach (var item in resulte)
            {
                Console.WriteLine($"{item.RecipeName} contains: {item.Allergens}");

            }
        } 
    
    
   }
 }
