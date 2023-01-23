namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe Create(Recipe recipeData)
  {
    Recipe recipe = _repo.Create(recipeData);
    return recipe;
  }

  internal List<Recipe> Get()
  {
    List<Recipe> recipes = _repo.Get();
    return recipes;
  }
  internal Recipe Get(int id)
  {
    Recipe recipe = _repo.Get(id);
    if (recipe == null)
    {
      throw new Exception("no recipe by that id");
    }
    return recipe;
  }
  internal Recipe GetOne(int id, string userId)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null)
    {
      throw new Exception("No Recipe at that id");
    }
    if (recipe.CreatorId != userId)
    {
      throw new Exception("You don't own that recipe");
    }
    return recipe;
  }

  internal Recipe Update(Recipe recipeUpdate, int id, string userId)
  {
    Recipe original = Get(id);
    if (original.CreatorId != userId)
    {
      throw new Exception("nacho recipe");
    }
    original.Title = recipeUpdate.Title ?? original.Title;
    original.Instructions = recipeUpdate.Instructions ?? original.Instructions;
    original.Img = recipeUpdate.Img ?? original.Img;
    original.Category = recipeUpdate.Category ?? original.Category;
    bool edited = _repo.Update(original);
    if (edited == false)
    {
      throw new Exception("Recipe was not edited");
    }
    return original;
  }

  internal string Remove(int id, string userId)
  {
    Recipe original = GetOne(id, userId);
    if (original.CreatorId != userId)
    {
      throw new Exception("Nacho recipe");
    }
    _repo.Remove(id);
    return $"{original.Title} has been removed";
  }

}
