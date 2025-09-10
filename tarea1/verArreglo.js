let arreglo = [20,30,40,50,60,70]
if (process.argv.slice(2).length == 0) {
    console.log(arreglo)
} else if (process.argv.slice(2)[0] == "recorrido") {
    let suma = 0
        for (let i = 0; i < arreglo.length; i++){
            console.log("En la posicion " + (i + 1) + " del arreglo se encuentra el valor: " + arreglo[i] + ".");           
            suma += arreglo[i]
        }
        console.log("La sumatoria es: " + suma + ".")
} else if (process.argv.slice(2)[0] == "reversa") {
    let suma = 0
        for (let i = arreglo.length - 1; i >= 0; i--){
            console.log("En la posicion " + (i + 1) + " del arreglo se encuentra el valor: " + arreglo[i] + ".");           
            suma += arreglo[i]
        }
        console.log("La sumatoria es: " + suma + ".")
} else if (process.argv.slice(2)[0] == "indice" && process.argv.slice(2).length == 1 || process.argv.slice(2)[0] == "indice" && process.argv.slice(2)[1] < 1 || process.argv.slice(2)[0] == "indice" && process.argv.slice(2)[1] > arreglo.length) {
    console.log("Indice invalido") 
    console.log("Prueba con un valor entre 1 y " + arreglo.length + ".")
} else if (process.argv.slice(2)[0] == "indice" && process.argv.slice(2)[1] != undefined) {
    console.log("En el indice " + process.argv.slice(2)[1] + " del arreglo se encuentra el valor: " + arreglo[process.argv.slice(2)[1] - 1] + ".")
} else if (process.argv.slice(2)[0] == "buscar") {
    let indice = -1
    for (let i = 0; i < arreglo.length; i++) {
        if (arreglo[i] == process.argv.slice(2)[1]){
            indice = i + 1
        }
    }
    if (indice == -1 && process.argv.slice(2).length == 2){
        console.log("El valor no se encontro en el arreglo.")
    } else if (process.argv.slice(2).length == 1) {
        console.log("Por favor introduzca un valor a buscar.")
    } else {
        console.log("El valor se encontro en el indice " + indice + ".")
    }
}