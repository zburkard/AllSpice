namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;
  private readonly RecipesService _recipesService;

  public FavoritesService(FavoritesRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }

  internal Favorite Create(Favorite favoriteData)
  {
    Recipe recipe = _recipesService.GetOne(favoriteData.RecipeId, favoriteData.AccountId);
    Favorite favorite = _repo.Create(favoriteData);
    return favorite;
  }

  internal List<MyRecipe> GetMyRecipes(string accountId)
  {
    List<MyRecipe> myRecipes = _repo.GetMyRecipes(accountId);
    return myRecipes;
  }

  internal string Remove(int id, string userId)
  {
    Favorite original = _repo.GetOne(id);
    if (original == null)
    {
      throw new Exception("No like with that Id");
    }
    if (original.AccountId != userId)
    {
      throw new Exception("You didn't like this");
    }
    _repo.Remove(id);
    return $"Removed like with id : {id}";
  }
}
