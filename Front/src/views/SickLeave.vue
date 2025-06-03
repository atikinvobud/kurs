<template>
  <div> <!-- Основной корневой элемент -->
     <PatientNav 
      class="sticky top-0 z-50 w-full bg-gradient-to-r from-blue-800 to-indigo-800 shadow-lg transition-all duration-300"
    />
    <div class="grid grid-cols-1 lg:grid-cols-3 gap-8 mx-40 my-5">
      <!-- Левая колонка — список клиник -->
      <div class="lg:col-span-1">
        <div class="space-y-6">
          <ClinicCard
            v-for="clinic in clinics"
            :key="clinic.id"
            :cardId="`clinic-${clinic.id}`"
            :clinicName="clinic.name"
            :address="clinic.address"
            :passport="clinic.passport"
            :snils="clinic.snils"
            :oms="clinic.oms"
            @click.native="selectClinic(clinic.id)"
            class="card clinic-card p-6 cursor-pointer transition-all duration-300"
            :class="{ 'active-clinic': selectedClinic?.id === clinic.id }"
          />
        </div>
      </div>

      <!-- Правая колонка — таблица или заглушка -->
      <div class="lg:col-span-2">
        <div class="card p-6 h-full" id="sick-leaves-container">
          <ClinicSickLeave
            v-if="selectedClinic"
            :tableId="`sickleave-${selectedClinic.id}`"
            :sickLeaves="selectedClinic.sickLeaves"
            class="sick-leaves-table active"
          />
          
          <NoChoice 
            v-else 
            class="no-selection py-10"
          />
        </div>
      </div>
    </div>
    
    <footer class="bg-gradient-to-r from-blue-800 to-indigo-800 text-white py-6 mt-12">
      <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
        <p>Медицинский портал © 2025. Все права защищены.</p>
      </div>
    </footer>
  </div> <!-- Закрытие корневого элемента -->
</template>

<script>
import axios from 'axios';
import ClinicCard from '../components/ClinicCard.vue';
import ClinicSickLeave from '../components/ClinicSickLeave.vue';
import NoChoice from '../components/NoChoice.vue';
import PatientNav from '../components/PatientNav.vue';
export default {
  name: 'ClinicsView',
  components: {
    ClinicCard,
    ClinicSickLeave,
    NoChoice,
    PatientNav
  },
  data() {
    return {
      clinics: [],
      selectedClinicId: null
    }
  },
  computed: {
    selectedClinic() {
      return this.clinics.find(c => c.id === this.selectedClinicId)
    }
  },
  mounted() {
    this.fetchClinics();
  },
  methods: {
    async fetchClinics() {
      try {
        const response = await axios.get(
          'http://localhost:5279/medicalcards/FullInfo', 
          {
            withCredentials: true  // Добавлен параметр для передачи кук
          }
        );
        this.processClinicData(response.data);
      } catch (error) {
        console.error('Ошибка при загрузке данных:', error);
        this.clinics = [];
      }
    },
    
    processClinicData(apiData) {
      const clinicsMap = new Map();
      
      apiData.forEach(item => {
        const clinicId = item.polyclinicId;
        
        if (!clinicsMap.has(clinicId)) {
          clinicsMap.set(clinicId, {
            id: clinicId,
            name: `Поликлиника №${clinicId}`,
            address: item.address || 'Адрес не указан',
            passport: item.passport || '—',
            snils: item.snils || '—',
            oms: item.polis || '—',
            sickLeaves: []
          });
        }
        
        clinicsMap.get(clinicId).sickLeaves.push({
          period: `${this.formatDate(item.startDate)} — ${this.calculateEndDate(item.startDate, item.length)}`,
          reason: item.diagnos || 'Диагноз не указан',
          doctor: item.doctorFIO || 'Врач не указан',
          initials: this.getInitials(item.doctorFIO),
          badgeBg: 'bg-blue-100',
          badgeText: 'text-blue-800'
        });
      });
      
      this.clinics = Array.from(clinicsMap.values());
    },
    
    formatDate(dateString) {
      if (!dateString) return 'дд.мм.гггг';
      const date = new Date(dateString);
      return date.toLocaleDateString('ru-RU');
    },
    
    calculateEndDate(startDate, days) {
      if (!startDate || !days) return 'дд.мм.гггг';
      const date = new Date(startDate);
      date.setDate(date.getDate() + parseInt(days));
      return date.toLocaleDateString('ru-RU');
    },
    
    getInitials(fullName) {
      if (!fullName) return '—';
      const names = fullName.split(' ');
      return names.slice(0, 2).map(n => n[0]?.toUpperCase() ?? '').join('');
    },
    
    selectClinic(id) {
      this.selectedClinicId = id;
    }
  }
}
</script>