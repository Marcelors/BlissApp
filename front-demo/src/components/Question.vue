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
export * as api from "../shared/api";

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
  methods: {
    get() {
      const filters = {
        limit: this.limit,
        offset: this.offset,
        filter: this.filter,
      };
      api.getQuestions(filters).then((data) => {
        (this.totalItems = data.totalItems), (this.questions = data.questions);
      });
    },
    detail(id) {},
  },
};
</script>