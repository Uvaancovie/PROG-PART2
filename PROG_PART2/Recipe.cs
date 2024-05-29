using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{

    // this is very similar to models in cloud development 

    // you have your public class recipe 
    public class Recipe
    {
        // what do getter & setters do 

        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public delegate void CalorieNotification(string message);

        public event CalorieNotification OnCaloriesExceeded;

        public Recipe(string name)
            // what is the meaning of these lines of codes 
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void Display()
        {
            // you can just create the methods with the approriate naming conventions & call them to display 
            // explain how you are calling the values & what you are doing to get them . 
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine("Steps:");
            foreach (var step in Steps)
            {
                Console.WriteLine($"- {step}");
            }

            double totalCalories = Ingredients.Sum(i => i.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: The total calories of the recipe '{Name}' exceed 300!");
            }
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
        }
    }
}
