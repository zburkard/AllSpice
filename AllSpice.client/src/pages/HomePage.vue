<template>
  <div class="container-fluid">
    <div class="row justify-content-center move">
      <div class="col-5 text-center">
        <ul class="menu-bar">
          <li class="menu">Home</li>
          <li class="menu">My Recipes</li>
          <li class="menu">Favorites</li>
        </ul>
      </div>
      <div class="row justify-content-center">
        <div v-for="r in recipes" class="col-3 p-3">
          <RecipeCard :recipe="r" />
        </div>
      </div>
    </div>
    <footer class="sticky-bottom justify-content-end m-4">
      <ul class="wrapper mb-5">
        <li class="icon facebook" data-bs-toggle="modal" data-bs-target="#createModal">
          <div class="tooltip">Create Recipe</div>
          <span><i class="mdi mdi-plus"></i></span>
        </li>
      </ul>
    </footer>
  </div>
</template>

<script>
import RecipeCard from "../components/RecipeCard.vue";
import { computed, reactive, onMounted } from 'vue';
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error(error.message)
        logger.error(error)
      }
    }
    onMounted(() => {
      getRecipes();
    })
    return {
      account: computed(() => AppState.account),
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.move {
  position: relative;
  top: -20px;
}

.menu-bar {
  border-radius: 25px;
  height: fit-content;
  display: inline-flex;
  background-color: rgba(0, 0, 0, .4);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  align-items: center;
  padding: 0 10px;

  .menu {
    list-style: none;
    color: white;
    font-family: sans-serif;
    font-weight: bold;
    padding: 12px 16px;
    position: relative;
    cursor: pointer;
    white-space: nowrap;

    &::before {
      content: " ";
      position: absolute;
      top: 0;
      left: 0;
      height: 100%;
      width: 100%;
      z-index: -1;
      transition: .2s;
      border-radius: 25px;
    }

    &:hover {
      &::before {
        background: linear-gradient(to bottom, #e8edec, #d2d1d3);
        box-shadow: 0px 3px 20px 0px black;
        transform: scale(1.1);
      }

      color: black;
    }
  }
}

@import url("https://fonts.googleapis.com/css2?family=Poppins&display=swap");


.wrapper {
  display: inline-flex;
  list-style: none;
}

.wrapper .icon {
  position: relative;
  background: #006408c2;
  color: #ececec;
  backdrop-filter: blur(10px);
  border-radius: 50%;
  padding: 15px;
  margin: 10px;
  width: 50px;
  height: 50px;
  font-size: 18px;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  box-shadow: 0 10px 10px rgba(0, 0, 0, 0.37);
  cursor: pointer;
  transition: all 0.2s cubic-bezier(0.68, -0.55, 0.265, 1.55);
}

.wrapper .tooltip {
  position: absolute;
  top: 0;
  font-size: 14px;
  background: #ffffff;
  color: #ffffff;
  padding: 5px 8px;
  border-radius: 5px;
  box-shadow: 0 10px 10px rgba(0, 0, 0, 0.1);
  opacity: 0;
  pointer-events: none;
  transition: all 0.3s cubic-bezier(0.68, -0.55, 0.265, 1.55);
}

.wrapper .tooltip::before {
  position: absolute;
  content: "";
  height: 8px;
  width: 8px;
  background: #ffffff;
  bottom: -3px;
  left: 50%;
  transform: translate(-50%) rotate(45deg);
  transition: all 0.3s cubic-bezier(0.68, -0.55, 0.265, 1.55);
}

.wrapper .icon:hover .tooltip {
  top: -65px;
  opacity: 1;
  visibility: visible;
  pointer-events: auto;
}

.wrapper .icon:hover span,
.wrapper .icon:hover .tooltip {
  text-shadow: 0px -1px 0px rgba(0, 0, 0, 0.1);
}

.wrapper .facebook:hover,
.wrapper .facebook:hover .tooltip,
.wrapper .facebook:hover .tooltip::before {
  background: #176321;
  color: #ffffff;
}
</style>
