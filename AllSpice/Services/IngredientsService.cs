namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;
  private readonly RecipesService _recipesService;

  public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }
  internal Ingredient Create(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.Create(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredients(int recipeId, string userId)
  {
    Recipe recipe = _recipesService.GetOne(recipeId, userId);
    List<Ingredient> ingredients = _repo.GetIngredients(recipeId);
    return ingredients;
  }
  internal string Remove(int id, string userId)
  {
    Ingredient original = _repo.GetOne(id);
    if (original == null)
    {
      throw new Exception("no ingredient to delete at that id");
    }
    if (original.CreatorId != userId)
    {
      throw new Exception("Nacho Ingredient");
    }
    _repo.Remove(id);
    return $"Ingredient at {id} was removed";
  }
}
