<template>
  <div id="app">
    <div v-show="mainScreen">
      <h1>Questions</h1>
      <el-divider></el-divider>
      <el-container>
        <el-header>
          <el-col :span="24"
            ><el-button type="success" @click="dialogVisible = true"
              >Add Question</el-button
            ></el-col
          >
        </el-header>
        <el-main>
          <el-col :span="24">
            <question ref="tableQuestion" @detail="detail"></question
          ></el-col>
        </el-main>
      </el-container>
      <add-question
        :dialogVisible="dialogVisible"
        @close="dialogVisible = false"
        @refresh="get"
      ></add-question>
    </div>
    <div v-show="!mainScreen">
      <h1>Question Detail</h1>
      <el-divider></el-divider>
      <question-detail
        ref="questionDetail"
        :id="id"
        @cancel="mainScreen = true"
      ></question-detail>
    </div>
  </div>
</template>

<script>
import Question from "./components/Question.vue";
import AddQuestion from "./components/AddQuestion.vue";
import QuestionDetail from "./components/QuestionDetail.vue";
import * as Api from "./shared/api";

export default {
  name: "App",
  components: {
    Question,
    AddQuestion,
    QuestionDetail,
  },
  data() {
    return {
      dialogVisible: false,
      mainScreen: true,
      id: null,
    };
  },
  mounted() {
    this.health();
  },
  methods: {
    get() {
      this.$refs["tableQuestion"].get();
    },
    detail(id) {
      this.mainScreen = false;
      this.$refs["questionDetail"].getById(id);
      this.id = id;
    },
    health() {
      Api.health()
        .then(() => {
          setTimeout(() => {
            this.health();
          }, 60000);
        })
        .catch(() => {
          this.$swal({
            icon: "error",
            title: "Retry Action",
          }).then(() => {
            this.health();
          });
        });
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.swal2-container {
  z-index: 999999999 !important;
}
</style>
