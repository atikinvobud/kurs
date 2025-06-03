<template>
  <div class="min-h-screen flex items-center justify-center bg-blue-100 p-4">
    <div class="bg-white w-full max-w-md rounded-xl shadow-xl overflow-hidden animate-fade-in">
      <div class="bg-blue-600 text-white text-center p-8 relative overflow-hidden">
        <div class="relative z-10">
          <h1 class="text-2xl font-semibold mb-2">Восстановление пароля</h1>
          <p class="text-sm opacity-90">Следуйте шагам для сброса доступа</p>
        </div>
        <div class="absolute top-[-50px] left-[-50px] w-[150px] h-[150px] bg-white/10 rounded-full"></div>
        <div class="absolute bottom-[-80px] right-[-30px] w-[200px] h-[200px] bg-white/10 rounded-full"></div>
      </div>

      <div class="px-8 pt-10 pb-8">
        <!-- Этап 1: логин -->
        <InputGroup
          v-if="step === 'login'"
          id="username"
          label="Имя пользователя"
          placeholder="Введите ваше имя"
          icon="fas fa-user"
          v-model="username"
        />

        <!-- Этап 2: код -->
        <InputGroup
          v-if="step === 'code'"
          id="code"
          label="Код из письма"
          placeholder="Введите код"
          icon="fas fa-key"
          v-model="code"
        />

        <!-- Этап 3: новый пароль -->
        <InputGroup
          v-if="step === 'reset'"
          id="newPassword"
          label="Новый пароль"
          placeholder="Введите новый пароль"
          icon="fas fa-lock"
          v-model="newPassword"
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
        <!-- Кнопка -->
        <button
          class="bg-blue-600 text-white font-semibold text-lg py-4 w-full rounded-lg shadow-md hover:bg-blue-700 transition-all relative overflow-hidden mt-2"
          @click="handleClick"
          :disabled="isSending"
        >
          <span v-if="isSending"><i class="fas fa-spinner fa-spin mr-2"></i>Обработка...</span>
          <span v-else-if="step === 'login'"><i class="fas fa-paper-plane mr-2"></i>Отправить код</span>
          <span v-else-if="step === 'code'"><i class="fas fa-check mr-2"></i>Подтвердить код</span>
          <span v-else><i class="fas fa-lock mr-2"></i>Сбросить пароль</span>
        </button>

        <div class="text-center text-gray-600 mt-4">
          Вспомнили пароль?
          <RouterLink 
            to="/login" 
            class="text-blue-600 font-medium hover:text-indigo-700 transition-colors ml-1"
          >
            Войти
          </RouterLink>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'
import InputGroup from '../components/InputGroup.vue'

const router = useRouter()
const message = ref('')
const messageClass = ref('')
const username = ref('')
const code = ref('')
const newPassword = ref('')

const step = ref<'login' | 'code' | 'reset'>('login')
const isSending = ref(false)
const errorMessage = ref('')
const successMessage = ref('')

async function handleClick() {
  errorMessage.value = ''
  successMessage.value = ''
  isSending.value = true

  try {
    if (step.value === 'login') {
      if (!username.value.trim()) {
        message.value = 'Успешный смена. Перенаправление...'
        messageClass.value = 'success'
        return
      }
      await axios.post(`http://localhost:5279/mail/create-reset-code/${username.value}`)
      message.value = 'Код отправлен на почту'
        messageClass.value = 'success'
      step.value = 'code'

    } else if (step.value === 'code') {
      if (!code.value.trim()) {
        message.value = 'Введите код подтверждения'
        messageClass.value = 'success'
        return
      }
      try {
        const response = await axios.post(`http://localhost:5279/mail/verify-reset-code/${username.value}/${code.value}`);

        if (response.status === 200) {
            message.value = 'Код подтвержден, введите новый пароль';
            messageClass.value = 'success';
            step.value = 'reset';
        } else {
            message.value = 'Ошибка подтверждения кода. Повторите попытку.';
            messageClass.value = 'error';
        }
        } catch (error) {
        message.value = 'Произошла ошибка при подтверждении кода';
        messageClass.value = 'error';
        console.error(error);
        }

    } else if (step.value === 'reset') {
      if (!newPassword.value.trim()) {
        message.value = 'Введите новый пароль'
        messageClass.value = 'success'
        return
      }
      await axios.post(`http://localhost:5279/mail/update-password/${username.value}/${newPassword.value}`)
      message.value = 'Парольл успешно сброшен'
        messageClass.value = 'success'
      setTimeout(() => router.push('/login'), 1500)
    }

  } catch (err: any) {
    message.value = 'ошибка обработки запроса'
        messageClass.value = 'error'
  } finally {
    isSending.value = false
  }
}
</script>

<style scoped>
@keyframes fade-in {
  from { opacity: 0; transform: translateY(20px); }
  to { opacity: 1; transform: translateY(0); }
}
.animate-fade-in {
  animation: fade-in 0.8s ease-out;
}
</style>
