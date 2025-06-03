<template>
  <p class="text-lg text-gray-600 text-center">
    {{ infoText }}
    <RouterLink :to="href" class="text-blue-600 hover:underline">{{ linkText }}</RouterLink>
  </p>
</template>

<script lang="ts" setup>
defineProps<{
  href: string
  linkText?: string
  infoText?: string
}>()
</script>
