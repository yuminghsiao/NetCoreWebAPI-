import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/login.vue'

const routes = [
  {
    path: '/Home',
    name: 'Home',
    component: Home,
    meta:{
      isShow:false
    },
    children:[
      {
        path:'/courseList',
        name: 'CourseList',
        meta:{
          isShow:true,
          title:'課程列表'
        },
        component: () => import(/* webpackChunkName: "courseList" */ '../views/courseList.vue')
      },
      {
        path:'/teacherList',
        name: 'TeacherList',
        meta:{
          isShow:true,
          title:'講師列表'
        },
        component: () => import(/* webpackChunkName: "teacherList" */ '../views/teacherList.vue')
      },
      {
        path:'/personal',
        name: 'Personal',
        meta:{
          isShow:true,
          title:'個人中心'
        },
        component: () => import(/* webpackChunkName: "personal" */ '../views/personal.vue')
      },
    ]
  },
  {
    path:'/',
    name: 'Login',
    component:Login,
    meta:{
      isShow:false
    }
    // component: () => import(/* webpackChunkName: "login" */ '../views/login.vue')
  },
 
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
