namespace AllSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite Create(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites
    (recipeId, accountId)
    VALUES
    (@recipeId, @accountId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = id;
    return favoriteData;
  }

  internal List<MyRecipe> GetMyRecipes(string accountId)
  {
    string sql = @"
    SELECT
    rec.*,
    fav.*,
    cr.*
    FROM favorites fav
    JOIN recipes rec ON rec.id = fav.recipeId
    JOIN accounts cr ON rec.creatorId = cr.id
    WHERE fav.accountId = @accountId;
    ";
    List<MyRecipe> myRecipes = _db.Query<MyRecipe, Favorite, Account, MyRecipe>(sql, (rec, fav, cr) =>
    {
      rec.FavoriteId = fav.Id;
      rec.Creator = cr;
      return rec;
    }, new { accountId }).ToList();
    return myRecipes;
  }

  internal Favorite GetOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM favorites
    WHERE id = @id;
    ";
    return _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
  }

  internal void Remove(int id)
  {
    string sql = @"
    DELETE FROM favorites
    WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }
}
