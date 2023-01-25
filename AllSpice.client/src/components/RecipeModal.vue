<template>
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                <img class="img-fit" :src="recipe?.img" alt="">
              </div>
              <div class="col-6 p-2">
                <h4>Ingredients</h4>
                <div v-for="i in ingredients" class="col-3 rounded">
                  <p>{{ i.quantity }} {{ i.name }}</p>
                </div>
                <div v-if="recipe?.creator.id == account.id">
                  <div class="box">
                    <form name="search">
                      <input type="text" class="input" name="txt" onmouseout="this.value = ''; this.blur();">
                    </form>
                    <i class="mdi mdi-plus"></i>
                  </div>
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

.box {
  position: relative;
}

.input {
  padding: 10px;
  width: 40px;
  height: 40px;
  background: none;
  border: 4px solid #ffd52d;
  border-radius: 50px;
  box-sizing: border-box;
  font-family: Comic Sans MS;
  font-size: 26px;
  color: #ffd52d;
  outline: none;
  transition: .5s;
}

.box:hover input {
  width: 280px;
  background: #3b3640;
  border-radius: 10px;
}

.box i {
  position: absolute;
  top: 50%;
  right: -7px;
  transform: translate(-50%, -50%);
  font-size: 26px;
  color: #00570c;
  transition: .2s;
}

.box:hover i {
  opacity: 0;
  z-index: -1;
}
</style>