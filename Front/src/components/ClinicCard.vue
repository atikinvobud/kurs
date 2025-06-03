<template>
  <div 
    class="card clinic-card p-6 cursor-pointer transition-all duration-300"
    :id="cardId"
    :class="{ 'active-clinic': isActive }"
  >
    <div class="clinic-badge">{{ clinicName }}</div>
    <p class="text-gray-700 mb-6 flex items-center">
      <i class="fas fa-map-marker-alt text-blue-500 mr-2"></i>
      {{ address }}
    </p>

    <div class="space-y-3">
      <div class="info-item">
        <p class="text-sm text-gray-500">Паспорт:</p>
        <p class="font-medium">{{ passport }}</p>
      </div>

      <div class="info-item">
        <p class="text-sm text-gray-500">СНИЛС:</p>
        <p class="font-medium">{{ snils }}</p>
      </div>

      <div class="info-item">
        <p class="text-sm text-gray-500">Полис ОМС:</p>
        <p class="font-medium">{{ oms }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ClinicCard',
  props: {
    cardId: {
      type: String,
      required: true
    },
    clinicName: {
      type: String,
      required: true
    },
    address: {
      type: String,
      required: true
    },
    passport: {
      type: String,
      required: true
    },
    snils: {
      type: String,
      required: true
    },
    oms: {
      type: String,
      required: true
    }
  }
}
</script>

<style scoped>
.clinic-card {
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
  transition: all 0.4s ease;
  border: 1px solid #e2e8f0;
  margin-bottom: 20px;
}

.clinic-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 8px 25px rgba(0, 0, 0, 0.12);
}

.clinic-badge {
  background: linear-gradient(90deg, #3b82f6 0%, #60a5fa 100%);
  color: white;
  padding: 6px 14px;
  border-radius: 20px;
  font-weight: 500;
  display: inline-block;
  margin-bottom: 15px;
}

.info-item {
  border-bottom: 1px solid #edf2f7;
  padding: 12px 0;
}

.info-item:last-child {
  border-bottom: none;
}

.active-clinic {
  position: relative;
  border: 2px solid #3b82f6;
  box-shadow: 0 0 0 4px rgba(59, 130, 246, 0.2);
}

.active-clinic::before {
  content: '';
  position: absolute;
  top: -1px;
  right: -1px;
  width: 0;
  height: 0;
  border-top: 20px solid #3b82f6;
  border-left: 20px solid transparent;
}

.active-clinic::after {
  content: '\f00c';
  font-family: 'Font Awesome 5 Free';
  font-weight: 900;
  position: absolute;
  top: -1px;
  right: -1px;
  color: white;
  font-size: 10px;
  width: 18px;
  height: 18px;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>