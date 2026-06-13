<template>
  <div class="contenedor">
    <h2>Nueva compra</h2>
    <p class="subtitulo">Compra de criptomonedas</p>

    <div class="formulario">
      <label>Criptomoneda</label>
      <select v-model="criptomoneda">
        <option>Bitcoin</option>
        <option>Ethereum</option>
        <option>USDC</option>
      </select>

      <label>Cantidad</label>
      <input type="number" v-model="cantidad" />

      <label>Fecha y Hora</label>
      <input type="datetime-local" v-model="fechaHora" />

      <button @click="guardarCompra">Guardar Compra</button>

      <p v-if="mensaje" class="mensaje">{{ mensaje }}</p>
    </div>
  </div>
</template>

<script>
import axios from "axios"

export default {
  name: "NuevaCompra",

  data() {
    return {
      criptomoneda: "Bitcoin",
      cantidad: "",
      fechaHora: "",
      mensaje: ""
    }
  },

  methods: {
    async guardarCompra() {
      try {
        const compra = {
          criptomoneda: this.criptomoneda,
          cantidad: Number(this.cantidad),
          tipoMovimiento: "Compra",
          fechaHora: this.fechaHora
        }

        await axios.post("https://localhost:7042/api/Movimientos", compra)

        this.mensaje = "Compra guardada correctamente"

        this.cantidad = ""
        this.fechaHora = ""
      } catch (error) {
        this.mensaje = "Error al guardar la compra"
        console.log(error)
      }
    }
  }
}
</script>

<style>
.contenedor {
  width: 500px;
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

.subtitulo {
  text-align: center;
  color: #666;
  margin-bottom: 20px;
}

.formulario {
  display: flex;
  flex-direction: column;
}

label {
  margin-top: 10px;
  font-weight: bold;
}

input,
select {
  padding: 10px;
  margin-top: 5px;
}

button {
  margin-top: 20px;
  padding: 12px;
  background-color: #b8860b;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.mensaje {
  text-align: center;
  margin-top: 15px;
  font-weight: bold;
  color: #8b6508;
}
</style>