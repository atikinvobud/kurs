<template>
  <div class="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100 flex items-center justify-center font-sans px-4">
    <div class="bg-white rounded-2xl shadow-xl overflow-hidden w-full max-w-md">
      <!-- Заголовок с градиентом -->
      <div class="bg-gradient-to-r from-blue-500 to-indigo-600 py-6">
        <h1 class="text-2xl font-bold text-white text-center">Регистрация</h1>
      </div>

      <div class="p-8">
        <InputGroup
          id="name"
          label="Email:"
          placeholder="Введите ваш email"
          v-model="form.name"
          class="mb-6"
        />
        <InputGroup
          id="password"
          type="password"
          label="Пароль:"
          placeholder="Введите пароль"
          v-model="form.password"
          class="mb-6"
        />
        <InputGroup
          id="confirm-password"
          type="password"
          label="Подтвердите пароль:"
          placeholder="Подтвердите пароль"
          v-model="form.confirmPassword"
          class="mb-6"
        />
        <InputGroup
          id="fio"
          label="ФИО:"
          placeholder="Введите ваше ФИО"
          v-model="form.fio"
          class="mb-6"
        />
        <InputGroup
          id="dateOfBirth"
          type="date"
          label="Дата рождения:"
          placeholder="Выберите дату рождения"
          v-model="form.dateOfBirth"
          class="mb-6"
        />

        <div
        v-if="message"
        :class="[
          'text-sm text-center p-3 rounded-lg border my-4',
          messageClass === 'error'
            ? 'text-red-700 bg-red-100 border-red-300'
            : 'text-green-700 bg-green-100 border-green-300'
        ]"
      >
        {{ message }}
      </div>

        <!-- Разделитель -->
        <div class="border-t border-gray-200 my-6"></div>

        <Button 
          text="Зарегистрироваться" 
          @click="submitForm"
          class="w-full bg-gradient-to-r from-blue-500 to-indigo-600 hover:from-blue-600 hover:to-indigo-700 text-white font-bold py-3 px-4 rounded-lg shadow-md hover:shadow-lg transition-all duration-300"
        />

        <Link
          class="mt-6 text-center text-gray-600"
          href="/login"
          infoText="Уже зарегистрированы?"
          linkText="Войти"
        />
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

import InputGroup from '../components/InputGroup.vue'
import Button from '../components/Button.vue'
import Link from '../components/Link.vue'

const router = useRouter()

interface FormData {
  name: string
  password: string
  confirmPassword: string
  fio: string
  dateOfBirth: string
}

const form = reactive<FormData>({
  name: '',
  password: '',
  confirmPassword: '',
  fio: '',
  dateOfBirth: ''
})

const message = ref('')
const messageClass = ref<'error' | 'success' | ''>('')

function isValidEmail(email: string): boolean {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  return re.test(email)
}

async function registerPatient() {
  const payload = {
    Login: form.name,
    Password: form.password,
    FIO: form.fio,
    DateOfBirth: form.dateOfBirth
  }

  try {
    const response = await axios.post('http://localhost:5279/authorization/patient', payload, {
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })

    if (response.status === 200) {
      message.value = 'Регистрация прошла успешно!'
      messageClass.value = 'success'

      // Очистка формы
      form.name = ''
      form.password = ''
      form.confirmPassword = ''
      form.fio = ''
      form.dateOfBirth = ''

      // Небольшая задержка перед переходом (чтобы показать сообщение)
      setTimeout(() => router.push('/login'), 1500)
    }
  } catch (error: any) {
    messageClass.value = 'error'
    if (error.response) {
      if (error.response.status === 409) {
        message.value = 'Пользователь с таким логином уже существует'
      } else {
        message.value = 'Ошибка регистрации, попробуйте позже'
      }
    } else {
      message.value = 'Ошибка сети, попробуйте позже'
      console.error(error)
    }
  }
}

function submitForm() {
  if (!form.name.trim()) {
    message.value = 'Пожалуйста, введите email'
    messageClass.value = 'error'
    return
  }

  if (!isValidEmail(form.name)) {
    message.value = 'Пожалуйста, введите корректный email'
    messageClass.value = 'error'
    return
  }

  if (form.password !== form.confirmPassword) {
    message.value = 'Пароли не совпадают!'
    messageClass.value = 'error'
    return
  }

  if (!form.fio.trim()) {
    message.value = 'Пожалуйста, введите ФИО'
    messageClass.value = 'error'
    return
  }

  if (!form.dateOfBirth) {
    message.value = 'Пожалуйста, выберите дату рождения'
    messageClass.value = 'error'
    return
  }

  // Очистка сообщений перед отправкой
  message.value = ''
  messageClass.value = ''

  registerPatient()
}
</script>
