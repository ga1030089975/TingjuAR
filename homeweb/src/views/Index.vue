<template>
	<div>
		<el-tabs v-model="activeName"  stretch>
			<el-tab-pane label="推荐" name="first">
				<el-carousel :height="height" >
					<el-carousel-item v-for="item in lunboimage" :key="item.id">
						<img :src="item.url" height="100%" width="100%"/>
					</el-carousel-item>
				</el-carousel>
				
			
				<p style="font-family: 'PingFang SC'; margin-left: 10px;" >
					最新书籍
				</p>
				
				
				<el-card v-for="item in new_book" :key="item.id"
				 style="margin: 10px;">
					<el-row :gutter="10">
						<el-col :span="8">
							<img :src="item.img" height="80px" />
						</el-col>
						<el-col :span="16">
							<el-row>
								<el-col>
									{{item.name}}
								</el-col>
							</el-row>
							<el-row style="margin-top: 8px;">
								<el-col>
									<el-tag size="mini" 
									style="border-color: #a2bfbd;
											color: #425c5a;
											background-color: #ffffff;">{{item.type}}</el-tag>
								</el-col>
							</el-row>
							<el-row style="margin-top: 8px;">
								<div style="font-size: 12px; display: -webkit-box;
								-webkit-box-orient: vertical;-webkit-line-clamp: 2;
overflow: hidden;">
									{{item.detail}}
								</div>
							</el-row>
						</el-col>
					</el-row>
				</el-card>
				
			</el-tab-pane>
			<el-tab-pane label="我的下载" name="second">
				订阅内容
			</el-tab-pane>

		</el-tabs>
	</div>
</template>

<script>
	export default{
		data(){
			return{
				activeName: 'first',
				lunboimage:[
					{id:1,url:require("../assets/lunbo1.png")},
					{id:2,url:require("../assets/lunbo2.png")},
					{id:3,url:require("../assets/lunbo3.png")}
				],
				height:'',
				new_book:[
					{
						id:1,
						img:require("../assets/book1.png"),
						name:'消失的世界',
						type:'AR绘本',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					},
					{
						id:2,
						img:require("../assets/book1.png"),
						name:'消失的世界2',
						type:'AR绘本',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					}
				]
			};
		},
		created(){
			this.height = this.$getViewportSize().height*0.3 + 'px';
		},
		computed:{
			
		}
	}
</script>

<style scoped>

	.el-tabs__nav-scroll{
	  width: 50%!important;
	  margin: 0 auto!important;
	}
	.el-tabs__active-bar{
		background-color:#425c5a
	}
	.el-tabs__item:hover{
		color:#425c5a
	}
	.el-tabs__item.is-active{
		color:#5e756e
	}
	.el-card__body{
		padding: 10px;
	}
</style>
