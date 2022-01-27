<template>
  <el-table :data="questions" style="width: 100%">
    <el-table-column prop="question" label="Question"></el-table-column>
    <el-table-column label="Thumb">
      <template slot-scope="scope">
        <el-image
          style="width: 100px; height: 100px"
          :src="scope.row.thumbUrl"
          :fit="fit"
        ></el-image>
      </template>
    </el-table-column>
    <el-table-column label="Image">
      <template slot-scope="scope">
        <el-image
          style="width: 100px; height: 100px"
          :src="scope.row.imageUrl"
          :fit="fit"
        ></el-image>
      </template>
      <el-image
        style="width: 100px; height: 100px"
        :src="imageUrl"
        :fit="fit"
      ></el-image>
    </el-table-column>
    <el-table-column label="Operations" width="120">
      <template slot-scope="scope">
        <el-button @click="detail(scope.row.id)" type="text" size="small"
          >Detail</el-button
        >
      </template>
    </el-table-column>
  </el-table>
</template>
<script>
import * as Api from "../shared/api";

export default {
  data() {
    return {
      totalItems: 0,
      questions: [],
      limit: 10,
      offset: 0,
      filter: "",
    };
  },
  mounted() {
    this.get();
  },
  methods: {
    get() {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      const filters = {
        limit: this.limit,
        offset: this.offset,
        filter: this.filter,
      };
      Api.getQuestions(filters)
        .then((data) => {
          this.totalItems = data.totalItems;
          this.questions = data.questions;
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
    detail(id) {
      this.$emit("detail", id);
    },
  },
};
</script>