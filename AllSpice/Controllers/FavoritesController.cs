namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0provider;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0provider)
  {
    _favoritesService = favoritesService;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
  {
    try
    {
      Favorite userInfo = await _auth0provider.GetUserInfoAsync<Favorite>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      int id = _favoritesService.Create(favoriteData);
      userInfo.RecipeLikeId = id;
      return Ok(userInfo);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
