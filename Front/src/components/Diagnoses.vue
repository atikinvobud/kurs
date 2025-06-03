<template>
  <div class="flex flex-col md:flex-row gap-6">
    <!-- Колонка с предписаниями -->
    <div class="w-full overflow-x-auto">
      <h2 class="text-xl font-semibold mb-3">Предписания</h2>
      
      <div v-if="prescriptions.length === 0" class="bg-blue-50 border border-blue-200 rounded-lg p-6 text-center">
        <i class="fas fa-pills text-blue-500 text-3xl mb-3"></i>
        <p class="text-blue-700">Назначенные медикаменты отсутствуют</p>
      </div>

      <table v-else class="min-w-full border border-gray-300 text-left">
        <thead class="bg-gray-100">
          <tr>
            <th class="px-4 py-3 border-b border-gray-300 font-semibold text-gray-700">Медикамент</th>
            <th class="px-4 py-3 border-b border-gray-300 font-semibold text-gray-700">Дозировка</th>
            <th class="px-4 py-3 border-b border-gray-300 font-semibold text-gray-700">Правила приёма</th>
          </tr>
        </thead>
        <tbody>
          <tr 
            v-for="(prescription, index) in prescriptions" 
            :key="index" 
            class="hover:bg-blue-50 transition-colors"
          >
            <td class="px-4 py-3 border-b border-gray-300 font-medium">
              {{ prescription.medication || prescription.name }}
            </td>
            <td class="px-4 py-3 border-b border-gray-300">
              {{ prescription.dosage }}
            </td>
            <td class="px-4 py-3 border-b border-gray-300">
              {{ prescription.rulesOfTaking || prescription.instruction }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
defineProps({
  prescriptions: {
    type: Array,
    required: true,
    default: () => []
  }
});
</script>

<style scoped>
table {
  border-collapse: collapse;
  width: 100%;
}

th, td {
  border: 1px solid #e2e8f0;
}

tr:last-child td {
  border-bottom: none;
}
</style>