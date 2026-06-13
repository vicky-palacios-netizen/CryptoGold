<template>
  <div>
    <nav class="menu">
      <h1>CryptoGold</h1>

      <div class="links">
        <RouterLink to="/compra">Compra</RouterLink>
        <RouterLink to="/historial">Historial de movimientos</RouterLink>
      </div>
    </nav>

    <router-view />
  </div>
</template>

<style>
body {
  font-family: Arial, Helvetica, sans-serif;
  background: linear-gradient(135deg, #b8860b, #ffd700, #fff8dc);
  margin: 0;
}

.menu {
  background: white;
  padding: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.menu h1 {
  color: #8b6508;
  margin: 0;
}

.links a {
  margin-left: 20px;
  text-decoration: none;
  color: #8b6508;
  font-weight: bold;
}

.links a:hover {
  text-decoration: underline;
}
</style>
