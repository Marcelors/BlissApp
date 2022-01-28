<template>
  <el-dialog
    title="Share Question"
    :visible.sync="dialogVisible"
    width="30%"
    :before-close="close"
  >
    <el-form :model="form">
      <el-form-item label="Email">
        <el-input v-model="form.destinationEmail" autocomplete="off"></el-input>
      </el-form-item>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button @click="close">Cancel</el-button>
      <el-button type="primary" @click="shareQuestion">Share</el-button>
    </span>
  </el-dialog>
</template>
<script>
import * as Api from "../shared/api";
export default {
  props: ["dialogVisible", "id"],
  data() {
    return {
      form: {
        destinationEmail: "",
        contentUrl: "",
      },
    };
  },
  methods: {
    close() {
      this.clear();
      this.$emit("close");
    },
    shareQuestion() {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });

      this.form.contentUrl = `http://localhost:5000/question/${this.id}`;

      Api.shareQuestion(this.form)
        .then(() => {
          this.clear();
          this.$emit("close");
          loading.close();
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
      this.form.destinationEmail = "";
      this.form.contentUrl = "";
    },
  },
};
</script>