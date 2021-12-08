<template>
	<div>
		<el-tabs v-model="activeName"  type="card" 
			style="">
		  <el-tab-pane label="推荐" name="first" >推荐内容</el-tab-pane>
		  <el-tab-pane label="订阅" name="second">订阅内容</el-tab-pane>
		</el-tabs>
	</div>
</template>

<script>
	export default{
		data(){
			return{
				activeName: 'second',
			};
		}
	}
</script>

<style>
</style>
