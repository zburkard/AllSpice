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
  internal Recipe Get(int id)
  {
    string sql = @"
    SELECT
    *
    FROM recipes
    WHERE id = @id;
    ";
    Recipe recipe = _db.Query<Recipe>(sql, new { id }).FirstOrDefault();
    return recipe;
  }

  internal Recipe GetOne(int id)
  {
    string sql = @"
    SELECT
    rc.*,
    ac.*
    FROM recipes rc
    JOIN accounts ac ON ac.id = rc.creatorId
    WHERE rc.id = @id;
    ";
    return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { id }).FirstOrDefault();
  }

  internal bool Update(Recipe update)
  {
    string sql = @"
    UPDATE recipes
      SET
      instructions = @instructions
      WHERE id = @id;
    ";
    int rows = _db.Execute(sql, update);
    return rows > 0;
  }
  internal void Remove(int id)
  {
    string sql = @"
      DELETE FROM recipes
      WHERE id = @id;
      ";
    _db.Execute(sql, new { id });
  }
}
