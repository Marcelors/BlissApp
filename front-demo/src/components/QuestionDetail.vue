<template >
  <el-form :model="question">
    <el-form-item label="Question">
      <el-input
        v-model="question.question"
        autocomplete="off"
        :disabled="true"
      ></el-input>
    </el-form-item>
    <el-form-item label="Image Url">
      <el-input
        v-model="question.imageUrl"
        autocomplete="off"
        :disabled="true"
      ></el-input>
    </el-form-item>
    <el-form-item label="Thumb Url">
      <el-input
        v-model="question.thumbUrl"
        autocomplete="off"
        :disabled="true"
      ></el-input>
    </el-form-item>
    <el-table :data="question.choices" style="width: 100%">
      <el-table-column label="Choice">
        <template slot-scope="scope">
          {{ scope.row.choice }}
        </template>
      </el-table-column>
      <el-table-column label="Votes">
        <template slot-scope="scope">
          {{ scope.row.votes }}
        </template>
      </el-table-column>
      <el-table-column label="Operations">
        <template slot-scope="scope">
          <el-button @click="addVotes(scope.$index)" type="text" size="small"
            >Adicionar Voto</el-button
          >
        </template></el-table-column
      ></el-table
    >
    <br />
    <el-divider></el-divider>
    <el-form-item>
      <el-button @click="cancel">Cancel</el-button>
      <el-button type="primary" @click="update">Update</el-button>
    </el-form-item>
  </el-form>
</template>
<script>
import * as Api from "../shared/api";

export default {
  props: ["id"],
  data() {
    return {
      question: null,
    };
  },
  mounted() {
    if (this.id) this.getById(this.id);
  },
  methods: {
    getById(id) {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });

      Api.getQuestionsById(id)
        .then((data) => {
          this.question = data;
          loading.close();
        })
        .catch((err) => {
          this.$swal({
            icon: "error",
            title: err.data.title,
            text: err.data.detail,
          });
          loading.close();
        });
    },
    addVotes(index) {
      this.question.choices[index].votes += 1;
    },
    cancel() {
      this.question = null;
      this.$emit("cancel");
    },
    update() {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });

      Api.updateQuestions(this.id, this.question)
        .then((data) => {
          this.question = data;
          loading.close();
          this.$emit("cancel");
        })
        .catch((err) => {
          if (err.status == 400) {
            this.$swal({
              icon: "error",
              title: err.data.detail,
              text: JSON.stringify(err.data.errors),
            });
          } else {
            this.$swal({
              icon: "error",
              title: err.data.title,
              text: err.data.detail,
            });
          }
          loading.close();
        });
    },
  },
};
</script>