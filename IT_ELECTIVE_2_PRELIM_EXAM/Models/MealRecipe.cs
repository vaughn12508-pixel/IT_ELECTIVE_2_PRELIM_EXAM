using IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 7: Inheritance
// EXERCISE 9: Interfaces
public class MealRecipe : RecipeBase, IRecipeSearchable
{
    public string Category { get; set; } = "";
    public string Area { get; set; } = "";

    // Default constructor
    public MealRecipe() : base()
    {
    }

    // Constructor with base constructor call
    public MealRecipe(string title, int prepTime, string difficulty)
        : base(title, prepTime, difficulty)
    {
    }

    // EXERCISE 7: Constructor with Category and Area
    public MealRecipe(string title, int prepTime, string difficulty, string category, string area)
        : base(title, prepTime, difficulty)
    {
        Category = category;
        Area = area;
    }

    // Override base method and include Category and Area
    public override string GetRecipeInfo()
    {
        return $"{base.GetRecipeInfo()} | Category: {Category} | Area: {Area}";
    }

    // EXERCISE 9: Interface implementation
    public string SearchCriteria => Title;

    public bool MatchesSearch(string searchTerm)
    {
        return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }
}