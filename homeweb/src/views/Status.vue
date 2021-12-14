<template>
  <div>
    <div class="background">
      <div class="a">
        <img
          src="../assets/background1.jpg"
          style="width: 100%; height: calc(100vh * 0.3)"
        />
      </div>
      <div class="head">
        <img
          src="../assets/background.jpg"
          style="width: 100%; height: 100%; border-radius: 50%"
        />
      </div>
    </div>

    <div class="select">
      <div class="card">
        <el-card shadow="hover" style="width: 60%; height: calc(100vh * 0.09);font-size:1.1em">
          <router-link to="/home/download"><i class="el-icon-folder-opened"></i>下 载 列 表</router-link>
        </el-card>
      </div>
      <div class="card">
        <el-card shadow="hover" style="width: 60%; height: calc(100vh * 0.09);font-size:1.1em"
          ><i class="el-icon-edit"></i>
          更 改 主 题
        </el-card>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
  },
};
</script>
<style scoped>
.el-footer {
  background-color: #425c5a;
  color: #ffcea2;
  display: flex;
  align-items: center;
  justify-content: center;
}
.el-main {
  padding: 0%;
}
.head {
  width: calc(100vh * 0.12);
  height: calc(100vh * 0.12);
  border: 1px solid #b2bfb6;
  border-radius: 50%;
  padding: 1px;
  position: absolute;
  left: 50%;
  transform: translate(-50%, -40%);
}
.el-card {
  display: flex;
  justify-content: center;
  align-items: center;
  color: #425c5a;
  border: 1px solid #b2bfb6;
}

.select {
  height: calc(100vh * 0.4);
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  transform: translate(0%, 25%);
}
.card {
  display: flex;
  justify-content: center;
}
a:-webkit-any-link {
  color: #425c5a;
  text-decoration: none;
}
.el-icon-folder-opened,.el-icon-edit{
  padding-inline: 10px;
}

</style>
