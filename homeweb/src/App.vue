<template>
  <div id="app" class="zhuti1" ref="app">
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'app',
  components: {   
  }
}
</script>

<style>
#app {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  --themeColor:#008cff;
}
</style>

