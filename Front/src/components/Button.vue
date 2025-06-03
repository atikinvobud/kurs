<template>
  <button
    class="text-lg font-bold text-center text-black hover:text-blue-600 mb-4 w-full"
    @click="$emit('click')"
  >
    {{ text }}
  </button>
</template>

<script lang="ts" setup>
defineProps<{
  text: string
}>()

defineEmits<{
  (e: 'click'): void
}>()
</script>
