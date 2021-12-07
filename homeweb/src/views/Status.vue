<template>
    <el-container style="height: 100%">
      <el-main>
        <h1>This is personal center page</h1>
      </el-main>
      <el-footer><common-footer> </common-footer></el-footer>
    </el-container>
</template>
<script>
import CommonFooter from '../components/CommonFooter.vue'
export default {
  name:"Home",
  components: { CommonFooter },    
};
</script>
<style scoped>
.el-footer{
  background-color: #425c5a;
  color: #ffcea2;
  display: flex;
  align-items: center;
  justify-content: center;
}
.el-main {
  padding-top: 0%;
}
</style>