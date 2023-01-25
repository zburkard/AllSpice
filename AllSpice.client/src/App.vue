<template>
  <header class="nav-comp elevation-3"
    :style="`background-image: url(https://images.unsplash.com/photo-1606913079621-e64bd28682ba?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80)`">
    <Navbar />
    <div class="text-center">
      <img class="logo"
        src="https://cdn.shopify.com/s/files/1/1571/1787/files/AllSpiceLogo_72be7ca9-9356-4d7c-97bc-75119e629499.png?4374816212607438696"
        alt="">
    </div>
  </header>
  <main>
    <router-view />
  </main>
  <RecipeModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import RecipeModal from "./components/RecipeModal.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, RecipeModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

header {
  height: 55vh;
  margin-top: 20px;
  place-content: center;
}

.logo {
  height: 30vh;
  width: 30vh;
}

.nav-comp {
  background-size: 100%;
  background-repeat: no-repeat;
  border-radius: 10px;
  margin-inline: 10vh;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
