import { ElLoading } from 'element-plus'
import $http from './index.js'

export const getData=$http.get('http://jsonplaceholder.typicode.com/posts')

export const testlogin=(qq,pwd,validateKey,validateCode)=>
{
    return $http.get(`http://localhost:5217/Login/CheckLogin/${qq}/${pwd}/${validateKey}/${validateCode}`)
}

export const login=(data)=>{
    return $http.get('http://jsonplaceholder.typicode.com/posts',data) 
}

export const getCouresList=(data)=>
{
    return $http.get('http://jsonplaceholder.typicode.com/posts',data) 
}

// export const logintest=async(qq,pwd,validateKey,validateCode)=>
// {
//     const loadingInstance = ElLoading.service();
//     try{
//         res = await $http.get(`http://localhost:5217/Login/CheckLogin/${qq}/${pwd}/${validateKey}/${validateCode}`);
//         console.log(res);
//         return res;
//     }catch(error)
//     {
//         console.log(error);
//     }finally{
//         loadingInstance.close();
//     }
    
// }

export const getToken=async(userId)=>
{
    return (await $http.get(`http://localhost:5217/user/GetToken?userId=${userid}`)).data;
}

// export const getList=(toekn)=>
// {
//     //在header攜帶token訪問後端
//     $http.defaults.headers.common['Authorization']="Bearer " + sessionStorage["token"];
//     return ($http.get(`http://localhost:5217/User/GetCoureses`)).data;
// }

export const getList=(data)=>
{
    $http.defaults.headers.common['Authorization']="Bearer " + sessionStorage["token"];
    return $http.get('http://localhost:5217/User/GetCoureses',data) 
}


export const regist=async(nickName,qq,passWord,userSex,mobile,validateKey,validateCode)=>
{
    return await $http.get(`http://localhost:5217/user/RegistUser`,{nickName,qq,passWord,userSex,mobile,validateKey,validateCode});
}

export const getCaptcha=async(validateKey)=>
{
    return await $http.get(`http://localhost:5217/Login/GetValidateCodeImages?t=${validateKey}`,{responseType:'blob'}) 
}


