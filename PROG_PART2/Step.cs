using System;

namespace RecipeApp
{
    public class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }


        //what does public override mean ?
        public override string ToString()
        {
            return Description;
        }
    }
}
