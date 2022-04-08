import axios from "axios"
//axios.create 創建一個axios實例 我們給這個實例編寫配置,後續所有通過實例發送的請求,都受當前配置約束
const $http = axios.create({
    baseURL:'',
    timeout:5000,
    // headers:{'X-Custom-Header':'foobar'}
})

// 添加请求拦截器
$http.interceptors.request.use(function (config) {
    // 在发送请求之前做些什么
    // config.headers.token='123456'
    return config;
  }, function (error) {
    // 对请求错误做些什么
    return Promise.reject(error);
  });

// 添加响应拦截器
$http.interceptors.response.use(function (response) {
    // 对响应数据做点什么
    
    let data = response.data;
    return data;
  }, function (error) {
    // 对响应错误做点什么
    return Promise.reject(error);
  });

  export default $http