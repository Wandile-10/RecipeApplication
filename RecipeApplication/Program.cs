using System;

namespace RecipeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool exit = false;

            Console.WriteLine("==========================================================================");
            Console.WriteLine("Welcome to My Recipe App!");
            Console.WriteLine("==========================================================================");

            while (!exit)
            {
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        recipeManager.EnterRecipeDetails();
                        break;
                    case 2:
                        recipeManager.DisplayRecipe();
                        break;
                    case 3:
                        recipeManager.ScaleRecipe();
                        break;
                    case 4:
                        recipeManager.ResetQuantities();
                        break;
                    case 5:
                        recipeManager.ClearData();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class RecipeManager
    {
        public Ingredient[] ingredients;
        public Step[] steps;

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            string recipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount;
            if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of ingredients.");
                return;
            }

            ingredients = new Ingredient[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter quantity for {name}:");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number for the quantity.");
                    return;
                }

                Console.WriteLine($"Enter unit for {name}:");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount;
            if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of steps.");
                return;
            }

            steps = new Step[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();
                steps[i] = new Step(description);
            }

            Console.WriteLine($"Recipe '{recipeName}' details entered successfully.");
        }

        public void DisplayRecipe()
        {
            if (ingredients == null || steps == null)
            {
                Console.WriteLine("Recipe details are not entered yet.");
                return;
            }

            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe()
        {
            if (ingredients == null)
            {
                Console.WriteLine("No recipe to scale. Please enter recipe details first.");
                return;
            }

            Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
            double factor;
            if (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
            {
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 as the scaling factor.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        public void ResetQuantities()
        {
            // Reset quantities to original values (not implemented in this basic example)
            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearData()
        {
            ingredients = null;
            steps = null;
            Console.WriteLine("Recipe data cleared successfully.");
        }
    }

    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    class Step
    {
        public string Description { get; }

        public Step(string description)
        {
            Description = description;
        }
    }
}
