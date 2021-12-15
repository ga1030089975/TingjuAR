<template>
	<div>
		<div>
			<div>
				<img :src="data.mainimg" width="100%" :height="height*0.27+'px'"/>
			</div>
			<div style="margin-top: -5px;"
				:style="{'background-color':data.mainimg_color}">
				<img :src="data.mainimg" width="100%" :height="height*0.07+'px'"
					style="filter: blur(20px);"/>
				
			</div>
			<div :style="{height:height*0.07+'px','margin-top':-(height*0.07)+'px'}">
				<el-row type="flex"  justify="center" style="height: 100%;">
					<el-col :span="24" style="display: flex;justify-content: center;
									align-items: center;">
						<span style="font-size: 30px; color: white;">
							{{data.name}}
						</span>
						
					</el-col>
				</el-row>
				
			</div>
				
			<div style="padding: 20px;">
				<h4>产品详情</h4>
				<span>
					{{data.detail}}
				</span>
				<el-divider content-position="right">TingjuAR</el-divider>
			</div>
			
			<div style="align-items: center;
					justify-content: center;
					display: flex;">
				 <el-button type="warning" style="width: 90%;" round>立即下载</el-button>
			</div>
			
			
			<h4 style="padding: 20px;">产品预览</h4>
		</div>
		
		
		
		<div>
			<div style="overflow: hidden;">
			    <div style="white-space: nowrap;overflow-y:auto;">
			        <img :width="width*0.7+'px'" v-for="item in data.imglist"
			        		:key="item.name" :src="item.img" 
			        		style="padding-left: 20px;padding-right: 20px;"/>
			    </div>
			</div>
		</div>
		<div style="padding: 20px;">
			<el-divider content-position="right">TingjuAR</el-divider>
		</div>
		
		
		<div style="padding: 20px;">
			<h4>最新动态</h4>
			<span>
				{{data.zuixindongtai}}
			</span>
		</div>
	</div>
	
	
</template>

<script>
	export default {
	    name: "ReserveInfo",
	    data() {
			return {
				data:{},
				height:'',
				width:''
			};
	    },
	    created() {
			this.data = this.$route.params.data;
			this.height = this.$getViewportSize().height;
			this.width = this.$getViewportSize().width;
	    },
		methods: {
			
	    },
		computed:{
			// height:function(){
			// 	console.log("height:" + this.$getViewportSize().height);
			// 	return this.$getViewportSize().height;
			// },
			// width:function(){
			// 	console.log("width:" + this.$getViewportSize().width);
			// 	return this.$getViewportSize().width;
			// }
		}
	}
</script>

<style  scoped>
	.tagstyle{
		border-color: #a2bfbd;
		color: #425c5a;
		background-color: #ffffff
	}
	.box1{
	    width: 49%;
	    margin-left: 3%;
	    height: 100px;
	    background: #fff;
	    display: inline-block;/*行内块元素*/
	}
</style>
