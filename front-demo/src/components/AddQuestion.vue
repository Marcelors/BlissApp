<template>
  <el-dialog
    title="New Question"
    :visible.sync="dialogVisible"
    width="30%"
    :before-close="close"
  >
    <el-form :model="form">
      <el-form-item label="Question">
        <el-input v-model="form.question" autocomplete="off"></el-input>
      </el-form-item>
      <el-form-item label="Image Url">
        <el-input v-model="form.imageUrl" autocomplete="off"></el-input>
      </el-form-item>
      <el-form-item label="Thumb Url">
        <el-input v-model="form.thumbUrl" autocomplete="off"></el-input>
      </el-form-item>
      <el-form-item label="Choice">
        <el-input v-model="form.choice" class="input-with-select">
          <el-button
            slot="append"
            icon="el-icon-circle-plus-outline"
            @click="addChoice"
          ></el-button>
        </el-input>
      </el-form-item>
      <el-table :data="form.choices" style="width: 100%">
        <el-table-column label="Choice">
          <template slot-scope="scope">
            {{ scope.row }}
          </template>
        </el-table-column>
        <el-table-column label="Operations">
          <template slot-scope="scope">
            <el-button
              @click="removeChoice(scope.$index)"
              type="text"
              size="small"
              >Remove</el-button
            >
          </template>
        </el-table-column>
      </el-table>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button @click="close">Cancel</el-button>
      <el-button type="primary" @click="addQuestion">Confirm</el-button>
    </span>
  </el-dialog>
</template>
<script>
import * as Api from "../shared/api";
export default {
  props: ["dialogVisible"],
  data() {
    return {
      form: {
        question: "",
        imageUrl: "",
        thumbUrl: "",
        choices: [],
        choice: "",
      },
    };
  },
  methods: {
    close() {
      this.clear();
      this.$emit("close");
    },
    addChoice() {
      this.form.choices.push(this.form.choice);
      this.form.choice = "";
    },
    removeChoice(index) {
      this.form.choices.splice(index, 1);
    },
    addQuestion() {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });

      Api.addQuestions(this.form)
        .then((data) => {
          this.$emit("refresh");
          this.clear();
          this.$emit("close");
          loading.close();
          this.$notify({
            title: "Success",
            message: "Question successfully added",
            type: "success",
          });
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
    clear() {
      this.form.question = "";
      this.form.imageUrl = "";
      this.form.thumbUrl = "";
      this.form.choices = [];
      this.form.choice = [];
    },
  },
};
</script>