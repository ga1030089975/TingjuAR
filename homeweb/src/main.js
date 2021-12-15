import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './plugins/element.js'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import './assets/css/global.css'


Vue.use(ElementUI);
Vue.config.productionTip = false

Vue.prototype.$getViewportSize = function(){
  return {
    width: window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth,//兼容性获取屏幕宽度
    height: window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight//兼容性获取屏幕高度
  };
};



new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
