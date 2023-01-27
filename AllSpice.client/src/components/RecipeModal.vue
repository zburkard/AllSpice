<template>
  <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content m-style">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">{{ recipe?.title }}</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-6">
                <img class="img-fit rounded" :src="recipe?.img" alt="">
              </div>
              <div class="col-6 p-2">
                <h4>Ingredients</h4>
                <div v-for="i in ingredients" class="col-3 rounded">
                  <p>{{ i.quantity }} {{ i.name }}</p>
                </div>
                <div v-if="recipe?.creator.id == account.id">
                  <input type="text" class="ing-inp rounded mx-1" placeholder="Ingredient Name">
                  <input placeholder="Ammount" class="ing-inp rounded" type="text">
                  <button class="col-3 btn btn-success mt-2">Add
                    Ingredient</button>
                </div>
                <h4>Instructions</h4>
                <p>{{ recipe?.instructions }}</p>
              </div>
            </div>
          </div>
        </div>
        <!-- <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div> -->
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState.js';
import { computed } from 'vue'
export default {
  setup() {
    return {
      recipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      ingredients: computed(() => AppState.ingredients)
    }
  }
}
</script>


<style lang="scss" scoped>
.img-fit {
  height: 60vh;
  width: 80%;
}

.m-style {
  background-color: rgba(235, 226, 226, 0.587);
  backdrop-filter: blur(10px);
}

$white: rgba(255, 255, 255, 0.3);

.ing-inp {
  background: transparent;
  width: 200px;
  padding: 0.5em;
  border: none;
  border-left: 1px solid $white;
  border-top: 1px solid $white;
  backdrop-filter: blur(5px);
  box-shadow: 4px 4px 60px rgba(0, 0, 0, 0.2);
  color: rgb(0, 0, 0);
  font-weight: 500;
}
</style>