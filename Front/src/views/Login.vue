<template>
  <div class="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-50 to-indigo-100 p-4">
    <div class="bg-white rounded-2xl shadow-xl overflow-hidden w-full max-w-md">
      <!-- Заголовок с градиентом -->
      <div class="bg-gradient-to-r from-blue-500 to-indigo-600 py-6">
        <h1 class="text-2xl font-bold text-white text-center">Вход</h1>
      </div>

      <div class="p-8">
        <form @submit.prevent="handleLogin">
          <InputGroup
            id="username"
            label="Имя"
            placeholder="Введите ваше имя"
            v-model="username"
            class="mb-6"
          />

          <InputGroup
            id="password"
            label="Пароль"
            type="password"
            placeholder="Введите ваш пароль"
            v-model="password"
            class="mb-6"
          />

          <div
            v-if="message"
            :class="['text-sm text-center p-3 rounded-lg border my-4', 
                    messageClass === 'error' ? 
                    'text-red-700 bg-red-100 border-red-300' : 
                    'text-green-700 bg-green-100 border-green-300']"
          >
            {{ message }}
          </div>

          <Button
            text="Войти"
            @click="handleLogin"
            class="w-full bg-gradient-to-r from-blue-500 to-indigo-600 hover:from-blue-600 hover:to-indigo-700 text-white font-bold py-3 px-4 rounded-lg shadow-md hover:shadow-lg transition-all duration-300"
          />
        </form>

        <div class="flex flex-col gap-4 mt-8">
          <div class="text-center text-gray-600">
            Забыли пароль?
            <RouterLink 
              to="/forgot-password" 
              class="text-blue-600 font-medium hover:text-indigo-700 transition-colors ml-1"
            >
              Восстановить пароль
            </RouterLink>
          </div>

          <div class="text-center text-gray-600">
            Нет аккаунта?
            <RouterLink 
              to="/about" 
              class="text-blue-600 font-medium hover:text-indigo-700 transition-colors ml-1"
            >
              Зарегистрироваться
            </RouterLink>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import axios from 'axios'
import { useRouter } from 'vue-router'

import InputGroup from '../components/InputGroup.vue'
import Button from '../components/Button.vue'


const username = ref('')
const password = ref('')
const message = ref('')
const messageClass = ref('')
const router = useRouter()

async function handleLogin() {
  message.value = ''
  messageClass.value = ''

  if (!username.value.trim()) {
  message.value = 'Имя пользователя не может быть пустым'
  messageClass.value = 'error' // Вместо строки классов просто флаг
  return
}

if (!password.value.trim()) {
  message.value = 'Пароль не может быть пустым'
  messageClass.value = 'error' // Просто устанавливаем 'error'
  return
}

  try {
    const response = await axios.post('http://localhost:5279/authorization/login', {
      login: username.value,
      password: password.value
    }, {
      withCredentials: true
    })

    // Сохраняем разрешённые страницы
    localStorage.setItem('allowedPages', JSON.stringify(response.data.allowedPages))

    message.value = 'Успешный вход. Перенаправление...'
     messageClass.value = 'success'

    setTimeout(() => {
      router.push(response.data.mainPage)
    }, 1000)
  } catch (error: any) {
    if (error.response?.status === 401) {
      message.value = 'Неверный логин или пароль'
    } else if (error.response?.status === 404) {
      message.value = 'Пользователь не найден'
    } else {
      message.value = 'Ошибка при входе. Попробуйте позже'
    }
     messageClass.value = 'error'
  }
}
</script>
