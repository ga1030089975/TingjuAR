<template>
  <footer>
    <div class="footer-button">
      <el-button type="text" icon="el-icon-s-home" name="first" @click="toHome"
        >首页</el-button
      >
      <el-button type="text" icon="el-icon-user" name="second" @click="toStatus"
        >我的</el-button
      >
    </div>
  </footer>
</template>

<script>
export default {
  methods: {
    toHome() {
      this.$router.push("/");
    },
    toStatus() {
      this.$router.push("/status");
    },
  },
};
</script>

<style scoped>
.footer {
  background-color: #425c5a;
  color: #ffcea2;
  display: flex;
  align-items: center;
  justify-content: center;
}
.footer-button {
  display: flex;
  align-content: center;
}
.el-button {
  color: #ffcea2;
  padding: 10px 35px;
}
</style>
