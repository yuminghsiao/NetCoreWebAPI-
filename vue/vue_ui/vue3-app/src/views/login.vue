<template>
  <div class="login">
    <h4>登入頁面</h4>
     <el-form
    label-width="80px"
    :model="loginData"
  >
    <!-- <el-form-item label="帳號">
      <el-input placeholder="請輸入帳號" v-model="loginData.name" />
    </el-form-item>
    <el-form-item label="密碼">
      <el-input placeholder="請輸入密碼" v-model="loginData.password" show-password></el-input>
    </el-form-item> -->
    <el-form-item label="qq">
      <el-input placeholder="請輸入帳號" v-model="qq" />
    </el-form-item>
    <el-form-item label="密碼">
      <el-input placeholder="請輸入密碼" v-model="pwd" show-password></el-input>
    </el-form-item>
      <el-form-item label="驗證碼">
      <el-input placeholder="請輸入驗證碼" v-model="validateInput" ></el-input>
    </el-form-item>
    <img :src="validateCode" alt="" id="img-validateCode" @click="changeValidateCode"/>
    <el-form-item>
       <el-button @click="subFun" class="sub-btn" type="primary">登入</el-button>
    </el-form-item>
  </el-form>
 
  </div>
</template>
<script>
import{reactive,ref,onMounted} from 'vue'
import{defineComponent} from'vue'
import {ElMessage} from 'element-plus'
import {login,testlogin} from '../http/api'
import router from '../router/index.js'
export default {
 name:'Login',
 setup(){
   let num=Math.ceil(Math.random()*1000);
   let validateCode="http://localhost:5217/Login/GetValidateCodeImages"+"?t="+num;
   const qq= ref("1234567");
   const pwd= ref("1234567");
   const validateInput= ref("");
   
   let loginData=reactive({
     name:'',
     password:''
   })
    let user=null;
    let subFun= async()=>{
      //先判斷帳號米碼是否已經填寫
      // if(!loginData.name||!loginData.password)
      // {
      //   ElMessage.error('請先填寫帳號和密碼');
      //   return
      // }
      const validateKey = localStorage[num];
      //執行登入操作
      // login(loginData).then(res=>{
      //   console.log(res)
      //   router.push('/Home')
      // })
      testlogin(qq.value,pwd.value,num,validateInput.value).then(res=>{
        user = res;
        console.log("data123 " + user)
         if(user!="")
          {
            let userString = decodeURIComponent(
              escape(window.atob(user.split(".")[1]))
            );
            sessionStorage["token"]= user;
            sessionStorage["userInfo"]=userString;
            // userName.value = JSON.parse(userString).nickName;
            router.push('/Home')
          }else{
            alert("請檢查用戶名密碼和驗證碼")
          }
      })
      
      // console.log("user" + user);
      // console.log("asdasd321321 " + user);
     
    }

    let changeValidateCode=(e)=>{
      console.log(e.target.src);
      
      num=Math.ceil(Math.random()*1000);//升成一個隨機數（防止缓存）
      // validateCode = "http://localhost:5217/Login/GetValidateCodeImages?t=" + num;
      e.target.src = "http://localhost:5217/Login/GetValidateCodeImages?t=" + num;
    }
    // onMounted(()=>{
    //  validateCode = validateCode+"?t="+num;
    //  console.log(validateCode);
    // })


   return{
     loginData,
     subFun,
     user,
     qq,
     pwd,
     validateInput,
     validateCode,
     changeValidateCode
   }
 }, 
};
</script>

<style scoped>
.login{
  width: 500px;
  margin: 150px auto;
  border: 1px solid #efefef;
  border-radius: 10px;
  padding: 20%;
}
h4{
  text-align: center;
}
.sub-btn{
  width: 100%;
}
</style>
