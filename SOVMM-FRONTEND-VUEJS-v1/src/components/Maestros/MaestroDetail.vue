<template>
  <div>
    {{currentTeacher.firstName}}
  </div>
</template>
<script>

export default {
  props: ['currentTeacher'],
  name: 'MaestroDetail',
  data() {
    return {
    };
  },
};
</script>

<style scoped>

</style>
