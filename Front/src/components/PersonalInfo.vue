<template>
  <!-- Информация о пациенте (без тени) -->
  <div class="p-4">
    <div class="flex justify-between mb-3">
      <div class="font-bold text-lg">{{ patient.name }}</div>
      <div class="text-sm text-gray-600">№ пациента: {{ patient.id }}</div>
    </div>
    
    <div class="text-base">
      <div>
        <div class="font-semibold text-gray-800">Дата рождения</div>
        <div class="text-gray-600">{{ patient.birthDate }}</div>
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  patient: {
    type: Object,
    required: true,
    default: () => ({
      name: '',
      id: '',
      birthDate: ''
    })
  }
})
</script>
