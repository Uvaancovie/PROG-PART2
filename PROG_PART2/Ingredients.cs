using System;

namespace RecipeApp
{

    //how are they calling values from the ingredients class into the recipe.cs class 
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }


        //ingredients is the generic list
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void Scale(double factor)
        {
            Quantity *= factor;
        }

        // you are displaying a value from a method to a string 
        // you are using {} to put the values of the of the ingredient list 

        //what is the generic list here ?
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
        }
    }
}
