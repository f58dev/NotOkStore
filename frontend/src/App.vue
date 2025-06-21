<template>
  <div>
    <h1>My Store</h1>

    <form @submit.prevent="addProduct">
      <input v-model="newProduct.name" placeholder="Product Name" required />
      <input v-model.number="newProduct.price" placeholder="Price" type="number" required />
      <input v-model="newProduct.description" placeholder="Description" required />
      <button type="submit">Add Product</button>
    </form>

    <ul>
      <li v-for="product in products" :key="product.id">
        {{ product.name }} - ${{ product.price }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from 'axios'

interface Product {
  id: number
  name: string
  price: number
  description: string
}

const products = ref<Product[]>([])
const newProduct = ref<Omit<Product, 'id'>>({
  name: '',
  price: 0,
  description: ''
})

async function loadProducts() {
  const response = await axios.get('http://localhost:5157/api/products')
  products.value = response.data
}

async function addProduct() {
  const response = await axios.post('http://localhost:5157/api/products', newProduct.value)
  products.value.push(response.data)
  newProduct.value = { name: '', price: 0, description: '' }
}

onMounted(loadProducts)
</script>