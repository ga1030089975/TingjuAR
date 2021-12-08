<template>
  <el-container style="height:100%">
    <el-header height="30px">
      <span>科学荟（待确定）</span>
    </el-header>

    <el-main>
      <template>
        <el-tabs v-model="activeName" @tab-click="handleClick">
          <el-tab-pane label="推荐" name="first" >推荐内容</el-tab-pane>
          <el-tab-pane label="订阅" name="second">订阅内容</el-tab-pane>
        </el-tabs>
      </template>
    </el-main>
    <el-footer><common-footer> </common-footer></el-footer>
  </el-container>
</template>

<script>
import CommonFooter from '../components/CommonFooter.vue'
export default {
  name:"Home",
  components: { CommonFooter },
  data() {
      return {
        activeName: 'second'
      };
    },
    methods: {
      handleClick(tab, event) {
        console.log(tab, event);
      },
    },    
};
</script>
<style scoped>
.el-header, .el-footer{
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
