<template>
  <div id="app">
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
        <el-col :span="24"> <question ref="tableQuestion"></question></el-col>
      </el-main>
    </el-container>
    <add-question
      :dialogVisible="dialogVisible"
      @close="dialogVisible = false"
      @refresh="get"
    ></add-question>
  </div>
</template>

<script>
import Question from "./components/Question.vue";
import AddQuestion from "./components/AddQuestion.vue";

export default {
  name: "App",
  components: {
    Question,
    AddQuestion,
  },
  data() {
    return {
      dialogVisible: false,
    };
  },
  methods: {
    get() {
      this.$refs["tableQuestion"].get();
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
</style>
