#!/usr/bin/env node

class gato
{
    constructor(color, nombre)
    {
        this.color = color
        this.nombre = nombre
    }
}

const arreglo = [
    new gato("Naranja","Wilson"),
    new gato("Negro","Batman"),
    new gato("Blanco","Nieve")
]

arreglo.forEach(x => console.log(`Gato(${x.color},${x.nombre})`))
console.log()