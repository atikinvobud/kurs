<template>
  <div class="no-selection" :id="blockId">
    <i class="fas fa-hospital text-4xl mb-4"></i>
    <h4 class="text-lg font-medium text-gray-500 mb-2">{{ title }}</h4>
    <p class="text-gray-400">{{ subtitle }}</p>
  </div>
</template>

<script>
export default {
  name: 'NoClinicSelected',
  props: {
    blockId: {
      type: String,
      default: 'no-selection'
    },
    title: {
      type: String,
      default: 'Выберите поликлинику'
    },
    subtitle: {
      type: String,
      default: 'Нажмите на одну из поликлиник слева, чтобы просмотреть больничные листы'
    }
  }
}
</script>

<style scoped>
.no-selection {
  text-align: center;
  padding: 40px 20px;
  color: #94a3b8;
}

.no-selection i {
  font-size: 48px;
  margin-bottom: 20px;
  color: #cbd5e1;
}
</style>