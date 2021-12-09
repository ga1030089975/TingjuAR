<template>
  <el-container style="height:100%">
    <el-header height="30px">
      <span>TingjuAR</span>
    </el-header>
    <el-main>
	  <router-view></router-view>
    </el-main>
    <el-footer>
		<div class="footer-button">
		  <el-button type="text" icon="el-icon-s-home" name="first" @click="toHome">
			  首页
		  </el-button>
		  <el-button type="text" icon="el-icon-user" name="second" @click="toStatus">
			  我的
		  </el-button>
		</div>
	</el-footer>
  </el-container>
</template>

<script>
export default {
    name:"Home",
    data() {
        return {
			activeName: 'second'
        };
    },
    methods: {
        handleClick(tab, event) {
			console.log(tab, event);
        },
		toHome() {
		  this.$router.push("/home/index");
		},
		toStatus() {
		  this.$router.push("/home/status");
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
  padding: 0;
}
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
