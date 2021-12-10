<template>
	<div>
		<el-tabs v-model="activeName"  stretch>
			<el-tab-pane label="推荐" name="first">
				<el-carousel :height="height*0.28 + 'px'" >
					<el-carousel-item v-for="item in lunboimage" :key="item.id">
						<img :src="item.url" height="100%" width="100%"/>
					</el-carousel-item>
				</el-carousel>
				
			
				<p style="font-family: 'PingFang SC'; margin-left: 10px;" >
					推荐产品
				</p>
				
				
				<el-card v-for="item in new_book" :key="item.id"
				 style="margin: 10px;" @click.native="toDetail(item)">
					<el-row :gutter="20">
						<el-col :span="Math.ceil(height*0.15*0.75*24/(width))+1"
							:style="{'padding-left':((Math.ceil(height*0.15*0.75*24/width)+1)/24*width-height*0.15*0.75)/2+'px'}">
							<img :src="item.img" :height="height*0.15 + 'px'"
							 :width="height*0.15*0.75 + 'px'"/>
						</el-col>
						<el-col :span="23-Math.ceil(height*0.15*0.75*24/(width))"
						 :style="{'height':height*0.15 + 'px'}">
							<el-row :style="{height:height*0.15*0.2+'px'}">
								<el-col>
									<span :style="{'font-size':Math.ceil(height*0.15*0.75*0.2*0.75)+'px'}">
										{{item.name}}
									</span>
								</el-col>
							</el-row>
							<el-row :style="{height:height*0.15*0.2+'px'}">
								<el-col>
									<el-tag v-if="height*0.15*0.2 < 25" size="mini" 
										class="tagstyle">{{item.type}}</el-tag>
									<el-tag v-else size="medium" 
										class="tagstyle">{{item.type}}</el-tag>
								</el-col>
							</el-row>
							<el-row :style="{height:height*0.15*0.6+'px'}">
								<div class="detailstyle"
									:style="{'font-size':Math.ceil(height*0.15*0.75*0.2*0.75)-2+'px'}"
									style="width: 100%;">
									{{item.detail}}
								</div>
							</el-row>
						</el-col>
					</el-row>
				</el-card>
				
				<p style="font-family: 'PingFang SC'; margin-left: 10px;" >
					产品列表
				</p>
				
				<el-card v-for="item in all_book" :key="item.id"
				style="margin: 10px;" @click.native="toDetail(item)">
					<el-row :gutter="20">
						<el-col :span="Math.ceil(height*0.15*0.75*24/width)+1"
						:style="{'padding-left':((Math.ceil(height*0.15*0.75*24/width)+1)/24*width-height*0.15*0.75)/2+'px'}">
							<img :src="item.img" :height="height*0.15 + 'px'"
							 :width="height*0.15*0.75 + 'px'"/>
						</el-col>
						<el-col :span="22-Math.ceil(height*0.15*0.75*24/width)"
						 :style="{'height':height*0.15 + 'px'}">
							<el-row :style="{height:height*0.15*0.2+'px'}">
								<el-col>
									<span :style="{'font-size':Math.ceil(height*0.15*0.75*0.2*0.75)+'px'}">
										{{item.name}}
									</span>
								</el-col>
							</el-row>
							<el-row :style="{height:height*0.15*0.2+'px'}">
								<el-col>
									<el-tag v-if="height*0.15*0.2 < 25" size="mini" 
										class="tagstyle">{{item.type}}</el-tag>
									<el-tag v-else size="medium" 
										class="tagstyle">{{item.type}}</el-tag>
								</el-col>
							</el-row>
							<el-row :style="{height:height*0.15*0.6+'px'}">
								<div class="detailstyle"
									:style="{'font-size':Math.ceil(height*0.15*0.75*0.2*0.75)-2+'px'}"
									style="width: 100%;">
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
				// height:'',
				// width:'',
				new_book:[
					{
						id:1,
						img:require("../assets/book1.png"),
						name:'消失的世界',
						type:'AR绘本',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					},
					{
						id:2,
						img:require("../assets/book2.png"),
						name:'消失的世界2',
						type:'科普图书',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					}
				],
				all_book:[
					{
						id:4,
						img:require("../assets/book1.png"),
						name:'消失的世界',
						type:'AR绘本',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					},
					{
						id:5,
						img:require("../assets/book2.png"),
						name:'消失的世界2',
						type:'科普图书',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					},
					{
						id:6,
						img:require("../assets/book3.png"),
						name:'消失的世界3',
						type:'益智游戏',
						detail:'冈瓦纳古陆（Gondwanaland)是一片消失的大陆。数百万年前生活着各种各样的生物，有些和现在的生物迥异，另一些则在许多方面仍十分相似。'
					}
				]
			};
		},
		created(){
			// this.height = this.$getViewportSize().height;
			// this.width = this.$getViewportSize().width;
		},
		computed:{
			height:function(){
				console.log(this.$getViewportSize().height);
				return this.$getViewportSize().height;
			},
			width:function(){
				console.log(this.$getViewportSize().width);
				return this.$getViewportSize().width;
			}
		},
		methods:{
			toDetail(item){
				console.log(item);
				this.$router.push({
					path:'/home/detail',
					name:'Detail',
					params:{
						data:item
					}
				})
			}
		}
	}
</script>

<style>

	.el-card__body{
		padding: 10px;
	}
	.tagstyle{
		border-color: #a2bfbd;
		color: #425c5a;
		background-color: #ffffff
	}
	.detailstyle{
		display: -webkit-box;
		-webkit-box-orient: vertical;
		-webkit-line-clamp: 4;
		overflow: hidden;
	}
</style>

