<template>
  <div class="p-4">
    <div>
      <div class="font-semibold text-gray-800">Больничный</div>
      <div :class="isActive ? 'text-green-600 font-medium' : 'text-gray-500 font-medium'">
        {{ statusText }}
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  statusText: String,
  isActive: {
    type: Boolean,
    default: true,
  },
});
</script>
