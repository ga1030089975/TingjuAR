<template>
  <div>
    <div class="background">
      <div class="a">
        <img
          src="../assets/background1.jpg"
          style="width: 100%; height: calc(100vh * 0.25)"
        />
      </div>
      <div class="head">
        <img
          src="../assets/background.jpg"
          style="width: 100%; height: 100%; border-radius: 50%"
        />
      </div>
    </div>
 
        </div>
      </el-card>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
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
</style>
