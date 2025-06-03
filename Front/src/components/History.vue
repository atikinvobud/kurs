<template>
  <div class="w-full overflow-x-auto">
    <h2 class="text-xl font-semibold mb-4">История посещения</h2>
    <table class="min-w-full border border-gray-300 text-left">
      <thead class="bg-gray-100">
        <tr>
          <th class="px-4 py-2 border-b border-gray-300">Дата</th>
          <th class="px-4 py-2 border-b border-gray-300">Врач</th>
          <th class="px-4 py-2 border-b border-gray-300">Причина</th>
          <th class="px-4 py-2 border-b border-gray-300">Детали</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(visit, index) in visits" :key="index" class="odd:bg-white even:bg-gray-50">
          <td class="px-4 py-2 border-b border-gray-300">{{ visit.date }}</td>
          <td class="px-4 py-2 border-b border-gray-300">{{ visit.doctor }}</td>
          <td class="px-4 py-2 border-b border-gray-300">{{ visit.reason }}</td>
          <td class="px-4 py-2 border-b border-gray-300">{{ visit.details }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
defineProps({
  visits: {
    type: Array,
    required: true,
  },
});
</script>
