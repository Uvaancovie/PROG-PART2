using System;
using System.Collections.Generic;
using System.Linq;
using RecipeApp;

namespace RecipeApp
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();
        // explain classes & how you call values from classes beginners stuff 
        //what is a static list & what does it mean ?
       

        

        static void Main(string[] args)
        {
            bool running = true;
            //what is a boolean value & explain this 

            //the application is running on a while loop with condition that while the boolean
            // value "running" is true all the operations in the while loop MUST RUN 
            while (running)
            {
                Console.WriteLine("Recipe Application");
                Console.WriteLine("1. Enter new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Clear all recipes");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();


                //WHAT IS A SWITCH CASE AND HOW DOES IT WORK 
                // THE SWITCH CASE IS BEING USED TO INDEX THE CONSOLE.WRITELINES
                switch (choice)
                {
                    case "1":
                        EnterRecipe();
                        break;
                    case "2":
                        DisplayAllRecipes();
                        break;
                    case "3":
                        DisplaySpecificRecipe();
                        break;
                    case "4":
                        ScaleRecipe();
                        break;
                    case "5":
                        recipes.Clear();
                        Console.WriteLine("All recipes cleared.");
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void EnterRecipe()
        {
            //Explain what a static void is & how it works 
            //what does it do & how you are calling the method within in 
            // switch case and that will break if the program is exited
            Console.Write("Enter the name of the recipe: ");
            var name = Console.ReadLine();
            var recipe = new Recipe(name);

            Console.Write("Enter the number of ingredients: ");
            var numIngredients = int.Parse(Console.ReadLine());

            //explain how a for loop works & what it does 
            // you have a for looop for the ingredients 
            // this will now get all the relevant details of the ingredients 
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                var ingredientName = Console.ReadLine();

                Console.Write($"Enter the quantity of {ingredientName}: ");
                var quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {ingredientName}: ");
                var unit = Console.ReadLine();

                Console.Write($"Enter the calories for {ingredientName}: ");
                var calories = double.Parse(Console.ReadLine());

                Console.Write($"Enter the food group for {ingredientName}: ");
                var foodGroup = Console.ReadLine();

                recipe.Ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            // How To Get The Number Of Steps 

            Console.Write("Enter the number of steps: ");
            var numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter the description of step {i + 1}: ");
                var description = Console.ReadLine();
                recipe.Steps.Add(new Step(description));
            }

            recipe.OnCaloriesExceeded += (message) => Console.WriteLine(message);

            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList();
        }

        //how to display the recipes , for example 
        //each one of the steps have a method & static void next to it 
        // notice how all the methods & functionality , whether it be 
        // calculating the calories of the number of steps , it used methods 
        // to get the input , process the input , then capture the output again 
        // display the output to you 

        static void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"- {recipe.Name}");
            }
        }

        static void DisplaySpecificRecipe()
        {
            Console.Write("Enter the name of the recipe to display: ");
            var name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            //explain what this line of code means 


            //simple if & else statements
            if (recipe != null)
            {
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        //Explain the method of the scale of recipes 
        static void ScaleRecipe()
        {
            Console.Write("Enter the name of the recipe to scale: ");
            var name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                Console.Write("Enter the scaling factor (0.5, 2, 3): ");
                var factor = double.Parse(Console.ReadLine());
                recipe.Scale(factor);
                Console.WriteLine("Recipe scaled.");
            }

        }
    }
}