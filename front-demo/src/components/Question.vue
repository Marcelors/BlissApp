<template>
  <div>
    <el-input placeholder="Search" v-model="filter">
      <el-button
        slot="append"
        icon="el-icon-search"
        @click="search"
      ></el-button>
    </el-input>
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
    <el-pagination
      background
      layout="pager"
      :total="totalItems"
      :current-page="page"
      @current-change="changePage"
    >
    </el-pagination>
  </div>
</template>
<script>
import * as Api from "../shared/api";

export default {
  data() {
    return {
      totalItems: 0,
      questions: [],
      limit: 10,
      page: 1,
      filter: "",
    };
  },
  mounted() {
    this.get();
  },
  methods: {
    changePage(newPage) {
      this.page = newPage;
      this.get();
    },
    search() {
      this.page = 1;
      this.get();
    },
    get() {
      const loading = this.$loading({
        lock: true,
        text: "Loading",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      const filters = {
        limit: this.limit,
        offset: (this.page - 1) * this.limit,
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