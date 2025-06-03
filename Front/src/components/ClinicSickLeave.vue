<template>
  <div class="sick-leaves-table active" :id="tableId">
    <h3 class="text-xl font-bold text-gray-800 mb-6 flex items-center">
      <i class="fas fa-file-medical text-blue-500 mr-3"></i>
      Больничные листы
    </h3>
    
    <div class="table-container">
      <table class="medical-table w-full">
        <thead>
          <tr class="text-left">
            <th class="py-3 px-4">Период</th>
            <th class="py-3 px-4">Причина</th>
            <th class="py-3 px-4">Врач</th>
            <th class="py-3 px-4">Действия</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(leave, index) in sickLeaves" :key="index">
            <td class="py-3 px-4 font-medium">{{ leave.period }}</td>
            <td class="py-3 px-4">{{ leave.reason }}</td>
            <td class="py-3 px-4">
              <div class="flex items-center">
                <div
                  class="rounded-full w-8 h-8 flex items-center justify-center mr-2"
                  :class="leave.badgeBg + ' ' + leave.badgeText"
                >
                  {{ leave.initials }}
                </div>
                {{ leave.doctor }}
              </div>
            </td>
            <td class="py-3 px-4">
              <button class="text-blue-500 hover:text-blue-700 mr-3">
                <i class="fas fa-download"></i>
              </button>
              <button class="text-blue-500 hover:text-blue-700">
                <i class="fas fa-print"></i>
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  
  </div>
</template>

<script>
export default {
  name: 'SickLeavesTable',
  props: {
    tableId: {
      type: String,
      required: true
    },
    sickLeaves: {
      type: Array,
      required: true,
      default: () => []
    }
  }
}
</script>

<style scoped>
.medical-table {
  min-width: 600px;
  border-collapse: separate;
  border-spacing: 0;
}

.medical-table th {
  background-color: #f7fafc;
  font-weight: 600;
  color: #4a5568;
}

.medical-table tr:nth-child(even) {
  background-color: #f8fafc;
}

.medical-table th,
.medical-table td {
  padding: 12px 16px;
  text-align: left;
  border-bottom: 1px solid #edf2f7;
}

.medical-table tr:last-child td {
  border-bottom: none;
}

.table-container {
  overflow-x: auto;
  border-radius: 8px;
  border: 1px solid #e2e8f0;
}

.sick-leaves-table {
  animation: fadeIn 0.3s ease;
}

@keyframes fadeIn {
  from { opacity: 0; transform: translateY(10px); }
  to { opacity: 1; transform: translateY(0); }
}
</style>