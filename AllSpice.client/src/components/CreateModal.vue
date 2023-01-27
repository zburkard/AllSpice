<template>
  <div class="modal fade" id="createModal" tabindex="-1" aria-labelledby="createModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content m-style">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">Create A Recipe!</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="row justify-content-center">
            <form @submit.prevent="createRecipe()" class="d-flex flex-column">
              <input v-model="editable.title" class="col-3 rounded p-2 m-2" type="text" placeholder="Title">
              <input v-model="editable.category" class="col-3 rounded p-2 m-2" type="text" placeholder="Category">
              <input v-model="editable.img" class="col-3 rounded p-2 m-2" type="url" placeholder="Cover Image">
              <textarea v-model="editable.instructions" class="rounded p-2 m-2" type="text"
                placeholder="Instructions"></textarea>
              <div>
                <button class="btn btn-success m-2" type="submit">
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
export default {
  props: { recipeData: { type: Object, default: {} } },
  setup(props) {
    const editable = ref({})
    return {
      editable,
      async createRecipe() {
        try {
          await recipesService.createRecipe(editable.value)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
      }
    }
  }
};
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
</style>