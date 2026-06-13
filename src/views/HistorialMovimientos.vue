<template>
  <div class="contenedor">
    <h2>Historial de movimientos</h2>

    <table v-if="movimientos.length > 0">
      <thead>
        <tr>
          <th>Criptomoneda</th>
          <th>Cantidad</th>
          <th>Monto</th>
          <th>Tipo</th>
          <th>Fecha y hora</th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="movimiento in movimientos" :key="movimiento.id">
          <td>{{ movimiento.criptomoneda }}</td>
          <td>{{ movimiento.cantidad }}</td>
          <td>${{ movimiento.monto }}</td>
          <td>{{ movimiento.tipoMovimiento }}</td>
        <td>{{ formatearFecha(movimiento.fechaHora) }}</td>
        </tr>
      </tbody>
    </table>

    <p v-else class="mensaje">No hay movimientos cargados</p>
  </div>
</template>

<script>
import axios from "axios"

export default {
  name: "HistorialMovimientos",

  data() {
    return {
      movimientos: []
    }
  },

  methods: {
  async obtenerMovimientos() {
    try {
      const respuesta = await axios.get("https://localhost:7042/api/Movimientos")
      this.movimientos = respuesta.data
    } catch (error) {
      console.log(error)
    }
  },

  formatearFecha(fecha) {
    const d = new Date(fecha)

    return d.toLocaleDateString('es-AR') + ' ' +
      d.toLocaleTimeString('es-AR', {
        hour: '2-digit',
        minute: '2-digit'
      })
  }
},

  mounted() {
    this.obtenerMovimientos()
  }
}
</script>

<style>
.contenedor {
  width: 850px;
  margin: 50px auto;
  background: rgba(255, 255, 255, 0.95);
  padding: 25px;
  border-radius: 15px;
  box-shadow: 0 0 20px rgba(0,0,0,0.2);
}

h2 {
  text-align: center;
  color: #8b6508;
}

table {
  width: 100%;
  margin-top: 15px;
  border-collapse: collapse;
}

th {
  background-color: #8b6508;
  color: white;
  padding: 10px;
}

td {
  padding: 10px;
  border-bottom: 1px solid #ddd;
  text-align: center;
}

.mensaje {
  text-align: center;
  margin-top: 15px;
  font-weight: bold;
  color: #8b6508;
}
</style>