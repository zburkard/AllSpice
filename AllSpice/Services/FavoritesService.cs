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

  internal int Create(Favorite favoriteData)
  {
    Recipe recipe = _recipesService.GetOne(favoriteData.RecipeId, favoriteData.AccountId);
    int id = _repo.Create(favoriteData);
    return id;
  }
}
