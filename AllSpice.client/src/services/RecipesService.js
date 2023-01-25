import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService"

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[GOT RECIPES]', res.data)
    AppState.recipes = res.data
  }
  async setActiveRecipe(recipeId) {
    const res = await api.get('api/recipes/' + recipeId)
    console.log(res.data)
    AppState.activeRecipe = res.data
    console.log(AppState.activeRecipe)
  }
}

export const recipesService = new RecipesService()