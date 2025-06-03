<template>
  <div class="bg-gradient-to-r from-blue-700 to-blue-600 shadow-md py-6 w-full">
    <nav class="max-w-7xl mx-auto px-4">
      <ul class="flex justify-around text-white text-xl">
        <li v-for="item in navItems" :key="item.id">
          <router-link 
            :to="item.route"
            custom
            v-slot="{ isActive, navigate }"
          >
            <a 
              @click="navigate"
              :class="[
                'px-6 py-3 rounded transition cursor-pointer',
                isActive 
                  ? 'bg-white/30 font-bold' 
                  : 'font-semibold hover:bg-white/20'
              ]"
            >
              {{ item.label }}
            </a>
          </router-link>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
export default {
  name: 'PatientNav',
  data() {
    return {
      navItems: [
        { id: 'appointment', label: 'Записаться', route: { name: 'login' } },
        { id: 'medical-card', label: 'Медицинская карта', route: { name: 'SickLeave' } },
        { id: 'clinics', label: 'Поликлиники', route: { name: 'login' } },
        { id: 'profile', label: 'Личный кабинет', route: { name: 'PatientHome' } }
      ]
    }
  }
}
</script>