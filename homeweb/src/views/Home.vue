<template>
  <el-container style="height: 100%">
    <el-header height="30px">
      <span>TingjuAR</span>
    </el-header>
    <el-main>
      <router-view></router-view>
    </el-main>
    <el-footer>
      <div class="footer-guid">
        <el-menu
          :default-active="activeIndex"
          class="el-menu-demo"
          mode="horizontal"
          background-color="#425c5a"
          text-color="#ffcea2"
          active-text-color="#fbeae2"
        >
          <el-menu-item index="1" @click="toHome">
            <i class="el-icon-s-home"></i>首页
          </el-menu-item>
          <el-menu-item index="2" @click="toStatus">
            <i class="el-icon-user"></i>我的</el-menu-item
          >
        </el-menu>
      </div>
    </el-footer>
  </el-container>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      activeIndex: "1",
    };
  },
  methods: {
    toStatus() {
      {
        this.$router.push({ path: "/home/status" });
      }
    },
    toHome() {
      {
        this.$router.push({ path: "/home" });
      }
    },
  },
};
</script>
<style>
.el-header,
.el-footer {
  padding: 0%;
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
.el-tabs__active-bar {
  background-color: #425c5a;
}
.el-tabs__item:hover {
  color: #425c5a;
}
.el-tabs__item.is-active {
  color: #5e756e;
}
a:-webkit-any-link {
  text-decoration: none;
}
.el-menu-item i {
  color: #ffcea2;
}
.footer-guid {
  width: 100%;
}
.el-menu-item {
  width: 50%;
  font-size: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
