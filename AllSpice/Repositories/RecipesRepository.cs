using System.Linq;

namespace AllSpice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe Create(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, img, category, instructions, creatorId)
    VALUES
    (@title, @img, @category, @instructions, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.Id = id;
    return recipeData;
  }
  internal List<Recipe> Get()
  {
    string sql = @"
    SELECT
    rec.*,
    ac.*
    FROM recipes rec
    JOIN accounts ac ON ac.id = rec.creatorId;
    ";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();

    return recipes;
  }
}
