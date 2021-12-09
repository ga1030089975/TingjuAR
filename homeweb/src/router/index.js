import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Index from '../views/Index.vue'
import Status from '../views/Status.vue'
import Download from '../views/Download.vue'

Vue.use(VueRouter)

const routes = [
	{path: '/',redirect:'/home'},
    {
		path: '/home',
		name: 'Home',
		redirect:'/home/index',
		component: Home,
		children:[
			{path:'/home/index',component:Index},
			{path:'/home/status',component:Status},
			{path:'/home/download',component:Download},
		]
    },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
