<template>
<el-carousel :interval="5000" arrow="always">  
  <el-carousel-item>
      <el-image :src="img1" class="img-all"></el-image>  
  </el-carousel-item>
    <el-carousel-item>
    <el-image :src="img2" class="img-all"></el-image>
  </el-carousel-item>
</el-carousel>
</template>

<script>
export default {
  name: 'TeacherList',
  setup() {
    // let url= 'https://www.artstation.com/wlop';
    // let toRescue=()=>{
    //   // window.location.href = url;
    //   window.open(url,"_blank")
    // }
    return{
      img1: require('@/assets/wlop1.jpg'),
      img2: require('@/assets/wlop2.jpg')
      // url,
      // toRescue     
    }
  }
}
</script>

<style lang="scss" scoped>
  .img-all{
    height: 100%;
    width: 100%;
  }
</style>