<template>
  <div class="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-50">
    <PatientNav 
      class="sticky top-0 z-50 w-full bg-gradient-to-r from-blue-800 to-indigo-800 shadow-lg transition-all duration-300"
    />

    <!-- Индикатор загрузки -->
    <div v-if="loading" class="text-center py-20">
      <div class="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-indigo-500 mx-auto"></div>
      <p class="mt-4 text-gray-600">Загрузка данных...</p>
    </div>

    <!-- Сообщение об ошибке -->
    <div v-else-if="error" class="max-w-6xl mx-auto p-8 text-center">
      <div class="bg-red-50 text-red-700 p-6 rounded-xl">
        <i class="fas fa-exclamation-triangle text-2xl mb-3"></i>
        <h3 class="text-xl font-bold">Ошибка загрузки данных</h3>
        <p>{{ error }}</p>
        <button 
          @click="loadData"
          class="mt-4 px-4 py-2 bg-red-600 text-white rounded-lg hover:bg-red-700 transition"
        >
          Повторить попытку
        </button>
      </div>
    </div>

    <!-- Основной контент -->
    <template v-else>
      <main class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8 py-8 space-y-8">
        <!-- Заголовок -->
        <div class="text-center animate-fade-in">
          <h1 class="text-4xl font-bold text-gray-800 mb-2">Личный кабинет пациента</h1>
          <div class="w-32 h-1.5 bg-gradient-to-r from-blue-500 to-indigo-500 mx-auto rounded-full"></div>
        </div>

        <!-- Карточка пациента -->
        <section v-if="patient" class="bg-white rounded-2xl shadow-xl overflow-hidden transition-all duration-300 hover:shadow-2xl animate-slide-up">
          <PersonalInfo :patient="patient" class="p-8" />
        </section>

        <!-- Больничный лист -->
        <section v-if="sickLeave" class="bg-gradient-to-r from-blue-50 to-indigo-50 rounded-2xl shadow-xl border border-blue-100 transition-all duration-300 hover:shadow-2xl animate-slide-up delay-100">
          <PersonalSickLeave
            :statusText="sickLeave.statusText"
            :isActive="sickLeave.isActive"
            class="p-8"
          />
        </section>

        <!-- Лечение -->
        <section class="bg-white rounded-2xl shadow-xl transition-all duration-300 hover:shadow-2xl animate-slide-up delay-200">
          <div class="p-8">
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-8">
              <div>
                <h2 class="text-2xl font-semibold text-gray-800 mb-6 flex items-center">
                  <span class="w-8 h-8 bg-indigo-100 text-indigo-600 rounded-full flex items-center justify-center mr-3">
                    <i class="fas fa-prescription-bottle-alt text-lg"></i>
                  </span>
                  Лечение
                </h2>
                <div class="overflow-x-auto">
                  <table class="w-full med-table">
                    <thead>
                      <tr class="bg-gray-50">
                        <th class="py-3 px-4 text-left text-gray-600 font-semibold">Медикамент</th>
                        <th class="py-3 px-4 text-left text-gray-600 font-semibold">Дозировка</th>
                        <th class="py-3 px-4 text-left text-gray-600 font-semibold">Инструкция</th>
                      </tr>
                    </thead>
                    <tbody class="divide-y divide-gray-100">
                      <tr v-if="prescriptions.length === 0">
                        <td colspan="3" class="py-6 text-center text-gray-500">Назначения отсутствуют</td>
                      </tr>
                      <tr v-for="(item, index) in prescriptions" :key="index">
                        <td class="py-3 px-4 text-gray-700">{{ item.medication }}</td>
                        <td class="py-3 px-4 text-gray-700">{{ item.dosage }}</td>
                        <td class="py-3 px-4 text-gray-700">{{ item.instruction }}</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </section>

        <!-- История посещений -->
        <section class="bg-white rounded-2xl shadow-xl transition-all duration-300 hover:shadow-2xl animate-slide-up delay-400">
          <div class="p-8">
            <h2 class="text-2xl font-semibold text-gray-800 mb-6 flex items-center">
              <span class="w-8 h-8 bg-green-100 text-green-600 rounded-full flex items-center justify-center mr-3">
                <i class="fas fa-history text-lg"></i>
              </span>
              История посещений
            </h2>
            <History v-if="visitHistory.length > 0" :visits="visitHistory" />
            <div v-else class="text-center py-6 text-gray-500">
              История посещений отсутствует
            </div>
          </div>
        </section>
      </main>
    </template>

    <!-- Футер -->
    <footer class="bg-gradient-to-r from-blue-800 to-indigo-800 text-white py-6 mt-12">
      <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
        <p>Медицинский портал © 2025. Все права защищены.</p>
      </div>
    </footer>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

import PatientNav from '../components/PatientNav.vue'
import PersonalInfo from '../components/PersonalInfo.vue'
import PersonalSickLeave from '../components/PersonalSickLeave.vue'
import History from '../components/History.vue'

const patient = ref(null)
const sickLeave = ref(null)
const prescriptions = ref([])
const visitHistory = ref([])
const loading = ref(true)
const error = ref(null)

const api = axios.create({
  baseURL: 'http://localhost:5279',
  withCredentials: true,
})

// Загрузка данных с API
async function loadData() {
  try {
    console.log("Начало загрузки данных...")
    loading.value = true
    error.value = null
    
    // Выполняем запросы последовательно для упрощения отладки
    const userResponse = await api.get('/user')
    console.log("Данные пользователя:", userResponse.data)
    
    patient.value = {
      name: userResponse.data.fio,
      id: userResponse.data.id,
      birthDate: userResponse.data.dateofBirth,
    }

    // Больничный лист
    const sickResponse = await api.get('/sickLeave/shorts')
    console.log("Данные больничного:", sickResponse.data)
    
    if (sickResponse.data && sickResponse.data.length > 0) {
      const latest = sickResponse.data[sickResponse.data.length - 1]
      const endDate = new Date(latest.startDate)
      endDate.setDate(endDate.getDate() + latest.length)
      sickLeave.value = {
        statusText: `Активен до ${endDate.toLocaleDateString('ru-RU')}`,
        isActive: new Date() <= endDate,
      }
    } else {
      sickLeave.value = {
        statusText: 'Нет активных больничных',
        isActive: false,
      }
    }

    // Медикаменты
    const medsResponse = await api.get('/medicine')
    console.log("Медикаменты:", medsResponse.data)
    
    // ОБНОВЛЕННЫЙ МАППИНГ ДАННЫХ:
    prescriptions.value = medsResponse.data.map((x) => ({
      medication: x.name || x.medication || x.medicationName,
      dosage: x.dosage || x.dose,
      instruction: x.rulesOfTaking  // <-- ИСПОЛЬЗУЕМ ПРАВИЛЬНОЕ ПОЛЕ С СЕРВЕРА
    }))

    // История посещений
    const historyResponse = await api.get('/appointment/history')
    console.log("История посещений:", historyResponse.data)
    
    visitHistory.value = historyResponse.data.map((x) => ({
      date: new Date(x.date).toLocaleDateString('ru-RU'),
      doctor: x.doctorFIO,
      reason: x.diagnos,
      details: x.description,
    }))

    console.log("Данные успешно загружены!")

  } catch (err) {
    console.error('Ошибка при загрузке данных:', err)
    
    // Подробная обработка ошибок
    if (err.response) {
      // Ошибка от сервера (4xx, 5xx)
      error.value = `Ошибка сервера: ${err.response.status} - ${err.response.data?.message || 'Нет дополнительной информации'}`
    } else if (err.request) {
      // Запрос был сделан, но ответ не получен
      error.value = 'Сервер не отвечает. Проверьте подключение к интернету.'
    } else {
      // Другие ошибки
      error.value = `Ошибка: ${err.message}`
    }
  } finally {
    loading.value = false
    console.log("Состояние загрузки завершено")
  }
}

// Вызываем загрузку данных при монтировании компонента
onMounted(() => {
  loadData()
})
</script>