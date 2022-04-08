<template>
<div> 
<div class="select-box">
    <div>
        <span>id:</span>
        <el-select v-model="option.id" placeholder="請選擇id">
                <el-option
                    v-for="item in [1,2,3,4,5,6,7]"
                    :key="item"
                    :label="item"
                    :value="item"
                >
            </el-option>
        </el-select>
    </div>
    <div>
        <span>標題:</span>
        <el-input v-model="option.title" placeholder="請輸入標題"></el-input>
    </div>
    <div>
        <el-button @click="getTableList" type="primary">查詢</el-button>
    </div>
</div>

               
    <el-table border :data="data.table.slice(
          (data.page - 1) * data.pagesize,
          data.page * data.pagesize
        )">
            <el-table-column prop="title" label="標題"/>
            <el-table-column prop="body" label="內容"/>
            <el-table-column prop="id" label="id" />
        </el-table>
        <el-pagination
            @current-change="handleCurrentChange"
            :crrent-page="data.page"
            layout="total, prev, pager, next, jumper"
            :total="data.total">
        </el-pagination>
    </div>
</template>

<script>
import {reactive} from 'vue'
import {getCouresList} from '../http/api'
export default {
  name: 'CourseList',
  setup(){
        let data=reactive({
            table:[],
            page:1,
            pagesize:10,
            total:0,
        });

        let option=reactive({
            id:'',
            title:'',
            page:0,
        })

        let getCouresListFun=async(obj)=>{
            // data.table = await getCouresList(obj)
            let arr = await getCouresList(obj),newArr=[];
            console.log("arr" + arr)
            data.total = arr.length;
            //[1,2,3,4,5,6,7]
            //[[1,2],[3,4],[5,6],[7]]
            //splice(index,10)==[0-10]
            // for(let index=0;index<arr.length;index++)
            // {
            //     newArr.push(arr.splice(index,10));
            //     index+=10;
            // }
            data.table=arr;
        }
        getCouresListFun()

        let handleCurrentChange=(index)=>{
            option.page=index;
            data.page = index;
            // getCouresListFun({page:data.page})
            // getCouresListFun({page:data.page})//前端點擊後需要後端請求資料,此為傳入頁碼參數給後端請求資料
        }
        let handleSizeChange = (val) => {
            data.pagesize = val;
            console.log(`每页 ${val} 条`);
            };
        let getTableList=()=>{
            console.log(option)
        }
        return{
            data,
            handleCurrentChange,
            handleSizeChange,
            getTableList,
            option
        }
  }
}
</script>

<style lang="scss" scoped>
    .select-box{
        display: flex;
        align-items: center;
        width: 100%;
        margin-bottom: 10px;
        >div{
            margin-right: 10px;
            width: 30%;
            display: flex;
            align-items: center;
            span{
                width: 50px;
            }
        }
    }
</style>