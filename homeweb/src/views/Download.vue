<template>
	<div>
		<el-button @click="change('zhuti2')">123</el-button>
		<el-button @click="change('zhuti1')">456</el-button>
	</div>
</template>

<script>
	export default{
		data(){
			return{
			};
		},
		methods:{
			change(name){
				const dom = document.getElementById('app');
				dom.className = name;
			}
		}
	}
</script>

<style>
</style>
