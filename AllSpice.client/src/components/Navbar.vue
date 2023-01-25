<template>
  <nav class="navbar navbar-expand-lg navbar-dark px-3">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse d-flex justify-content-end" id="navbarText">
      <div class="box mx-2">
        <form name="search">
          <input type="text" class="input" name="txt" onmouseout="this.value = ''; this.blur();">
        </form>
        <i class="mdi mdi-magnify"></i>
      </div>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
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
