<template>
 <router-view />
</template>

<script>
import {getData} from './http/api'
// import axios from 'axios'
// import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',

  setup(){
    // axios.get('http://jsonplaceholder.typicode.com/posts').then(res=>{
    //   console.log(res)
    // })
    // getData.then(res=>{
    //   console.log(res)
    // })
    
  }
}
</script>

<style>
body{
  margin: 0;
}
</style>
