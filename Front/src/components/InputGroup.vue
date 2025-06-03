<template>
  <div class="mb-5">
    <label :for="id" class="block font-bold mb-1">{{ label }}</label>
    <input
      :type="type"
      :id="id"
      :placeholder="placeholder"
      class="w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
      :value="modelValue"
      @input="onInput"
    />
  </div>
</template>

<script lang="ts" setup>
const props = defineProps<{
  id: string
  label: string
  type?: string
  placeholder: string
  modelValue: string
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()

function onInput(event: Event) {
  const target = event.target as HTMLInputElement
  emit('update:modelValue', target.value)
}
</script>
