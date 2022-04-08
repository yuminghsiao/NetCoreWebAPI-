<template>
  <div>
    <el-table
      :data="data.papersData.slice(
          (data.currentPage - 1) * data.pagesize,
          data.currentPage * data.pagesize
        )"
      
      border
      style="width: 100%"
    >
      <el-table-column prop="title" label="標題" />
      <el-table-column prop="body" label="內容" />
      <el-table-column prop="id" label="id" />
    </el-table>
    <div class="block">
      <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page="currentPage"
        :page-size="pagesize"
        layout="total,  prev, pager, next, jumper"
        :total="data.papersData.length"
      >
      </el-pagination>
    </div>
  </div>
</template>

<script>
import { reactive,ref,onMounted } from "vue";
import {getCouresList,getList} from '../http/api'
export default {
  name: "Personal",
  setup() {
    let data = reactive({
      papersData: [],
      currentPage: 1, // 初始頁
      pagesize: 10, // 每頁數據
    });
    const list = ref();
    let getCouresListFun = async (obj) => {
      // data.table = await getCouresList(obj)
      let arr = await getCouresList(obj);
      // console.log("arr" + arr);
      data.papersData = arr;
    };
    getCouresListFun();

    let handleCurrentChange = (val) => {
      data.currentPage = val;
      console.log(`當前頁: ${val}`);
      // getCouresListFun({page:data.page})
      // getCouresListFun({page:data.page})//前端點擊後需要後端請求資料,此為傳入頁碼參數給後端請求資料
    };
    let handleSizeChange = (val) => {
      data.pagesize = val;
      console.log(`每頁 ${val} 條`);
    };

    onMounted(()=>{
      // const listres= getList(sessionStorage["token"]);
      // console.log("getList => "+listres);
      getList(sessionStorage["token"]).then(res=>{
        console.log(res);
        // list.value=listres; //獲得值
      })
      
    })



    return {
      data,
      handleCurrentChange,
      handleSizeChange,
      // list 返回值
    };
  },
};
</script>
